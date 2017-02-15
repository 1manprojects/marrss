namespace MARRSS.Forms
{
    partial class SettingsForm
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
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Logging");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("DataBase");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Global", new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12});
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Orbit");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("TLE-Data");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Genetic");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Greedy");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Hill-Climber");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("EFT(Earliest Finsish Time)");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Scheduler", new System.Windows.Forms.TreeNode[] {
            treeNode16,
            treeNode17,
            treeNode18,
            treeNode19});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.settingsTreeView = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.settingsLocationText = new System.Windows.Forms.Label();
            this.GeneticPanel = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.maxDurationRadioButton = new System.Windows.Forms.RadioButton();
            this.runMaxGenerationsRadioButton = new System.Windows.Forms.RadioButton();
            this.genMaxTime = new System.Windows.Forms.NumericUpDown();
            this.genMaxGen = new System.Windows.Forms.NumericUpDown();
            this.checkConflictHandling = new System.Windows.Forms.CheckBox();
            this.checkSolveConflicts = new System.Windows.Forms.CheckBox();
            this.genMutation = new System.Windows.Forms.NumericUpDown();
            this.label25 = new System.Windows.Forms.Label();
            this.genStartChance = new System.Windows.Forms.NumericUpDown();
            this.label24 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.genPopsize = new System.Windows.Forms.NumericUpDown();
            this.OrbitPanel = new System.Windows.Forms.Panel();
            this.minElevationTextBox = new System.Windows.Forms.TextBox();
            this.minElevationLabel = new System.Windows.Forms.Label();
            this.minDurationTextBox = new System.Windows.Forms.TextBox();
            this.minDurationLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.wgsGroupBox = new System.Windows.Forms.GroupBox();
            this.wgs84RadioButton = new System.Windows.Forms.RadioButton();
            this.wgs72RadioButton = new System.Windows.Forms.RadioButton();
            this.accuracySelect = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Tlepanel = new System.Windows.Forms.Panel();
            this.deleteCredentialsButton = new System.Windows.Forms.Button();
            this.tlegroupBox = new System.Windows.Forms.GroupBox();
            this.tlehourlyradioButton = new System.Windows.Forms.RadioButton();
            this.tleStartUpRadioButton = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.tleAutoUpdateCheckBox = new System.Windows.Forms.CheckBox();
            this.LoggingPanel = new System.Windows.Forms.Panel();
            this.showLogCheckBox = new System.Windows.Forms.CheckBox();
            this.logFitnessCheckBox = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.saveLogPathTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.saveResultsPathTextBox = new System.Windows.Forms.TextBox();
            this.saveLogFileCheckBox = new System.Windows.Forms.CheckBox();
            this.autoSaveResultsCheckBox = new System.Windows.Forms.CheckBox();
            this.GlobalPanel = new System.Windows.Forms.Panel();
            this.warningLabel2 = new System.Windows.Forms.Label();
            this.warningLabel1 = new System.Windows.Forms.Label();
            this.MaxPerformanceCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.RandSeedTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.savePathButton = new System.Windows.Forms.Button();
            this.SavePathTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AutoScheduleCheckBox = new System.Windows.Forms.CheckBox();
            this.AutoContactsCheckBox = new System.Windows.Forms.CheckBox();
            this.AutoSaveCheckBox = new System.Windows.Forms.CheckBox();
            this.dbPanel = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.databaseTextBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.EFTPanel = new System.Windows.Forms.Panel();
            this.label48 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.FairPanel = new System.Windows.Forms.Panel();
            this.fairBruteForceCheckbox = new System.Windows.Forms.CheckBox();
            this.label57 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.applySettingButton = new System.Windows.Forms.Button();
            this.cancelSettingsButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.hillpanel = new System.Windows.Forms.Panel();
            this.hillmaxIterationsNumberic = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.hillAdaptiveMaxIterations = new System.Windows.Forms.CheckBox();
            this.hillRandomStartCheckBox = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.GeneticPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.genMaxTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.genMaxGen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.genMutation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.genStartChance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.genPopsize)).BeginInit();
            this.OrbitPanel.SuspendLayout();
            this.wgsGroupBox.SuspendLayout();
            this.Tlepanel.SuspendLayout();
            this.tlegroupBox.SuspendLayout();
            this.LoggingPanel.SuspendLayout();
            this.GlobalPanel.SuspendLayout();
            this.dbPanel.SuspendLayout();
            this.EFTPanel.SuspendLayout();
            this.FairPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.hillpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hillmaxIterationsNumberic)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.settingsTreeView);
            this.panel1.Location = new System.Drawing.Point(12, 77);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(217, 409);
            this.panel1.TabIndex = 0;
            // 
            // settingsTreeView
            // 
            this.settingsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingsTreeView.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsTreeView.Location = new System.Drawing.Point(0, 0);
            this.settingsTreeView.Name = "settingsTreeView";
            treeNode11.Name = "Logging";
            treeNode11.Text = "Logging";
            treeNode12.Name = "dataBase";
            treeNode12.Text = "DataBase";
            treeNode13.Name = "gloabal_set";
            treeNode13.Text = "Global";
            treeNode14.Name = "orbit_set";
            treeNode14.Text = "Orbit";
            treeNode15.Name = "tle_set";
            treeNode15.Text = "TLE-Data";
            treeNode16.Name = "genetig_set";
            treeNode16.Text = "Genetic";
            treeNode17.Name = "fair_set";
            treeNode17.Text = "Greedy";
            treeNode18.Name = "hillClimber";
            treeNode18.Text = "Hill-Climber";
            treeNode19.Name = "eft_set";
            treeNode19.Text = "EFT(Earliest Finsish Time)";
            treeNode20.Name = "scheduler_set";
            treeNode20.Text = "Scheduler";
            this.settingsTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode20});
            this.settingsTreeView.Size = new System.Drawing.Size(217, 409);
            this.settingsTreeView.TabIndex = 0;
            this.settingsTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.settingsTreeView_AfterSelect);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.hillpanel);
            this.panel2.Controls.Add(this.OrbitPanel);
            this.panel2.Controls.Add(this.Tlepanel);
            this.panel2.Controls.Add(this.LoggingPanel);
            this.panel2.Controls.Add(this.GlobalPanel);
            this.panel2.Controls.Add(this.dbPanel);
            this.panel2.Controls.Add(this.EFTPanel);
            this.panel2.Controls.Add(this.FairPanel);
            this.panel2.Controls.Add(this.GeneticPanel);
            this.panel2.Location = new System.Drawing.Point(235, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(569, 452);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::MARRSS.Properties.Resources.smallBanner;
            this.panel3.Controls.Add(this.settingsLocationText);
            this.panel3.Location = new System.Drawing.Point(3, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(570, 60);
            this.panel3.TabIndex = 1;
            // 
            // settingsLocationText
            // 
            this.settingsLocationText.AutoSize = true;
            this.settingsLocationText.BackColor = System.Drawing.Color.Transparent;
            this.settingsLocationText.Dock = System.Windows.Forms.DockStyle.Right;
            this.settingsLocationText.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsLocationText.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.settingsLocationText.Location = new System.Drawing.Point(436, 0);
            this.settingsLocationText.Name = "settingsLocationText";
            this.settingsLocationText.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.settingsLocationText.Size = new System.Drawing.Size(134, 19);
            this.settingsLocationText.TabIndex = 0;
            this.settingsLocationText.Text = "Global - Settings";
            this.settingsLocationText.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // GeneticPanel
            // 
            this.GeneticPanel.Controls.Add(this.label10);
            this.GeneticPanel.Controls.Add(this.label9);
            this.GeneticPanel.Controls.Add(this.label8);
            this.GeneticPanel.Controls.Add(this.groupBox1);
            this.GeneticPanel.Controls.Add(this.checkConflictHandling);
            this.GeneticPanel.Controls.Add(this.checkSolveConflicts);
            this.GeneticPanel.Controls.Add(this.genMutation);
            this.GeneticPanel.Controls.Add(this.label25);
            this.GeneticPanel.Controls.Add(this.genStartChance);
            this.GeneticPanel.Controls.Add(this.label24);
            this.GeneticPanel.Controls.Add(this.label6);
            this.GeneticPanel.Controls.Add(this.genPopsize);
            this.GeneticPanel.Location = new System.Drawing.Point(6, 72);
            this.GeneticPanel.Name = "GeneticPanel";
            this.GeneticPanel.Size = new System.Drawing.Size(560, 377);
            this.GeneticPanel.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(310, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(154, 13);
            this.label10.TabIndex = 32;
            this.label10.Text = "Mutation chance for each child";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(310, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(243, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "Percentage used to randomice starting poplulation";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(310, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(155, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "Number of used population size";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.maxDurationRadioButton);
            this.groupBox1.Controls.Add(this.runMaxGenerationsRadioButton);
            this.groupBox1.Controls.Add(this.genMaxTime);
            this.groupBox1.Controls.Add(this.genMaxGen);
            this.groupBox1.Location = new System.Drawing.Point(11, 105);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(542, 113);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Run Genetic Scheduler";
            // 
            // label12
            // 
            this.label12.AutoEllipsis = true;
            this.label12.Location = new System.Drawing.Point(293, 67);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(243, 30);
            this.label12.TabIndex = 28;
            this.label12.Text = "Genetic scheduler will run for defined time frame and return the best solution fo" +
    "und";
            // 
            // label11
            // 
            this.label11.AutoEllipsis = true;
            this.label11.Location = new System.Drawing.Point(293, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(243, 30);
            this.label11.TabIndex = 27;
            this.label11.Text = "Genetic scheduler will run until no better solution is found for next N number of" +
    " generations";
            // 
            // maxDurationRadioButton
            // 
            this.maxDurationRadioButton.AutoSize = true;
            this.maxDurationRadioButton.Location = new System.Drawing.Point(11, 68);
            this.maxDurationRadioButton.Name = "maxDurationRadioButton";
            this.maxDurationRadioButton.Size = new System.Drawing.Size(162, 17);
            this.maxDurationRadioButton.TabIndex = 1;
            this.maxDurationRadioButton.TabStop = true;
            this.maxDurationRadioButton.Text = "for a certain duration in hours";
            this.maxDurationRadioButton.UseVisualStyleBackColor = true;
            this.maxDurationRadioButton.CheckedChanged += new System.EventHandler(this.maxDurationRadioButton_CheckedChanged);
            // 
            // runMaxGenerationsRadioButton
            // 
            this.runMaxGenerationsRadioButton.AutoSize = true;
            this.runMaxGenerationsRadioButton.Location = new System.Drawing.Point(11, 32);
            this.runMaxGenerationsRadioButton.Name = "runMaxGenerationsRadioButton";
            this.runMaxGenerationsRadioButton.Size = new System.Drawing.Size(204, 17);
            this.runMaxGenerationsRadioButton.TabIndex = 0;
            this.runMaxGenerationsRadioButton.TabStop = true;
            this.runMaxGenerationsRadioButton.Text = "until number of generations is reached";
            this.runMaxGenerationsRadioButton.UseVisualStyleBackColor = true;
            this.runMaxGenerationsRadioButton.CheckedChanged += new System.EventHandler(this.runMaxGenerationsRadioButton_CheckedChanged);
            // 
            // genMaxTime
            // 
            this.genMaxTime.DecimalPlaces = 2;
            this.genMaxTime.Enabled = false;
            this.genMaxTime.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.genMaxTime.Location = new System.Drawing.Point(220, 68);
            this.genMaxTime.Maximum = new decimal(new int[] {
            72,
            0,
            0,
            0});
            this.genMaxTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.genMaxTime.Name = "genMaxTime";
            this.genMaxTime.Size = new System.Drawing.Size(67, 20);
            this.genMaxTime.TabIndex = 26;
            this.genMaxTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.genMaxTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // genMaxGen
            // 
            this.genMaxGen.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.genMaxGen.Location = new System.Drawing.Point(220, 32);
            this.genMaxGen.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.genMaxGen.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.genMaxGen.Name = "genMaxGen";
            this.genMaxGen.Size = new System.Drawing.Size(67, 20);
            this.genMaxGen.TabIndex = 19;
            this.genMaxGen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.genMaxGen.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // checkConflictHandling
            // 
            this.checkConflictHandling.AutoSize = true;
            this.checkConflictHandling.Location = new System.Drawing.Point(3, 244);
            this.checkConflictHandling.Name = "checkConflictHandling";
            this.checkConflictHandling.Size = new System.Drawing.Size(243, 17);
            this.checkConflictHandling.TabIndex = 28;
            this.checkConflictHandling.Text = "Handle Conflicst by Priority instead of Random";
            this.checkConflictHandling.UseVisualStyleBackColor = true;
            // 
            // checkSolveConflicts
            // 
            this.checkSolveConflicts.AutoSize = true;
            this.checkSolveConflicts.Location = new System.Drawing.Point(3, 276);
            this.checkSolveConflicts.Name = "checkSolveConflicts";
            this.checkSolveConflicts.Size = new System.Drawing.Size(301, 17);
            this.checkSolveConflicts.TabIndex = 27;
            this.checkSolveConflicts.Text = "Check for conflicts in completed schedule and solve them.";
            this.checkSolveConflicts.UseVisualStyleBackColor = true;
            // 
            // genMutation
            // 
            this.genMutation.Location = new System.Drawing.Point(231, 59);
            this.genMutation.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.genMutation.Name = "genMutation";
            this.genMutation.Size = new System.Drawing.Size(67, 20);
            this.genMutation.TabIndex = 23;
            this.genMutation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.genMutation.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(8, 35);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(108, 13);
            this.label25.TabIndex = 22;
            this.label25.Text = "Starting Chance in %:";
            // 
            // genStartChance
            // 
            this.genStartChance.Location = new System.Drawing.Point(231, 33);
            this.genStartChance.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.genStartChance.Name = "genStartChance";
            this.genStartChance.Size = new System.Drawing.Size(67, 20);
            this.genStartChance.TabIndex = 21;
            this.genStartChance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.genStartChance.Value = new decimal(new int[] {
            65,
            0,
            0,
            0});
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(8, 61);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(122, 13);
            this.label24.TabIndex = 20;
            this.label24.Text = "Chance of Mutaion in %:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Population Size:";
            // 
            // genPopsize
            // 
            this.genPopsize.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.genPopsize.Location = new System.Drawing.Point(231, 7);
            this.genPopsize.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.genPopsize.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.genPopsize.Name = "genPopsize";
            this.genPopsize.Size = new System.Drawing.Size(67, 20);
            this.genPopsize.TabIndex = 16;
            this.genPopsize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.genPopsize.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // OrbitPanel
            // 
            this.OrbitPanel.Controls.Add(this.minElevationTextBox);
            this.OrbitPanel.Controls.Add(this.minElevationLabel);
            this.OrbitPanel.Controls.Add(this.minDurationTextBox);
            this.OrbitPanel.Controls.Add(this.minDurationLabel);
            this.OrbitPanel.Controls.Add(this.label5);
            this.OrbitPanel.Controls.Add(this.wgsGroupBox);
            this.OrbitPanel.Controls.Add(this.accuracySelect);
            this.OrbitPanel.Controls.Add(this.label4);
            this.OrbitPanel.Location = new System.Drawing.Point(6, 72);
            this.OrbitPanel.Name = "OrbitPanel";
            this.OrbitPanel.Size = new System.Drawing.Size(560, 377);
            this.OrbitPanel.TabIndex = 13;
            // 
            // minElevationTextBox
            // 
            this.minElevationTextBox.Location = new System.Drawing.Point(184, 218);
            this.minElevationTextBox.Name = "minElevationTextBox";
            this.minElevationTextBox.Size = new System.Drawing.Size(58, 20);
            this.minElevationTextBox.TabIndex = 16;
            this.minElevationTextBox.Text = "0";
            this.minElevationTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // minElevationLabel
            // 
            this.minElevationLabel.AutoSize = true;
            this.minElevationLabel.Location = new System.Drawing.Point(8, 221);
            this.minElevationLabel.Name = "minElevationLabel";
            this.minElevationLabel.Size = new System.Drawing.Size(124, 13);
            this.minElevationLabel.TabIndex = 15;
            this.minElevationLabel.Text = "Min. Elevation ( in deg ) :";
            // 
            // minDurationTextBox
            // 
            this.minDurationTextBox.Location = new System.Drawing.Point(184, 192);
            this.minDurationTextBox.Name = "minDurationTextBox";
            this.minDurationTextBox.Size = new System.Drawing.Size(58, 20);
            this.minDurationTextBox.TabIndex = 14;
            this.minDurationTextBox.Text = "300";
            this.minDurationTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // minDurationLabel
            // 
            this.minDurationLabel.AutoSize = true;
            this.minDurationLabel.Location = new System.Drawing.Point(8, 195);
            this.minDurationLabel.Name = "minDurationLabel";
            this.minDurationLabel.Size = new System.Drawing.Size(119, 13);
            this.minDurationLabel.TabIndex = 13;
            this.minDurationLabel.Text = "Min. Duration ( in sec. ):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(182, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Global Contact Window Calculations:";
            // 
            // wgsGroupBox
            // 
            this.wgsGroupBox.Controls.Add(this.wgs84RadioButton);
            this.wgsGroupBox.Controls.Add(this.wgs72RadioButton);
            this.wgsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wgsGroupBox.Location = new System.Drawing.Point(16, 53);
            this.wgsGroupBox.Name = "wgsGroupBox";
            this.wgsGroupBox.Size = new System.Drawing.Size(169, 103);
            this.wgsGroupBox.TabIndex = 11;
            this.wgsGroupBox.TabStop = false;
            this.wgsGroupBox.Text = "WGS";
            // 
            // wgs84RadioButton
            // 
            this.wgs84RadioButton.AutoSize = true;
            this.wgs84RadioButton.Checked = true;
            this.wgs84RadioButton.Location = new System.Drawing.Point(39, 53);
            this.wgs84RadioButton.Name = "wgs84RadioButton";
            this.wgs84RadioButton.Size = new System.Drawing.Size(66, 17);
            this.wgs84RadioButton.TabIndex = 1;
            this.wgs84RadioButton.TabStop = true;
            this.wgs84RadioButton.Text = "WGS-84";
            this.wgs84RadioButton.UseVisualStyleBackColor = true;
            // 
            // wgs72RadioButton
            // 
            this.wgs72RadioButton.AutoSize = true;
            this.wgs72RadioButton.Location = new System.Drawing.Point(39, 30);
            this.wgs72RadioButton.Name = "wgs72RadioButton";
            this.wgs72RadioButton.Size = new System.Drawing.Size(66, 17);
            this.wgs72RadioButton.TabIndex = 0;
            this.wgs72RadioButton.Text = "WGS-72";
            this.wgs72RadioButton.UseVisualStyleBackColor = true;
            // 
            // accuracySelect
            // 
            this.accuracySelect.FormattingEnabled = true;
            this.accuracySelect.Items.AddRange(new object[] {
            "00.5 sec.",
            "01.0 sec.",
            "05.0 sec.",
            "10.0 sec.",
            "30.0 sec.",
            "60.0 sec."});
            this.accuracySelect.Location = new System.Drawing.Point(184, 19);
            this.accuracySelect.Name = "accuracySelect";
            this.accuracySelect.Size = new System.Drawing.Size(121, 21);
            this.accuracySelect.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Orbit Calculation Accuracy: ";
            // 
            // Tlepanel
            // 
            this.Tlepanel.Controls.Add(this.deleteCredentialsButton);
            this.Tlepanel.Controls.Add(this.tlegroupBox);
            this.Tlepanel.Controls.Add(this.label7);
            this.Tlepanel.Controls.Add(this.tleAutoUpdateCheckBox);
            this.Tlepanel.Location = new System.Drawing.Point(6, 73);
            this.Tlepanel.Name = "Tlepanel";
            this.Tlepanel.Size = new System.Drawing.Size(557, 377);
            this.Tlepanel.TabIndex = 4;
            // 
            // deleteCredentialsButton
            // 
            this.deleteCredentialsButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteCredentialsButton.Location = new System.Drawing.Point(11, 149);
            this.deleteCredentialsButton.Name = "deleteCredentialsButton";
            this.deleteCredentialsButton.Size = new System.Drawing.Size(215, 23);
            this.deleteCredentialsButton.TabIndex = 6;
            this.deleteCredentialsButton.Text = "Delete stored Credentials";
            this.deleteCredentialsButton.UseVisualStyleBackColor = true;
            this.deleteCredentialsButton.Click += new System.EventHandler(this.deleteCredentialsButton_Click);
            // 
            // tlegroupBox
            // 
            this.tlegroupBox.Controls.Add(this.tlehourlyradioButton);
            this.tlegroupBox.Controls.Add(this.tleStartUpRadioButton);
            this.tlegroupBox.Location = new System.Drawing.Point(26, 41);
            this.tlegroupBox.Name = "tlegroupBox";
            this.tlegroupBox.Size = new System.Drawing.Size(200, 93);
            this.tlegroupBox.TabIndex = 5;
            this.tlegroupBox.TabStop = false;
            this.tlegroupBox.Text = "update at";
            // 
            // tlehourlyradioButton
            // 
            this.tlehourlyradioButton.AutoSize = true;
            this.tlehourlyradioButton.Location = new System.Drawing.Point(29, 53);
            this.tlehourlyradioButton.Name = "tlehourlyradioButton";
            this.tlehourlyradioButton.Size = new System.Drawing.Size(75, 17);
            this.tlehourlyradioButton.TabIndex = 1;
            this.tlehourlyradioButton.TabStop = true;
            this.tlehourlyradioButton.Text = "every hour";
            this.tlehourlyradioButton.UseVisualStyleBackColor = true;
            // 
            // tleStartUpRadioButton
            // 
            this.tleStartUpRadioButton.AutoSize = true;
            this.tleStartUpRadioButton.Location = new System.Drawing.Point(29, 24);
            this.tleStartUpRadioButton.Name = "tleStartUpRadioButton";
            this.tleStartUpRadioButton.Size = new System.Drawing.Size(64, 17);
            this.tleStartUpRadioButton.TabIndex = 0;
            this.tleStartUpRadioButton.TabStop = true;
            this.tleStartUpRadioButton.Text = "Start Up";
            this.tleStartUpRadioButton.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(238, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(288, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Download latest TLE data  automaticaly at specific intervals";
            // 
            // tleAutoUpdateCheckBox
            // 
            this.tleAutoUpdateCheckBox.AutoSize = true;
            this.tleAutoUpdateCheckBox.Location = new System.Drawing.Point(11, 11);
            this.tleAutoUpdateCheckBox.Name = "tleAutoUpdateCheckBox";
            this.tleAutoUpdateCheckBox.Size = new System.Drawing.Size(135, 17);
            this.tleAutoUpdateCheckBox.TabIndex = 0;
            this.tleAutoUpdateCheckBox.Text = "Auto Update TLE-Data";
            this.tleAutoUpdateCheckBox.UseVisualStyleBackColor = true;
            this.tleAutoUpdateCheckBox.CheckedChanged += new System.EventHandler(this.tleAutoUpdateCheckBox_CheckedChanged);
            // 
            // LoggingPanel
            // 
            this.LoggingPanel.Controls.Add(this.showLogCheckBox);
            this.LoggingPanel.Controls.Add(this.logFitnessCheckBox);
            this.LoggingPanel.Controls.Add(this.button2);
            this.LoggingPanel.Controls.Add(this.saveLogPathTextBox);
            this.LoggingPanel.Controls.Add(this.button1);
            this.LoggingPanel.Controls.Add(this.saveResultsPathTextBox);
            this.LoggingPanel.Controls.Add(this.saveLogFileCheckBox);
            this.LoggingPanel.Controls.Add(this.autoSaveResultsCheckBox);
            this.LoggingPanel.Location = new System.Drawing.Point(6, 71);
            this.LoggingPanel.Name = "LoggingPanel";
            this.LoggingPanel.Size = new System.Drawing.Size(557, 377);
            this.LoggingPanel.TabIndex = 4;
            // 
            // showLogCheckBox
            // 
            this.showLogCheckBox.AutoSize = true;
            this.showLogCheckBox.Location = new System.Drawing.Point(3, 169);
            this.showLogCheckBox.Name = "showLogCheckBox";
            this.showLogCheckBox.Size = new System.Drawing.Size(124, 17);
            this.showLogCheckBox.TabIndex = 13;
            this.showLogCheckBox.Text = "Show Log during run";
            this.showLogCheckBox.UseVisualStyleBackColor = true;
            // 
            // logFitnessCheckBox
            // 
            this.logFitnessCheckBox.AutoSize = true;
            this.logFitnessCheckBox.Location = new System.Drawing.Point(6, 64);
            this.logFitnessCheckBox.Name = "logFitnessCheckBox";
            this.logFitnessCheckBox.Size = new System.Drawing.Size(207, 17);
            this.logFitnessCheckBox.TabIndex = 6;
            this.logFitnessCheckBox.Text = "Log the fitness values during run to file";
            this.logFitnessCheckBox.UseVisualStyleBackColor = true;
            this.logFitnessCheckBox.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(499, 140);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(27, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "..";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // saveLogPathTextBox
            // 
            this.saveLogPathTextBox.Location = new System.Drawing.Point(25, 140);
            this.saveLogPathTextBox.Name = "saveLogPathTextBox";
            this.saveLogPathTextBox.Size = new System.Drawing.Size(459, 20);
            this.saveLogPathTextBox.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(499, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "..";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // saveResultsPathTextBox
            // 
            this.saveResultsPathTextBox.Location = new System.Drawing.Point(23, 35);
            this.saveResultsPathTextBox.Name = "saveResultsPathTextBox";
            this.saveResultsPathTextBox.Size = new System.Drawing.Size(459, 20);
            this.saveResultsPathTextBox.TabIndex = 2;
            // 
            // saveLogFileCheckBox
            // 
            this.saveLogFileCheckBox.AutoSize = true;
            this.saveLogFileCheckBox.Location = new System.Drawing.Point(6, 120);
            this.saveLogFileCheckBox.Name = "saveLogFileCheckBox";
            this.saveLogFileCheckBox.Size = new System.Drawing.Size(119, 17);
            this.saveLogFileCheckBox.TabIndex = 1;
            this.saveLogFileCheckBox.Text = "Auto save log to file";
            this.saveLogFileCheckBox.UseVisualStyleBackColor = true;
            // 
            // autoSaveResultsCheckBox
            // 
            this.autoSaveResultsCheckBox.AutoSize = true;
            this.autoSaveResultsCheckBox.Location = new System.Drawing.Point(6, 13);
            this.autoSaveResultsCheckBox.Name = "autoSaveResultsCheckBox";
            this.autoSaveResultsCheckBox.Size = new System.Drawing.Size(135, 17);
            this.autoSaveResultsCheckBox.TabIndex = 0;
            this.autoSaveResultsCheckBox.Text = "Auto save results to file";
            this.autoSaveResultsCheckBox.UseVisualStyleBackColor = true;
            // 
            // GlobalPanel
            // 
            this.GlobalPanel.Controls.Add(this.warningLabel2);
            this.GlobalPanel.Controls.Add(this.warningLabel1);
            this.GlobalPanel.Controls.Add(this.MaxPerformanceCheckBox);
            this.GlobalPanel.Controls.Add(this.label3);
            this.GlobalPanel.Controls.Add(this.RandSeedTextBox);
            this.GlobalPanel.Controls.Add(this.label2);
            this.GlobalPanel.Controls.Add(this.savePathButton);
            this.GlobalPanel.Controls.Add(this.SavePathTextBox);
            this.GlobalPanel.Controls.Add(this.label1);
            this.GlobalPanel.Controls.Add(this.AutoScheduleCheckBox);
            this.GlobalPanel.Controls.Add(this.AutoContactsCheckBox);
            this.GlobalPanel.Controls.Add(this.AutoSaveCheckBox);
            this.GlobalPanel.Location = new System.Drawing.Point(6, 71);
            this.GlobalPanel.Name = "GlobalPanel";
            this.GlobalPanel.Size = new System.Drawing.Size(560, 377);
            this.GlobalPanel.TabIndex = 2;
            // 
            // warningLabel2
            // 
            this.warningLabel2.AutoEllipsis = true;
            this.warningLabel2.ForeColor = System.Drawing.Color.DarkRed;
            this.warningLabel2.Location = new System.Drawing.Point(3, 330);
            this.warningLabel2.Name = "warningLabel2";
            this.warningLabel2.Size = new System.Drawing.Size(532, 40);
            this.warningLabel2.TabIndex = 12;
            this.warningLabel2.Text = "If this is active the Software will not react and appear to be not responding. Th" +
    "e calculations will keep runing in the background. Be aware this might take some" +
    " time.";
            // 
            // warningLabel1
            // 
            this.warningLabel1.AutoSize = true;
            this.warningLabel1.ForeColor = System.Drawing.Color.DarkRed;
            this.warningLabel1.Location = new System.Drawing.Point(143, 311);
            this.warningLabel1.Name = "warningLabel1";
            this.warningLabel1.Size = new System.Drawing.Size(56, 13);
            this.warningLabel1.TabIndex = 11;
            this.warningLabel1.Text = "Warning!!!";
            // 
            // MaxPerformanceCheckBox
            // 
            this.MaxPerformanceCheckBox.AutoSize = true;
            this.MaxPerformanceCheckBox.Location = new System.Drawing.Point(6, 310);
            this.MaxPerformanceCheckBox.Name = "MaxPerformanceCheckBox";
            this.MaxPerformanceCheckBox.Size = new System.Drawing.Size(109, 17);
            this.MaxPerformanceCheckBox.TabIndex = 10;
            this.MaxPerformanceCheckBox.Text = "Max Performance";
            this.MaxPerformanceCheckBox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(205, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(334, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Random Seed used to randomice contact windows and for Scenarios\r\n";
            // 
            // RandSeedTextBox
            // 
            this.RandSeedTextBox.Location = new System.Drawing.Point(96, 140);
            this.RandSeedTextBox.Name = "RandSeedTextBox";
            this.RandSeedTextBox.Size = new System.Drawing.Size(103, 20);
            this.RandSeedTextBox.TabIndex = 8;
            this.RandSeedTextBox.Text = "58496";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Random Seed:";
            // 
            // savePathButton
            // 
            this.savePathButton.Location = new System.Drawing.Point(514, 102);
            this.savePathButton.Name = "savePathButton";
            this.savePathButton.Size = new System.Drawing.Size(21, 21);
            this.savePathButton.TabIndex = 6;
            this.savePathButton.Text = "..";
            this.savePathButton.UseVisualStyleBackColor = true;
            this.savePathButton.Click += new System.EventHandler(this.savePathButton_Click);
            // 
            // SavePathTextBox
            // 
            this.SavePathTextBox.Location = new System.Drawing.Point(96, 102);
            this.SavePathTextBox.Name = "SavePathTextBox";
            this.SavePathTextBox.Size = new System.Drawing.Size(412, 20);
            this.SavePathTextBox.TabIndex = 5;
            this.SavePathTextBox.Text = "C:\\Path\\ToSave\\";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Save Path:";
            // 
            // AutoScheduleCheckBox
            // 
            this.AutoScheduleCheckBox.AutoSize = true;
            this.AutoScheduleCheckBox.Location = new System.Drawing.Point(3, 68);
            this.AutoScheduleCheckBox.Name = "AutoScheduleCheckBox";
            this.AutoScheduleCheckBox.Size = new System.Drawing.Size(172, 17);
            this.AutoScheduleCheckBox.TabIndex = 3;
            this.AutoScheduleCheckBox.Text = "Auto save calculated schedule";
            this.AutoScheduleCheckBox.UseVisualStyleBackColor = true;
            // 
            // AutoContactsCheckBox
            // 
            this.AutoContactsCheckBox.AutoSize = true;
            this.AutoContactsCheckBox.Location = new System.Drawing.Point(3, 45);
            this.AutoContactsCheckBox.Name = "AutoContactsCheckBox";
            this.AutoContactsCheckBox.Size = new System.Drawing.Size(210, 17);
            this.AutoContactsCheckBox.TabIndex = 2;
            this.AutoContactsCheckBox.Text = "Auto save calculated Contact windows";
            this.AutoContactsCheckBox.UseVisualStyleBackColor = true;
            // 
            // AutoSaveCheckBox
            // 
            this.AutoSaveCheckBox.AutoSize = true;
            this.AutoSaveCheckBox.Location = new System.Drawing.Point(3, 22);
            this.AutoSaveCheckBox.Name = "AutoSaveCheckBox";
            this.AutoSaveCheckBox.Size = new System.Drawing.Size(74, 17);
            this.AutoSaveCheckBox.TabIndex = 1;
            this.AutoSaveCheckBox.Text = "Auto save";
            this.AutoSaveCheckBox.UseVisualStyleBackColor = true;
            this.AutoSaveCheckBox.CheckedChanged += new System.EventHandler(this.AutoSaveCheckBox_CheckedChanged);
            // 
            // dbPanel
            // 
            this.dbPanel.Controls.Add(this.label13);
            this.dbPanel.Controls.Add(this.button3);
            this.dbPanel.Controls.Add(this.databaseTextBox);
            this.dbPanel.Controls.Add(this.label14);
            this.dbPanel.Location = new System.Drawing.Point(6, 72);
            this.dbPanel.Name = "dbPanel";
            this.dbPanel.Size = new System.Drawing.Size(560, 377);
            this.dbPanel.TabIndex = 31;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(32, 77);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(306, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "A restart of the application is required for changes to take effekt\r\n";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(512, 34);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(27, 23);
            this.button3.TabIndex = 12;
            this.button3.Text = "..";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // databaseTextBox
            // 
            this.databaseTextBox.Location = new System.Drawing.Point(32, 38);
            this.databaseTextBox.Name = "databaseTextBox";
            this.databaseTextBox.Size = new System.Drawing.Size(461, 20);
            this.databaseTextBox.TabIndex = 11;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 13);
            this.label14.TabIndex = 10;
            this.label14.Text = "DataBase Path";
            // 
            // EFTPanel
            // 
            this.EFTPanel.Controls.Add(this.label48);
            this.EFTPanel.Controls.Add(this.label52);
            this.EFTPanel.Location = new System.Drawing.Point(6, 72);
            this.EFTPanel.Name = "EFTPanel";
            this.EFTPanel.Size = new System.Drawing.Size(560, 377);
            this.EFTPanel.TabIndex = 30;
            // 
            // label48
            // 
            this.label48.Location = new System.Drawing.Point(20, 36);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(244, 71);
            this.label48.TabIndex = 11;
            this.label48.Text = "This Greedy scheduler selects the next best solution based on the contact with th" +
    "e\r\n  - earliest finish time\r\n  - and / or priority";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(8, 17);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(140, 13);
            this.label52.TabIndex = 10;
            this.label52.Text = "Earliest Finish Time - Greedy";
            // 
            // FairPanel
            // 
            this.FairPanel.Controls.Add(this.fairBruteForceCheckbox);
            this.FairPanel.Controls.Add(this.label57);
            this.FairPanel.Controls.Add(this.label46);
            this.FairPanel.Location = new System.Drawing.Point(6, 72);
            this.FairPanel.Name = "FairPanel";
            this.FairPanel.Size = new System.Drawing.Size(560, 377);
            this.FairPanel.TabIndex = 0;
            // 
            // fairBruteForceCheckbox
            // 
            this.fairBruteForceCheckbox.AutoSize = true;
            this.fairBruteForceCheckbox.Location = new System.Drawing.Point(11, 194);
            this.fairBruteForceCheckbox.Name = "fairBruteForceCheckbox";
            this.fairBruteForceCheckbox.Size = new System.Drawing.Size(279, 17);
            this.fairBruteForceCheckbox.TabIndex = 11;
            this.fairBruteForceCheckbox.Text = "use pseudo Brute Force to calculate optimal schedule";
            this.fairBruteForceCheckbox.UseVisualStyleBackColor = true;
            // 
            // label57
            // 
            this.label57.Location = new System.Drawing.Point(8, 30);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(462, 157);
            this.label57.TabIndex = 10;
            this.label57.Text = resources.GetString("label57.Text");
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(8, 7);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(41, 13);
            this.label46.TabIndex = 9;
            this.label46.Text = "Greedy";
            // 
            // applySettingButton
            // 
            this.applySettingButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applySettingButton.Location = new System.Drawing.Point(648, 463);
            this.applySettingButton.Name = "applySettingButton";
            this.applySettingButton.Size = new System.Drawing.Size(75, 23);
            this.applySettingButton.TabIndex = 2;
            this.applySettingButton.Text = "Apply";
            this.applySettingButton.UseVisualStyleBackColor = true;
            this.applySettingButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // cancelSettingsButton
            // 
            this.cancelSettingsButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelSettingsButton.Location = new System.Drawing.Point(729, 463);
            this.cancelSettingsButton.Name = "cancelSettingsButton";
            this.cancelSettingsButton.Size = new System.Drawing.Size(75, 23);
            this.cancelSettingsButton.TabIndex = 3;
            this.cancelSettingsButton.Text = "Cancel";
            this.cancelSettingsButton.UseVisualStyleBackColor = true;
            this.cancelSettingsButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.CheckFileExists = false;
            this.openFileDialog1.DefaultExt = "mab";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Database|*.mab";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // hillpanel
            // 
            this.hillpanel.Controls.Add(this.hillRandomStartCheckBox);
            this.hillpanel.Controls.Add(this.hillAdaptiveMaxIterations);
            this.hillpanel.Controls.Add(this.label15);
            this.hillpanel.Controls.Add(this.hillmaxIterationsNumberic);
            this.hillpanel.Location = new System.Drawing.Point(5, 73);
            this.hillpanel.Name = "hillpanel";
            this.hillpanel.Size = new System.Drawing.Size(560, 377);
            this.hillpanel.TabIndex = 32;
            // 
            // hillmaxIterationsNumberic
            // 
            this.hillmaxIterationsNumberic.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.hillmaxIterationsNumberic.Location = new System.Drawing.Point(220, 102);
            this.hillmaxIterationsNumberic.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.hillmaxIterationsNumberic.Name = "hillmaxIterationsNumberic";
            this.hillmaxIterationsNumberic.Size = new System.Drawing.Size(63, 20);
            this.hillmaxIterationsNumberic.TabIndex = 0;
            this.hillmaxIterationsNumberic.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(22, 104);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(127, 13);
            this.label15.TabIndex = 1;
            this.label15.Text = "max Number of Iterations:";
            // 
            // hillAdaptiveMaxIterations
            // 
            this.hillAdaptiveMaxIterations.AutoSize = true;
            this.hillAdaptiveMaxIterations.Location = new System.Drawing.Point(12, 73);
            this.hillAdaptiveMaxIterations.Name = "hillAdaptiveMaxIterations";
            this.hillAdaptiveMaxIterations.Size = new System.Drawing.Size(315, 17);
            this.hillAdaptiveMaxIterations.TabIndex = 2;
            this.hillAdaptiveMaxIterations.Text = "set max number of iterations dependendly on the problem size";
            this.hillAdaptiveMaxIterations.UseVisualStyleBackColor = true;
            this.hillAdaptiveMaxIterations.CheckedChanged += new System.EventHandler(this.hillAdaptiveMaxIterations_CheckedChanged);
            // 
            // hillRandomStartCheckBox
            // 
            this.hillRandomStartCheckBox.AutoSize = true;
            this.hillRandomStartCheckBox.Location = new System.Drawing.Point(12, 20);
            this.hillRandomStartCheckBox.Name = "hillRandomStartCheckBox";
            this.hillRandomStartCheckBox.Size = new System.Drawing.Size(221, 17);
            this.hillRandomStartCheckBox.TabIndex = 3;
            this.hillRandomStartCheckBox.Text = "Start with a Random schedule to optimize";
            this.hillRandomStartCheckBox.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 498);
            this.Controls.Add(this.cancelSettingsButton);
            this.Controls.Add(this.applySettingButton);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.GeneticPanel.ResumeLayout(false);
            this.GeneticPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.genMaxTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.genMaxGen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.genMutation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.genStartChance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.genPopsize)).EndInit();
            this.OrbitPanel.ResumeLayout(false);
            this.OrbitPanel.PerformLayout();
            this.wgsGroupBox.ResumeLayout(false);
            this.wgsGroupBox.PerformLayout();
            this.Tlepanel.ResumeLayout(false);
            this.Tlepanel.PerformLayout();
            this.tlegroupBox.ResumeLayout(false);
            this.tlegroupBox.PerformLayout();
            this.LoggingPanel.ResumeLayout(false);
            this.LoggingPanel.PerformLayout();
            this.GlobalPanel.ResumeLayout(false);
            this.GlobalPanel.PerformLayout();
            this.dbPanel.ResumeLayout(false);
            this.dbPanel.PerformLayout();
            this.EFTPanel.ResumeLayout(false);
            this.EFTPanel.PerformLayout();
            this.FairPanel.ResumeLayout(false);
            this.FairPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.hillpanel.ResumeLayout(false);
            this.hillpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hillmaxIterationsNumberic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView settingsTreeView;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label settingsLocationText;
        private System.Windows.Forms.Button applySettingButton;
        private System.Windows.Forms.Button cancelSettingsButton;
        private System.Windows.Forms.Panel GlobalPanel;
        private System.Windows.Forms.Button savePathButton;
        private System.Windows.Forms.TextBox SavePathTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox AutoScheduleCheckBox;
        private System.Windows.Forms.CheckBox AutoContactsCheckBox;
        private System.Windows.Forms.CheckBox AutoSaveCheckBox;
        private System.Windows.Forms.TextBox RandSeedTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox MaxPerformanceCheckBox;
        private System.Windows.Forms.Label warningLabel2;
        private System.Windows.Forms.Label warningLabel1;
        private System.Windows.Forms.Panel OrbitPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox wgsGroupBox;
        private System.Windows.Forms.ComboBox accuracySelect;
        private System.Windows.Forms.RadioButton wgs84RadioButton;
        private System.Windows.Forms.RadioButton wgs72RadioButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox minElevationTextBox;
        private System.Windows.Forms.Label minElevationLabel;
        private System.Windows.Forms.TextBox minDurationTextBox;
        private System.Windows.Forms.Label minDurationLabel;
        private System.Windows.Forms.CheckBox showLogCheckBox;
        private System.Windows.Forms.Panel GeneticPanel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton maxDurationRadioButton;
        private System.Windows.Forms.RadioButton runMaxGenerationsRadioButton;
        private System.Windows.Forms.NumericUpDown genMaxTime;
        private System.Windows.Forms.CheckBox checkConflictHandling;
        private System.Windows.Forms.CheckBox checkSolveConflicts;
        private System.Windows.Forms.NumericUpDown genMutation;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.NumericUpDown genStartChance;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.NumericUpDown genMaxGen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown genPopsize;
        private System.Windows.Forms.Panel EFTPanel;
        private System.Windows.Forms.Panel FairPanel;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Panel LoggingPanel;
        private System.Windows.Forms.CheckBox saveLogFileCheckBox;
        private System.Windows.Forms.CheckBox autoSaveResultsCheckBox;
        private System.Windows.Forms.Panel Tlepanel;
        private System.Windows.Forms.CheckBox tleAutoUpdateCheckBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox tlegroupBox;
        private System.Windows.Forms.RadioButton tlehourlyradioButton;
        private System.Windows.Forms.RadioButton tleStartUpRadioButton;
        private System.Windows.Forms.Button deleteCredentialsButton;
        private System.Windows.Forms.TextBox saveResultsPathTextBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox saveLogPathTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox logFitnessCheckBox;
        private System.Windows.Forms.CheckBox fairBruteForceCheckbox;
        private System.Windows.Forms.Panel dbPanel;
        private System.Windows.Forms.TextBox databaseTextBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label13;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Panel hillpanel;
        private System.Windows.Forms.CheckBox hillRandomStartCheckBox;
        private System.Windows.Forms.CheckBox hillAdaptiveMaxIterations;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown hillmaxIterationsNumberic;
    }
}