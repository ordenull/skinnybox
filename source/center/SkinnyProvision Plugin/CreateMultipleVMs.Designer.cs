namespace SkinnyProvision
{
    partial class CreateMultipleVMs
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
            this.masterList = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.templateList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.autoStart = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.vmName = new System.Windows.Forms.TextBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.createBtn = new System.Windows.Forms.Button();
            this.lastCountBox = new System.Windows.Forms.NumericUpDown();
            this.firstCountBox = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.paddingBox = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.createVMsWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.lastCountBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstCountBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paddingBox)).BeginInit();
            this.SuspendLayout();
            // 
            // masterList
            // 
            this.masterList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.masterList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.masterList.FormattingEnabled = true;
            this.masterList.Location = new System.Drawing.Point(12, 166);
            this.masterList.Name = "masterList";
            this.masterList.Size = new System.Drawing.Size(371, 21);
            this.masterList.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Master VM";
            // 
            // templateList
            // 
            this.templateList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.templateList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.templateList.FormattingEnabled = true;
            this.templateList.Location = new System.Drawing.Point(12, 126);
            this.templateList.Name = "templateList";
            this.templateList.Size = new System.Drawing.Size(371, 21);
            this.templateList.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Template to clone";
            // 
            // autoStart
            // 
            this.autoStart.AutoSize = true;
            this.autoStart.Location = new System.Drawing.Point(15, 90);
            this.autoStart.Name = "autoStart";
            this.autoStart.Size = new System.Drawing.Size(131, 17);
            this.autoStart.TabIndex = 14;
            this.autoStart.Text = "Start after provisioning";
            this.autoStart.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "New VM name prefix";
            // 
            // vmName
            // 
            this.vmName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vmName.Location = new System.Drawing.Point(15, 25);
            this.vmName.Name = "vmName";
            this.vmName.Size = new System.Drawing.Size(371, 20);
            this.vmName.TabIndex = 12;
            this.vmName.TextChanged += new System.EventHandler(this.vmName_TextChanged);
            this.vmName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.vmName_KeyPress);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelBtn.Location = new System.Drawing.Point(12, 248);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 11;
            this.cancelBtn.Text = "Close";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // createBtn
            // 
            this.createBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.createBtn.Location = new System.Drawing.Point(308, 248);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(75, 23);
            this.createBtn.TabIndex = 10;
            this.createBtn.Text = "Create";
            this.createBtn.UseVisualStyleBackColor = true;
            this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // lastCountBox
            // 
            this.lastCountBox.Location = new System.Drawing.Point(141, 64);
            this.lastCountBox.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.lastCountBox.Name = "lastCountBox";
            this.lastCountBox.Size = new System.Drawing.Size(120, 20);
            this.lastCountBox.TabIndex = 19;
            this.lastCountBox.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // firstCountBox
            // 
            this.firstCountBox.Location = new System.Drawing.Point(15, 64);
            this.firstCountBox.Name = "firstCountBox";
            this.firstCountBox.Size = new System.Drawing.Size(120, 20);
            this.firstCountBox.TabIndex = 20;
            this.firstCountBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "First count";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(138, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Last count";
            // 
            // paddingBox
            // 
            this.paddingBox.Location = new System.Drawing.Point(266, 64);
            this.paddingBox.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.paddingBox.Name = "paddingBox";
            this.paddingBox.Size = new System.Drawing.Size(120, 20);
            this.paddingBox.TabIndex = 23;
            this.paddingBox.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(263, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Digit padding";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 193);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(371, 44);
            this.progressBar.TabIndex = 25;
            // 
            // createVMsWorker
            // 
            this.createVMsWorker.WorkerReportsProgress = true;
            this.createVMsWorker.WorkerSupportsCancellation = true;
            this.createVMsWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.createVMsWorker_DoWork);
            this.createVMsWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.createVMsWorker_ProgressChanged);
            this.createVMsWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.createVMsWorker_RunWorkerCompleted);
            // 
            // CreateMultipleVMs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 283);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.paddingBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.firstCountBox);
            this.Controls.Add(this.lastCountBox);
            this.Controls.Add(this.masterList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.templateList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.autoStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.vmName);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.createBtn);
            this.Name = "CreateMultipleVMs";
            this.Text = "Batch Create SkinnyBox VMs";
            this.Load += new System.EventHandler(this.CreateMultipleVMs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lastCountBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstCountBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paddingBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox masterList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox templateList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox autoStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox vmName;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button createBtn;
        private System.Windows.Forms.NumericUpDown lastCountBox;
        private System.Windows.Forms.NumericUpDown firstCountBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown paddingBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.ComponentModel.BackgroundWorker createVMsWorker;
    }
}