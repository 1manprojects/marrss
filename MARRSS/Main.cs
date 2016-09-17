/**
* ----------------------------------------------------------------
* Nikolai Jonathan Reed 
*
* 
* Copyright (c) 2015, Nikolai Reed, 1manprojects.de
* All rights reserved.
*
* Licensed under
* Creative Commons Attribution NonCommercial (CC-BY-NC)
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Threading;
using System.Media;

using System.Diagnostics;
using MARRSS.Global;

namespace MARRSS
{
    /**
    * \brief Main Class
    *
    * This is the Main class file that handles the interactions with the Form
    * Main
    */
    public partial class Main : Form
    {
        private List<One_Sgp4.Tle> satTleData;
        private List<Ground.Station> stationData;
        private Definition.ContactWindowsVector contactsVector;

        private DataBase.DataBase _MainDataBase; //!< Database connection
        double accuracy = 0.5;

        Image imgSatellite = null;
        Image imgStation = null;

        //! Main Startup Function
        /*!
            Startup function reading from settings loading Database and if it
            does not exist it will create a new DataBase
        */
        public Main()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            InitializeComponent();
            accuracySelect.SelectedIndex = 0;
            
            _MainDataBase = new DataBase.DataBase();
            UpdateAllLists();
            radioGenetic.PerformClick();
            //load Settings
            genPopsize.Value = Properties.Settings.Default.GeneticMaxPopulation;
            genMutation.Value = Properties.Settings.Default.GeneticMutation;
            genMaxGen.Value = Properties.Settings.Default.GenMaxGenerations;
            genStartChance.Value = Properties.Settings.Default.GeneticCreation;

            comboBox4.SelectedIndex = 0;
            comboScenarioBox.SelectedIndex = 0;
            
            if (Properties.Settings.Default.PlotData > 0)
            {
                checkPlotData.Checked = true;
                comboPlottDataSettingsBox.SelectedIndex = Properties.Settings.Default.PlotData - 1;
            }
            if (Properties.Settings.Default.SaveContacts == 1)
            {
                checkAutoSaveSchedule.Checked = true;
            }
            else
            {
                checkAutoSaveSchedule.Checked = false;
            }
            if (Properties.Settings.Default.SaveImages == 1)
            {
                checkAutoSaveImage.Checked = true;
            }
            else
            {
                checkAutoSaveImage.Checked = false;
            }

            if (Properties.Settings.Default.MaxPerf == 1)
            {
                checkMaxPerf.Checked = true;
                warningLabel1.Visible = true;
                warningLabel2.Visible = true;
            }

            //DateTime date = new DateTime(2015,08,20,12,20,30);
            //startTimePicker.Value = date;
            //stopTimePicker.Value = date;
            DateTime time = DateTime.UtcNow;
            string format = "dd-MM-yyyy HH:mm";
            toolStripStatusLabel4.Text = time.ToString(format) + " UTC";

            imgSatellite = Properties.Resources.worldsmaller;
            imgStation = Properties.Resources.worldsmaller;
            drawGroundStations();
            //mapCanvas1.
        }

        //! Calculate Schedule
        /*!
            Calculates the orbit positions of the selected Satellites for the
            given time period and then the contact windows for each selected
            ground station. The calculation of the orbits and contact windows
            is done in multiple threads to save time. Afterwards the selected
            scheduler will compute a solution.
            New schedulers can be added inside this function below.
        */
        private void startScheduleButton_Click(object sender, EventArgs e)
        {
            //Set defaults
                contactNumberLabel.Text = "--";
                generationLabel.Text = "--";
                collisionLabel.Text = "--";
                stationFairLabel.Text = "--";
                fairSatLabel.Text = "--";
                calcTimeLabel.Text = "--";
                priorityLabel.Text = "--";
                label47.Text = "--";
                fitnessValueLabel.Text = "--";

                logRichTextBox.Clear();
                startScheduleButton.Enabled = false;
                toolStripStatusLabel3.Text = "Status: Starting";

             //Set Start and Stop Time
                int start_year = startDatePicker.Value.Year;
                int start_month = startDatePicker.Value.Month;
                int start_day = startDatePicker.Value.Day;
                int start_hh = startTimePicker.Value.Hour;
                int start_mm = startTimePicker.Value.Minute;
                int start_ss = startTimePicker.Value.Second;
                One_Sgp4.EpochTime startTime = new One_Sgp4.EpochTime(start_hh,
                    start_mm, (double)start_ss, start_year, start_month, start_day);

                int stop_year = stopDatePicker.Value.Year;
                int stop_month = stopDatePicker.Value.Month;
                int stop_day = stopDatePicker.Value.Day;
                int stop_hh = stopTimePicker.Value.Hour;
                int stop_mm = stopTimePicker.Value.Minute;
                int stop_ss = stopTimePicker.Value.Second;
                One_Sgp4.EpochTime stopTime = new One_Sgp4.EpochTime(stop_hh,
                    stop_mm, (double)stop_ss, stop_year, stop_month, stop_day);

                // create empty Lists and data containers for Data
                satTleData = new List<One_Sgp4.Tle>();
                stationData = new List<Ground.Station>();

                toolStripStatusLabel3.Text = "Status: Checking Data";
                //check if contacts vector has not been already created or loaded
                //from save file
                bool resetScenario = true;
                if (contactsVector == null)
                {
                    contactsVector = new Definition.ContactWindowsVector();
                    contactsVector.setStartTime(startTime);
                    contactsVector.setStopTime(stopTime);
                    toolStripStatusLabel3.Text = "Status: Reading Data";
                    //get selected Satellites to calculate Orbits
                    for (int i = 0; i < checkedSatellites.Items.Count; i++)
                    {
                        if (checkedSatellites.GetItemChecked(i))
                        {
                            One_Sgp4.Tle sattle = _MainDataBase.getTleDataFromDB(checkedSatellites.Items[i].ToString());
                            satTleData.Add(sattle);
                        }
                    }
                    //get selected GroundSTations for Calculations
                    for (int i = 0; i < checkedStations.Items.Count; i++)
                    {
                        if (checkedStations.GetItemChecked(i))
                        {
                            Ground.Station station = _MainDataBase.getStationFromDB(checkedStations.Items[i].ToString());
                            stationData.Add(station);
                        }
                    }

                    //starting with the orbit calculations
                    toolStripStatusLabel3.Text = "Status: Calculating Contacts";
                    Application.DoEvents();
                    Performance.TimeMeasurement tm1 = new Performance.TimeMeasurement();
                    tm1.activate();
                    /*
                     * Orbits ar Calculated here using Task[] to compute in 
                     * multiple threads without woring about the number of
                     * available CPU's.
                    */
                    One_Sgp4.Sgp4[] tasks = new One_Sgp4.Sgp4[satTleData.Count()];
                    Task[] threads = new Task[satTleData.Count()];
                    for (int i = 0; i < satTleData.Count(); i++)
                    {
                        tasks[i] = new One_Sgp4.Sgp4(satTleData[i], Properties.Settings.Default.Wgs);
                        tasks[i].setStart(startTime, stopTime, accuracy / 60.0);
                        threads[i] = new Task(tasks[i].starThread);
                    }
                    for (int i = 0; i < threads.Count(); i++)
                    {
                        //start each Thread
                        threads[i].Start();
                    }
                    try
                    {
                        //wait till all threads are finished
                        Task.WaitAll(threads);
                    }
                    catch (AggregateException ae)
                    {
                        //Logg any exceptions thrown
                        logRichTextBox.Text = logRichTextBox.Text + ae.InnerExceptions[0].Message + "\n";
                    }

                    /*
                     * Calculate the contact windows for each ground station
                     * from the selected ground stations and calculated orbits
                     * from bevor. This is also done in multiple threads using
                     * the Task[] function.
                     */
                    for (int i = 0; i < satTleData.Count(); i++)
                    {
                        Ground.InView[] inViews = new Ground.InView[stationData.Count()];
                        Task[] inThreads = new Task[stationData.Count()];
                        for (int k = 0; k < stationData.Count(); k++)
                        {
                            inViews[k] = new Ground.InView(stationData[k], startTime, tasks[i].getRestults(), satTleData[i].getName(), accuracy);
                            inThreads[k] = new Task(inViews[k].calcContactWindows);
                        }
                        for (int k = 0; k < stationData.Count(); k++)
                        {
                            //start every thread
                            inThreads[k].Start();
                        }
                        try
                        {
                            //whait for all threads to finish
                            Task.WaitAll(inThreads);
                        }
                        catch (AggregateException ae)
                        {
                            logRichTextBox.Text = logRichTextBox.Text + ae.InnerException.Message + "\n";
                        }
                        for (int k = 0; k < stationData.Count(); k++)
                        {
                            contactsVector.add(inViews[k].getResults());
                        }
                    }
                    string perfResCalc = tm1.getValueAndDeactivate();
                    toolStripStatusLabel3.Text = "Status: Contact Windows Calculated";
                }
                else
                {
                    startTime = contactsVector.getStartTime();
                    stopTime = contactsVector.getStopTime();
                    resetScenario = false;
                }

                //create save name String for all files that are saved automatacly
                DateTime time = DateTime.Now;
                string format = "dd-MM-yyyy_HHmmss";
                string SaveName = time.ToString(format);

                /*
                 * Check if the auto save functions should be enabled
                 * this saves the calculated contact windows and the image
                 * generated to schow a visible representation of the 
                 * finisched schedule
                 */
                if (checkAutoSaveImage.Checked)
                {
                    toolStripStatusLabel3.Text = "Status: Auto Saving Image";
                    string savePath = Properties.Settings.Default.SavePath;
                    Image contImages = Drawer.ContactsDrawer.drawContacts(contactsVector, true);
                    contImages.Save(savePath + "\\" + SaveName + "-UnScheduled.bmp");
                    toolStripStatusLabel3.Text = "Status: Saved Image";
                }
                if (checkAutoSaveSchedule.Checked)
                {
                    toolStripStatusLabel3.Text = "Status: Auto Saving Contacts";
                    string savePath = Properties.Settings.Default.SavePath;
                    DataBase.SaveLoad.saveToFile(savePath + "\\" + SaveName + ".xml", contactsVector, this);
                    toolStripStatusLabel3.Text = "Status: Saving Contacts";
                }

                toolStripStatusLabel3.Text = "Status: Starting Scheduler";
                //Set Scheduling Problem
                Scheduler.SchedulingProblem problem = new Scheduler.SchedulingProblem();
                problem.setContactWindows(contactsVector);
                //if (resetScenario)
                    problem.removeUnwantedContacts(Convert.ToInt32(minDurationTextBox.Text));
                /*
                 * Generate the selected Scenarios
                 * These are defined in the SchedulingProblem Class
                 * Other Scenarios can be selected here if they are added
                 */
                if (resetScenario != false)
                {
                    if (comboScenarioBox.SelectedIndex == 0)
                    {
                        problem.GenerateSzenarioA();
                    }
                    if (comboScenarioBox.SelectedIndex == 1)
                    {
                        problem.GenerateSzenarioB(Int32.Parse(randomSeedTextBox.Text));
                    }
                    if (comboScenarioBox.SelectedIndex == 2)
                    {
                        problem.GenerateSzenarioC(Int32.Parse(randomSeedTextBox.Text));
                    }
                    if (comboScenarioBox.SelectedIndex == 3)
                    {
                        problem.GenerateSzenarioD(Int32.Parse(randomSeedTextBox.Text));
                    }
                }

                /*
                 * The contact windows that have been calculate are randomized
                 * to imporve the result of the greedy algorithms. If the
                 * turning the randomiziation off will lead to the greedy
                 * algorithms to only schedule contacts for the first few 
                 * groundstation ignoring others.
                 */
                problem.getContactWindows().randomize(Int32.Parse(randomSeedTextBox.Text));

                /*
                 * The selected Scheduler starts here to calculate a solution
                 * to the scheduling problem. New Schedulers can be added here
                 * 
                 */
                toolStripStatusLabel3.Text = "Status: Running Scheduler";
                Performance.TimeMeasurement tm = new Performance.TimeMeasurement();
                //Start Scheduling

                //-----------------------------------------------------------------
                //---------------------------Add New SCHEDULER HERE-----------------
                //-----------------------------------------------------------------




                //-----------------------------------------------------------------
                //-----------------------------------------------------------------
                //-----------------------------------------------------------------
                //-----------GENETIC
                if (radioGenetic.Checked)
                {
                    toolStripStatusLabel3.Text = "Status: Genetor Running";
                    Scheduler.GeneticScheduler genetic = new Scheduler.GeneticScheduler();
                    if (genRunTimeCheck.Checked)
                    {
                        genetic.RunForCertainTime(true, (double)genMaxTime.Value);
                    }
                    genetic.setFormToUpdate(this);
                    //Set settings
                    genetic.setCreationPercentage((int)genStartChance.Value);
                    genetic.setMaxNumberOfGeneration((int)genMaxGen.Value);
                    genetic.setMutationPercentage((int)genMutation.Value);
                    genetic.setPopulationSize((int)genPopsize.Value);

                    //solve conflicts optional
                    if (checkSolveConflicts.Checked)
                    {
                        genetic.setSolveConflictsAfterRun(true);
                    }
                    if (checkConflictHandling.Checked)
                    {
                        genetic.setConflictHandeling(true);
                    }
                    tm.activate();
                    genetic.CalculateSchedule(problem);
                    calcTimeLabel.Text = tm.getValueAndDeactivate() + " s";
                    generationLabel.Text = genetic.getNrOfGenerations().ToString();
                    contactsVector = genetic.getFinischedSchedule();
                }
                //-----------------------------------------------------------------
                //-----------------------------------------------------------------
                //-----------------------------------------------------------------
                //-----------GREEDY
                if (radioGreedy.Checked)
                {
                    if (comboBox4.SelectedIndex == 0)
                    {
                        toolStripStatusLabel3.Text = "Status: Greedy Running";
                        Scheduler.EftGreedyScheduler greedy = new Scheduler.EftGreedyScheduler();
                        greedy.setFormToUpdate(this);
                        tm.activate();
                        greedy.CalculateSchedule(problem);
                        calcTimeLabel.Text = tm.getValueAndDeactivate() + " s";
                        generationLabel.Text = " --";
                        contactsVector = greedy.getFinischedSchedule();
                    }
                    if (comboBox4.SelectedIndex == 1)
                    {
                        toolStripStatusLabel3.Text = "Status: Fair Greedy Running";
                        Scheduler.FairGreedyScheduler greedy = new Scheduler.FairGreedyScheduler();
                        greedy.setFormToUpdate(this);
                        tm.activate();
                        greedy.CalculateSchedule(problem);
                        calcTimeLabel.Text = tm.getValueAndDeactivate() + " s";
                        generationLabel.Text = " --";
                        contactsVector = greedy.getFinischedSchedule();
                    }
                }
                //-----------------------------------------------------------------
                /*
                 * After calculation of the schedule the visual representation
                 * of the Schedule is drawn and if selected saved into its
                 * output folder.
                 */
                toolStripStatusLabel3.Text = "Status: Scheduler finisched";

                //Draw scheduled data to Main form
                pictureBox2.Image = Drawer.ContactsDrawer.drawContacts(contactsVector, false);
                pictureBox2.Width = pictureBox2.Image.Width;
                pictureBox2.Height = pictureBox2.Image.Height;

                //check if auto save of images is enabled
                //if yes then save files
                if (checkAutoSaveImage.Checked)
                {
                    toolStripStatusLabel3.Text = "Status: Auto Saving Image";
                    string savePath = Properties.Settings.Default.SavePath;
                    Image contImages = Drawer.ContactsDrawer.drawContacts(contactsVector, false);
                    if (radioGreedy.Checked)
                        contImages.Save(savePath + "\\" + SaveName + "-Scheduled-Greedy.bmp");
                    if (radioGenetic.Checked)
                        contImages.Save(savePath + "\\" + SaveName + "-Scheduled-Genetic.bmp");
                    toolStripStatusLabel3.Text = "Status: Saved Image";
                }


                /*
                 * The finisched Schedule is analized here by the Performance
                 * classes to deetermine its fairness values and fitness. The 
                 * value is represented as a number between 0 and 1. The value 
                 * of 1 means that every satellite and or station is used the
                 * same number of times as every other satellite and station.
                 */
                int _H = Performance.GeneralMeasurments.getNrOfScheduled(contactsVector);
                double _H1 = _H / (double)contactsVector.Count();
                double _H2 = Performance.GeneralMeasurments.getNrOfConflicts(contactsVector);
                double _H3 = Performance.GeneralMeasurments.getFairnesStations(contactsVector);
                double _H4 = Performance.GeneralMeasurments.getFairnesSatellites(contactsVector);

                fitnessValueLabel.Text = ((1.0 / 3.0) * (_H1 + _H3 + _H4)).ToString();

                contactNumberLabel.Text = _H.ToString() + " / " + contactsVector.Count().ToString();
                collisionLabel.Text = _H2.ToString();
                stationFairLabel.Text = _H3.ToString();
                fairSatLabel.Text = _H4.ToString();
                priorityLabel.Text = "Scheduled per priority: " + Performance.GeneralMeasurments.getNrOfPrioritysScheduled(contactsVector);
                label47.Text = Performance.GeneralMeasurments.getNrOfUweContacts(contactsVector);
                toolStripStatusLabel3.Text = "Status: Done";
                startScheduleButton.Enabled = true; ;
                for (int i = 0; i < 5; i++)
                {
                    SystemSounds.Beep.Play();
                    Thread.Sleep(100*i);
                }
        }

        //Draw all scheduled contacts onto form
        private void buttonReDraw_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Drawer.ContactsDrawer.drawContacts(contactsVector, false);
            pictureBox2.Width = pictureBox2.Image.Width;
            pictureBox2.Height = pictureBox2.Image.Height;
        }
        
        private void accuracySelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            accuracy = MainFunctions.selectAccuracy(accuracySelect.SelectedIndex);
        }

        private void UpdateAllLists()
        {
            _MainDataBase.displayAllSatellites(satelliteDataGrid);
            _MainDataBase.displayAllStations(staDataGridView);
            _MainDataBase.displayAllSatellites(checkedSatellites);
            _MainDataBase.displayAllStations(checkedStations);
        }

        private void genRunTimeCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (genRunTimeCheck.Checked)
            {
                genMaxGen.Enabled = false;
                genMaxTime.Enabled = true;
            }
            else
            {
                genMaxGen.Enabled = true;
                genMaxTime.Enabled = false;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            MainFunctions.maxPerfSelected(checkMaxPerf.Checked, warningLabel1,
                warningLabel2);
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPlotData.Checked)
            {
                comboPlottDataSettingsBox.Enabled = true;
            }
            else
            {
                comboPlottDataSettingsBox.Enabled = false;
            }
        }

        private void genPopsize_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.GeneticMaxPopulation = (int)genPopsize.Value;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = "Status: Opening File";
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Saved Contacts Files (.xml)|*.xml|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            DialogResult userSelect = openFileDialog1.ShowDialog();
            if (userSelect == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                toolStripStatusLabel3.Text = "Status: Loading SaveFile";
                contactsVector = DataBase.SaveLoad.loadFile(filePath, this);
                UpdateAllLists();

                toolStripStatusLabel3.Text = "Status: Updating Data";
                //Update selected satellites and Groundstations list
                foreach (string name in contactsVector.getSatelliteNames())
                {
                    int res = checkedSatellites.Items.IndexOf(name);
                    if ( res >= 0)
                    {
                        checkedSatellites.SetItemChecked(res, true);
                    }
                }
                foreach (string name in contactsVector.getStationNames())
                {
                    int res = checkedStations.Items.IndexOf(name);
                    if (res >= 0)
                    {
                        checkedStations.SetItemChecked(res, true);
                    }
                }
                startTimePicker.Value = contactsVector.getStartTime().toDateTime();
                stopTimePicker.Value = contactsVector.getStopTime().toDateTime();
                startDatePicker.Value = startTimePicker.Value;
                stopDatePicker.Value = stopTimePicker.Value;
                startTimePicker.Enabled = false;
                startDatePicker.Enabled = false;
                stopTimePicker.Enabled = false;
                stopDatePicker.Enabled = false;
                checkedSatellites.Enabled = false;
                checkedStations.Enabled = false;
                toolStripStatusLabel3.Text = "Status: Done";
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = "Status: Saving Data";
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Open Contacts Files (.xml)|*.xml|All Files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;

            DialogResult userSelect = saveFileDialog1.ShowDialog();
            if (userSelect == DialogResult.OK)
            {
                string filePath = saveFileDialog1.FileName;
                DataBase.SaveLoad.saveToFile(filePath, contactsVector, this);
            }
            toolStripStatusLabel3.Text = "Status: Done";
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startTimePicker.Enabled = true;
            startDatePicker.Enabled = true;
            stopTimePicker.Enabled = true;
            stopDatePicker.Enabled = true;
            checkedSatellites.Enabled = true;
            checkedStations.Enabled = true;
            contactsVector = null;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MARRSS.Forms.Info info = new Forms.Info();
            info.Show();
            //MARRSS.Forms.AboutBox1 aboutBox = new Forms.AboutBox1();
            //aboutBox.ShowDialog();
        }

        private void radioGreedy_CheckedChanged(object sender, EventArgs e)
        {
            if (radioGenetic.Checked)
            {
                tabControl2.SelectedIndex = 0;
                checkPlotData.Enabled = true;
                comboPlottDataSettingsBox.Enabled = true;
                //tabControl2.Enabled = true;
            }
            else
            {
                tabControl2.SelectedIndex = 1;
                checkPlotData.Enabled = false;
                comboPlottDataSettingsBox.Enabled = false;
                //tabControl2.Enabled = false;
            }
        }

        private void outputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            DialogResult userSelect = folderBrowser.ShowDialog();
            if (userSelect == DialogResult.OK)
            {
                Properties.Settings.Default.LogPath = folderBrowser.SelectedPath;
                Properties.Settings.Default.SavePath = folderBrowser.SelectedPath;
                Properties.Settings.Default.Save();
            }
        }


        //Save displayed image to file
        private void buttonSaveImage_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Save Image Files (.bmp)|*.bmp|All Files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;

            DialogResult userSelect = saveFileDialog1.ShowDialog();
            if (userSelect == DialogResult.OK)
            {
                string filePath = saveFileDialog1.FileName;
                pictureBox2.Image.Save(filePath);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.PlotData = comboPlottDataSettingsBox.SelectedIndex + 1;
            Properties.Settings.Default.Save();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.SaveContacts = 1;
            Properties.Settings.Default.Save();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.SaveImages = 1;
            Properties.Settings.Default.Save();
        }

        //Delete selected satellite entry from Databse
        private void button4_Click_2(object sender, EventArgs e)
        {
            _MainDataBase.deleteTle(satelliteNameLabel.Text);
            _MainDataBase.deleteSatellite(satelliteNameLabel.Text);
            _MainDataBase.displayAllSatellites(satelliteDataGrid);
            UpdateAllLists();
        }

        //Delete selected ground station entry from Database
        private void button6_Click_1(object sender, EventArgs e)
        {
            _MainDataBase.deleteStation(label20.Text);
            _MainDataBase.displayAllStations(staDataGridView);
            UpdateAllLists();
        }

        private void staDataGridView_SelectionChanged_1(object sender, EventArgs e)
        {
            try
            {
                Ground.Station st = _MainDataBase.getStationFromDB(
                    staDataGridView.SelectedRows[0].Cells[0].Value.ToString());
                label20.Text = st.getName();
                label56.Text = st.getLongitude().ToString();
                label55.Text = st.getLatitude().ToString();
                label54.Text = st.getHeight().ToString() +" m";
                label53.Text = st.getNrOfAntennas().ToString();
                Pen penSelected = new Pen(Color.Red, 4);
                Image image = new Bitmap(imgStation);
                Point p = st.getGeoCoordinate().toPoint(image.Width, image.Height);
                using (var graphics = Graphics.FromImage(image))
                {
                    graphics.DrawRectangle(penSelected, p.X-10, p.Y-10, 20, 20);
                }
                pictureBox3.Image = image;
            }
            catch
            {
                label20.Text = " -- ";
            }
        }

        private void satelliteDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (!_MainDataBase.connected())
            {
                _MainDataBase.connectDB();
            }
            try
            {
                satelliteNameLabel.Text = satelliteDataGrid.SelectedRows[0].Cells[0].Value.ToString();

                One_Sgp4.Tle tle = _MainDataBase.getTleDataFromDB(satelliteNameLabel.Text);
                if (tle.getStartYear() < 85)
                {
                    if (tle.getStartYear() > 10)
                    {
                        SatLabel1.Text = "20" + tle.getStartYear().ToString();
                    }
                    else
                    {
                        SatLabel1.Text = "200" + tle.getStartYear().ToString();
                    }
                }
                else
                {
                    SatLabel1.Text = "19" + tle.getStartYear().ToString();
                }
                SatLabel2.Text = tle.getStartNr().ToString();
                SatLabel3.Text = tle.getNoradID().ToString();
                if (tle.getClassification() == 0)
                    SatLabel4.Text = "UNCLASSIFIED";
                if (tle.getClassification() == 1)
                    SatLabel4.Text = "CLASSIFIED";
                if (tle.getClassification() == 1)
                    SatLabel4.Text = "SECRET";
                SatLabel5.Text = tle.getSetNumber().ToString();
                    
                pictureBox4.Image = Drawer.MapDrawer.drawSatellite(tle);
            }
            catch
            {
                satelliteNameLabel.Text = " -- ";
            }
        }

        //Create new Schedule
        private void label1_Click(object sender, EventArgs e)
        {
            startTimePicker.Enabled = true;
            startDatePicker.Enabled = true;
            stopTimePicker.Enabled = true;
            stopDatePicker.Enabled = true;
            checkedSatellites.Enabled = true;
            checkedStations.Enabled = true;
            contactsVector = null;
        }

        //Load existing Schedule
        private void label3_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = "Status: Opening File";
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Saved Contacts Files (.xml)|*.xml|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            DialogResult userSelect = openFileDialog1.ShowDialog();
            if (userSelect == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                toolStripStatusLabel3.Text = "Status: Loading SaveFile";
                contactsVector = DataBase.SaveLoad.loadFile(filePath, this);
                UpdateAllLists();

                toolStripStatusLabel3.Text = "Status: Updating Data";
                //Update selected satellites and Groundstations list
                foreach (string name in contactsVector.getSatelliteNames())
                {
                    int res = checkedSatellites.Items.IndexOf(name);
                    if (res >= 0)
                    {
                        checkedSatellites.SetItemChecked(res, true);
                    }
                }
                foreach (string name in contactsVector.getStationNames())
                {
                    int res = checkedStations.Items.IndexOf(name);
                    if (res >= 0)
                    {
                        checkedStations.SetItemChecked(res, true);
                    }
                }
                startTimePicker.Value = contactsVector.getStartTime().toDateTime();
                stopTimePicker.Value = contactsVector.getStopTime().toDateTime();
                startDatePicker.Value = startTimePicker.Value;
                stopDatePicker.Value = stopTimePicker.Value;
                startTimePicker.Enabled = false;
                startDatePicker.Enabled = false;
                stopTimePicker.Enabled = false;
                stopDatePicker.Enabled = false;
                checkedSatellites.Enabled = false;
                checkedStations.Enabled = false;
                toolStripStatusLabel3.Text = "Status: Done";
            }
        }

        //Update the UTC Time on the form
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime time = DateTime.UtcNow;
            string format = "dd-MM-yyyy HH:mm";
            toolStripStatusLabel4.Text = time.ToString(format) + " UTC";
        }

        //draw ALL contact windows onto form
        private void button7_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Drawer.ContactsDrawer.drawContacts(contactsVector, true);
            pictureBox2.Width = pictureBox2.Image.Width;
            pictureBox2.Height = pictureBox2.Image.Height;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();

            logRichTextBox.Clear();
            startScheduleButton.Enabled = false;
            toolStripStatusLabel3.Text = "Status: Starting";
            //Set Start and Stop Time

            int start_year = startDatePicker.Value.Year;
            int start_month = startDatePicker.Value.Month;
            int start_day = startDatePicker.Value.Day;
            int start_hh = startTimePicker.Value.Hour;
            int start_mm = startTimePicker.Value.Minute;
            int start_ss = startTimePicker.Value.Second;
            One_Sgp4.EpochTime startTime = new One_Sgp4.EpochTime(start_hh,
                start_mm, (double)start_ss, start_year, start_month, start_day);

            int stop_year = stopDatePicker.Value.Year;
            int stop_month = stopDatePicker.Value.Month;
            int stop_day = stopDatePicker.Value.Day;
            int stop_hh = stopTimePicker.Value.Hour;
            int stop_mm = stopTimePicker.Value.Minute;
            int stop_ss = stopTimePicker.Value.Second;
            One_Sgp4.EpochTime stopTime = new One_Sgp4.EpochTime(stop_hh,
                stop_mm, (double)stop_ss, stop_year, stop_month, stop_day);

            // create empty Lists and data containers for Data
            satTleData = new List<One_Sgp4.Tle>();
            stationData = new List<Ground.Station>();

            toolStripStatusLabel3.Text = "Status: Checking Data";
            //check if contacts vector has not been already created or loaded
            //from save file
            contactsVector = new Definition.ContactWindowsVector();
            contactsVector.setStartTime(startTime);
            contactsVector.setStopTime(stopTime);

            toolStripStatusLabel3.Text = "Status: Reading Data";
            //get selected Satellites to calculate Orbits
            for (int i = 0; i < checkedSatellites.Items.Count; i++)
            {
                if (checkedSatellites.GetItemChecked(i))
                {
                    One_Sgp4.Tle sattle = _MainDataBase.getTleDataFromDB(checkedSatellites.Items[i].ToString());
                    satTleData.Add(sattle);
                }
            }
            //get selected GroundSTations for Calculations
            for (int i = 0; i < checkedStations.Items.Count; i++)
            {
                if (checkedStations.GetItemChecked(i))
                {
                    Ground.Station station = _MainDataBase.getStationFromDB(checkedStations.Items[i].ToString());
                    stationData.Add(station);
                }
            }

            //calculate Orbits
            toolStripStatusLabel3.Text = "Status: Calculating Contacts";
            Application.DoEvents();
            Performance.TimeMeasurement tm1 = new Performance.TimeMeasurement();
            tm1.activate();

            //-------------------------------------------------------------
            //Calculate orbits using Tasks
            //Each Satellite is calculated in another Thread
            //thus speading up calculations immensly
            One_Sgp4.Sgp4[] tasks = new One_Sgp4.Sgp4[satTleData.Count()];
            Task[] threads = new Task[satTleData.Count()];
            for (int i = 0; i < satTleData.Count(); i++)
            {
                tasks[i] = new One_Sgp4.Sgp4(satTleData[i], Properties.Settings.Default.Wgs);
                tasks[i].setStart(startTime, stopTime, accuracy / 60.0);
                threads[i] = new Task(tasks[i].starThread);
            }
            for (int i = 0; i < threads.Count(); i++)
            {
                threads[i].Start();
            }

            try
            {
                Task.WaitAll(threads);
            }
            catch (AggregateException ae)
            {
                //throw ae.Flatten();
                logRichTextBox.Text = logRichTextBox.Text + ae.InnerExceptions[0].Message + "\n";
            }


            //-------------------------------------------------------------
            //Calculate contacts in another Thread
            //Each set of contacts for a Satellite is calculated in another Thread
            //thus speading up calculations immensly
            for (int i = 0; i < satTleData.Count(); i++)
            {
                Ground.InView[] inViews = new Ground.InView[stationData.Count()];
                Task[] inThreads = new Task[stationData.Count()];
                for (int k = 0; k < stationData.Count(); k++)
                {
                    inViews[k] = new Ground.InView(stationData[k], startTime, tasks[i].getRestults(), satTleData[i].getName(), accuracy);
                    inThreads[k] = new Task(inViews[k].calcContactWindows);
                }
                for (int k = 0; k < stationData.Count(); k++)
                {
                    inThreads[k].Start();
                }
                Task.WaitAll(inThreads);
                for (int k = 0; k < stationData.Count(); k++)
                {
                    contactsVector.add(inViews[k].getResults());
                }
            }
            string perfResCalc = tm1.getValueAndDeactivate();
            toolStripStatusLabel3.Text = "Status: Contact Windows Calculated";
            toolStripStatusLabel3.Text = "Status: Starting Scheduler";
            //Set Scheduling Problem
            Scheduler.SchedulingProblem problem = new Scheduler.SchedulingProblem();
            problem.setContactWindows(contactsVector);
            problem.removeUnwantedContacts(Convert.ToInt32(minDurationTextBox.Text));
            //check if loading from SaveFile
            //if Yes then one does not have to set Szenarios
            problem.getContactWindows().randomize(Int32.Parse(randomSeedTextBox.Text));

            for (int i = 0; i < contactsVector.Count(); i++)
            {
                toolStripStatusLabel3.Text = "Status: Fair Greedy Running";
                Scheduler.FairGreedyScheduler greedy = new Scheduler.FairGreedyScheduler();
                greedy.setFormToUpdate(this);
                //tm.activate();
                greedy.BruteForceSchedule(problem, i);
                //label37.Text = tm.getValueAndDeactivate() + " s";
                generationLabel.Text = " --";
                contactsVector = greedy.getFinischedSchedule();
                Application.DoEvents();

                toolStripStatusLabel3.Text = "Status: Scheduler finisched";

                //Draw scheduled data to Main form
                pictureBox2.Image = Drawer.ContactsDrawer.drawContacts(contactsVector, false);
                pictureBox2.Width = pictureBox2.Image.Width;
                pictureBox2.Height = pictureBox2.Image.Height;

                //Get Information of finisched Schedule
                //fairnes is a value from 0 to 1 
                //1 meaning every satellite or station is contacted / used equally
                int _H = Performance.GeneralMeasurments.getNrOfScheduled(contactsVector);
                double _H1 = _H / (double)contactsVector.Count();
                double _H2 = Performance.GeneralMeasurments.getNrOfConflicts(contactsVector);
                double _H3 = Performance.GeneralMeasurments.getFairnesStations(contactsVector);
                double _H4 = Performance.GeneralMeasurments.getFairnesSatellites(contactsVector);

                fitnessValueLabel.Text = ((1.0 / 3.0) * (_H1 + _H3 + _H4)).ToString();
                contactNumberLabel.Text = _H.ToString() + " / " + contactsVector.Count().ToString();
                collisionLabel.Text = _H2.ToString();
                stationFairLabel.Text = _H3.ToString();
                fairSatLabel.Text = _H4.ToString();
                priorityLabel.Text = "Scheduled per priority: " + Performance.GeneralMeasurments.getNrOfPrioritysScheduled(contactsVector);
                label47.Text = Performance.GeneralMeasurments.getNrOfUweContacts(contactsVector);
                toolStripStatusLabel3.Text = "Status: Done";

                string res = i+": " + DateTime.Now.ToString() + " Contacts: " + contactNumberLabel.Text + "; " + fitnessLabel.Text + ": " + fitnessValueLabel.Text + "\n";
                richTextBox2.AppendText(res);
                for (int k = 0; k < contactsVector.Count(); k++)
                {
                    contactsVector.getAt(k).setExclusion(false);
                    contactsVector.getAt(k).unShedule();
                }
            }
        }

        private void importTLEsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _MainDataBase.closeDB();
            Forms.SatelliteForm satForm = new Forms.SatelliteForm();
            satForm.ShowDialog();
            UpdateAllLists();
        }

        private void wGSToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            wgs72MenuItem.Checked = true;
            wgs84MenuItem.Checked = false;
            Properties.Settings.Default.Wgs = 1;
            Properties.Settings.Default.Save();
        }

        private void wGS84ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            wgs72MenuItem.Checked = false;
            wgs84MenuItem.Checked = true;
            Properties.Settings.Default.Wgs = 0;
            Properties.Settings.Default.Save();
        }

        private void addGroundStationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.StationForm addStation = new Forms.StationForm();
            addStation.ShowDialog();
            UpdateAllLists();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DialogResult result1 = MessageBox.Show("Exit Programm?",
            //    "Attention",
            //    MessageBoxButtons.YesNo);
            //if (result1 == DialogResult.Yes)
                this.Close();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            string satname = satelliteDataGrid.SelectedRows[0].Cells[0].Value.ToString();
            One_Sgp4.Tle tle = _MainDataBase.getTleDataFromDB(satelliteNameLabel.Text);
            _MainDataBase.deleteSatellite(satname);
            _MainDataBase.deleteTle(tle.getNoradID());
            UpdateAllLists();
        }

        private void deleteSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ground.Station st = _MainDataBase.getStationFromDB(
                    staDataGridView.SelectedRows[0].Cells[0].Value.ToString());
            _MainDataBase.deleteStation(st.getName());
            UpdateAllLists();
        }

        private void label59_Click(object sender, EventArgs e)
        {
            _MainDataBase.closeDB();
            Forms.SatelliteForm satForm = new Forms.SatelliteForm();
            satForm.setSelection(3);
            satForm.ShowDialog();
            UpdateAllLists();
        }

        /*
         * Form Actions, Interactions and mouse over
         * 
         */

        /*
        * Side Panel Interactions
        * 
        */
        //---------------------------Satellite Button----------------
        private void button2_Click(object sender, EventArgs e)
        {
            MainFunctions.sidePanelAction(panel1, satellitePanel);
        }
        //---------------------------Schedule Button----------------
        private void button1_Click(object sender, EventArgs e)
        {
            MainFunctions.sidePanelAction(panel1, schedulePanel);
        }
        //---------------------------Ground Station Button----------------
        private void button3_Click(object sender, EventArgs e)
        {
            MainFunctions.sidePanelAction(panel1, groundPanel);
        }
        //------------------------------end Sidepanel Interaction----------
        //-----------------------------------------------------------------

        /*
        * Mouse over actions and highligting of Text
        * 
        */
        private void label1_MouseEnter(object sender, EventArgs e)
        {
            newScheduleButton.ForeColor = Color.CadetBlue;
        }
        private void label1_MouseLeave(object sender, EventArgs e)
        {
            newScheduleButton.ForeColor = Color.Black;
        }
        private void label3_MouseEnter(object sender, EventArgs e)
        {
            openScheduleButton.ForeColor = Color.CadetBlue;
        }
        private void label3_MouseLeave(object sender, EventArgs e)
        {
            openScheduleButton.ForeColor = Color.Black;
        }
        private void label5_MouseEnter(object sender, EventArgs e)
        {
            addStationButton.ForeColor = Color.CadetBlue;
        }
        private void label5_MouseLeave(object sender, EventArgs e)
        {
            addStationButton.ForeColor = Color.Black;
        }
        private void label2_MouseEnter(object sender, EventArgs e)
        {
            AddSatelliteButton.ForeColor = Color.CadetBlue;
        }
        private void label2_MouseLeave(object sender, EventArgs e)
        {
            AddSatelliteButton.ForeColor = Color.Black;
        }
        private void updateTleButton_MouseEnter(object sender, EventArgs e)
        {
            updateTleButton.ForeColor = Color.CadetBlue;
        }
        private void updateTleButton_MouseLeave(object sender, EventArgs e)
        {
            updateTleButton.ForeColor = Color.Black;
        }

        /*
        * Menu Items Actions
        * 
        */
        private void checkAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedSatellites.Items.Count; i++)
            {
                checkedSatellites.SetItemChecked(i, true);
            }
        }
        private void uncheckAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedSatellites.Items.Count; i++)
            {
                checkedSatellites.SetItemChecked(i, false);
            }
        }
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedStations.Items.Count; i++)
            {
                checkedStations.SetItemChecked(i, true);
            }
        }
        private void uncheckAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedStations.Items.Count; i++)
            {
                checkedStations.SetItemChecked(i, false);
            }
        }

        /*
         * Add Ground stations and satellites
         * */
        //Add Satellite to DataBase
        private void label2_Click(object sender, EventArgs e)
        {
            Forms.SatelliteForm satForm = new Forms.SatelliteForm();
            satForm.ShowDialog();
            UpdateAllLists();
        }

        //Add a ground station to Database
        private void label5_Click(object sender, EventArgs e)
        {
            Forms.StationForm addStation = new Forms.StationForm();
            addStation.ShowDialog();
            UpdateAllLists();
        }
        /*
         * Gloabel Progress Bar function to update Progress Bar of main Form
         */
        public void incrementProgressBar()
        {
            MainFunctions.incrementProgressBar(progressBar1);
        }
        public void resetProgressBar()
        {
            MainFunctions.resetProgressBar(progressBar1);
        }
        public void updateProgressBar(int val)
        {
            MainFunctions.updateProgressBar(progressBar1, val);
        }
        public void setProgressBar(int val)
        {
            MainFunctions.setProgressBar(progressBar1, val);
        }

        /*
         * Draw Ground Stations and Satlites
         */
        private void drawGroundStations()
        {
            imgStation = Drawer.MapDrawer.drawStation(staDataGridView.Rows, _MainDataBase);
            pictureBox3.Image = imgStation;
        }

        private void documentationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO
            //ADD link to GitHUB Wiki
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //TODO
            //AD link to GitHub Help
        }



    }
}
