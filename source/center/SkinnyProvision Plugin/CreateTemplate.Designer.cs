namespace SkinnyProvision
{
    partial class CreateTemplate
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
            this.label1 = new System.Windows.Forms.Label();
            this.createBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.templateName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.sizeLabel = new System.Windows.Forms.Label();
            this.overlaySize = new System.Windows.Forms.NumericUpDown();
            this.templateList = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.overlaySize)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Template to clone";
            // 
            // createBtn
            // 
            this.createBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.createBtn.Location = new System.Drawing.Point(388, 195);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(75, 23);
            this.createBtn.TabIndex = 2;
            this.createBtn.Text = "Create";
            this.createBtn.UseVisualStyleBackColor = true;
            this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelBtn.Location = new System.Drawing.Point(12, 195);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 3;
            this.cancelBtn.Text = "Close";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // templateName
            // 
            this.templateName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.templateName.Location = new System.Drawing.Point(12, 25);
            this.templateName.MaxLength = 256;
            this.templateName.Name = "templateName";
            this.templateName.Size = new System.Drawing.Size(356, 20);
            this.templateName.TabIndex = 4;
            this.templateName.Text = "Ubuntu Overlay (64MB)";
            this.templateName.TextChanged += new System.EventHandler(this.templateName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Template name";
            // 
            // sizeLabel
            // 
            this.sizeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sizeLabel.AutoSize = true;
            this.sizeLabel.Location = new System.Drawing.Point(372, 9);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(91, 13);
            this.sizeLabel.TabIndex = 7;
            this.sizeLabel.Text = "Overlay Size (MB)";
            // 
            // overlaySize
            // 
            this.overlaySize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.overlaySize.Increment = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.overlaySize.Location = new System.Drawing.Point(374, 25);
            this.overlaySize.Maximum = new decimal(new int[] {
            1048576,
            0,
            0,
            0});
            this.overlaySize.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.overlaySize.Name = "overlaySize";
            this.overlaySize.Size = new System.Drawing.Size(89, 20);
            this.overlaySize.TabIndex = 8;
            this.overlaySize.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            // 
            // templateList
            // 
            this.templateList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.templateList.FormattingEnabled = true;
            this.templateList.IntegralHeight = false;
            this.templateList.Location = new System.Drawing.Point(12, 64);
            this.templateList.Name = "templateList";
            this.templateList.Size = new System.Drawing.Size(451, 125);
            this.templateList.TabIndex = 0;
            this.templateList.SelectedIndexChanged += new System.EventHandler(this.templateList_SelectedIndexChanged);
            // 
            // CreateTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 230);
            this.Controls.Add(this.overlaySize);
            this.Controls.Add(this.sizeLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.templateName);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.createBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.templateList);
            this.Name = "CreateTemplate";
            this.Text = "Create a SkinnyBox Template";
            this.Load += new System.EventHandler(this.CreateTemplate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.overlaySize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button createBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.TextBox templateName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label sizeLabel;
        private System.Windows.Forms.NumericUpDown overlaySize;
        private System.Windows.Forms.ListBox templateList;
    }
}