using OxyPlot.WindowsForms;

namespace MARRSS
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label resultsTimeSumLabel;
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Stations");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Satellites");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Overall Results", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dataiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripSeparator();
            this.runsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripSeparator();
            this.addGroundStationToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addSatelliteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.tLEDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateTLEsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.objectiveBuilderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scenariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadDataScenarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groundPanel = new System.Windows.Forms.Panel();
            this.addStationButton = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.satellitePanel = new System.Windows.Forms.Panel();
            this.updateTleButton = new System.Windows.Forms.Label();
            this.AddSatelliteButton = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.schedulePanel = new System.Windows.Forms.Panel();
            this.openScheduleButton = new System.Windows.Forms.Label();
            this.newScheduleButton = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.objectiveComboBox = new System.Windows.Forms.ComboBox();
            this.logPanel = new System.Windows.Forms.Panel();
            this.label41 = new System.Windows.Forms.Label();
            this.logRichTextBox = new System.Windows.Forms.RichTextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.datShedLabel = new System.Windows.Forms.Label();
            this.durationLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.fitnessLabel = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.uweLabel = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.priorityLabel = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.contactNumberLabel = new System.Windows.Forms.Label();
            this.generationLabel = new System.Windows.Forms.Label();
            this.fitnessValueLabel = new System.Windows.Forms.Label();
            this.calcTimeLabel = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.collisionLabel = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.stationFairLabel = new System.Windows.Forms.Label();
            this.fairSatLabel = new System.Windows.Forms.Label();
            this.schedulerGroupBox = new System.Windows.Forms.GroupBox();
            this.radioHillClimber = new System.Windows.Forms.RadioButton();
            this.radioGreedy = new System.Windows.Forms.RadioButton();
            this.radioGenetic = new System.Windows.Forms.RadioButton();
            this.radioEFTGreedy = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.comboScenarioBox = new System.Windows.Forms.ComboBox();
            this.checkedSatellites = new System.Windows.Forms.CheckedListBox();
            this.contextSatellites = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.checkAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uncheckAllToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.checkedStations = new System.Windows.Forms.CheckedListBox();
            this.contextStations = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uncheckAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopTimePicker = new System.Windows.Forms.DateTimePicker();
            this.startTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.startScheduleButton = new System.Windows.Forms.Button();
            this.stopTimeLabel = new System.Windows.Forms.Label();
            this.startTimeLabel = new System.Windows.Forms.Label();
            this.stopDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.satRestultPanel = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.plot1 = new OxyPlot.WindowsForms.PlotView();
            this.satRestultAvgDownLabel = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.satResultAvDurationLabel = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.satRestulLostLabel = new System.Windows.Forms.Label();
            this.satRestulDownloadedLabel = new System.Windows.Forms.Label();
            this.satRestulMaxGenDataLabel = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.satRestulDurationLabel = new System.Windows.Forms.Label();
            this.satRestultSchedContactsLabel = new System.Windows.Forms.Label();
            this.satResultContactsLabel = new System.Windows.Forms.Label();
            this.satResultNameLabel = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.label84 = new System.Windows.Forms.Label();
            this.label85 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.resultSeletNameLabel = new System.Windows.Forms.Label();
            this.stationResultPanel = new System.Windows.Forms.Panel();
            this.stationResultIdleLabel = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.stationResultMaxDowLabel = new System.Windows.Forms.Label();
            this.stationResultAverageDownLabel = new System.Windows.Forms.Label();
            this.stationResultDownloadLabel = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.label77 = new System.Windows.Forms.Label();
            this.label78 = new System.Windows.Forms.Label();
            this.label83 = new System.Windows.Forms.Label();
            this.stationResultDurationLabel = new System.Windows.Forms.Label();
            this.stationResultScheduledContactsLAbel = new System.Windows.Forms.Label();
            this.stationResultContactsLabel = new System.Windows.Forms.Label();
            this.stationResultHeightLabel = new System.Windows.Forms.Label();
            this.stationResultLongLabel = new System.Windows.Forms.Label();
            this.stationResultLatLabel = new System.Windows.Forms.Label();
            this.stationResultNameLabel = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.label80 = new System.Windows.Forms.Label();
            this.label81 = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.label87 = new System.Windows.Forms.Label();
            this.label88 = new System.Windows.Forms.Label();
            this.label92 = new System.Windows.Forms.Label();
            this.label93 = new System.Windows.Forms.Label();
            this.OverallResultPanel = new System.Windows.Forms.Panel();
            this.resultAverageDownLabel = new System.Windows.Forms.Label();
            this.resultDataLostLabel = new System.Windows.Forms.Label();
            this.resultDownloadLabel = new System.Windows.Forms.Label();
            this.resultGeneratedDataLabel = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.resultsGenerationsLabel = new System.Windows.Forms.Label();
            this.resultSchedulingTimeLabel = new System.Windows.Forms.Label();
            this.resultTimeContactsLabel = new System.Windows.Forms.Label();
            this.resultCollisionLabel = new System.Windows.Forms.Label();
            this.resultScheduledContactsLabel = new System.Windows.Forms.Label();
            this.resultValidContactsLabel = new System.Windows.Forms.Label();
            this.resultNrStationLabel = new System.Windows.Forms.Label();
            this.resultNrSatellitesLabel = new System.Windows.Forms.Label();
            this.resultFitnessContactsValue = new System.Windows.Forms.Label();
            this.resultFitnessDurationLabel = new System.Windows.Forms.Label();
            this.resultDataFitnessLabel = new System.Windows.Forms.Label();
            this.resultFitnessSatelliteLabel = new System.Windows.Forms.Label();
            this.resultFitnesStationLabel = new System.Windows.Forms.Label();
            this.resultFairnessLabel = new System.Windows.Forms.Label();
            this.resultFitnessLabel = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label50 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.onBoardStoargeSizeText = new System.Windows.Forms.NumericUpDown();
            this.satelliteStorageUpdateButton = new System.Windows.Forms.Button();
            this.comboBoxSatelliteStorage = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.SatLabel5 = new System.Windows.Forms.Label();
            this.SatLabel4 = new System.Windows.Forms.Label();
            this.SatLabel3 = new System.Windows.Forms.Label();
            this.SatLabel2 = new System.Windows.Forms.Label();
            this.SatLabel1 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.satelliteNameLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.satelliteDataGrid = new System.Windows.Forms.DataGridView();
            this.Satellite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoradID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextSatDb = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label51 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.MaxUpLinkText = new System.Windows.Forms.TextBox();
            this.MaxDownTextBox = new System.Windows.Forms.TextBox();
            this.UpdateStationButton = new System.Windows.Forms.Button();
            this.UpDataSizeCombo = new System.Windows.Forms.ComboBox();
            this.DownDataSizeCombo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.StationNameLabel = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.staDataGridView = new System.Windows.Forms.DataGridView();
            this.Station = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextStationDB = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.satResultMaxDataLabel = new System.Windows.Forms.Label();
            resultsTimeSumLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groundPanel.SuspendLayout();
            this.satellitePanel.SuspendLayout();
            this.schedulePanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.logPanel.SuspendLayout();
            this.panel8.SuspendLayout();
            this.schedulerGroupBox.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.contextSatellites.SuspendLayout();
            this.contextStations.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.satRestultPanel.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel5.SuspendLayout();
            this.stationResultPanel.SuspendLayout();
            this.OverallResultPanel.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.onBoardStoargeSizeText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.satelliteDataGrid)).BeginInit();
            this.contextSatDb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.staDataGridView)).BeginInit();
            this.contextStationDB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // resultsTimeSumLabel
            // 
            resultsTimeSumLabel.AutoSize = true;
            resultsTimeSumLabel.Location = new System.Drawing.Point(260, 410);
            resultsTimeSumLabel.Name = "resultsTimeSumLabel";
            resultsTimeSumLabel.Size = new System.Drawing.Size(13, 13);
            resultsTimeSumLabel.TabIndex = 31;
            resultsTimeSumLabel.Text = "--";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataiToolStripMenuItem,
            this.databaseToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.testingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1174, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dataiToolStripMenuItem
            // 
            this.dataiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.toolStripMenuItem2,
            this.openToolStripMenuItem,
            this.toolStripMenuItem3,
            this.toolStripMenuItem11,
            this.runsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.closeToolStripMenuItem});
            this.dataiToolStripMenuItem.Name = "dataiToolStripMenuItem";
            this.dataiToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.dataiToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(160, 6);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(163, 22);
            this.toolStripMenuItem3.Text = "Save";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(160, 6);
            // 
            // runsToolStripMenuItem
            // 
            this.runsToolStripMenuItem.Name = "runsToolStripMenuItem";
            this.runsToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.runsToolStripMenuItem.Text = "Automated Runs";
            this.runsToolStripMenuItem.Click += new System.EventHandler(this.runsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(160, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.closeToolStripMenuItem.Text = "Exit";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem12,
            this.addGroundStationToolStripMenuItem1,
            this.addSatelliteToolStripMenuItem1});
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.databaseToolStripMenuItem.Text = "Database";
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(176, 6);
            // 
            // addGroundStationToolStripMenuItem1
            // 
            this.addGroundStationToolStripMenuItem1.Name = "addGroundStationToolStripMenuItem1";
            this.addGroundStationToolStripMenuItem1.Size = new System.Drawing.Size(179, 22);
            this.addGroundStationToolStripMenuItem1.Text = "Add Ground Station";
            this.addGroundStationToolStripMenuItem1.Click += new System.EventHandler(this.addGroundStationToolStripMenuItem1_Click_1);
            // 
            // addSatelliteToolStripMenuItem1
            // 
            this.addSatelliteToolStripMenuItem1.Name = "addSatelliteToolStripMenuItem1";
            this.addSatelliteToolStripMenuItem1.Size = new System.Drawing.Size(179, 22);
            this.addSatelliteToolStripMenuItem1.Text = "Add Satellite";
            this.addSatelliteToolStripMenuItem1.Click += new System.EventHandler(this.addSatelliteToolStripMenuItem1_Click_1);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem1,
            this.toolStripMenuItem8,
            this.tLEDataToolStripMenuItem,
            this.toolStripMenuItem9,
            this.objectiveBuilderToolStripMenuItem,
            this.scenariosToolStripMenuItem,
            this.loadDataScenarioToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // settingsToolStripMenuItem1
            // 
            this.settingsToolStripMenuItem1.Name = "settingsToolStripMenuItem1";
            this.settingsToolStripMenuItem1.Size = new System.Drawing.Size(175, 22);
            this.settingsToolStripMenuItem1.Text = "Settings";
            this.settingsToolStripMenuItem1.Click += new System.EventHandler(this.settingsToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(172, 6);
            // 
            // tLEDataToolStripMenuItem
            // 
            this.tLEDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateTLEsToolStripMenuItem});
            this.tLEDataToolStripMenuItem.Name = "tLEDataToolStripMenuItem";
            this.tLEDataToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.tLEDataToolStripMenuItem.Text = "TLE-Data";
            // 
            // updateTLEsToolStripMenuItem
            // 
            this.updateTLEsToolStripMenuItem.Name = "updateTLEsToolStripMenuItem";
            this.updateTLEsToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.updateTLEsToolStripMenuItem.Text = "Update TLE\'s";
            this.updateTLEsToolStripMenuItem.Click += new System.EventHandler(this.updateTLEsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(172, 6);
            // 
            // objectiveBuilderToolStripMenuItem
            // 
            this.objectiveBuilderToolStripMenuItem.Name = "objectiveBuilderToolStripMenuItem";
            this.objectiveBuilderToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.objectiveBuilderToolStripMenuItem.Text = "Objective Builder";
            this.objectiveBuilderToolStripMenuItem.Click += new System.EventHandler(this.objectiveBuilderToolStripMenuItem_Click);
            // 
            // scenariosToolStripMenuItem
            // 
            this.scenariosToolStripMenuItem.Name = "scenariosToolStripMenuItem";
            this.scenariosToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.scenariosToolStripMenuItem.Text = "Scenarios";
            this.scenariosToolStripMenuItem.Click += new System.EventHandler(this.scenariosToolStripMenuItem_Click);
            // 
            // loadDataScenarioToolStripMenuItem
            // 
            this.loadDataScenarioToolStripMenuItem.Name = "loadDataScenarioToolStripMenuItem";
            this.loadDataScenarioToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.loadDataScenarioToolStripMenuItem.Text = "Load Data Scenario";
            this.loadDataScenarioToolStripMenuItem.Click += new System.EventHandler(this.loadDataScenarioToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.documentationToolStripMenuItem,
            this.toolStripMenuItem4,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // documentationToolStripMenuItem
            // 
            this.documentationToolStripMenuItem.Name = "documentationToolStripMenuItem";
            this.documentationToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.documentationToolStripMenuItem.Text = "Wiki";
            this.documentationToolStripMenuItem.Click += new System.EventHandler(this.documentationToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(104, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // testingToolStripMenuItem
            // 
            this.testingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formTestToolStripMenuItem});
            this.testingToolStripMenuItem.Name = "testingToolStripMenuItem";
            this.testingToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.testingToolStripMenuItem.Text = "Testing";
            // 
            // formTestToolStripMenuItem
            // 
            this.formTestToolStripMenuItem.Name = "formTestToolStripMenuItem";
            this.formTestToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.formTestToolStripMenuItem.Text = "formTest";
            this.formTestToolStripMenuItem.Click += new System.EventHandler(this.formTestToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.progressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 660);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1174, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(95, 17);
            this.toolStripStatusLabel4.Text = "01-01-2000 12:00";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(785, 17);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(77, 17);
            this.toolStripStatusLabel3.Text = "Status: Ready";
            // 
            // progressBar1
            // 
            this.progressBar1.Maximum = 500;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(200, 16);
            this.progressBar1.Step = 1;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.groundPanel);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.satellitePanel);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.schedulePanel);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(165, 603);
            this.panel1.TabIndex = 2;
            // 
            // groundPanel
            // 
            this.groundPanel.Controls.Add(this.addStationButton);
            this.groundPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.groundPanel.Location = new System.Drawing.Point(0, 350);
            this.groundPanel.Name = "groundPanel";
            this.groundPanel.Size = new System.Drawing.Size(165, 70);
            this.groundPanel.TabIndex = 9;
            // 
            // addStationButton
            // 
            this.addStationButton.AutoSize = true;
            this.addStationButton.Location = new System.Drawing.Point(12, 10);
            this.addStationButton.Name = "addStationButton";
            this.addStationButton.Size = new System.Drawing.Size(97, 13);
            this.addStationButton.TabIndex = 0;
            this.addStationButton.Text = "Add GroundStation";
            this.addStationButton.Click += new System.EventHandler(this.label5_Click);
            this.addStationButton.MouseEnter += new System.EventHandler(this.label5_MouseEnter);
            this.addStationButton.MouseLeave += new System.EventHandler(this.label5_MouseLeave);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button3.Dock = System.Windows.Forms.DockStyle.Top;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Calibri", 25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.button3.Location = new System.Drawing.Point(0, 280);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(165, 70);
            this.button3.TabIndex = 7;
            this.button3.Text = "Ground Stations";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // satellitePanel
            // 
            this.satellitePanel.Controls.Add(this.updateTleButton);
            this.satellitePanel.Controls.Add(this.AddSatelliteButton);
            this.satellitePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.satellitePanel.Location = new System.Drawing.Point(0, 210);
            this.satellitePanel.Name = "satellitePanel";
            this.satellitePanel.Size = new System.Drawing.Size(165, 70);
            this.satellitePanel.TabIndex = 6;
            // 
            // updateTleButton
            // 
            this.updateTleButton.AutoSize = true;
            this.updateTleButton.Location = new System.Drawing.Point(12, 32);
            this.updateTleButton.Name = "updateTleButton";
            this.updateTleButton.Size = new System.Drawing.Size(72, 13);
            this.updateTleButton.TabIndex = 1;
            this.updateTleButton.Text = "Update TLE\'s";
            this.updateTleButton.Click += new System.EventHandler(this.label59_Click);
            this.updateTleButton.MouseEnter += new System.EventHandler(this.updateTleButton_MouseEnter);
            this.updateTleButton.MouseLeave += new System.EventHandler(this.updateTleButton_MouseLeave);
            // 
            // AddSatelliteButton
            // 
            this.AddSatelliteButton.AutoSize = true;
            this.AddSatelliteButton.Location = new System.Drawing.Point(12, 7);
            this.AddSatelliteButton.Name = "AddSatelliteButton";
            this.AddSatelliteButton.Size = new System.Drawing.Size(71, 13);
            this.AddSatelliteButton.TabIndex = 0;
            this.AddSatelliteButton.Text = "Add Satellites";
            this.AddSatelliteButton.Click += new System.EventHandler(this.label2_Click);
            this.AddSatelliteButton.MouseEnter += new System.EventHandler(this.label2_MouseEnter);
            this.AddSatelliteButton.MouseLeave += new System.EventHandler(this.label2_MouseLeave);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Calibri", 25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.button2.Location = new System.Drawing.Point(0, 140);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(165, 70);
            this.button2.TabIndex = 5;
            this.button2.Text = "Satellites";
            this.button2.UseMnemonic = false;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // schedulePanel
            // 
            this.schedulePanel.Controls.Add(this.openScheduleButton);
            this.schedulePanel.Controls.Add(this.newScheduleButton);
            this.schedulePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.schedulePanel.Location = new System.Drawing.Point(0, 70);
            this.schedulePanel.Name = "schedulePanel";
            this.schedulePanel.Size = new System.Drawing.Size(165, 70);
            this.schedulePanel.TabIndex = 4;
            // 
            // openScheduleButton
            // 
            this.openScheduleButton.AutoSize = true;
            this.openScheduleButton.Location = new System.Drawing.Point(10, 30);
            this.openScheduleButton.Name = "openScheduleButton";
            this.openScheduleButton.Size = new System.Drawing.Size(81, 13);
            this.openScheduleButton.TabIndex = 1;
            this.openScheduleButton.Text = "Open Schedule";
            this.openScheduleButton.Click += new System.EventHandler(this.label3_Click);
            this.openScheduleButton.MouseEnter += new System.EventHandler(this.label3_MouseEnter);
            this.openScheduleButton.MouseLeave += new System.EventHandler(this.label3_MouseLeave);
            // 
            // newScheduleButton
            // 
            this.newScheduleButton.AutoSize = true;
            this.newScheduleButton.Location = new System.Drawing.Point(10, 5);
            this.newScheduleButton.Name = "newScheduleButton";
            this.newScheduleButton.Size = new System.Drawing.Size(77, 13);
            this.newScheduleButton.TabIndex = 0;
            this.newScheduleButton.Text = "New Schedule";
            this.newScheduleButton.Click += new System.EventHandler(this.label1_Click);
            this.newScheduleButton.MouseEnter += new System.EventHandler(this.label1_MouseEnter);
            this.newScheduleButton.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Calibri", 25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 70);
            this.button1.TabIndex = 0;
            this.button1.Text = "Schedule";
            this.button1.UseMnemonic = false;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Location = new System.Drawing.Point(172, 24);
            this.panel2.Margin = new System.Windows.Forms.Padding(10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1039, 636);
            this.panel2.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(0, 10);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(10);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1002, 616);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.logPanel);
            this.tabPage2.Controls.Add(this.panel8);
            this.tabPage2.Controls.Add(this.schedulerGroupBox);
            this.tabPage2.Controls.Add(this.groupBox6);
            this.tabPage2.Controls.Add(this.checkedSatellites);
            this.tabPage2.Controls.Add(this.checkedStations);
            this.tabPage2.Controls.Add(this.stopTimePicker);
            this.tabPage2.Controls.Add(this.startTimePicker);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.startScheduleButton);
            this.tabPage2.Controls.Add(this.stopTimeLabel);
            this.tabPage2.Controls.Add(this.startTimeLabel);
            this.tabPage2.Controls.Add(this.stopDatePicker);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.startDatePicker);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(994, 587);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Schedule";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.objectiveComboBox);
            this.groupBox1.Location = new System.Drawing.Point(480, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(178, 76);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Objective";
            // 
            // objectiveComboBox
            // 
            this.objectiveComboBox.FormattingEnabled = true;
            this.objectiveComboBox.Location = new System.Drawing.Point(21, 32);
            this.objectiveComboBox.Name = "objectiveComboBox";
            this.objectiveComboBox.Size = new System.Drawing.Size(148, 21);
            this.objectiveComboBox.TabIndex = 0;
            // 
            // logPanel
            // 
            this.logPanel.Controls.Add(this.label41);
            this.logPanel.Controls.Add(this.logRichTextBox);
            this.logPanel.Location = new System.Drawing.Point(556, 462);
            this.logPanel.Name = "logPanel";
            this.logPanel.Size = new System.Drawing.Size(430, 106);
            this.logPanel.TabIndex = 48;
            this.logPanel.Visible = false;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(3, 2);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(28, 13);
            this.label41.TabIndex = 39;
            this.label41.Text = "Log:";
            // 
            // logRichTextBox
            // 
            this.logRichTextBox.Location = new System.Drawing.Point(6, 18);
            this.logRichTextBox.Name = "logRichTextBox";
            this.logRichTextBox.Size = new System.Drawing.Size(417, 82);
            this.logRichTextBox.TabIndex = 38;
            this.logRichTextBox.Text = "";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.label4);
            this.panel8.Controls.Add(this.datShedLabel);
            this.panel8.Controls.Add(this.durationLabel);
            this.panel8.Controls.Add(this.label2);
            this.panel8.Controls.Add(this.label1);
            this.panel8.Controls.Add(this.fitnessLabel);
            this.panel8.Controls.Add(this.label31);
            this.panel8.Controls.Add(this.uweLabel);
            this.panel8.Controls.Add(this.label32);
            this.panel8.Controls.Add(this.priorityLabel);
            this.panel8.Controls.Add(this.label33);
            this.panel8.Controls.Add(this.contactNumberLabel);
            this.panel8.Controls.Add(this.generationLabel);
            this.panel8.Controls.Add(this.fitnessValueLabel);
            this.panel8.Controls.Add(this.calcTimeLabel);
            this.panel8.Controls.Add(this.label21);
            this.panel8.Controls.Add(this.collisionLabel);
            this.panel8.Controls.Add(this.label34);
            this.panel8.Controls.Add(this.label38);
            this.panel8.Controls.Add(this.stationFairLabel);
            this.panel8.Controls.Add(this.fairSatLabel);
            this.panel8.Location = new System.Drawing.Point(556, 182);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(430, 264);
            this.panel8.TabIndex = 47;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 50;
            this.label4.Text = "Data Downlink";
            // 
            // datShedLabel
            // 
            this.datShedLabel.AutoSize = true;
            this.datShedLabel.Location = new System.Drawing.Point(209, 160);
            this.datShedLabel.Name = "datShedLabel";
            this.datShedLabel.Size = new System.Drawing.Size(13, 13);
            this.datShedLabel.TabIndex = 51;
            this.datShedLabel.Text = "--";
            this.toolTip1.SetToolTip(this.datShedLabel, "Fairness value of satellites in shedule. A value of 1.0 means that all satellites" +
        " are contacted eqaly");
            // 
            // durationLabel
            // 
            this.durationLabel.AutoSize = true;
            this.durationLabel.Location = new System.Drawing.Point(208, 184);
            this.durationLabel.Name = "durationLabel";
            this.durationLabel.Size = new System.Drawing.Size(13, 13);
            this.durationLabel.TabIndex = 49;
            this.durationLabel.Text = "--";
            this.toolTip1.SetToolTip(this.durationLabel, "Fairness value of satellites in shedule. A value of 1.0 means that all satellites" +
        " are contacted eqaly");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 48;
            this.label2.Text = "Duration";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 47;
            this.label1.Text = "Results:";
            // 
            // fitnessLabel
            // 
            this.fitnessLabel.AutoSize = true;
            this.fitnessLabel.Location = new System.Drawing.Point(20, 28);
            this.fitnessLabel.Name = "fitnessLabel";
            this.fitnessLabel.Size = new System.Drawing.Size(73, 13);
            this.fitnessLabel.TabIndex = 42;
            this.fitnessLabel.Text = "Fitness Value:";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(18, 62);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(135, 13);
            this.label31.TabIndex = 23;
            this.label31.Text = "Nr. of Scheduled Contacts:";
            // 
            // uweLabel
            // 
            this.uweLabel.AutoSize = true;
            this.uweLabel.Location = new System.Drawing.Point(298, 62);
            this.uweLabel.Name = "uweLabel";
            this.uweLabel.Size = new System.Drawing.Size(13, 13);
            this.uweLabel.TabIndex = 46;
            this.uweLabel.Text = "--";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(18, 81);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(93, 13);
            this.label32.TabIndex = 24;
            this.label32.Text = "Nr. of Generations";
            // 
            // priorityLabel
            // 
            this.priorityLabel.AutoSize = true;
            this.priorityLabel.Location = new System.Drawing.Point(18, 237);
            this.priorityLabel.Name = "priorityLabel";
            this.priorityLabel.Size = new System.Drawing.Size(38, 13);
            this.priorityLabel.TabIndex = 45;
            this.priorityLabel.Text = "Priority";
            this.toolTip1.SetToolTip(this.priorityLabel, "Number of Scheduled contacts in relation to their priority. Ranging from 0 (Criti" +
        "cyl) to 4 (None)");
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(18, 203);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(88, 13);
            this.label33.TabIndex = 25;
            this.label33.Text = "Calculation Time:";
            // 
            // contactNumberLabel
            // 
            this.contactNumberLabel.AutoSize = true;
            this.contactNumberLabel.Location = new System.Drawing.Point(208, 63);
            this.contactNumberLabel.Name = "contactNumberLabel";
            this.contactNumberLabel.Size = new System.Drawing.Size(13, 13);
            this.contactNumberLabel.TabIndex = 27;
            this.contactNumberLabel.Text = "--";
            this.toolTip1.SetToolTip(this.contactNumberLabel, "Number of scheduled contacts");
            // 
            // generationLabel
            // 
            this.generationLabel.AutoSize = true;
            this.generationLabel.Location = new System.Drawing.Point(208, 81);
            this.generationLabel.Name = "generationLabel";
            this.generationLabel.Size = new System.Drawing.Size(13, 13);
            this.generationLabel.TabIndex = 28;
            this.generationLabel.Text = "--";
            this.toolTip1.SetToolTip(this.generationLabel, "Number of generations that were computed");
            // 
            // fitnessValueLabel
            // 
            this.fitnessValueLabel.AutoSize = true;
            this.fitnessValueLabel.Location = new System.Drawing.Point(210, 28);
            this.fitnessValueLabel.Name = "fitnessValueLabel";
            this.fitnessValueLabel.Size = new System.Drawing.Size(13, 13);
            this.fitnessValueLabel.TabIndex = 43;
            this.fitnessValueLabel.Text = "--";
            // 
            // calcTimeLabel
            // 
            this.calcTimeLabel.AutoSize = true;
            this.calcTimeLabel.Location = new System.Drawing.Point(208, 203);
            this.calcTimeLabel.Name = "calcTimeLabel";
            this.calcTimeLabel.Size = new System.Drawing.Size(13, 13);
            this.calcTimeLabel.TabIndex = 29;
            this.calcTimeLabel.Text = "--";
            this.toolTip1.SetToolTip(this.calcTimeLabel, "Calulation time of the scheduler in seconds not including the orbit and contact w" +
        "indows calculation times.");
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(18, 101);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(79, 13);
            this.label21.TabIndex = 31;
            this.label21.Text = "Nr. of Collisions";
            // 
            // collisionLabel
            // 
            this.collisionLabel.AutoSize = true;
            this.collisionLabel.Location = new System.Drawing.Point(208, 101);
            this.collisionLabel.Name = "collisionLabel";
            this.collisionLabel.Size = new System.Drawing.Size(13, 13);
            this.collisionLabel.TabIndex = 32;
            this.collisionLabel.Text = "--";
            this.toolTip1.SetToolTip(this.collisionLabel, "Number of collisions in the finished schedule");
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(18, 120);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(90, 13);
            this.label34.TabIndex = 34;
            this.label34.Text = "Fairness Stations:";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(18, 140);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(94, 13);
            this.label38.TabIndex = 35;
            this.label38.Text = "Fairness Satellites:";
            // 
            // stationFairLabel
            // 
            this.stationFairLabel.AutoSize = true;
            this.stationFairLabel.Location = new System.Drawing.Point(208, 120);
            this.stationFairLabel.Name = "stationFairLabel";
            this.stationFairLabel.Size = new System.Drawing.Size(13, 13);
            this.stationFairLabel.TabIndex = 36;
            this.stationFairLabel.Text = "--";
            this.toolTip1.SetToolTip(this.stationFairLabel, "Fitness value of stations used in schedule. A 1.0 means that all Stations are use" +
        "d the same number of times.");
            // 
            // fairSatLabel
            // 
            this.fairSatLabel.AutoSize = true;
            this.fairSatLabel.Location = new System.Drawing.Point(208, 140);
            this.fairSatLabel.Name = "fairSatLabel";
            this.fairSatLabel.Size = new System.Drawing.Size(13, 13);
            this.fairSatLabel.TabIndex = 37;
            this.fairSatLabel.Text = "--";
            this.toolTip1.SetToolTip(this.fairSatLabel, "Fairness value of satellites in shedule. A value of 1.0 means that all satellites" +
        " are contacted eqaly");
            // 
            // schedulerGroupBox
            // 
            this.schedulerGroupBox.Controls.Add(this.radioHillClimber);
            this.schedulerGroupBox.Controls.Add(this.radioGreedy);
            this.schedulerGroupBox.Controls.Add(this.radioGenetic);
            this.schedulerGroupBox.Controls.Add(this.radioEFTGreedy);
            this.schedulerGroupBox.Location = new System.Drawing.Point(285, 35);
            this.schedulerGroupBox.Name = "schedulerGroupBox";
            this.schedulerGroupBox.Size = new System.Drawing.Size(178, 76);
            this.schedulerGroupBox.TabIndex = 2;
            this.schedulerGroupBox.TabStop = false;
            this.schedulerGroupBox.Text = "Scheduler";
            // 
            // radioHillClimber
            // 
            this.radioHillClimber.AutoSize = true;
            this.radioHillClimber.Location = new System.Drawing.Point(90, 47);
            this.radioHillClimber.Name = "radioHillClimber";
            this.radioHillClimber.Size = new System.Drawing.Size(76, 17);
            this.radioHillClimber.TabIndex = 3;
            this.radioHillClimber.Text = "Hill Climber";
            this.radioHillClimber.UseVisualStyleBackColor = true;
            // 
            // radioGreedy
            // 
            this.radioGreedy.AutoSize = true;
            this.radioGreedy.Location = new System.Drawing.Point(10, 22);
            this.radioGreedy.Name = "radioGreedy";
            this.radioGreedy.Size = new System.Drawing.Size(59, 17);
            this.radioGreedy.TabIndex = 2;
            this.radioGreedy.Text = "Greedy";
            this.radioGreedy.UseVisualStyleBackColor = true;
            // 
            // radioGenetic
            // 
            this.radioGenetic.AutoSize = true;
            this.radioGenetic.Checked = true;
            this.radioGenetic.Location = new System.Drawing.Point(10, 48);
            this.radioGenetic.Name = "radioGenetic";
            this.radioGenetic.Size = new System.Drawing.Size(62, 17);
            this.radioGenetic.TabIndex = 1;
            this.radioGenetic.TabStop = true;
            this.radioGenetic.Text = "Genetic";
            this.radioGenetic.UseVisualStyleBackColor = true;
            // 
            // radioEFTGreedy
            // 
            this.radioEFTGreedy.AutoSize = true;
            this.radioEFTGreedy.Location = new System.Drawing.Point(90, 23);
            this.radioEFTGreedy.Name = "radioEFTGreedy";
            this.radioEFTGreedy.Size = new System.Drawing.Size(82, 17);
            this.radioEFTGreedy.TabIndex = 0;
            this.radioEFTGreedy.Text = "EFT-Greedy";
            this.radioEFTGreedy.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.comboScenarioBox);
            this.groupBox6.Location = new System.Drawing.Point(674, 35);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(286, 75);
            this.groupBox6.TabIndex = 44;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Test Scenarios";
            // 
            // comboScenarioBox
            // 
            this.comboScenarioBox.FormattingEnabled = true;
            this.comboScenarioBox.Items.AddRange(new object[] {
            "A: Daily Operations - No Priority\'s",
            "B: Daily Operations - Random Priority",
            "C: LEOP UWE-3 Critical",
            "D: Critical over home station"});
            this.comboScenarioBox.Location = new System.Drawing.Point(24, 32);
            this.comboScenarioBox.Name = "comboScenarioBox";
            this.comboScenarioBox.Size = new System.Drawing.Size(254, 21);
            this.comboScenarioBox.TabIndex = 0;
            // 
            // checkedSatellites
            // 
            this.checkedSatellites.CheckOnClick = true;
            this.checkedSatellites.ContextMenuStrip = this.contextSatellites;
            this.checkedSatellites.FormattingEnabled = true;
            this.checkedSatellites.Location = new System.Drawing.Point(285, 152);
            this.checkedSatellites.Name = "checkedSatellites";
            this.checkedSatellites.Size = new System.Drawing.Size(250, 409);
            this.checkedSatellites.TabIndex = 22;
            this.checkedSatellites.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedSatellites_ItemCheck);
            // 
            // contextSatellites
            // 
            this.contextSatellites.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkAllToolStripMenuItem,
            this.uncheckAllToolStripMenuItem1});
            this.contextSatellites.Name = "contextSatellites";
            this.contextSatellites.Size = new System.Drawing.Size(138, 48);
            // 
            // checkAllToolStripMenuItem
            // 
            this.checkAllToolStripMenuItem.Name = "checkAllToolStripMenuItem";
            this.checkAllToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.checkAllToolStripMenuItem.Text = "Select All";
            this.checkAllToolStripMenuItem.Click += new System.EventHandler(this.checkAllToolStripMenuItem_Click);
            // 
            // uncheckAllToolStripMenuItem1
            // 
            this.uncheckAllToolStripMenuItem1.Name = "uncheckAllToolStripMenuItem1";
            this.uncheckAllToolStripMenuItem1.Size = new System.Drawing.Size(137, 22);
            this.uncheckAllToolStripMenuItem1.Text = "Uncheck All";
            this.uncheckAllToolStripMenuItem1.Click += new System.EventHandler(this.uncheckAllToolStripMenuItem1_Click);
            // 
            // checkedStations
            // 
            this.checkedStations.CheckOnClick = true;
            this.checkedStations.ContextMenuStrip = this.contextStations;
            this.checkedStations.FormattingEnabled = true;
            this.checkedStations.Location = new System.Drawing.Point(10, 152);
            this.checkedStations.Name = "checkedStations";
            this.checkedStations.Size = new System.Drawing.Size(250, 409);
            this.checkedStations.TabIndex = 21;
            this.checkedStations.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedStations_ItemCheck);
            // 
            // contextStations
            // 
            this.contextStations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllToolStripMenuItem,
            this.uncheckAllToolStripMenuItem});
            this.contextStations.Name = "contextStations";
            this.contextStations.Size = new System.Drawing.Size(138, 48);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // uncheckAllToolStripMenuItem
            // 
            this.uncheckAllToolStripMenuItem.Name = "uncheckAllToolStripMenuItem";
            this.uncheckAllToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.uncheckAllToolStripMenuItem.Text = "Uncheck All";
            this.uncheckAllToolStripMenuItem.Click += new System.EventHandler(this.uncheckAllToolStripMenuItem_Click);
            // 
            // stopTimePicker
            // 
            this.stopTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.stopTimePicker.Location = new System.Drawing.Point(189, 82);
            this.stopTimePicker.Name = "stopTimePicker";
            this.stopTimePicker.ShowUpDown = true;
            this.stopTimePicker.Size = new System.Drawing.Size(71, 20);
            this.stopTimePicker.TabIndex = 17;
            this.toolTip1.SetToolTip(this.stopTimePicker, "Starting time in UTC");
            this.stopTimePicker.Value = new System.DateTime(2015, 8, 18, 0, 0, 0, 0);
            this.stopTimePicker.ValueChanged += new System.EventHandler(this.stopTimePicker_ValueChanged);
            // 
            // startTimePicker
            // 
            this.startTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.startTimePicker.Location = new System.Drawing.Point(189, 53);
            this.startTimePicker.Name = "startTimePicker";
            this.startTimePicker.ShowUpDown = true;
            this.startTimePicker.Size = new System.Drawing.Size(71, 20);
            this.startTimePicker.TabIndex = 16;
            this.toolTip1.SetToolTip(this.startTimePicker, "Starting time in UTC");
            this.startTimePicker.Value = new System.DateTime(2015, 8, 18, 0, 0, 0, 0);
            this.startTimePicker.ValueChanged += new System.EventHandler(this.startTimePicker_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(282, 136);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Satellites";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 136);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "GroundStations:";
            // 
            // startScheduleButton
            // 
            this.startScheduleButton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.startScheduleButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.startScheduleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startScheduleButton.Location = new System.Drawing.Point(738, 135);
            this.startScheduleButton.Name = "startScheduleButton";
            this.startScheduleButton.Size = new System.Drawing.Size(129, 23);
            this.startScheduleButton.TabIndex = 8;
            this.startScheduleButton.Text = "Calculate Schedule";
            this.startScheduleButton.UseVisualStyleBackColor = false;
            this.startScheduleButton.Click += new System.EventHandler(this.startScheduleButton_Click);
            // 
            // stopTimeLabel
            // 
            this.stopTimeLabel.AutoSize = true;
            this.stopTimeLabel.Location = new System.Drawing.Point(7, 88);
            this.stopTimeLabel.Name = "stopTimeLabel";
            this.stopTimeLabel.Size = new System.Drawing.Size(52, 13);
            this.stopTimeLabel.TabIndex = 5;
            this.stopTimeLabel.Text = "StopTime";
            // 
            // startTimeLabel
            // 
            this.startTimeLabel.AutoSize = true;
            this.startTimeLabel.Location = new System.Drawing.Point(7, 60);
            this.startTimeLabel.Name = "startTimeLabel";
            this.startTimeLabel.Size = new System.Drawing.Size(55, 13);
            this.startTimeLabel.TabIndex = 4;
            this.startTimeLabel.Text = "StartTime:";
            // 
            // stopDatePicker
            // 
            this.stopDatePicker.CustomFormat = "dd.MM.yyyy";
            this.stopDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.stopDatePicker.Location = new System.Drawing.Point(82, 82);
            this.stopDatePicker.Name = "stopDatePicker";
            this.stopDatePicker.Size = new System.Drawing.Size(101, 20);
            this.stopDatePicker.TabIndex = 3;
            this.toolTip1.SetToolTip(this.stopDatePicker, "Starting date to start simulation");
            this.stopDatePicker.Value = new System.DateTime(2018, 1, 22, 0, 0, 0, 0);
            this.stopDatePicker.ValueChanged += new System.EventHandler(this.stopDatePicker_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(156, 19);
            this.label6.TabIndex = 1;
            this.label6.Text = "Calculate Schedule";
            // 
            // startDatePicker
            // 
            this.startDatePicker.CustomFormat = "dd.MM.yyyy";
            this.startDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startDatePicker.Location = new System.Drawing.Point(82, 53);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(101, 20);
            this.startDatePicker.TabIndex = 0;
            this.toolTip1.SetToolTip(this.startDatePicker, "Starting date to start simulation");
            this.startDatePicker.Value = new System.DateTime(2018, 1, 12, 0, 0, 0, 0);
            this.startDatePicker.ValueChanged += new System.EventHandler(this.startDatePicker_ValueChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(994, 587);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Results";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel5);
            this.splitContainer1.Panel2.Controls.Add(this.satRestultPanel);
            this.splitContainer1.Panel2.Controls.Add(this.stationResultPanel);
            this.splitContainer1.Panel2.Controls.Add(this.OverallResultPanel);
            this.splitContainer1.Size = new System.Drawing.Size(988, 581);
            this.splitContainer1.SplitterDistance = 206;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.HideSelection = false;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "StationsNode";
            treeNode1.Text = "Stations";
            treeNode2.Name = "SatellitesNode";
            treeNode2.Text = "Satellites";
            treeNode3.Name = "RootNode";
            treeNode3.Text = "Overall Results";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.treeView1.Size = new System.Drawing.Size(206, 581);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // satRestultPanel
            // 
            this.satRestultPanel.Controls.Add(this.satResultMaxDataLabel);
            this.satRestultPanel.Controls.Add(this.panel12);
            this.satRestultPanel.Controls.Add(this.satRestultAvgDownLabel);
            this.satRestultPanel.Controls.Add(this.label72);
            this.satRestultPanel.Controls.Add(this.satResultAvDurationLabel);
            this.satRestultPanel.Controls.Add(this.label47);
            this.satRestultPanel.Controls.Add(this.satRestulLostLabel);
            this.satRestultPanel.Controls.Add(this.satRestulDownloadedLabel);
            this.satRestultPanel.Controls.Add(this.satRestulMaxGenDataLabel);
            this.satRestultPanel.Controls.Add(this.label58);
            this.satRestultPanel.Controls.Add(this.label59);
            this.satRestultPanel.Controls.Add(this.label60);
            this.satRestultPanel.Controls.Add(this.label61);
            this.satRestultPanel.Controls.Add(this.satRestulDurationLabel);
            this.satRestultPanel.Controls.Add(this.satRestultSchedContactsLabel);
            this.satRestultPanel.Controls.Add(this.satResultContactsLabel);
            this.satRestultPanel.Controls.Add(this.satResultNameLabel);
            this.satRestultPanel.Controls.Add(this.label74);
            this.satRestultPanel.Controls.Add(this.label76);
            this.satRestultPanel.Controls.Add(this.label84);
            this.satRestultPanel.Controls.Add(this.label85);
            this.satRestultPanel.Location = new System.Drawing.Point(8, 38);
            this.satRestultPanel.Name = "satRestultPanel";
            this.satRestultPanel.Size = new System.Drawing.Size(770, 537);
            this.satRestultPanel.TabIndex = 3;
            this.satRestultPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel9_Paint);
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.plot1);
            this.panel12.Location = new System.Drawing.Point(9, 138);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(755, 393);
            this.panel12.TabIndex = 57;
            // 
            // plot1
            // 
            this.plot1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plot1.Location = new System.Drawing.Point(0, 0);
            this.plot1.Name = "plot1";
            this.plot1.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plot1.Size = new System.Drawing.Size(755, 393);
            this.plot1.TabIndex = 0;
            this.plot1.Text = "plot1";
            this.plot1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plot1.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plot1.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // satRestultAvgDownLabel
            // 
            this.satRestultAvgDownLabel.AutoSize = true;
            this.satRestultAvgDownLabel.Location = new System.Drawing.Point(548, 110);
            this.satRestultAvgDownLabel.Name = "satRestultAvgDownLabel";
            this.satRestultAvgDownLabel.Size = new System.Drawing.Size(13, 13);
            this.satRestultAvgDownLabel.TabIndex = 56;
            this.satRestultAvgDownLabel.Text = "--";
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Location = new System.Drawing.Point(400, 107);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(97, 13);
            this.label72.TabIndex = 53;
            this.label72.Text = "Average Downlink:";
            // 
            // satResultAvDurationLabel
            // 
            this.satResultAvDurationLabel.AutoSize = true;
            this.satResultAvDurationLabel.Location = new System.Drawing.Point(216, 104);
            this.satResultAvDurationLabel.Name = "satResultAvDurationLabel";
            this.satResultAvDurationLabel.Size = new System.Drawing.Size(13, 13);
            this.satResultAvDurationLabel.TabIndex = 52;
            this.satResultAvDurationLabel.Text = "--";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(15, 107);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(130, 13);
            this.label47.TabIndex = 51;
            this.label47.Text = "Average contact duration:";
            // 
            // satRestulLostLabel
            // 
            this.satRestulLostLabel.AutoSize = true;
            this.satRestulLostLabel.Location = new System.Drawing.Point(548, 84);
            this.satRestulLostLabel.Name = "satRestulLostLabel";
            this.satRestulLostLabel.Size = new System.Drawing.Size(13, 13);
            this.satRestulLostLabel.TabIndex = 49;
            this.satRestulLostLabel.Text = "--";
            // 
            // satRestulDownloadedLabel
            // 
            this.satRestulDownloadedLabel.AutoSize = true;
            this.satRestulDownloadedLabel.Location = new System.Drawing.Point(548, 62);
            this.satRestulDownloadedLabel.Name = "satRestulDownloadedLabel";
            this.satRestulDownloadedLabel.Size = new System.Drawing.Size(13, 13);
            this.satRestulDownloadedLabel.TabIndex = 48;
            this.satRestulDownloadedLabel.Text = "--";
            // 
            // satRestulMaxGenDataLabel
            // 
            this.satRestulMaxGenDataLabel.AutoSize = true;
            this.satRestulMaxGenDataLabel.Location = new System.Drawing.Point(548, 39);
            this.satRestulMaxGenDataLabel.Name = "satRestulMaxGenDataLabel";
            this.satRestulMaxGenDataLabel.Size = new System.Drawing.Size(13, 13);
            this.satRestulMaxGenDataLabel.TabIndex = 47;
            this.satRestulMaxGenDataLabel.Text = "--";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(400, 81);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(56, 13);
            this.label58.TabIndex = 44;
            this.label58.Text = "Lost Data:";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(400, 59);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(96, 13);
            this.label59.TabIndex = 43;
            this.label59.Text = "Downloaded Data:";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(400, 36);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(106, 13);
            this.label60.TabIndex = 42;
            this.label60.Text = "Max Generated Data";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(395, 12);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(98, 13);
            this.label61.TabIndex = 41;
            this.label61.Text = "Data max capacity:";
            // 
            // satRestulDurationLabel
            // 
            this.satRestulDurationLabel.AutoSize = true;
            this.satRestulDurationLabel.Location = new System.Drawing.Point(216, 82);
            this.satRestulDurationLabel.Name = "satRestulDurationLabel";
            this.satRestulDurationLabel.Size = new System.Drawing.Size(13, 13);
            this.satRestulDurationLabel.TabIndex = 28;
            this.satRestulDurationLabel.Text = "--";
            // 
            // satRestultSchedContactsLabel
            // 
            this.satRestultSchedContactsLabel.AutoSize = true;
            this.satRestultSchedContactsLabel.Location = new System.Drawing.Point(216, 59);
            this.satRestultSchedContactsLabel.Name = "satRestultSchedContactsLabel";
            this.satRestultSchedContactsLabel.Size = new System.Drawing.Size(13, 13);
            this.satRestultSchedContactsLabel.TabIndex = 25;
            this.satRestultSchedContactsLabel.Text = "--";
            // 
            // satResultContactsLabel
            // 
            this.satResultContactsLabel.AutoSize = true;
            this.satResultContactsLabel.Location = new System.Drawing.Point(216, 37);
            this.satResultContactsLabel.Name = "satResultContactsLabel";
            this.satResultContactsLabel.Size = new System.Drawing.Size(13, 13);
            this.satResultContactsLabel.TabIndex = 24;
            this.satResultContactsLabel.Text = "--";
            // 
            // satResultNameLabel
            // 
            this.satResultNameLabel.AutoSize = true;
            this.satResultNameLabel.Location = new System.Drawing.Point(216, 12);
            this.satResultNameLabel.Name = "satResultNameLabel";
            this.satResultNameLabel.Size = new System.Drawing.Size(13, 13);
            this.satResultNameLabel.TabIndex = 17;
            this.satResultNameLabel.Text = "--";
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Location = new System.Drawing.Point(15, 85);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(107, 13);
            this.label74.TabIndex = 6;
            this.label74.Text = "Duration of Contacts:";
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.Location = new System.Drawing.Point(15, 12);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(44, 13);
            this.label76.TabIndex = 5;
            this.label76.Text = "Satellite";
            this.label76.Click += new System.EventHandler(this.label76_Click);
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.Location = new System.Drawing.Point(15, 59);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(158, 13);
            this.label84.TabIndex = 1;
            this.label84.Text = "Number of Scheduled Contacts:";
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.Location = new System.Drawing.Point(15, 37);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(104, 13);
            this.label85.TabIndex = 0;
            this.label85.Text = "Number of Contacts:";
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.resultSeletNameLabel);
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(770, 29);
            this.panel5.TabIndex = 1;
            // 
            // resultSeletNameLabel
            // 
            this.resultSeletNameLabel.AutoSize = true;
            this.resultSeletNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultSeletNameLabel.Location = new System.Drawing.Point(4, 1);
            this.resultSeletNameLabel.Name = "resultSeletNameLabel";
            this.resultSeletNameLabel.Size = new System.Drawing.Size(91, 25);
            this.resultSeletNameLabel.TabIndex = 0;
            this.resultSeletNameLabel.Text = "Results";
            // 
            // stationResultPanel
            // 
            this.stationResultPanel.Controls.Add(this.stationResultIdleLabel);
            this.stationResultPanel.Controls.Add(this.label70);
            this.stationResultPanel.Controls.Add(this.stationResultMaxDowLabel);
            this.stationResultPanel.Controls.Add(this.stationResultAverageDownLabel);
            this.stationResultPanel.Controls.Add(this.stationResultDownloadLabel);
            this.stationResultPanel.Controls.Add(this.label75);
            this.stationResultPanel.Controls.Add(this.label77);
            this.stationResultPanel.Controls.Add(this.label78);
            this.stationResultPanel.Controls.Add(this.label83);
            this.stationResultPanel.Controls.Add(this.stationResultDurationLabel);
            this.stationResultPanel.Controls.Add(this.stationResultScheduledContactsLAbel);
            this.stationResultPanel.Controls.Add(this.stationResultContactsLabel);
            this.stationResultPanel.Controls.Add(this.stationResultHeightLabel);
            this.stationResultPanel.Controls.Add(this.stationResultLongLabel);
            this.stationResultPanel.Controls.Add(this.stationResultLatLabel);
            this.stationResultPanel.Controls.Add(this.stationResultNameLabel);
            this.stationResultPanel.Controls.Add(this.label79);
            this.stationResultPanel.Controls.Add(this.label80);
            this.stationResultPanel.Controls.Add(this.label81);
            this.stationResultPanel.Controls.Add(this.label82);
            this.stationResultPanel.Controls.Add(this.label87);
            this.stationResultPanel.Controls.Add(this.label88);
            this.stationResultPanel.Controls.Add(this.label92);
            this.stationResultPanel.Controls.Add(this.label93);
            this.stationResultPanel.Location = new System.Drawing.Point(8, 37);
            this.stationResultPanel.Name = "stationResultPanel";
            this.stationResultPanel.Size = new System.Drawing.Size(767, 541);
            this.stationResultPanel.TabIndex = 2;
            // 
            // stationResultIdleLabel
            // 
            this.stationResultIdleLabel.AutoSize = true;
            this.stationResultIdleLabel.Location = new System.Drawing.Point(558, 56);
            this.stationResultIdleLabel.Name = "stationResultIdleLabel";
            this.stationResultIdleLabel.Size = new System.Drawing.Size(13, 13);
            this.stationResultIdleLabel.TabIndex = 52;
            this.stationResultIdleLabel.Text = "--";
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(400, 56);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(53, 13);
            this.label70.TabIndex = 51;
            this.label70.Text = "Time Idle:";
            // 
            // stationResultMaxDowLabel
            // 
            this.stationResultMaxDowLabel.AutoSize = true;
            this.stationResultMaxDowLabel.Location = new System.Drawing.Point(555, 161);
            this.stationResultMaxDowLabel.Name = "stationResultMaxDowLabel";
            this.stationResultMaxDowLabel.Size = new System.Drawing.Size(13, 13);
            this.stationResultMaxDowLabel.TabIndex = 49;
            this.stationResultMaxDowLabel.Text = "--";
            // 
            // stationResultAverageDownLabel
            // 
            this.stationResultAverageDownLabel.AutoSize = true;
            this.stationResultAverageDownLabel.Location = new System.Drawing.Point(555, 139);
            this.stationResultAverageDownLabel.Name = "stationResultAverageDownLabel";
            this.stationResultAverageDownLabel.Size = new System.Drawing.Size(13, 13);
            this.stationResultAverageDownLabel.TabIndex = 48;
            this.stationResultAverageDownLabel.Text = "--";
            // 
            // stationResultDownloadLabel
            // 
            this.stationResultDownloadLabel.AutoSize = true;
            this.stationResultDownloadLabel.Location = new System.Drawing.Point(555, 116);
            this.stationResultDownloadLabel.Name = "stationResultDownloadLabel";
            this.stationResultDownloadLabel.Size = new System.Drawing.Size(13, 13);
            this.stationResultDownloadLabel.TabIndex = 47;
            this.stationResultDownloadLabel.Text = "--";
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Location = new System.Drawing.Point(406, 161);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(75, 13);
            this.label75.TabIndex = 44;
            this.label75.Text = "Max downlink:";
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.Location = new System.Drawing.Point(406, 139);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(116, 13);
            this.label77.TabIndex = 43;
            this.label77.Text = "Average downlink rate:";
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.Location = new System.Drawing.Point(406, 116);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(96, 13);
            this.label78.TabIndex = 42;
            this.label78.Text = "Downloaded Data:";
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.Location = new System.Drawing.Point(397, 94);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(33, 13);
            this.label83.TabIndex = 41;
            this.label83.Text = "Data:";
            // 
            // stationResultDurationLabel
            // 
            this.stationResultDurationLabel.AutoSize = true;
            this.stationResultDurationLabel.Location = new System.Drawing.Point(558, 34);
            this.stationResultDurationLabel.Name = "stationResultDurationLabel";
            this.stationResultDurationLabel.Size = new System.Drawing.Size(13, 13);
            this.stationResultDurationLabel.TabIndex = 28;
            this.stationResultDurationLabel.Text = "--";
            // 
            // stationResultScheduledContactsLAbel
            // 
            this.stationResultScheduledContactsLAbel.AutoSize = true;
            this.stationResultScheduledContactsLAbel.Location = new System.Drawing.Point(219, 182);
            this.stationResultScheduledContactsLAbel.Name = "stationResultScheduledContactsLAbel";
            this.stationResultScheduledContactsLAbel.Size = new System.Drawing.Size(13, 13);
            this.stationResultScheduledContactsLAbel.TabIndex = 25;
            this.stationResultScheduledContactsLAbel.Text = "--";
            // 
            // stationResultContactsLabel
            // 
            this.stationResultContactsLabel.AutoSize = true;
            this.stationResultContactsLabel.Location = new System.Drawing.Point(219, 160);
            this.stationResultContactsLabel.Name = "stationResultContactsLabel";
            this.stationResultContactsLabel.Size = new System.Drawing.Size(13, 13);
            this.stationResultContactsLabel.TabIndex = 24;
            this.stationResultContactsLabel.Text = "--";
            // 
            // stationResultHeightLabel
            // 
            this.stationResultHeightLabel.AutoSize = true;
            this.stationResultHeightLabel.Location = new System.Drawing.Point(216, 100);
            this.stationResultHeightLabel.Name = "stationResultHeightLabel";
            this.stationResultHeightLabel.Size = new System.Drawing.Size(13, 13);
            this.stationResultHeightLabel.TabIndex = 21;
            this.stationResultHeightLabel.Text = "--";
            // 
            // stationResultLongLabel
            // 
            this.stationResultLongLabel.AutoSize = true;
            this.stationResultLongLabel.Location = new System.Drawing.Point(216, 79);
            this.stationResultLongLabel.Name = "stationResultLongLabel";
            this.stationResultLongLabel.Size = new System.Drawing.Size(13, 13);
            this.stationResultLongLabel.TabIndex = 20;
            this.stationResultLongLabel.Text = "--";
            // 
            // stationResultLatLabel
            // 
            this.stationResultLatLabel.AutoSize = true;
            this.stationResultLatLabel.Location = new System.Drawing.Point(216, 57);
            this.stationResultLatLabel.Name = "stationResultLatLabel";
            this.stationResultLatLabel.Size = new System.Drawing.Size(13, 13);
            this.stationResultLatLabel.TabIndex = 19;
            this.stationResultLatLabel.Text = "--";
            // 
            // stationResultNameLabel
            // 
            this.stationResultNameLabel.AutoSize = true;
            this.stationResultNameLabel.Location = new System.Drawing.Point(216, 12);
            this.stationResultNameLabel.Name = "stationResultNameLabel";
            this.stationResultNameLabel.Size = new System.Drawing.Size(13, 13);
            this.stationResultNameLabel.TabIndex = 17;
            this.stationResultNameLabel.Text = "--";
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.Location = new System.Drawing.Point(40, 100);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(41, 13);
            this.label79.TabIndex = 14;
            this.label79.Text = "Height:";
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.Location = new System.Drawing.Point(39, 79);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(57, 13);
            this.label80.TabIndex = 13;
            this.label80.Text = "Longitude:";
            // 
            // label81
            // 
            this.label81.AutoSize = true;
            this.label81.Location = new System.Drawing.Point(40, 57);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(48, 13);
            this.label81.TabIndex = 12;
            this.label81.Text = "Latitude:";
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.Location = new System.Drawing.Point(24, 34);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(51, 13);
            this.label82.TabIndex = 11;
            this.label82.Text = "Location:";
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.Location = new System.Drawing.Point(400, 34);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(107, 13);
            this.label87.TabIndex = 6;
            this.label87.Text = "Duration of Contacts:";
            // 
            // label88
            // 
            this.label88.AutoSize = true;
            this.label88.Location = new System.Drawing.Point(15, 12);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(81, 13);
            this.label88.TabIndex = 5;
            this.label88.Text = "Ground Station:";
            // 
            // label92
            // 
            this.label92.AutoSize = true;
            this.label92.Location = new System.Drawing.Point(18, 182);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(158, 13);
            this.label92.TabIndex = 1;
            this.label92.Text = "Number of Scheduled Contacts:";
            // 
            // label93
            // 
            this.label93.AutoSize = true;
            this.label93.Location = new System.Drawing.Point(18, 160);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(104, 13);
            this.label93.TabIndex = 0;
            this.label93.Text = "Number of Contacts:";
            // 
            // OverallResultPanel
            // 
            this.OverallResultPanel.Controls.Add(this.resultAverageDownLabel);
            this.OverallResultPanel.Controls.Add(this.resultDataLostLabel);
            this.OverallResultPanel.Controls.Add(this.resultDownloadLabel);
            this.OverallResultPanel.Controls.Add(this.resultGeneratedDataLabel);
            this.OverallResultPanel.Controls.Add(this.label45);
            this.OverallResultPanel.Controls.Add(this.label44);
            this.OverallResultPanel.Controls.Add(this.label43);
            this.OverallResultPanel.Controls.Add(this.label42);
            this.OverallResultPanel.Controls.Add(this.resultsGenerationsLabel);
            this.OverallResultPanel.Controls.Add(resultsTimeSumLabel);
            this.OverallResultPanel.Controls.Add(this.resultSchedulingTimeLabel);
            this.OverallResultPanel.Controls.Add(this.resultTimeContactsLabel);
            this.OverallResultPanel.Controls.Add(this.resultCollisionLabel);
            this.OverallResultPanel.Controls.Add(this.resultScheduledContactsLabel);
            this.OverallResultPanel.Controls.Add(this.resultValidContactsLabel);
            this.OverallResultPanel.Controls.Add(this.resultNrStationLabel);
            this.OverallResultPanel.Controls.Add(this.resultNrSatellitesLabel);
            this.OverallResultPanel.Controls.Add(this.resultFitnessContactsValue);
            this.OverallResultPanel.Controls.Add(this.resultFitnessDurationLabel);
            this.OverallResultPanel.Controls.Add(this.resultDataFitnessLabel);
            this.OverallResultPanel.Controls.Add(this.resultFitnessSatelliteLabel);
            this.OverallResultPanel.Controls.Add(this.resultFitnesStationLabel);
            this.OverallResultPanel.Controls.Add(this.resultFairnessLabel);
            this.OverallResultPanel.Controls.Add(this.resultFitnessLabel);
            this.OverallResultPanel.Controls.Add(this.label40);
            this.OverallResultPanel.Controls.Add(this.label39);
            this.OverallResultPanel.Controls.Add(this.label37);
            this.OverallResultPanel.Controls.Add(this.label36);
            this.OverallResultPanel.Controls.Add(this.label35);
            this.OverallResultPanel.Controls.Add(this.label30);
            this.OverallResultPanel.Controls.Add(this.label29);
            this.OverallResultPanel.Controls.Add(this.label28);
            this.OverallResultPanel.Controls.Add(this.label27);
            this.OverallResultPanel.Controls.Add(this.label26);
            this.OverallResultPanel.Controls.Add(this.label25);
            this.OverallResultPanel.Controls.Add(this.label24);
            this.OverallResultPanel.Controls.Add(this.label23);
            this.OverallResultPanel.Controls.Add(this.label22);
            this.OverallResultPanel.Controls.Add(this.label20);
            this.OverallResultPanel.Controls.Add(this.label11);
            this.OverallResultPanel.Controls.Add(this.label8);
            this.OverallResultPanel.Location = new System.Drawing.Point(12, 38);
            this.OverallResultPanel.Name = "OverallResultPanel";
            this.OverallResultPanel.Size = new System.Drawing.Size(773, 524);
            this.OverallResultPanel.TabIndex = 0;
            // 
            // resultAverageDownLabel
            // 
            this.resultAverageDownLabel.AutoSize = true;
            this.resultAverageDownLabel.Location = new System.Drawing.Point(640, 100);
            this.resultAverageDownLabel.Name = "resultAverageDownLabel";
            this.resultAverageDownLabel.Size = new System.Drawing.Size(13, 13);
            this.resultAverageDownLabel.TabIndex = 40;
            this.resultAverageDownLabel.Text = "--";
            // 
            // resultDataLostLabel
            // 
            this.resultDataLostLabel.AutoSize = true;
            this.resultDataLostLabel.Location = new System.Drawing.Point(640, 79);
            this.resultDataLostLabel.Name = "resultDataLostLabel";
            this.resultDataLostLabel.Size = new System.Drawing.Size(13, 13);
            this.resultDataLostLabel.TabIndex = 39;
            this.resultDataLostLabel.Text = "--";
            // 
            // resultDownloadLabel
            // 
            this.resultDownloadLabel.AutoSize = true;
            this.resultDownloadLabel.Location = new System.Drawing.Point(640, 57);
            this.resultDownloadLabel.Name = "resultDownloadLabel";
            this.resultDownloadLabel.Size = new System.Drawing.Size(13, 13);
            this.resultDownloadLabel.TabIndex = 38;
            this.resultDownloadLabel.Text = "--";
            // 
            // resultGeneratedDataLabel
            // 
            this.resultGeneratedDataLabel.AutoSize = true;
            this.resultGeneratedDataLabel.Location = new System.Drawing.Point(640, 34);
            this.resultGeneratedDataLabel.Name = "resultGeneratedDataLabel";
            this.resultGeneratedDataLabel.Size = new System.Drawing.Size(13, 13);
            this.resultGeneratedDataLabel.TabIndex = 37;
            this.resultGeneratedDataLabel.Text = "--";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(452, 79);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(52, 13);
            this.label45.TabIndex = 36;
            this.label45.Text = "Data lost:";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(452, 102);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(116, 13);
            this.label44.TabIndex = 35;
            this.label44.Text = "Average downlink rate:";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(452, 57);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(96, 13);
            this.label43.TabIndex = 34;
            this.label43.Text = "Downloaded Data:";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(452, 34);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(86, 13);
            this.label42.TabIndex = 33;
            this.label42.Text = "Generated Data:";
            // 
            // resultsGenerationsLabel
            // 
            this.resultsGenerationsLabel.AutoSize = true;
            this.resultsGenerationsLabel.Location = new System.Drawing.Point(260, 451);
            this.resultsGenerationsLabel.Name = "resultsGenerationsLabel";
            this.resultsGenerationsLabel.Size = new System.Drawing.Size(13, 13);
            this.resultsGenerationsLabel.TabIndex = 32;
            this.resultsGenerationsLabel.Text = "--";
            // 
            // resultSchedulingTimeLabel
            // 
            this.resultSchedulingTimeLabel.AutoSize = true;
            this.resultSchedulingTimeLabel.Location = new System.Drawing.Point(260, 384);
            this.resultSchedulingTimeLabel.Name = "resultSchedulingTimeLabel";
            this.resultSchedulingTimeLabel.Size = new System.Drawing.Size(13, 13);
            this.resultSchedulingTimeLabel.TabIndex = 30;
            this.resultSchedulingTimeLabel.Text = "--";
            // 
            // resultTimeContactsLabel
            // 
            this.resultTimeContactsLabel.AutoSize = true;
            this.resultTimeContactsLabel.Location = new System.Drawing.Point(260, 355);
            this.resultTimeContactsLabel.Name = "resultTimeContactsLabel";
            this.resultTimeContactsLabel.Size = new System.Drawing.Size(13, 13);
            this.resultTimeContactsLabel.TabIndex = 29;
            this.resultTimeContactsLabel.Text = "--";
            // 
            // resultCollisionLabel
            // 
            this.resultCollisionLabel.AutoSize = true;
            this.resultCollisionLabel.Location = new System.Drawing.Point(260, 282);
            this.resultCollisionLabel.Name = "resultCollisionLabel";
            this.resultCollisionLabel.Size = new System.Drawing.Size(13, 13);
            this.resultCollisionLabel.TabIndex = 28;
            this.resultCollisionLabel.Text = "--";
            // 
            // resultScheduledContactsLabel
            // 
            this.resultScheduledContactsLabel.AutoSize = true;
            this.resultScheduledContactsLabel.Location = new System.Drawing.Point(260, 259);
            this.resultScheduledContactsLabel.Name = "resultScheduledContactsLabel";
            this.resultScheduledContactsLabel.Size = new System.Drawing.Size(13, 13);
            this.resultScheduledContactsLabel.TabIndex = 27;
            this.resultScheduledContactsLabel.Text = "--";
            // 
            // resultValidContactsLabel
            // 
            this.resultValidContactsLabel.AutoSize = true;
            this.resultValidContactsLabel.Location = new System.Drawing.Point(260, 237);
            this.resultValidContactsLabel.Name = "resultValidContactsLabel";
            this.resultValidContactsLabel.Size = new System.Drawing.Size(13, 13);
            this.resultValidContactsLabel.TabIndex = 26;
            this.resultValidContactsLabel.Text = "--";
            // 
            // resultNrStationLabel
            // 
            this.resultNrStationLabel.AutoSize = true;
            this.resultNrStationLabel.Location = new System.Drawing.Point(260, 214);
            this.resultNrStationLabel.Name = "resultNrStationLabel";
            this.resultNrStationLabel.Size = new System.Drawing.Size(13, 13);
            this.resultNrStationLabel.TabIndex = 25;
            this.resultNrStationLabel.Text = "--";
            // 
            // resultNrSatellitesLabel
            // 
            this.resultNrSatellitesLabel.AutoSize = true;
            this.resultNrSatellitesLabel.Location = new System.Drawing.Point(260, 192);
            this.resultNrSatellitesLabel.Name = "resultNrSatellitesLabel";
            this.resultNrSatellitesLabel.Size = new System.Drawing.Size(13, 13);
            this.resultNrSatellitesLabel.TabIndex = 24;
            this.resultNrSatellitesLabel.Text = "--";
            // 
            // resultFitnessContactsValue
            // 
            this.resultFitnessContactsValue.AutoSize = true;
            this.resultFitnessContactsValue.Location = new System.Drawing.Point(260, 142);
            this.resultFitnessContactsValue.Name = "resultFitnessContactsValue";
            this.resultFitnessContactsValue.Size = new System.Drawing.Size(13, 13);
            this.resultFitnessContactsValue.TabIndex = 23;
            this.resultFitnessContactsValue.Text = "--";
            // 
            // resultFitnessDurationLabel
            // 
            this.resultFitnessDurationLabel.AutoSize = true;
            this.resultFitnessDurationLabel.Location = new System.Drawing.Point(260, 122);
            this.resultFitnessDurationLabel.Name = "resultFitnessDurationLabel";
            this.resultFitnessDurationLabel.Size = new System.Drawing.Size(13, 13);
            this.resultFitnessDurationLabel.TabIndex = 22;
            this.resultFitnessDurationLabel.Text = "--";
            // 
            // resultDataFitnessLabel
            // 
            this.resultDataFitnessLabel.AutoSize = true;
            this.resultDataFitnessLabel.Location = new System.Drawing.Point(260, 100);
            this.resultDataFitnessLabel.Name = "resultDataFitnessLabel";
            this.resultDataFitnessLabel.Size = new System.Drawing.Size(13, 13);
            this.resultDataFitnessLabel.TabIndex = 21;
            this.resultDataFitnessLabel.Text = "--";
            // 
            // resultFitnessSatelliteLabel
            // 
            this.resultFitnessSatelliteLabel.AutoSize = true;
            this.resultFitnessSatelliteLabel.Location = new System.Drawing.Point(260, 79);
            this.resultFitnessSatelliteLabel.Name = "resultFitnessSatelliteLabel";
            this.resultFitnessSatelliteLabel.Size = new System.Drawing.Size(13, 13);
            this.resultFitnessSatelliteLabel.TabIndex = 20;
            this.resultFitnessSatelliteLabel.Text = "--";
            // 
            // resultFitnesStationLabel
            // 
            this.resultFitnesStationLabel.AutoSize = true;
            this.resultFitnesStationLabel.Location = new System.Drawing.Point(260, 57);
            this.resultFitnesStationLabel.Name = "resultFitnesStationLabel";
            this.resultFitnesStationLabel.Size = new System.Drawing.Size(13, 13);
            this.resultFitnesStationLabel.TabIndex = 19;
            this.resultFitnesStationLabel.Text = "--";
            // 
            // resultFairnessLabel
            // 
            this.resultFairnessLabel.AutoSize = true;
            this.resultFairnessLabel.Location = new System.Drawing.Point(260, 34);
            this.resultFairnessLabel.Name = "resultFairnessLabel";
            this.resultFairnessLabel.Size = new System.Drawing.Size(13, 13);
            this.resultFairnessLabel.TabIndex = 18;
            this.resultFairnessLabel.Text = "--";
            // 
            // resultFitnessLabel
            // 
            this.resultFitnessLabel.AutoSize = true;
            this.resultFitnessLabel.Location = new System.Drawing.Point(260, 12);
            this.resultFitnessLabel.Name = "resultFitnessLabel";
            this.resultFitnessLabel.Size = new System.Drawing.Size(13, 13);
            this.resultFitnessLabel.TabIndex = 17;
            this.resultFitnessLabel.Text = "--";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(24, 147);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(82, 13);
            this.label40.TabIndex = 16;
            this.label40.Text = "Contacts Value:";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(24, 124);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(80, 13);
            this.label39.TabIndex = 15;
            this.label39.Text = "Duration Value:";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(24, 102);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(63, 13);
            this.label37.TabIndex = 14;
            this.label37.Text = "Data Value:";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(39, 79);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(67, 13);
            this.label36.TabIndex = 13;
            this.label36.Text = "for Satellites:";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(40, 57);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(96, 13);
            this.label35.TabIndex = 12;
            this.label35.Text = "for Groundstations:";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(24, 34);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(79, 13);
            this.label30.TabIndex = 11;
            this.label30.Text = "Fairness Value:";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(15, 410);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(49, 13);
            this.label29.TabIndex = 10;
            this.label29.Text = "    - Sum:";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(15, 384);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(81, 13);
            this.label28.TabIndex = 9;
            this.label28.Text = "    - Scheduling:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(15, 355);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(70, 13);
            this.label27.TabIndex = 8;
            this.label27.Text = "    - Contacts:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(15, 332);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(88, 13);
            this.label26.TabIndex = 7;
            this.label26.Text = "Calculation Time:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(15, 282);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(153, 13);
            this.label25.TabIndex = 6;
            this.label25.Text = "Number of Collisons in solution:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(15, 12);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(141, 13);
            this.label24.TabIndex = 5;
            this.label24.Text = "Fitness value of the solution:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(6, 451);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(113, 13);
            this.label23.TabIndex = 4;
            this.label23.Text = "Generations (Genetic):";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(15, 259);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(158, 13);
            this.label22.TabIndex = 3;
            this.label22.Text = "Number of Scheduled Contacts:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(15, 237);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(129, 13);
            this.label20.TabIndex = 2;
            this.label20.Text = "Number of valid Contacts:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 214);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(133, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Number of Groundstations:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 192);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Number of Satellites:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label50);
            this.tabPage3.Controls.Add(this.panel4);
            this.tabPage3.Controls.Add(this.panel3);
            this.tabPage3.Controls.Add(this.pictureBox4);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(994, 587);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Satellites";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.BackColor = System.Drawing.Color.Transparent;
            this.label50.Location = new System.Drawing.Point(848, 571);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(143, 13);
            this.label50.TabIndex = 6;
            this.label50.Text = "Image: NASA/ NOAA NGDC";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.onBoardStoargeSizeText);
            this.panel4.Controls.Add(this.satelliteStorageUpdateButton);
            this.panel4.Controls.Add(this.comboBoxSatelliteStorage);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.panel10);
            this.panel4.Controls.Add(this.SatLabel5);
            this.panel4.Controls.Add(this.SatLabel4);
            this.panel4.Controls.Add(this.SatLabel3);
            this.panel4.Controls.Add(this.SatLabel2);
            this.panel4.Controls.Add(this.SatLabel1);
            this.panel4.Controls.Add(this.label49);
            this.panel4.Controls.Add(this.label15);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.label14);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.satelliteNameLabel);
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(997, 172);
            this.panel4.TabIndex = 2;
            // 
            // onBoardStoargeSizeText
            // 
            this.onBoardStoargeSizeText.Increment = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.onBoardStoargeSizeText.Location = new System.Drawing.Point(681, 41);
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
            this.onBoardStoargeSizeText.TabIndex = 23;
            this.onBoardStoargeSizeText.Value = new decimal(new int[] {
            512,
            0,
            0,
            0});
            // 
            // satelliteStorageUpdateButton
            // 
            this.satelliteStorageUpdateButton.Location = new System.Drawing.Point(913, 142);
            this.satelliteStorageUpdateButton.Name = "satelliteStorageUpdateButton";
            this.satelliteStorageUpdateButton.Size = new System.Drawing.Size(70, 23);
            this.satelliteStorageUpdateButton.TabIndex = 22;
            this.satelliteStorageUpdateButton.Text = "Update";
            this.satelliteStorageUpdateButton.UseVisualStyleBackColor = true;
            this.satelliteStorageUpdateButton.Click += new System.EventHandler(this.satelliteStorageUpdateButton_Click);
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
            this.comboBoxSatelliteStorage.Location = new System.Drawing.Point(759, 41);
            this.comboBoxSatelliteStorage.Name = "comboBoxSatelliteStorage";
            this.comboBoxSatelliteStorage.Size = new System.Drawing.Size(118, 21);
            this.comboBoxSatelliteStorage.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(586, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Onboard storage:";
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel10.Location = new System.Drawing.Point(546, 43);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(5, 115);
            this.panel10.TabIndex = 18;
            // 
            // SatLabel5
            // 
            this.SatLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SatLabel5.Location = new System.Drawing.Point(392, 124);
            this.SatLabel5.Name = "SatLabel5";
            this.SatLabel5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SatLabel5.Size = new System.Drawing.Size(148, 18);
            this.SatLabel5.TabIndex = 17;
            this.SatLabel5.Text = "SatText1";
            this.SatLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SatLabel4
            // 
            this.SatLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SatLabel4.Location = new System.Drawing.Point(392, 102);
            this.SatLabel4.Name = "SatLabel4";
            this.SatLabel4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SatLabel4.Size = new System.Drawing.Size(148, 18);
            this.SatLabel4.TabIndex = 16;
            this.SatLabel4.Text = "SatText1";
            this.SatLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SatLabel3
            // 
            this.SatLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SatLabel3.Location = new System.Drawing.Point(392, 79);
            this.SatLabel3.Name = "SatLabel3";
            this.SatLabel3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SatLabel3.Size = new System.Drawing.Size(148, 18);
            this.SatLabel3.TabIndex = 15;
            this.SatLabel3.Text = "SatText1";
            this.SatLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SatLabel2
            // 
            this.SatLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SatLabel2.Location = new System.Drawing.Point(389, 57);
            this.SatLabel2.Name = "SatLabel2";
            this.SatLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SatLabel2.Size = new System.Drawing.Size(151, 18);
            this.SatLabel2.TabIndex = 14;
            this.SatLabel2.Text = "SatText1";
            this.SatLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SatLabel1
            // 
            this.SatLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SatLabel1.Location = new System.Drawing.Point(389, 39);
            this.SatLabel1.Name = "SatLabel1";
            this.SatLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SatLabel1.Size = new System.Drawing.Size(151, 18);
            this.SatLabel1.TabIndex = 13;
            this.SatLabel1.Text = "SatText1";
            this.SatLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(301, 133);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(65, 13);
            this.label49.TabIndex = 12;
            this.label49.Text = "Element Nr.:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(301, 111);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(71, 13);
            this.label15.TabIndex = 7;
            this.label15.Text = "Classification:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(301, 88);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 13);
            this.label13.TabIndex = 6;
            this.label13.Text = "Norad ID:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(301, 64);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(86, 13);
            this.label14.TabIndex = 5;
            this.label14.Text = "Launch Number:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(301, 44);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "Launch Year:";
            // 
            // satelliteNameLabel
            // 
            this.satelliteNameLabel.AutoSize = true;
            this.satelliteNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.satelliteNameLabel.Location = new System.Drawing.Point(298, 12);
            this.satelliteNameLabel.Name = "satelliteNameLabel";
            this.satelliteNameLabel.Size = new System.Drawing.Size(93, 20);
            this.satelliteNameLabel.TabIndex = 2;
            this.satelliteNameLabel.Text = "Sat. Name";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.LightGray;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.ErrorImage = global::MARRSS.Properties.Resources.uwe3;
            this.pictureBox1.Image = global::MARRSS.Properties.Resources.uwe3;
            this.pictureBox1.Location = new System.Drawing.Point(48, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(182, 153);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel3.Controls.Add(this.satelliteDataGrid);
            this.panel3.Location = new System.Drawing.Point(6, 182);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(289, 402);
            this.panel3.TabIndex = 1;
            // 
            // satelliteDataGrid
            // 
            this.satelliteDataGrid.AllowUserToAddRows = false;
            this.satelliteDataGrid.AllowUserToDeleteRows = false;
            this.satelliteDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.satelliteDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Satellite,
            this.NoradID});
            this.satelliteDataGrid.ContextMenuStrip = this.contextSatDb;
            this.satelliteDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.satelliteDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.satelliteDataGrid.Location = new System.Drawing.Point(0, 0);
            this.satelliteDataGrid.MultiSelect = false;
            this.satelliteDataGrid.Name = "satelliteDataGrid";
            this.satelliteDataGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.satelliteDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.satelliteDataGrid.Size = new System.Drawing.Size(289, 402);
            this.satelliteDataGrid.TabIndex = 0;
            this.satelliteDataGrid.SelectionChanged += new System.EventHandler(this.satelliteDataGrid_SelectionChanged);
            // 
            // Satellite
            // 
            this.Satellite.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Satellite.HeaderText = "Satellite";
            this.Satellite.Name = "Satellite";
            // 
            // NoradID
            // 
            this.NoradID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NoradID.HeaderText = "Norad-ID";
            this.NoradID.Name = "NoradID";
            // 
            // contextSatDb
            // 
            this.contextSatDb.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.toolStripMenuItem10});
            this.contextSatDb.Name = "contextSatDb";
            this.contextSatDb.Size = new System.Drawing.Size(155, 32);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(151, 6);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(154, 22);
            this.toolStripMenuItem10.Text = "Delete Selected";
            this.toolStripMenuItem10.Click += new System.EventHandler(this.toolStripMenuItem10_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::MARRSS.Properties.Resources.worldsmaller;
            this.pictureBox4.Location = new System.Drawing.Point(301, 182);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(691, 402);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label51);
            this.tabPage4.Controls.Add(this.panel6);
            this.tabPage4.Controls.Add(this.panel7);
            this.tabPage4.Controls.Add(this.pictureBox3);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(994, 587);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Stations";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.BackColor = System.Drawing.Color.Transparent;
            this.label51.Location = new System.Drawing.Point(843, 571);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(143, 13);
            this.label51.TabIndex = 5;
            this.label51.Text = "Image: NASA/ NOAA NGDC";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.MaxUpLinkText);
            this.panel6.Controls.Add(this.MaxDownTextBox);
            this.panel6.Controls.Add(this.UpdateStationButton);
            this.panel6.Controls.Add(this.UpDataSizeCombo);
            this.panel6.Controls.Add(this.DownDataSizeCombo);
            this.panel6.Controls.Add(this.label7);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Controls.Add(this.panel11);
            this.panel6.Controls.Add(this.label53);
            this.panel6.Controls.Add(this.label54);
            this.panel6.Controls.Add(this.label55);
            this.panel6.Controls.Add(this.label56);
            this.panel6.Controls.Add(this.label16);
            this.panel6.Controls.Add(this.label17);
            this.panel6.Controls.Add(this.label18);
            this.panel6.Controls.Add(this.label19);
            this.panel6.Controls.Add(this.StationNameLabel);
            this.panel6.Controls.Add(this.pictureBox5);
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(989, 172);
            this.panel6.TabIndex = 3;
            // 
            // MaxUpLinkText
            // 
            this.MaxUpLinkText.Location = new System.Drawing.Point(729, 74);
            this.MaxUpLinkText.Name = "MaxUpLinkText";
            this.MaxUpLinkText.Size = new System.Drawing.Size(55, 20);
            this.MaxUpLinkText.TabIndex = 30;
            this.MaxUpLinkText.Text = "0";
            // 
            // MaxDownTextBox
            // 
            this.MaxDownTextBox.Location = new System.Drawing.Point(729, 41);
            this.MaxDownTextBox.Name = "MaxDownTextBox";
            this.MaxDownTextBox.Size = new System.Drawing.Size(55, 20);
            this.MaxDownTextBox.TabIndex = 29;
            this.MaxDownTextBox.Text = "128.2";
            // 
            // UpdateStationButton
            // 
            this.UpdateStationButton.Location = new System.Drawing.Point(913, 142);
            this.UpdateStationButton.Name = "UpdateStationButton";
            this.UpdateStationButton.Size = new System.Drawing.Size(70, 23);
            this.UpdateStationButton.TabIndex = 23;
            this.UpdateStationButton.Text = "Update";
            this.UpdateStationButton.UseVisualStyleBackColor = true;
            this.UpdateStationButton.Click += new System.EventHandler(this.UpdateStationButton_Click);
            // 
            // UpDataSizeCombo
            // 
            this.UpDataSizeCombo.FormattingEnabled = true;
            this.UpDataSizeCombo.Items.AddRange(new object[] {
            "B      (Byte)",
            "kB    (kilo Byte)",
            "MB  (MegaByte)",
            "GB   (GigaByte)",
            "TB   (TerraByte)"});
            this.UpDataSizeCombo.Location = new System.Drawing.Point(802, 71);
            this.UpDataSizeCombo.Name = "UpDataSizeCombo";
            this.UpDataSizeCombo.Size = new System.Drawing.Size(95, 21);
            this.UpDataSizeCombo.TabIndex = 28;
            // 
            // DownDataSizeCombo
            // 
            this.DownDataSizeCombo.FormattingEnabled = true;
            this.DownDataSizeCombo.Items.AddRange(new object[] {
            "B      (Byte)",
            "kB    (kilo Byte)",
            "MB  (MegaByte)",
            "GB   (GigaByte)",
            "TB   (TerraByte)"});
            this.DownDataSizeCombo.Location = new System.Drawing.Point(802, 40);
            this.DownDataSizeCombo.Name = "DownDataSizeCombo";
            this.DownDataSizeCombo.Size = new System.Drawing.Size(95, 21);
            this.DownDataSizeCombo.TabIndex = 27;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(601, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Max UpLink";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(601, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Max DownLink";
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel11.Location = new System.Drawing.Point(546, 43);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(5, 115);
            this.panel11.TabIndex = 22;
            // 
            // label53
            // 
            this.label53.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label53.Location = new System.Drawing.Point(389, 110);
            this.label53.Name = "label53";
            this.label53.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label53.Size = new System.Drawing.Size(148, 18);
            this.label53.TabIndex = 21;
            this.label53.Text = "SatText1";
            this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label54
            // 
            this.label54.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label54.Location = new System.Drawing.Point(389, 86);
            this.label54.Name = "label54";
            this.label54.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label54.Size = new System.Drawing.Size(148, 18);
            this.label54.TabIndex = 20;
            this.label54.Text = "SatText1";
            this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label55
            // 
            this.label55.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label55.Location = new System.Drawing.Point(386, 65);
            this.label55.Name = "label55";
            this.label55.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label55.Size = new System.Drawing.Size(151, 18);
            this.label55.TabIndex = 19;
            this.label55.Text = "SatText1";
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label56
            // 
            this.label56.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label56.Location = new System.Drawing.Point(386, 43);
            this.label56.Name = "label56";
            this.label56.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label56.Size = new System.Drawing.Size(151, 18);
            this.label56.TabIndex = 18;
            this.label56.Text = "SatText1";
            this.label56.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(299, 111);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(81, 13);
            this.label16.TabIndex = 7;
            this.label16.Text = "Nr of Antennas:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(299, 89);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(41, 13);
            this.label17.TabIndex = 6;
            this.label17.Text = "Height:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(299, 65);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(52, 13);
            this.label18.TabIndex = 5;
            this.label18.Text = "Latetude:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(299, 42);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(54, 13);
            this.label19.TabIndex = 3;
            this.label19.Text = "Longitute:";
            // 
            // StationNameLabel
            // 
            this.StationNameLabel.AutoSize = true;
            this.StationNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StationNameLabel.Location = new System.Drawing.Point(298, 12);
            this.StationNameLabel.Name = "StationNameLabel";
            this.StationNameLabel.Size = new System.Drawing.Size(113, 20);
            this.StationNameLabel.TabIndex = 2;
            this.StationNameLabel.Text = "StationName";
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.LightGray;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox5.ErrorImage = global::MARRSS.Properties.Resources.uwe3;
            this.pictureBox5.Location = new System.Drawing.Point(48, 12);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(182, 153);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 0;
            this.pictureBox5.TabStop = false;
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel7.Controls.Add(this.staDataGridView);
            this.panel7.Location = new System.Drawing.Point(3, 182);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(289, 402);
            this.panel7.TabIndex = 4;
            // 
            // staDataGridView
            // 
            this.staDataGridView.AllowUserToAddRows = false;
            this.staDataGridView.AllowUserToDeleteRows = false;
            this.staDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.staDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.staDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.staDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Station});
            this.staDataGridView.ContextMenuStrip = this.contextStationDB;
            this.staDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.staDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.staDataGridView.Location = new System.Drawing.Point(0, 0);
            this.staDataGridView.MultiSelect = false;
            this.staDataGridView.Name = "staDataGridView";
            this.staDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.staDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.staDataGridView.Size = new System.Drawing.Size(289, 402);
            this.staDataGridView.TabIndex = 0;
            this.staDataGridView.SelectionChanged += new System.EventHandler(this.staDataGridView_SelectionChanged_1);
            // 
            // Station
            // 
            this.Station.HeaderText = "Station";
            this.Station.Name = "Station";
            this.Station.Width = 65;
            // 
            // contextStationDB
            // 
            this.contextStationDB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteSelectedToolStripMenuItem});
            this.contextStationDB.Name = "contextStationDB";
            this.contextStationDB.Size = new System.Drawing.Size(155, 26);
            // 
            // deleteSelectedToolStripMenuItem
            // 
            this.deleteSelectedToolStripMenuItem.Name = "deleteSelectedToolStripMenuItem";
            this.deleteSelectedToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.deleteSelectedToolStripMenuItem.Text = "Delete Selected";
            this.deleteSelectedToolStripMenuItem.Click += new System.EventHandler(this.deleteSelectedToolStripMenuItem_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::MARRSS.Properties.Resources.worldsmaller;
            this.pictureBox3.Location = new System.Drawing.Point(301, 182);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(691, 402);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipTitle = "Hint:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // satResultMaxDataLabel
            // 
            this.satResultMaxDataLabel.AutoSize = true;
            this.satResultMaxDataLabel.Location = new System.Drawing.Point(548, 12);
            this.satResultMaxDataLabel.Name = "satResultMaxDataLabel";
            this.satResultMaxDataLabel.Size = new System.Drawing.Size(13, 13);
            this.satResultMaxDataLabel.TabIndex = 58;
            this.satResultMaxDataLabel.Text = "--";
            // 
            // Main
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Application;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1174, 682);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groundPanel.ResumeLayout(false);
            this.groundPanel.PerformLayout();
            this.satellitePanel.ResumeLayout(false);
            this.satellitePanel.PerformLayout();
            this.schedulePanel.ResumeLayout(false);
            this.schedulePanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.logPanel.ResumeLayout(false);
            this.logPanel.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.schedulerGroupBox.ResumeLayout(false);
            this.schedulerGroupBox.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.contextSatellites.ResumeLayout(false);
            this.contextStations.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.satRestultPanel.ResumeLayout(false);
            this.satRestultPanel.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.stationResultPanel.ResumeLayout(false);
            this.stationResultPanel.PerformLayout();
            this.OverallResultPanel.ResumeLayout(false);
            this.OverallResultPanel.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.onBoardStoargeSizeText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.satelliteDataGrid)).EndInit();
            this.contextSatDb.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.staDataGridView)).EndInit();
            this.contextStationDB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dataiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel satellitePanel;
        private System.Windows.Forms.Label AddSatelliteButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel schedulePanel;
        private System.Windows.Forms.Label openScheduleButton;
        private System.Windows.Forms.Label newScheduleButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel groundPanel;
        private System.Windows.Forms.Label addStationButton;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem documentationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView satelliteDataGrid;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label satelliteNameLabel;
        private System.Windows.Forms.Label stopTimeLabel;
        private System.Windows.Forms.Label startTimeLabel;
        private System.Windows.Forms.DateTimePicker stopDatePicker;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button startScheduleButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.DataGridView staDataGridView;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label StationNameLabel;
        private System.Windows.Forms.DateTimePicker stopTimePicker;
        private System.Windows.Forms.DateTimePicker startTimePicker;
        private System.Windows.Forms.CheckedListBox checkedSatellites;
        private System.Windows.Forms.CheckedListBox checkedStations;
        private System.Windows.Forms.ContextMenuStrip contextSatellites;
        private System.Windows.Forms.ContextMenuStrip contextStations;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uncheckAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uncheckAllToolStripMenuItem1;
        private System.Windows.Forms.GroupBox schedulerGroupBox;
        private System.Windows.Forms.RadioButton radioGenetic;
        private System.Windows.Forms.RadioButton radioEFTGreedy;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripProgressBar progressBar1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label calcTimeLabel;
        private System.Windows.Forms.Label generationLabel;
        private System.Windows.Forms.Label contactNumberLabel;
        private System.Windows.Forms.Label collisionLabel;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label fairSatLabel;
        private System.Windows.Forms.Label stationFairLabel;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.RichTextBox logRichTextBox;
        private System.Windows.Forms.Label fitnessValueLabel;
        private System.Windows.Forms.Label fitnessLabel;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox comboScenarioBox;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label priorityLabel;
        private System.Windows.Forms.Label uweLabel;
        private System.Windows.Forms.Label SatLabel5;
        private System.Windows.Forms.Label SatLabel4;
        private System.Windows.Forms.Label SatLabel3;
        private System.Windows.Forms.Label SatLabel2;
        private System.Windows.Forms.Label SatLabel1;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.DataGridViewTextBoxColumn Satellite;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoradID;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.DataGridViewTextBoxColumn Station;
        private System.Windows.Forms.RadioButton radioGreedy;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label updateTleButton;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.ContextMenuStrip contextSatDb;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private System.Windows.Forms.ContextMenuStrip contextStationDB;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectedToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem1;
        private System.Windows.Forms.Panel logPanel;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem tLEDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateTLEsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
        private System.Windows.Forms.Label durationLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem12;
        private System.Windows.Forms.ToolStripMenuItem addGroundStationToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addSatelliteToolStripMenuItem1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox objectiveComboBox;
        private System.Windows.Forms.ToolStripMenuItem objectiveBuilderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem11;
        private System.Windows.Forms.ToolStripMenuItem runsToolStripMenuItem;
        private System.Windows.Forms.RadioButton radioHillClimber;
        private System.Windows.Forms.ToolStripMenuItem testingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formTestToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button satelliteStorageUpdateButton;
        private System.Windows.Forms.ComboBox comboBoxSatelliteStorage;
        private System.Windows.Forms.NumericUpDown onBoardStoargeSizeText;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private System.Windows.Forms.ToolStripMenuItem scenariosToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label datShedLabel;
        private System.Windows.Forms.ToolStripMenuItem loadDataScenarioToolStripMenuItem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button UpdateStationButton;
        private System.Windows.Forms.ComboBox UpDataSizeCombo;
        private System.Windows.Forms.ComboBox DownDataSizeCombo;
        private System.Windows.Forms.TextBox MaxUpLinkText;
        private System.Windows.Forms.TextBox MaxDownTextBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel OverallResultPanel;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label resultSeletNameLabel;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label resultAverageDownLabel;
        private System.Windows.Forms.Label resultDataLostLabel;
        private System.Windows.Forms.Label resultDownloadLabel;
        private System.Windows.Forms.Label resultGeneratedDataLabel;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label resultsGenerationsLabel;
        private System.Windows.Forms.Label resultSchedulingTimeLabel;
        private System.Windows.Forms.Label resultTimeContactsLabel;
        private System.Windows.Forms.Label resultCollisionLabel;
        private System.Windows.Forms.Label resultScheduledContactsLabel;
        private System.Windows.Forms.Label resultValidContactsLabel;
        private System.Windows.Forms.Label resultNrStationLabel;
        private System.Windows.Forms.Label resultNrSatellitesLabel;
        private System.Windows.Forms.Label resultFitnessContactsValue;
        private System.Windows.Forms.Label resultFitnessDurationLabel;
        private System.Windows.Forms.Label resultDataFitnessLabel;
        private System.Windows.Forms.Label resultFitnessSatelliteLabel;
        private System.Windows.Forms.Label resultFitnesStationLabel;
        private System.Windows.Forms.Label resultFairnessLabel;
        private System.Windows.Forms.Label resultFitnessLabel;
        private System.Windows.Forms.Panel stationResultPanel;
        private System.Windows.Forms.Label stationResultDurationLabel;
        private System.Windows.Forms.Label stationResultScheduledContactsLAbel;
        private System.Windows.Forms.Label stationResultContactsLabel;
        private System.Windows.Forms.Label stationResultHeightLabel;
        private System.Windows.Forms.Label stationResultLongLabel;
        private System.Windows.Forms.Label stationResultLatLabel;
        private System.Windows.Forms.Label stationResultNameLabel;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.Label label81;
        private System.Windows.Forms.Label label82;
        private System.Windows.Forms.Label label87;
        private System.Windows.Forms.Label label88;
        private System.Windows.Forms.Label label92;
        private System.Windows.Forms.Label label93;
        private System.Windows.Forms.Label stationResultIdleLabel;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Label stationResultMaxDowLabel;
        private System.Windows.Forms.Label stationResultAverageDownLabel;
        private System.Windows.Forms.Label stationResultDownloadLabel;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.Label label83;
        private System.Windows.Forms.Panel satRestultPanel;
        private PlotView plot1;
        private System.Windows.Forms.Label satResultAvDurationLabel;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label satRestulLostLabel;
        private System.Windows.Forms.Label satRestulDownloadedLabel;
        private System.Windows.Forms.Label satRestulMaxGenDataLabel;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.Label satRestulDurationLabel;
        private System.Windows.Forms.Label satRestultSchedContactsLabel;
        private System.Windows.Forms.Label satResultContactsLabel;
        private System.Windows.Forms.Label satResultNameLabel;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.Label label84;
        private System.Windows.Forms.Label label85;
        private System.Windows.Forms.Label satRestultAvgDownLabel;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label satResultMaxDataLabel;
    }
}