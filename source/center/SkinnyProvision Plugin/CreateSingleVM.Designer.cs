namespace SkinnyProvision
{
    partial class CreateSingleVM
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
            this.createBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.vmName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.autoStart = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.templateList = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.masterList = new System.Windows.Forms.ComboBox();
            this.vmCreateWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // createBtn
            // 
            this.createBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.createBtn.Location = new System.Drawing.Point(347, 162);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(75, 23);
            this.createBtn.TabIndex = 1;
            this.createBtn.Text = "Create";
            this.createBtn.UseVisualStyleBackColor = true;
            this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelBtn.Location = new System.Drawing.Point(12, 162);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 2;
            this.cancelBtn.Text = "Close";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // vmName
            // 
            this.vmName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vmName.Location = new System.Drawing.Point(12, 25);
            this.vmName.Name = "vmName";
            this.vmName.Size = new System.Drawing.Size(410, 20);
            this.vmName.TabIndex = 3;
            this.vmName.TextChanged += new System.EventHandler(this.vmName_TextChanged);
            this.vmName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.vmName_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "New VM name";
            // 
            // autoStart
            // 
            this.autoStart.AutoSize = true;
            this.autoStart.Location = new System.Drawing.Point(13, 52);
            this.autoStart.Name = "autoStart";
            this.autoStart.Size = new System.Drawing.Size(131, 17);
            this.autoStart.TabIndex = 5;
            this.autoStart.Text = "Start after provisioning";
            this.autoStart.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Template to clone";
            // 
            // templateList
            // 
            this.templateList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.templateList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.templateList.FormattingEnabled = true;
            this.templateList.Location = new System.Drawing.Point(12, 88);
            this.templateList.Name = "templateList";
            this.templateList.Size = new System.Drawing.Size(410, 21);
            this.templateList.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Master VM";
            // 
            // masterList
            // 
            this.masterList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.masterList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.masterList.FormattingEnabled = true;
            this.masterList.Location = new System.Drawing.Point(12, 128);
            this.masterList.Name = "masterList";
            this.masterList.Size = new System.Drawing.Size(410, 21);
            this.masterList.TabIndex = 9;
            // 
            // vmCreateWorker
            // 
            this.vmCreateWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.vmCreateWorker_DoWork);
            this.vmCreateWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.vmCreateWorker_RunWorkerCompleted);
            // 
            // CreateSingleVM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 197);
            this.Controls.Add(this.masterList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.templateList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.autoStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.vmName);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.createBtn);
            this.MaximumSize = new System.Drawing.Size(450, 235);
            this.MinimumSize = new System.Drawing.Size(450, 235);
            this.Name = "CreateSingleVM";
            this.Text = "Create a SkinnyBox VM";
            this.Load += new System.EventHandler(this.CreateSingleVM_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.TextBox vmName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox autoStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox templateList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox masterList;
        private System.ComponentModel.BackgroundWorker vmCreateWorker;
    }
}