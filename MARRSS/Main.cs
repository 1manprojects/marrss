/**
* ----------------------------------------------------------------
* Nikolai Jonathan Reed 
*
* 
* Copyright (c) 2017, Nikolai Reed, 1manprojects.de
* All rights reserved.
*
* Licensed under
* Creative Commons Attribution NonCommercial (CC-BY-NC)
*/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

using MARRSS.Performance;
using MARRSS.Scheduler;
using System.Collections.Specialized;

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
        private List<One_Sgp4.Tle> satTleData; //!< List of TLE objects
        private List<Ground.Station> stationData; //!< List of Ground Stations
        private Definition.ContactWindowsVector contactsVector; //!< Contact Windows Vector stores all contacts

        private DataBase.DataBase _MainDataBase; //!< Database connection

        private ObjectiveFunction objectivefunct; //!< Objective function to schedule against

        private Interface2.SchedulerInterface scheduler = null; //!< Scheduler Interface current used scheduler

        Image imgSatellite = null; //!< Images used to display satellite on ground path
        Image imgStation = null; //!< Image used to display stations on Earth

        private int tle_timeCounter;

        //! Main Startup Function
        /*!
            Startup function reading from settings loading Database and if it
            does not exist it will create a new DataBase file
        */
        public Main()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            InitializeComponent();
            //Create new Database or connect to existing one
            _MainDataBase = new DataBase.DataBase();
            UpdateAllLists();
            radioGenetic.PerformClick();

            comboScenarioBox.SelectedIndex = 0;
            //set up current time
            DateTime time = DateTime.UtcNow;
            string format = "dd-MM-yyyy HH:mm";
            toolStripStatusLabel4.Text = time.ToString(format) + " UTC";
            //Load images from Resources
            imgSatellite = Properties.Resources.worldsmaller;
            imgStation = Properties.Resources.worldsmaller;
            //show Log Panel if set to true in settings            
            if (Properties.Settings.Default.log_ShowLog)
            {
                logPanel.Visible = true;
            }
            //Draws ground stations on World Image
            drawGroundStations();
            tle_timeCounter = 0;
            if (Properties.Settings.Default.tle_AutoUpdate && Properties.Settings.Default.tle_UpdateTime == 0)
            {
                Forms.SatelliteForm.UpdateTLeFromWeb();
            }
            List<string> objectiveFunctionnames = Forms.ObjectiveBuilderForm.getSavedObjectiveNames();
            //savedObjectives = Properties.Objective.Default.object_List;
            for (int i = 0; i < objectiveFunctionnames.Count; i++)
                objectiveComboBox.Items.Add(objectiveFunctionnames[i]);
            if (objectiveComboBox.Items.Count > 0)
                objectiveComboBox.SelectedIndex = 0;
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
        private void startSchedule(bool useBruteForce = false)
        {
            string logFile = MainFunctions.getLogFileName();
            prepareStart();
            updateLog(logFile, "Starting");
            //Set Start and Stop Time
            One_Sgp4.EpochTime startTime = getStartTime();
            One_Sgp4.EpochTime stopTime = getStopTime();
            updateLog(logFile, "StartTime: " + startTime.ToString());
            updateLog(logFile, "StartTime: " + stopTime.ToString());

            // create empty Lists and data containers for Data
            satTleData = new List<One_Sgp4.Tle>();
            stationData = new List<Ground.Station>();
            //check if contacts vector has not been already created or loaded
            //from save file
            bool resetScenario = true;
            if (contactsVector == null)
            {
                contactsVector = new Definition.ContactWindowsVector();
                contactsVector.setStartTime(startTime);
                contactsVector.setStopTime(stopTime);
                //get selected Satellites to calculate Orbits
                satTleData = getSatelliteData(logFile);
                stationData = getStationData(logFile);
                //starting with the orbit calculations
                updateLog(logFile, "Staring Orbit Calculations");
                //Calculate Orbits and Contact Windows
                CalculateContacts(startTime, stopTime, logFile);


            }
            else
            {
                // resuse old ContactWindows
                startTime = contactsVector.getStartTime();
                stopTime = contactsVector.getStopTime();
                resetScenario = false;
            }
                
            AutoSave(logFile);
            updateLog(logFile, "Setting Up Scheduler");
            //Set Scheduling Problem
            //set Objective Function
            setObjectiveFunction();
            string test = objectivefunct.ToString();
            //objectivefunct = new ObjectiveFunction(Global.Structs.ObjectiveEnum.DURATION,
            //    Global.Structs.ObjectiveEnum.FAIRNESSATELITE, Global.Structs.ObjectiveEnum.FAIRNESSTATION,
            //    Global.Structs.ObjectiveEnum.SCHEDULEDCONTACTS);

            SchedulingProblem problem = RunScheduler.setSchedulingProblem(contactsVector, objectivefunct);
            /* Generate the selected Scenarios
            * These are defined in the SchedulingProblem Class
            * Other Scenarios can be selected here if they are added
            */
            if (resetScenario != false)
            {
                getScenario(problem);
            }
            //enable time measurment Class
            TimeMeasurement tm = new Performance.TimeMeasurement();
            startScheduleButton.Enabled = true;
            scheduler = null;
            //create new scheduler object and set settings
            if (radioGenetic.Checked)
            {
                scheduler = RunScheduler.setScheduler(new GeneticScheduler(), this);
            }
            if (radioEFTGreedy.Checked)
            {
                scheduler = RunScheduler.setScheduler(new EftGreedyScheduler(), this);
            }
            if (radioGreedy.Checked)
            {
                scheduler = RunScheduler.setScheduler(new GreedyScheduler(), this);
            }
            //-----------------------------------------------------------------
            //---------------------------Add New SCHEDULER HERE-----------------
            //-----------------------------------------------------------------
            /*
            if (radioNEW.Checked
            {
                scheduler = RunScheduler.setScheduler(new Scheduler.ExampleScheduler(), this);
            }
            */
            //-----------------------------------------------------------------
            //-----------------------------------------------------------------
            //-----------------------------------------------------------------
            updateLog(logFile, "starting " + scheduler.ToString());
            //start Time Meassurment
            tm.activate();
            if (!useBruteForce)
            {
                RunScheduler.startScheduler(scheduler, problem);
            }
            else
            {
                RunScheduler.startBruteForce(scheduler, problem, this);
            }
            //get Time Measurment
            updateCalculationTime(tm.getValueAndDeactivate());
            //display resulst on main Page
            RunScheduler.displayResults(this, scheduler);
            //finisch clean up and write to logs if necesarry
            finischSchedule(scheduler.ToString(),logFile);
        }
        
        private void startScheduleButton_Click(object sender, EventArgs e)
        {
            if (startScheduleButton.Text == "Calculate Schedule")
            {
                bool useBruteForce = (Properties.Settings.Default.fair_BruteForce &&
                                        radioGreedy.Checked);
                objectivefunct = null;
                setObjectiveFunction();
                startSchedule(useBruteForce);
                //notifcation if done
                for (int i = 0; i < 5; i++)
                {
                    SystemSounds.Beep.Play();
                    Thread.Sleep(100 * i);
                }
            }
            //if Cancel button is pressed Cancel each scheduler if running
            else
            {
                if (scheduler != null)
                    scheduler.cancelCalculation();
            }
            startScheduleButton.Text = "Calculate Schedule";
            startScheduleButton.BackColor = Color.LightSkyBlue;
            startScheduleButton.Enabled = true;
        }

        private void setObjectiveFunction()
        {
            string name = objectiveComboBox.Items[objectiveComboBox.SelectedIndex].ToString();
            objectivefunct = new ObjectiveFunction( Forms.ObjectiveBuilderForm.getObjectiveEnumsByName(name));
        }

        //! Prepares Start of Schedule
        /*! 
            Clear labels on Main Form and show logs if set
        */
        private void prepareStart()
        {
            MainFunctions.checkAndCreateLogFolders();
            if (Properties.Settings.Default.log_ShowLog)
            {
                logPanel.Visible = true;
            }
            else
            {
                logPanel.Visible = false;
            }
            //Set defaults
            contactNumberLabel.Text = "--";
            generationLabel.Text = "--";
            collisionLabel.Text = "--";
            stationFairLabel.Text = "--";
            fairSatLabel.Text = "--";
            calcTimeLabel.Text = "--";
            priorityLabel.Text = "--";
            uweLabel.Text = "--";
            fitnessValueLabel.Text = "--";
            durationLabel.Text = "--";

            logRichTextBox.Clear();
            startScheduleButton.Text = "Cancel";
            startScheduleButton.BackColor = Color.LightCoral;
            startScheduleButton.Enabled = false;
        }

        //! gets the selected start time
        /*! 
         /return EpochTime startTime
        */
        private One_Sgp4.EpochTime getStartTime()
        {
            int start_year = startDatePicker.Value.Year;
            int start_month = startDatePicker.Value.Month;
            int start_day = startDatePicker.Value.Day;
            int start_hh = startTimePicker.Value.Hour;
            int start_mm = startTimePicker.Value.Minute;
            int start_ss = startTimePicker.Value.Second;
            One_Sgp4.EpochTime startTime = new One_Sgp4.EpochTime(start_hh,
                start_mm, (double)start_ss, start_year, start_month, start_day);
            return startTime;
        }

        //! gets the selected stop time
        /*! 
         /return EpochTime stopTime
        */
        private One_Sgp4.EpochTime getStopTime()
        {
            int stop_year = stopDatePicker.Value.Year;
            int stop_month = stopDatePicker.Value.Month;
            int stop_day = stopDatePicker.Value.Day;
            int stop_hh = stopTimePicker.Value.Hour;
            int stop_mm = stopTimePicker.Value.Minute;
            int stop_ss = stopTimePicker.Value.Second;
            One_Sgp4.EpochTime stopTime = new One_Sgp4.EpochTime(stop_hh,
                stop_mm, (double)stop_ss, stop_year, stop_month, stop_day);
            return stopTime;
        }

        //! Get the satellites selected for Schedule
        /*! 
         /param string Logfile
        */
        private List<One_Sgp4.Tle> getSatelliteData(string logfile)
        {
            satTleData = new List<One_Sgp4.Tle>();
            //get selected Satellites to calculate Orbits
            for (int i = 0; i < checkedSatellites.Items.Count; i++)
            {
                if (checkedSatellites.GetItemChecked(i))
                {
                    One_Sgp4.Tle sattle = _MainDataBase.getTleDataFromDB(checkedSatellites.Items[i].ToString());
                    satTleData.Add(sattle);
                    updateLog(logfile, "Adding Satellite: " + sattle.getName());
                }
            }
            return satTleData;
        }

        //! get the stations selected for Schedule
        /*! 
         /param string Logfile
        */
        private List<Ground.Station> getStationData(string logfile)
        {
            stationData = new List<Ground.Station>();
            //get selected GroundSTations for Calculations
            for (int i = 0; i < checkedStations.Items.Count; i++)
            {
                if (checkedStations.GetItemChecked(i))
                {
                    Ground.Station station = _MainDataBase.getStationFromDB(checkedStations.Items[i].ToString());
                    stationData.Add(station);
                    updateLog(logfile, "Adding Station: " + station.getName());
                }
            }
            return stationData;
        }

        //! Calculate Contact windows
        /*! 
         /param EpochTime starting time
         /param Epoch Time stoping time
         /param string Logfile
         * cacluated the orbits of selected satellites and then the contact windows
         * for each station in the given time frame
        */
        private void CalculateContacts(One_Sgp4.EpochTime start, One_Sgp4.EpochTime stop, string logfile)
        {
            TimeMeasurement timeMessurmentOribt = new Performance.TimeMeasurement();
            timeMessurmentOribt.activate();

            contactsVector = MainFunctions2.calculateContactWindows(satTleData, stationData, start, stop, logfile, this);
            
            string perfResCalc = timeMessurmentOribt.getValueAndDeactivate();
            updateLog(logfile, "Contact Windows Calculated in: " + perfResCalc + "sec.");
        }

        //! AutoSave Contacts and Schedule
        /*! 
         /param string logfile
         * Saves the contact windows as image and xml file
        */
        private void AutoSave(string logfile)
        {
            /*
            * Check if the auto save functions should be enabled
            * this saves the calculated contact windows and the image
            * generated to schow a visible representation of the 
            * finisched schedule
            */
            if (Properties.Settings.Default.global_AutoSave && Properties.Settings.Default.global_SaveSchedule)
            {
                string savePath = Properties.Settings.Default.global_Save_Path;
                Image contImages = Drawer.ContactsDrawer.drawContacts(contactsVector, true);
                contImages.Save(savePath + "\\" + logfile + "-UnScheduled.bmp");
                updateLog(logfile, "Saved Contact window image to File " + savePath + "\\" + logfile + " - UnScheduled.bmp");
            }
            if (Properties.Settings.Default.global_AutoSave && Properties.Settings.Default.global_SaveContacts)
            {
                string savePath = Properties.Settings.Default.global_Save_Path;
                DataBase.SaveLoad.saveToFile(savePath + "\\" + logfile + ".xml", contactsVector, this);
                updateLog(logfile, "Saved Contacts to XML-File " + savePath + "\\" + logfile + ".xml");
            }
        }

        //! get Selected Scenario
        /*! 
         * Generates the Scenario selected
        */
        private void getScenario(SchedulingProblem problem)
        {
            /*
                * Generate the selected Scenarios
                * These are defined in the SchedulingProblem Class
                * Other Scenarios can be selected here if they are added
                */
            if (comboScenarioBox.SelectedIndex == 0)
            {
                problem.GenerateSzenarioA();
            }
            if (comboScenarioBox.SelectedIndex == 1)
            {
                problem.GenerateSzenarioB(Properties.Settings.Default.global_Random_Seed);
            }
            if (comboScenarioBox.SelectedIndex == 2)
            {
                problem.GenerateSzenarioC(Properties.Settings.Default.global_Random_Seed);
            }
            if (comboScenarioBox.SelectedIndex == 3)
            {
                problem.GenerateSzenarioD(Properties.Settings.Default.global_Random_Seed);
            }
        }

        //! finisch and clean up after Schedule Calculation
        /*! 
         * Save calculated contactwindows to file if enabled
         * Calculate fairness values
         * Display information on Form
        */
        private void finischSchedule(string schedulerName, string logfile, int number = 0, bool bruteForce = false)
        {
            //Draw scheduled data to Main form
            pictureBox2.Image = Drawer.ContactsDrawer.drawContacts(contactsVector, false);
            pictureBox2.Width = pictureBox2.Image.Width;
            pictureBox2.Height = pictureBox2.Image.Height;

            //check if auto save of images is enabled
            //if yes then save files
            if (Properties.Settings.Default.global_AutoSave && Properties.Settings.Default.global_SaveSchedule)
            {
                string savePath = Properties.Settings.Default.global_Save_Path;
                Image contImages = Drawer.ContactsDrawer.drawContacts(contactsVector, false);
                if (radioEFTGreedy.Checked)
                    contImages.Save(savePath + "\\" + logfile + "-Scheduled-EFT-Greedy-"+ number +".bmp");
                if (radioGreedy.Checked)
                    contImages.Save(savePath + "\\" + logfile + "-Scheduled-Fair-Greedy-" + number + ".bmp");
                if (radioGenetic.Checked)
                    contImages.Save(savePath + "\\" + logfile + "-Scheduled-Genetic-" + number + ".bmp");
                updateLog(logfile, "Saved Calculated Schedule to Image (bmp) " + savePath + "\\" + logfile);
            }

            if (Properties.Settings.Default.log_AutoSave_Results)
            {
                List<string> results = new List<string>();
                results.Add("RunNumber: " + number);
                results.Add("Fitness Value:" + objectivefunct.getObjectiveResults().ToString());
                results.Add("Scheduled Contacts: " + fitnessLabel.Text + " / " + contactsVector.Count().ToString());
                results.Add("Collisions: " + collisionLabel.Text);
                results.Add("Fairnes Stations: " + stationFairLabel.Text);
                results.Add("Fairnes Satellites: " + fairSatLabel.Text);
                results.Add("Duration: " + durationLabel.Text + " sec.");
                results.Add("Calculation Time: " + calcTimeLabel.Text);
                results.Add("Scheduled per priority: " + uweLabel.Text );
                Log.writeResults(logfile, schedulerName, results);
                updateLog(logfile, "Results have been saved to File");
            }
            updateLog(logfile, "Done");
        }


        //! Update station and satellites lists on Main window
        /*! 
        */
        private void UpdateAllLists()
        {
            _MainDataBase.displayAllSatellites(satelliteDataGrid);
            _MainDataBase.displayAllStations(staDataGridView);
            _MainDataBase.displayAllSatellites(checkedSatellites);
            _MainDataBase.displayAllStations(checkedStations);
        }

        //! Create new Schedule
        /*! 
           \clears old contact vectors
        */
        private void clearScheduling()
        {
            startTimePicker.Enabled = true;
            startDatePicker.Enabled = true;
            stopTimePicker.Enabled = true;
            stopDatePicker.Enabled = true;
            checkedSatellites.Enabled = true;
            checkedStations.Enabled = true;
            contactsVector = null;
        }



        //! Update Labels 
        /*! 
           \param 
           \return 
        */
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

        //! Satellite grid on Selection Changed
        /*!
            Displays information about the currently selected satellite
        */
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

        //! Load Saved Schedule from File
        /*!
            opens File Dialog and will load a saved schedule from xml file
        */
        private void loadSavedSchedule()
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


        //! Timer Tick
        /*!
            every second Timer will tick and update the Time on the Form
            and if set update TLE data automaticaly
        */
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime time = DateTime.UtcNow;
            string format = "dd-MM-yyyy HH:mm";
            toolStripStatusLabel4.Text = time.ToString(format) + " UTC";
            if (Properties.Settings.Default.tle_AutoUpdate)
            {
                tle_timeCounter++;
                if (tle_timeCounter >= 60*60 && Properties.Settings.Default.secure_SavedLogin)
                {
                    tle_timeCounter = 0;
                    Forms.SatelliteForm.UpdateTLeFromWeb();
                }
            }
        }

        //! import TLE data into Datbase
        /*!
         /param int selection = 0 default selection to be set bevor form opens
         will add a satellite object or update existing ones in database
        */
        private void importTleData(int selection = 0)
        {
            _MainDataBase.closeDB();
            Forms.SatelliteForm satForm = new Forms.SatelliteForm();
            if (selection > 0)
                satForm.setSelection(3);
            satForm.ShowDialog();
            UpdateAllLists();
        }

        //! Add a Ground Stations to the Databse
        /*!
            
        */
        private void addGroundStationToDB()
        {
            Forms.StationForm addStation = new Forms.StationForm();
            addStation.ShowDialog();
            UpdateAllLists();
        }

        //! Update Log file  
        /*!
            calls the updateLog function in MainFunctison
        */
        private void updateLog(string file, string data)
        {
            MainFunctions.updateLog(file, data, this);
        }

        /*******************************************************************************************************
         * Form Actions, Interactions and mouse over
         * 
         *******************************************************************************************************/

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

        /*******************************************************************************************************
         * User Interactions
         * 
         *******************************************************************************************************/

        //! Redraw schedule Image
        /*! 
        */
        private void buttonReDraw_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Drawer.ContactsDrawer.drawContacts(contactsVector, false);
            pictureBox2.Width = pictureBox2.Image.Width;
            pictureBox2.Height = pictureBox2.Image.Height;
        }

        //! Load calculated schedule
        /*! 
        */
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadSavedSchedule();
        }

        //! Save calculated schedule to file
        /*! 
           \return void saves a xml file object of the scheduled contacts
        */
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

        //! Add a Sattellite to the Databse
        /*!
            
        */
        private void label2_Click(object sender, EventArgs e)
        {
            importTleData();
        }

        //! Add a Ground Stations to the Databse
        /*!
            
        */
        private void label5_Click(object sender, EventArgs e)
        {
            addGroundStationToDB();
        }

        //! Draws the Ground stations onto World Image
        /*!
            
        */
        private void drawGroundStations()
        {
            imgStation = Drawer.MapDrawer.drawStation(staDataGridView.Rows, _MainDataBase);
            pictureBox3.Image = imgStation;
        }

        //! oppens Link
        /*!
            
        */
        private void documentationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/1manprojects/marrss");
        }

        //! opens Link
        /*!
            
        */
        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/1manprojects/marrss");
        }

        //! Opens the Gloabal Settings Form
        /*!
            
        */
        private void settingsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MARRSS.Forms.SettingsForm settings = new Forms.SettingsForm();
            settings.Show(this);
        }

        //! Add a SAtellite to the Databse
        /*!
            
        */
        private void addSatelliteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            importTleData();
        }

        //! Add a Ground Stations to the Databse
        /*!
            
        */
        private void addGroundStationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            addGroundStationToDB();
        }

        //! Update TLE data
        /*!
            
        */
        private void updateTLEsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            importTleData(3);
        }

        //! Main Form on Load Event
        /*!
            
        */
        private void Main_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            startDatePicker.Value = now.Date;
            startTimePicker.Value = now.ToUniversalTime();
            now = now.AddDays(1.0);
            stopDatePicker.Value = now.Date;
            stopTimePicker.Value = now.ToUniversalTime();
        }


        //! opens Objective Builder Form
        /*!
            
        */
        private void objectiveBuilderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.ObjectiveBuilderForm obectiveBuilder = new Forms.ObjectiveBuilderForm();
            obectiveBuilder.Show(this);
        }

        //! Add a satellite to the Databse
        /*!
            
        */
        private void addSatelliteToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            importTleData();
        }

        //! Add a Ground Stations to the Databse
        /*!
            
        */
        private void addGroundStationToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            addGroundStationToDB();
        }

        //! Create new Schedule
        /*! 
        \clears old contact vectors
        */
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearScheduling();
        }

        //! Show Info Form
        /*! 
        */
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MARRSS.Forms.Info info = new Forms.Info();
            info.Show();
        }

        //! Save calculated schedule image
        /*! 
        \return saves a bmp file of the current schedule
        */
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


        //! Delete satellite object from DB
        /*! 
        */
        private void button4_Click_2(object sender, EventArgs e)
        {
            _MainDataBase.deleteTle(satelliteNameLabel.Text);
            _MainDataBase.deleteSatellite(satelliteNameLabel.Text);
            _MainDataBase.displayAllSatellites(satelliteDataGrid);
            UpdateAllLists();
        }

        //! Delete ground station object from DB
        /*! 
        */
        private void button6_Click_1(object sender, EventArgs e)
        {
            _MainDataBase.deleteStation(label20.Text);
            _MainDataBase.displayAllStations(staDataGridView);
            UpdateAllLists();
        }

        //! Create New Schedule
        /*!
        Clears contacts vector and resets form
        */
        private void label1_Click(object sender, EventArgs e)
        {
            clearScheduling();
        }

        //! Load Schedule from file
        /*!
        Load saved schedule from file
        */
        private void label3_Click(object sender, EventArgs e)
        {
            loadSavedSchedule();
        }

        //! Add a Satellite to the Databse
        /*!
            
        */
        private void label59_Click(object sender, EventArgs e)
        {
            importTleData(3);
        }


        //! Redraw Button
        /*!
            Redraws all contacts into image with unscheduled ones greyed out
        */
        private void button7_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Drawer.ContactsDrawer.drawContacts(contactsVector, true);
            pictureBox2.Width = pictureBox2.Image.Width;
            pictureBox2.Height = pictureBox2.Image.Height;
        }

        //! Add a Ground Stations to the Databse
        /*!
            
        */
        private void addGroundStationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //! Delete a object from the Satellite and TLE Database
        /*!
            
        */
        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            string satname = satelliteDataGrid.SelectedRows[0].Cells[0].Value.ToString();
            One_Sgp4.Tle tle = _MainDataBase.getTleDataFromDB(satelliteNameLabel.Text);
            _MainDataBase.deleteSatellite(satname);
            _MainDataBase.deleteTle(tle.getNoradID());
            UpdateAllLists();
        }

        //! Delete a object from the GroundStations Database
        /*!
            
        */
        private void deleteSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ground.Station st = _MainDataBase.getStationFromDB(
            staDataGridView.SelectedRows[0].Cells[0].Value.ToString());
            _MainDataBase.deleteStation(st.getName());
            UpdateAllLists();
        }

        //! add Satellite into db
        /*!
            
        */
        private void importTLEsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            importTleData();
        }

        //! Exit Programm
        /*!
            
        */
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*******************************************************************************************************
         * Public Funkction
         * 
         *******************************************************************************************************/

        //! increment Progress Bar on Main form
        /*!
            
        */
        public void incrementProgressBar()
        {
            MainFunctions.incrementProgressBar(progressBar1);
        }

        //! Resets the progress bar on main Form
        /*!
            
        */
        public void resetProgressBar()
        {
            MainFunctions.resetProgressBar(progressBar1);
        }
        //! Updates the Progressbar
        /*!
            /param int value to set progressbar
        */
        public void updateProgressBar(int val)
        {
            MainFunctions.updateProgressBar(progressBar1, val);
        }

        //! set the progress bar
        /*!
            /param value to update the progress bar
        */
        public void setProgressBar(int val)
        {
            MainFunctions.setProgressBar(progressBar1, val);
        }

        //! set Finess label on Main Form
        /*!
            /double value to display
        */
        public void setFitnessValue(double val)
        {
            fitnessValueLabel.Text = Convert.ToString(val);
        }

        //! set contats number label on Main Form
        /*!
            /double value to display
        */
        public void setContactsNumber(double val)
        {
            contactNumberLabel.Text = val.ToString() + " / " + contactsVector.Count().ToString();
        }

        //! set collisons label on Main Form
        /*!
            /double value to display
        */
        public void setCollisons(int val)
        {
            collisionLabel.Text = val.ToString();
        }

        //! set StationFairness label on Main Form
        /*!
            /double value to display
        */
        public void setFairnessStation(double val)
        {
            stationFairLabel.Text = val.ToString();
        }

        //! set FairnessStations label on Main Form
        /*!
            /double value to display
        */
        public void setFairnessSatellite(double val)
        {
            fairSatLabel.Text = val.ToString();
        }

        //! set duration label on Main Form
        /*!
            /double value to display
        */
        public void setDuration(double val)
        {
            durationLabel.Text = Convert.ToInt32(val).ToString() + " s.";
        }

        //! set Priority label on Main Form
        /*!
            /string value to display
        */
        public void setPriority(string val)
        {
            priorityLabel.Text = "Scheduled per priority: " + val;
        }

        //! set Number of Uwe3 contacts label on Main Form
        /*!
            /double value to display
        */
        public void setNumberOfUweContact(string val)
        {
            uweLabel.Text = val;
        }

        //! set generations label on Main Form
        /*!
            /double value to display
        */
        public void setNumberOfGeneration(int val)
        {
            generationLabel.Text = Convert.ToString(val);
        }

        //! set toolstrip label on Main Form
        /*!
            /double value to display
        */
        public void updateToolStrip(string text)
        {
            toolStripStatusLabel3.Text = text;
        }

        //! set calculation label on Main Form
        /*!
            /string time to display
        */
        public void updateCalculationTime(string val)
        {
            calcTimeLabel.Text = val + " sec.";
        }

        //! update Logon Main Form
        /*!
            /string information to display
        */
        public void updateLogTextBox(string data)
        {
            logRichTextBox.Text += "\n" + data;
            logRichTextBox.ScrollToCaret();
        }
    }
}
