using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MARRSS.DataBase;
using MARRSS.Definition;
using MARRSS.Interface2;
using MARRSS.Scheduler;
using MARRSS.Performance;
using One_Sgp4;

namespace MARRSS.Automated
{
    class AutomatedRun
    {
        private string schedulerName;
        private EpochTime startTime;
        private EpochTime stopTime;
        private List<string> satelliteList;
        private List<string> stationList;
        private int scenario;
        private string callback;
        private string settings;
        private string objectiveFunction;
        List<string> results;

        public AutomatedRun()
        {

        }

        public AutomatedRun(string name, EpochTime start, EpochTime stop, List<string> satellites,
            List<string> stations, int selectedScenario, string objective, string settingsString = null)
        {
            schedulerName = name;
            startTime = start;
            stopTime = stop;
            satelliteList = satellites;
            stationList = stations;
            scenario = selectedScenario;
            settings = settingsString;
            objectiveFunction = objective;
        }

        public bool runThisRun()
        {
            results = new List<string>();
            DataBase.DataBase db = new DataBase.DataBase();
            bool status = true;
            List<Ground.Station> stationData = new List<Ground.Station>();
            for (int i = 0; i < stationList.Count; i++)
            {
                Ground.Station station = db.getStationFromDB(stationList[i]);
                stationData.Add(station);
                //updateLog(logfile, "Adding Station: " + station.getName());
            }
            System.Windows.Forms.Application.DoEvents();
            List<One_Sgp4.Tle> tleData = new List<Tle>();
            for (int i = 0; i < satelliteList.Count; i++)
            {
                One_Sgp4.Tle sattle = db.getTleDataFromDB(satelliteList[i]);
                tleData.Add(sattle);
                //updateLog(logfile, "Adding Satellite: " + sattle.getName());
            }
            System.Windows.Forms.Application.DoEvents();
            ContactWindowsVector contactsVector = MainFunctions2.calculateContactWindows(tleData, stationData, startTime, stopTime);
            System.Windows.Forms.Application.DoEvents();
            SchedulerInterface scheduler = null; ;
            switch (schedulerName)
            {
                case "Genetic":
                    string[] settString = settings.Split(';');
                    scheduler = new GeneticScheduler(Convert.ToInt32(settString[0]), Convert.ToInt32(settString[1]),
                        Convert.ToInt32(settString[2]), Convert.ToInt32(settString[4]), Convert.ToBoolean(settString[5]),
                        Convert.ToDouble(settString[6]), Convert.ToBoolean(settString[7]), Convert.ToBoolean(settString[8]));
                    break;
                case "Greedy":
                    scheduler = new GreedyScheduler();
                    break;
                case "EFT-Greedy":
                    scheduler = new EftGreedyScheduler();
                    break;
                case "Hill-Climber":
                    string[] settString2 = settings.Split(';');
                    scheduler = new HillClimberScheduler(Convert.ToBoolean(settString2[0]), Convert.ToBoolean(settString2[2]),
                        Convert.ToInt32(settString2[1]));
                    break;
            }
            ObjectiveFunction objective = new ObjectiveFunction(Forms.ObjectiveBuilderForm.getObjectiveEnumsByName(objectiveFunction));
            System.Windows.Forms.Application.DoEvents();
            SchedulingProblem problem = new SchedulingProblem();
            problem.setContactWindows(contactsVector);
            problem.removeUnwantedContacts(Properties.Settings.Default.orbit_Minimum_Contact_Duration_sec);
            problem.setObjectiveFunction(objective);
            problem.getContactWindows().randomize(Properties.Settings.Default.global_Random_Seed);
            getScenario(problem, scenario);
            System.Windows.Forms.Application.DoEvents();
            TimeMeasurement tm = new TimeMeasurement();
            tm.activate();
            scheduler.CalculateSchedule(problem);
            string time = tm.getValueAndDeactivate();
            System.Windows.Forms.Application.DoEvents();
            contactsVector = scheduler.getFinischedSchedule();
            System.Windows.Forms.Application.DoEvents();


            if (scheduler != null)
            {
                ObjectiveFunction objfunc = scheduler.getObjectiveFunction();
                if (objfunc == null)
                    objfunc = new ObjectiveFunction();
                objfunc.calculateValues(scheduler.getFinischedSchedule());

                double fitness = objfunc.getObjectiveResults();

                int _H = scheduler.getFinischedSchedule().getNrOfScheduled();
                double _H1 = objfunc.getScheduledContactsValue();
                int _H2 = GeneralMeasurments.getNrOfConflicts(scheduler.getFinischedSchedule());
                double _H3 = objfunc.getStationFairnessValue();
                double _H4 = objfunc.getSatelliteFairnessValue();
                double _H5 = GeneralMeasurments.getDurationOfScheduledContacts(scheduler.getFinischedSchedule());

                results.Add("Run: " + schedulerName);
                results.Add("Fitness Value:" + objfunc.getObjectiveResults().ToString());
                results.Add("Scheduled Contacts: " + scheduler.getFinischedSchedule().getNrOfScheduled().ToString() + " / " + contactsVector.Count().ToString());
                results.Add("Collisions: " + GeneralMeasurments.getNrOfConflicts(scheduler.getFinischedSchedule()).ToString());
                results.Add("Fairnes Stations: " + objfunc.getStationFairnessValue().ToString());
                results.Add("Fairnes Satellites: " + objfunc.getSatelliteFairnessValue().ToString());
                results.Add("Duration: " + GeneralMeasurments.getDurationOfScheduledContacts(scheduler.getFinischedSchedule()).ToString() + " sec.");
                results.Add("Calculation Time: " + time);
                results.Add("Scheduled By Priority: " + GeneralMeasurments.getNrOfPrioritysScheduled(scheduler.getFinischedSchedule()));
                results.Add("Scheduled UWE-3: " + GeneralMeasurments.getNrOfUweContacts(scheduler.getFinischedSchedule()).ToString());

                //Log.writeResults(logfile, schedulerName, results);
                if (results == null)
                    status = false;
            }
            else
            {
                status = false;
            }
            return status;
        }

        public List<string> getResults()
        {
            return results;
        }

        //! get Selected Scenario
        /*! 
         * Generates the Scenario selected
        */
        private void getScenario(SchedulingProblem problem, int selectedScenario)
        {
            /*
                * Generate the selected Scenarios
                * These are defined in the SchedulingProblem Class
                * Other Scenarios can be selected here if they are added
                */
            if (selectedScenario == 0)
            {
                problem.GenerateSzenarioA();
            }
            if (selectedScenario == 1)
            {
                problem.GenerateSzenarioB(Properties.Settings.Default.global_Random_Seed);
            }
            if (selectedScenario == 2)
            {
                problem.GenerateSzenarioC(Properties.Settings.Default.global_Random_Seed);
            }
            if (selectedScenario == 3)
            {
                problem.GenerateSzenarioD(Properties.Settings.Default.global_Random_Seed);
            }
        }

        public override string ToString()
        {
            return schedulerName;
        }

        public string getNameOfScheduler()
        {
            return schedulerName;
        }

        public string getSettings()
        {
            return settings;
        }

        public string getObjectiveFunction()
        {
            return objectiveFunction;
        }

        public int getScenario()
        {
            return scenario;
        }

        public EpochTime getStartTime()
        {
            return startTime;
        }

        public EpochTime getStopTime()
        {
            return stopTime;
        }

        public List<string> getSatellites()
        {
            return satelliteList;
        }

        public List<string> getStation()
        {
            return stationList;
        }

    }
}
