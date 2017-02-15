namespace MARRSS.Forms
{
    partial class AutomatedRunsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutomatedRunsForm));
            this.button1 = new System.Windows.Forms.Button();
            this.schedulerComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.objectiveComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SettingsRichTextBox = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.comboScenarioBox = new System.Windows.Forms.ComboBox();
            this.checkedSatellites = new System.Windows.Forms.CheckedListBox();
            this.checkedStations = new System.Windows.Forms.CheckedListBox();
            this.stopTimePicker = new System.Windows.Forms.DateTimePicker();
            this.startTimePicker = new System.Windows.Forms.DateTimePicker();
            this.stopTimeLabel = new System.Windows.Forms.Label();
            this.startTimeLabel = new System.Windows.Forms.Label();
            this.stopDatePicker = new System.Windows.Forms.DateTimePicker();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.addRunButton = new System.Windows.Forms.Button();
            this.revoveRunButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewRunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(685, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start Run";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // schedulerComboBox
            // 
            this.schedulerComboBox.FormattingEnabled = true;
            this.schedulerComboBox.Items.AddRange(new object[] {
            "EFT-Greedy",
            "Greedy",
            "Genetic"});
            this.schedulerComboBox.Location = new System.Drawing.Point(12, 27);
            this.schedulerComboBox.Name = "schedulerComboBox";
            this.schedulerComboBox.Size = new System.Drawing.Size(190, 21);
            this.schedulerComboBox.TabIndex = 1;
            this.schedulerComboBox.SelectedIndexChanged += new System.EventHandler(this.schedulerComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select Scheduler";
            // 
            // objectiveComboBox
            // 
            this.objectiveComboBox.FormattingEnabled = true;
            this.objectiveComboBox.Location = new System.Drawing.Point(12, 72);
            this.objectiveComboBox.Name = "objectiveComboBox";
            this.objectiveComboBox.Size = new System.Drawing.Size(190, 21);
            this.objectiveComboBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Select Objective Function";
            // 
            // SettingsRichTextBox
            // 
            this.SettingsRichTextBox.Location = new System.Drawing.Point(12, 133);
            this.SettingsRichTextBox.Name = "SettingsRichTextBox";
            this.SettingsRichTextBox.Size = new System.Drawing.Size(255, 236);
            this.SettingsRichTextBox.TabIndex = 5;
            this.SettingsRichTextBox.Text = resources.GetString("SettingsRichTextBox.Text");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Settings";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.SettingsRichTextBox);
            this.panel1.Controls.Add(this.schedulerComboBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.objectiveComboBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(331, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(270, 372);
            this.panel1.TabIndex = 9;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(197, 117);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(70, 13);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "restor Default";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.comboScenarioBox);
            this.panel2.Controls.Add(this.checkedSatellites);
            this.panel2.Controls.Add(this.checkedStations);
            this.panel2.Controls.Add(this.stopTimePicker);
            this.panel2.Controls.Add(this.startTimePicker);
            this.panel2.Controls.Add(this.stopTimeLabel);
            this.panel2.Controls.Add(this.startTimeLabel);
            this.panel2.Controls.Add(this.stopDatePicker);
            this.panel2.Controls.Add(this.startDatePicker);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(322, 372);
            this.panel2.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Scenario";
            // 
            // comboScenarioBox
            // 
            this.comboScenarioBox.FormattingEnabled = true;
            this.comboScenarioBox.Items.AddRange(new object[] {
            "A: Daily Operations - No Priority\'s",
            "B: Daily Operations - Random Priority",
            "C: LEOP UWE-3 Critical",
            "D: Critical over home station"});
            this.comboScenarioBox.Location = new System.Drawing.Point(7, 117);
            this.comboScenarioBox.Name = "comboScenarioBox";
            this.comboScenarioBox.Size = new System.Drawing.Size(254, 21);
            this.comboScenarioBox.TabIndex = 18;
            // 
            // checkedSatellites
            // 
            this.checkedSatellites.FormattingEnabled = true;
            this.checkedSatellites.Location = new System.Drawing.Point(160, 155);
            this.checkedSatellites.Name = "checkedSatellites";
            this.checkedSatellites.Size = new System.Drawing.Size(151, 214);
            this.checkedSatellites.TabIndex = 25;
            // 
            // checkedStations
            // 
            this.checkedStations.FormattingEnabled = true;
            this.checkedStations.Location = new System.Drawing.Point(3, 155);
            this.checkedStations.Name = "checkedStations";
            this.checkedStations.Size = new System.Drawing.Size(151, 214);
            this.checkedStations.TabIndex = 24;
            // 
            // stopTimePicker
            // 
            this.stopTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.stopTimePicker.Location = new System.Drawing.Point(114, 61);
            this.stopTimePicker.Name = "stopTimePicker";
            this.stopTimePicker.ShowUpDown = true;
            this.stopTimePicker.Size = new System.Drawing.Size(71, 20);
            this.stopTimePicker.TabIndex = 23;
            this.stopTimePicker.Value = new System.DateTime(2017, 2, 4, 12, 0, 0, 0);
            // 
            // startTimePicker
            // 
            this.startTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.startTimePicker.Location = new System.Drawing.Point(114, 20);
            this.startTimePicker.Name = "startTimePicker";
            this.startTimePicker.ShowUpDown = true;
            this.startTimePicker.Size = new System.Drawing.Size(71, 20);
            this.startTimePicker.TabIndex = 22;
            this.startTimePicker.Value = new System.DateTime(2017, 2, 4, 12, 0, 0, 0);
            this.startTimePicker.ValueChanged += new System.EventHandler(this.startTimePicker_ValueChanged);
            // 
            // stopTimeLabel
            // 
            this.stopTimeLabel.AutoSize = true;
            this.stopTimeLabel.Location = new System.Drawing.Point(4, 45);
            this.stopTimeLabel.Name = "stopTimeLabel";
            this.stopTimeLabel.Size = new System.Drawing.Size(52, 13);
            this.stopTimeLabel.TabIndex = 21;
            this.stopTimeLabel.Text = "StopTime";
            // 
            // startTimeLabel
            // 
            this.startTimeLabel.AutoSize = true;
            this.startTimeLabel.Location = new System.Drawing.Point(4, 3);
            this.startTimeLabel.Name = "startTimeLabel";
            this.startTimeLabel.Size = new System.Drawing.Size(55, 13);
            this.startTimeLabel.TabIndex = 20;
            this.startTimeLabel.Text = "StartTime:";
            // 
            // stopDatePicker
            // 
            this.stopDatePicker.CustomFormat = "dd.MM.yyyy";
            this.stopDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.stopDatePicker.Location = new System.Drawing.Point(7, 61);
            this.stopDatePicker.Name = "stopDatePicker";
            this.stopDatePicker.Size = new System.Drawing.Size(101, 20);
            this.stopDatePicker.TabIndex = 19;
            this.stopDatePicker.Value = new System.DateTime(2015, 8, 18, 0, 0, 0, 0);
            // 
            // startDatePicker
            // 
            this.startDatePicker.CustomFormat = "dd.MM.yyyy";
            this.startDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startDatePicker.Location = new System.Drawing.Point(7, 20);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(101, 20);
            this.startDatePicker.TabIndex = 18;
            this.startDatePicker.Value = new System.DateTime(2015, 8, 17, 0, 0, 0, 0);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(609, 47);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(154, 329);
            this.listBox1.TabIndex = 12;
            // 
            // addRunButton
            // 
            this.addRunButton.Location = new System.Drawing.Point(607, 3);
            this.addRunButton.Name = "addRunButton";
            this.addRunButton.Size = new System.Drawing.Size(75, 23);
            this.addRunButton.TabIndex = 13;
            this.addRunButton.Text = "Add";
            this.addRunButton.UseVisualStyleBackColor = true;
            this.addRunButton.Click += new System.EventHandler(this.addRunButton_Click);
            // 
            // revoveRunButton
            // 
            this.revoveRunButton.Location = new System.Drawing.Point(688, 4);
            this.revoveRunButton.Name = "revoveRunButton";
            this.revoveRunButton.Size = new System.Drawing.Size(75, 23);
            this.revoveRunButton.TabIndex = 14;
            this.revoveRunButton.Text = "Remove";
            this.revoveRunButton.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.revoveRunButton);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.addRunButton);
            this.panel3.Controls.Add(this.listBox1);
            this.panel3.Location = new System.Drawing.Point(9, 27);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(777, 378);
            this.panel3.TabIndex = 15;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.button1);
            this.panel4.Location = new System.Drawing.Point(12, 411);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(774, 33);
            this.panel4.TabIndex = 16;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(804, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewRunToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripMenuItem1,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // createNewRunToolStripMenuItem
            // 
            this.createNewRunToolStripMenuItem.Name = "createNewRunToolStripMenuItem";
            this.createNewRunToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.createNewRunToolStripMenuItem.Text = "New";
            this.createNewRunToolStripMenuItem.Click += new System.EventHandler(this.createNewRunToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(100, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // AutomatedRunsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 481);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AutomatedRunsForm";
            this.Text = "AutomatedRuns";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AutomatedRunsForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox schedulerComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox objectiveComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox SettingsRichTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker stopTimePicker;
        private System.Windows.Forms.DateTimePicker startTimePicker;
        private System.Windows.Forms.Label stopTimeLabel;
        private System.Windows.Forms.Label startTimeLabel;
        private System.Windows.Forms.DateTimePicker stopDatePicker;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.CheckedListBox checkedSatellites;
        private System.Windows.Forms.CheckedListBox checkedStations;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button addRunButton;
        private System.Windows.Forms.Button revoveRunButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewRunToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboScenarioBox;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}