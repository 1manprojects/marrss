namespace MARRSS.Forms
{
    partial class NoteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoteForm));
            this.headerLabel = new System.Windows.Forms.Label();
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.footerPanel = new System.Windows.Forms.Panel();
            this.infoLabelText = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.HeaderPanel.SuspendLayout();
            this.footerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.Location = new System.Drawing.Point(3, 9);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(559, 55);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "Updating Database";
            this.headerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.headerLabel.Click += new System.EventHandler(this.header_Click);
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.Controls.Add(this.headerLabel);
            this.HeaderPanel.Location = new System.Drawing.Point(12, 12);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(565, 66);
            this.HeaderPanel.TabIndex = 1;
            // 
            // footerPanel
            // 
            this.footerPanel.Controls.Add(this.infoLabelText);
            this.footerPanel.Location = new System.Drawing.Point(13, 83);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(565, 44);
            this.footerPanel.TabIndex = 2;
            // 
            // infoLabelText
            // 
            this.infoLabelText.Location = new System.Drawing.Point(6, 6);
            this.infoLabelText.Name = "infoLabelText";
            this.infoLabelText.Size = new System.Drawing.Size(555, 23);
            this.infoLabelText.TabIndex = 0;
            this.infoLabelText.Text = "infoTextLabel";
            this.infoLabelText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MARRSS.Properties.Resources.ajax_loader;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(174, 133);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(235, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // NoteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 174);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.footerPanel);
            this.Controls.Add(this.HeaderPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NoteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "InfoForm";
            this.Load += new System.EventHandler(this.NoteForm_Load);
            this.HeaderPanel.ResumeLayout(false);
            this.footerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Panel HeaderPanel;
        private System.Windows.Forms.Panel footerPanel;
        private System.Windows.Forms.Label infoLabelText;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}