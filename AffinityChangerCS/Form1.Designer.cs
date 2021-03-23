namespace AffinityChangerCS
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbProcesses = new System.Windows.Forms.ComboBox();
            this.cpu0Affinity = new System.Windows.Forms.CheckedListBox();
            this.cpu1Affinity = new System.Windows.Forms.CheckedListBox();
            this.cpu2Affinity = new System.Windows.Forms.CheckedListBox();
            this.cpu3Affinity = new System.Windows.Forms.CheckedListBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.cpu0All = new System.Windows.Forms.CheckBox();
            this.cpu1All = new System.Windows.Forms.CheckBox();
            this.cpu2All = new System.Windows.Forms.CheckBox();
            this.cpu3All = new System.Windows.Forms.CheckBox();
            this.txAffinityMask = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbProcesses
            // 
            this.cbProcesses.FormattingEnabled = true;
            this.cbProcesses.Location = new System.Drawing.Point(18, 20);
            this.cbProcesses.Name = "cbProcesses";
            this.cbProcesses.Size = new System.Drawing.Size(758, 24);
            this.cbProcesses.TabIndex = 0;
            // 
            // cpu0Affinity
            // 
            this.cpu0Affinity.FormattingEnabled = true;
            this.cpu0Affinity.Location = new System.Drawing.Point(18, 84);
            this.cpu0Affinity.Name = "cpu0Affinity";
            this.cpu0Affinity.Size = new System.Drawing.Size(185, 310);
            this.cpu0Affinity.TabIndex = 2;
            // 
            // cpu1Affinity
            // 
            this.cpu1Affinity.FormattingEnabled = true;
            this.cpu1Affinity.Location = new System.Drawing.Point(209, 84);
            this.cpu1Affinity.Name = "cpu1Affinity";
            this.cpu1Affinity.Size = new System.Drawing.Size(185, 310);
            this.cpu1Affinity.TabIndex = 2;
            // 
            // cpu2Affinity
            // 
            this.cpu2Affinity.FormattingEnabled = true;
            this.cpu2Affinity.Location = new System.Drawing.Point(400, 84);
            this.cpu2Affinity.Name = "cpu2Affinity";
            this.cpu2Affinity.Size = new System.Drawing.Size(185, 310);
            this.cpu2Affinity.TabIndex = 2;
            // 
            // cpu3Affinity
            // 
            this.cpu3Affinity.FormattingEnabled = true;
            this.cpu3Affinity.Location = new System.Drawing.Point(591, 84);
            this.cpu3Affinity.Name = "cpu3Affinity";
            this.cpu3Affinity.Size = new System.Drawing.Size(185, 310);
            this.cpu3Affinity.TabIndex = 2;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(611, 416);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(139, 33);
            this.btnApply.TabIndex = 3;
            this.btnApply.Text = "Aplicar";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // cpu0All
            // 
            this.cpu0All.AutoSize = true;
            this.cpu0All.Location = new System.Drawing.Point(18, 57);
            this.cpu0All.Name = "cpu0All";
            this.cpu0All.Size = new System.Drawing.Size(119, 21);
            this.cpu0All.TabIndex = 4;
            this.cpu0All.Text = "CPU1 - Todos";
            this.cpu0All.UseVisualStyleBackColor = true;
            this.cpu0All.CheckedChanged += new System.EventHandler(this.cpu0All_CheckedChanged);
            // 
            // cpu1All
            // 
            this.cpu1All.AutoSize = true;
            this.cpu1All.Location = new System.Drawing.Point(209, 57);
            this.cpu1All.Name = "cpu1All";
            this.cpu1All.Size = new System.Drawing.Size(119, 21);
            this.cpu1All.TabIndex = 4;
            this.cpu1All.Text = "CPU2 - Todos";
            this.cpu1All.UseVisualStyleBackColor = true;
            this.cpu1All.CheckedChanged += new System.EventHandler(this.cpu1All_CheckedChanged);
            // 
            // cpu2All
            // 
            this.cpu2All.AutoSize = true;
            this.cpu2All.Location = new System.Drawing.Point(400, 57);
            this.cpu2All.Name = "cpu2All";
            this.cpu2All.Size = new System.Drawing.Size(119, 21);
            this.cpu2All.TabIndex = 4;
            this.cpu2All.Text = "CPU3 - Todos";
            this.cpu2All.UseVisualStyleBackColor = true;
            this.cpu2All.CheckedChanged += new System.EventHandler(this.cpu2All_CheckedChanged);
            // 
            // cpu3All
            // 
            this.cpu3All.AutoSize = true;
            this.cpu3All.Location = new System.Drawing.Point(591, 57);
            this.cpu3All.Name = "cpu3All";
            this.cpu3All.Size = new System.Drawing.Size(119, 21);
            this.cpu3All.TabIndex = 4;
            this.cpu3All.Text = "CPU4 - Todos";
            this.cpu3All.UseVisualStyleBackColor = true;
            this.cpu3All.CheckedChanged += new System.EventHandler(this.cpu3All_CheckedChanged);
            // 
            // txAffinityMask
            // 
            this.txAffinityMask.AutoSize = true;
            this.txAffinityMask.Location = new System.Drawing.Point(489, 424);
            this.txAffinityMask.Name = "txAffinityMask";
            this.txAffinityMask.Size = new System.Drawing.Size(96, 17);
            this.txAffinityMask.TabIndex = 5;
            this.txAffinityMask.Text = "(0x00000FFF)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 461);
            this.Controls.Add(this.txAffinityMask);
            this.Controls.Add(this.cpu3All);
            this.Controls.Add(this.cpu2All);
            this.Controls.Add(this.cpu1All);
            this.Controls.Add(this.cpu0All);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.cpu3Affinity);
            this.Controls.Add(this.cpu2Affinity);
            this.Controls.Add(this.cpu1Affinity);
            this.Controls.Add(this.cpu0Affinity);
            this.Controls.Add(this.cbProcesses);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbProcesses;
        private System.Windows.Forms.CheckedListBox cpu0Affinity;
        private System.Windows.Forms.CheckedListBox cpu1Affinity;
        private System.Windows.Forms.CheckedListBox cpu2Affinity;
        private System.Windows.Forms.CheckedListBox cpu3Affinity;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.CheckBox cpu0All;
        private System.Windows.Forms.CheckBox cpu1All;
        private System.Windows.Forms.CheckBox cpu2All;
        private System.Windows.Forms.CheckBox cpu3All;
        private System.Windows.Forms.Label txAffinityMask;
    }
}

