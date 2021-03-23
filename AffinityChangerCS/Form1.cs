using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AffinityChangerCS
{
    public partial class Form1 : Form
    {
        public class Processor
        {
            public string Name { get; set; }

            public int ProcNum { get; set; }

            public List<ProcessorThread> Threads { get; set; }

            public Processor(string name, int num, int logicalCores, int maskOffset)
            {
                Name = name;
                ProcNum = num;
                Threads = Enumerable
                    .Range(1, logicalCores)
                    .Select(lc => new ProcessorThread(num, lc, lc - 1 + maskOffset))
                    .ToList();
            }

            public override string ToString()
            {
                return $"{Name} - {ProcNum}";
            }
        }
        public class ProcessorThread
        {
            public int ProcNum { get; set; }

            public int ThreadNum { get; set; }

            public int Mask { get; set; }

            public ProcessorThread(int procNum, int threadNum, int mask)
            {
                ProcNum = procNum;
                ThreadNum = threadNum;
                Mask = mask;
            }

            public override string ToString()
            {
                return $"CPU {ProcNum} | Thread {ThreadNum}";
            }
        }

        public class RunningProcess
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public IntPtr Affinity { get; set; }

            public RunningProcess(int id, string name, IntPtr affinity)
            {
                Id = id;
                Name = name;
                Affinity = affinity;
            }

            public override string ToString()
            {
                return $"[{Id}] {Name} - ({Affinity.ToInt32().ToString("x2")})";
            }
        }

        public List<Processor> Processors { get; set; } = new List<Processor>();

        public List<RunningProcess> Processes { get; set; } = new List<RunningProcess>();

        public int SelectedAffinity { get; set; }

        public Form1()
        {
            InitializeComponent();
            ListProcessors();
            UpdateProcessThreads();

            cbProcesses.Items.AddRange(Processes.ToArray());

            if (Processors.Count >= 1)
                cpu0Affinity.Items.AddRange(Processors[0].Threads.ToArray());
            
            if (Processors.Count >= 2)
                cpu1Affinity.Items.AddRange(Processors[1].Threads.ToArray());
            
            if (Processors.Count >= 3)
                cpu2Affinity.Items.AddRange(Processors[2].Threads.ToArray());

            if (Processors.Count >= 4)
                cpu3Affinity.Items.AddRange(Processors[3].Threads.ToArray());
        }

        private void OnAffinityChanged()
        {
            CheckedListBox[] affinities = new CheckedListBox[]
            {
                cpu0Affinity,
                cpu1Affinity,
                cpu2Affinity,
                cpu3Affinity
            };

            int aff = 0; 
            for(var cpu = 0; cpu < affinities.Length; cpu++)
            {
                foreach (var checkedThread in affinities[cpu].CheckedItems)
                {
                    aff |= 1 << (checkedThread as ProcessorThread).Mask;
                }
            }

            SelectedAffinity = aff;
            txAffinityMask.Text = $"0x{aff.ToString("x8")}";
        }

        public void ListProcessors()
        {
            this.Processors.Clear();
            using (ManagementObjectSearcher win32Proc = new ManagementObjectSearcher("select * from Win32_Processor"))
            {
                int i = 0;
                int offs = 0;
                foreach (ManagementObject obj in win32Proc.Get())
                {
                    var name = obj["Name"].ToString();
                    var logicalCount = int.Parse(obj["NumberOfLogicalProcessors"].ToString());

                    this.Processors.Add(new Processor(name, ++i, logicalCount, offs));
                    offs += logicalCount;
                }
            }
        }

        public void UpdateProcessThreads()
        {
            Processes.Clear();
            Process.GetProcesses().ToList().ForEach(p =>
            {
                if (p.ProcessName != "svchost")
                {
                    try 
                    { 
                        Processes.Add(new RunningProcess(p.Id, p.ProcessName, p.ProcessorAffinity));
                    }
                    catch { }
                }
            });
        }

        private void cpu0All_CheckedChanged(object sender, EventArgs e)
        {
            for (var i = 0; i < cpu0Affinity.Items.Count; i++)
                cpu0Affinity.SetItemChecked(i, cpu0All.Checked);
        }

        private void cpu1All_CheckedChanged(object sender, EventArgs e)
        {
            for (var i = 0; i < cpu1Affinity.Items.Count; i++)
                cpu1Affinity.SetItemChecked(i, cpu1All.Checked);
        }

        private void cpu2All_CheckedChanged(object sender, EventArgs e)
        {
            for (var i = 0; i < cpu2Affinity.Items.Count; i++)
                cpu2Affinity.SetItemChecked(i, cpu2All.Checked);
        }

        private void cpu3All_CheckedChanged(object sender, EventArgs e)
        {
            for (var i = 0; i < cpu3Affinity.Items.Count; i++)
                cpu3Affinity.SetItemChecked(i, cpu3All.Checked);
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            var selectedProcess = cbProcesses.SelectedItem as RunningProcess;
            OnAffinityChanged();

            if(selectedProcess != null)
            {
                var process = Process.GetProcessById(selectedProcess.Id);

                if (process == null)
                    return;

                process.ProcessorAffinity = (IntPtr)SelectedAffinity;
            }
        }
    }
}
