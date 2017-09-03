namespace MARRSS.Forms
{
    partial class SatelliteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SatelliteForm));
            this.addButton = new System.Windows.Forms.Button();
            this.canelButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textFilePath = new System.Windows.Forms.TextBox();
            this.openFile = new System.Windows.Forms.Button();
            this.tlePanel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textTleLine2 = new System.Windows.Forms.TextBox();
            this.textNameID = new System.Windows.Forms.TextBox();
            this.textTleLine1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.tlePanel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.tlePanel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.storagePanel = new System.Windows.Forms.Panel();
            this.onBoardStoargeSizeText = new System.Windows.Forms.NumericUpDown();
            this.comboBoxSatelliteStorage = new System.Windows.Forms.ComboBox();
            this.tlePanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tlePanel1.SuspendLayout();
            this.tlePanel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.storagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.onBoardStoargeSizeText)).BeginInit();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.Location = new System.Drawing.Point(251, 403);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "ADD";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // canelButton
            // 
            this.canelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.canelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.canelButton.Location = new System.Drawing.Point(380, 403);
            this.canelButton.Name = "canelButton";
            this.canelButton.Size = new System.Drawing.Size(75, 23);
            this.canelButton.TabIndex = 5;
            this.canelButton.Text = "CANCEL";
            this.canelButton.UseVisualStyleBackColor = true;
            this.canelButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(535, 20);
            this.panel1.TabIndex = 0;
            // 
            // textFilePath
            // 
            this.textFilePath.Location = new System.Drawing.Point(16, 42);
            this.textFilePath.Name = "textFilePath";
            this.textFilePath.Size = new System.Drawing.Size(294, 20);
            this.textFilePath.TabIndex = 0;
            // 
            // openFile
            // 
            this.openFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openFile.Location = new System.Drawing.Point(16, 6);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(73, 23);
            this.openFile.TabIndex = 1;
            this.openFile.Text = "Select File";
            this.openFile.UseVisualStyleBackColor = true;
            this.openFile.Click += new System.EventHandler(this.button3_Click);
            // 
            // tlePanel3
            // 
            this.tlePanel3.Controls.Add(this.label4);
            this.tlePanel3.Controls.Add(this.label3);
            this.tlePanel3.Controls.Add(this.label2);
            this.tlePanel3.Controls.Add(this.textTleLine2);
            this.tlePanel3.Controls.Add(this.textNameID);
            this.tlePanel3.Controls.Add(this.textTleLine1);
            this.tlePanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlePanel3.Location = new System.Drawing.Point(0, 0);
            this.tlePanel3.Name = "tlePanel3";
            this.tlePanel3.Size = new System.Drawing.Size(334, 141);
            this.tlePanel3.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Line 2:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Line 1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name:";
            // 
            // textTleLine2
            // 
            this.textTleLine2.Location = new System.Drawing.Point(15, 114);
            this.textTleLine2.Name = "textTleLine2";
            this.textTleLine2.Size = new System.Drawing.Size(307, 20);
            this.textTleLine2.TabIndex = 2;
            // 
            // textNameID
            // 
            this.textNameID.Location = new System.Drawing.Point(15, 25);
            this.textNameID.Name = "textNameID";
            this.textNameID.Size = new System.Drawing.Size(307, 20);
            this.textNameID.TabIndex = 1;
            // 
            // textTleLine1
            // 
            this.textTleLine1.Location = new System.Drawing.Point(15, 68);
            this.textTleLine1.Name = "textTleLine1";
            this.textTleLine1.Size = new System.Drawing.Size(307, 20);
            this.textTleLine1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MARRSS.Properties.Resources.ImportBanner;
            this.pictureBox1.InitialImage = global::MARRSS.Properties.Resources.ImportBanner;
            this.pictureBox1.Location = new System.Drawing.Point(3, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(184, 400);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton4);
            this.groupBox2.Controls.Add(this.radioButton3);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Location = new System.Drawing.Point(190, 26);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(338, 137);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Import TLE-Data";
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(98, 109);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(83, 17);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.Text = "Update TLE";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(98, 79);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(86, 17);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "Manual input";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(98, 51);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(176, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "import online ( SpaceTrack.org )";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(98, 23);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(93, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Import from file";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // tlePanel1
            // 
            this.tlePanel1.Controls.Add(this.label6);
            this.tlePanel1.Controls.Add(this.textFilePath);
            this.tlePanel1.Controls.Add(this.openFile);
            this.tlePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlePanel1.Location = new System.Drawing.Point(3, 3);
            this.tlePanel1.Name = "tlePanel1";
            this.tlePanel1.Size = new System.Drawing.Size(328, 135);
            this.tlePanel1.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(187, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "File has to be *.txt format";
            // 
            // tlePanel2
            // 
            this.tlePanel2.Controls.Add(this.label7);
            this.tlePanel2.Controls.Add(this.label5);
            this.tlePanel2.Controls.Add(this.textBox1);
            this.tlePanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlePanel2.Location = new System.Drawing.Point(3, 3);
            this.tlePanel2.Name = "tlePanel2";
            this.tlePanel2.Size = new System.Drawing.Size(328, 135);
            this.tlePanel2.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(78, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(232, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Multiple Id\'s can be enterd seperated by comma";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Norad ID:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(294, 20);
            this.textBox1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(188, 135);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(342, 170);
            this.tabControl1.TabIndex = 15;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.tlePanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(334, 141);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tlePanel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(334, 141);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tlePanel3);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(334, 141);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Satellite Storage:";
            // 
            // storagePanel
            // 
            this.storagePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.storagePanel.Controls.Add(this.onBoardStoargeSizeText);
            this.storagePanel.Controls.Add(this.comboBoxSatelliteStorage);
            this.storagePanel.Controls.Add(this.label1);
            this.storagePanel.Location = new System.Drawing.Point(193, 311);
            this.storagePanel.Name = "storagePanel";
            this.storagePanel.Size = new System.Drawing.Size(333, 73);
            this.storagePanel.TabIndex = 19;
            // 
            // onBoardStoargeSizeText
            // 
            this.onBoardStoargeSizeText.Increment = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.onBoardStoargeSizeText.Location = new System.Drawing.Point(64, 37);
            this.onBoardStoargeSizeText.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.onBoardStoargeSizeText.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.onBoardStoargeSizeText.Name = "onBoardStoargeSizeText";
            this.onBoardStoargeSizeText.Size = new System.Drawing.Size(68, 20);
            this.onBoardStoargeSizeText.TabIndex = 25;
            this.onBoardStoargeSizeText.Value = new decimal(new int[] {
            512,
            0,
            0,
            0});
            // 
            // comboBoxSatelliteStorage
            // 
            this.comboBoxSatelliteStorage.FormattingEnabled = true;
            this.comboBoxSatelliteStorage.Items.AddRange(new object[] {
            "B      (Byte)",
            "kB    (kilo Byte)",
            "MB  (MegaByte)",
            "GB   (GigaByte)",
            "TB   (TerraByte)"});
            this.comboBoxSatelliteStorage.Location = new System.Drawing.Point(169, 36);
            this.comboBoxSatelliteStorage.Name = "comboBoxSatelliteStorage";
            this.comboBoxSatelliteStorage.Size = new System.Drawing.Size(118, 21);
            this.comboBoxSatelliteStorage.TabIndex = 24;
            // 
            // SatelliteForm
            // 
            this.AcceptButton = this.addButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.canelButton;
            this.ClientSize = new System.Drawing.Size(535, 435);
            this.Controls.Add(this.storagePanel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.canelButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SatelliteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Satellite";
            this.Load += new System.EventHandler(this.SatelliteForm_Load);
            this.tlePanel3.ResumeLayout(false);
            this.tlePanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tlePanel1.ResumeLayout(false);
            this.tlePanel1.PerformLayout();
            this.tlePanel2.ResumeLayout(false);
            this.tlePanel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.storagePanel.ResumeLayout(false);
            this.storagePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.onBoardStoargeSizeText)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button canelButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textFilePath;
        private System.Windows.Forms.Button openFile;
        private System.Windows.Forms.Panel tlePanel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textTleLine2;
        private System.Windows.Forms.TextBox textNameID;
        private System.Windows.Forms.TextBox textTleLine1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel tlePanel1;
        private System.Windows.Forms.Panel tlePanel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel storagePanel;
        private System.Windows.Forms.NumericUpDown onBoardStoargeSizeText;
        private System.Windows.Forms.ComboBox comboBoxSatelliteStorage;
    }
}