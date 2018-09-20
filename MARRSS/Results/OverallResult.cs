using MARRSS.Definition;
using MARRSS.Global;
using MARRSS.Scheduler;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARRSS.Results
{
    public class OverallResult
    {
        public string UsedScenario { get; set; }
        public string ObjectiveFunction { get; set; }
        public string CalculationTime { get; set; }
        public string Scheduler { get; set; }


        public string FitnessValue { get; set; }
        public string FitnessFairness { get; set; }
        public string FitnessFairStations { get; set; }
        public string FitnessFairSatellites { get; set; }
        public string FitnessDataDownload { get; set; }
        public string FitnessDuration { get; set; }
        public string FitnessContacts { get; set; }
        public int NumberOfSatellites { get; set; }
        public int NumberOfStation { get; set; }
        public int NumberOfContacts { get; set; }
        public int NumberOfScheduledContacts { get; set; }
        public int NumberOfCollisions { get; set; }
        public string MaxDurationContacts { get; set; }
        public string ScheduledContactDuration { get; set; }
        public string AverageContactWindowDuration { get; set; }
        public string CalculationTimeSum { get; set; }
        public string CalculationTimeContacts { get; set; }
        public string CalculationTimeSchedule { get; set; }
        public int NumberOfGenerations { get; set; }
        public string MaxGeneratedData { get; set; }
        public string MaxPossibleGeneratedData { get; set; }
        public string DownloadedData { get; set; }
        public string LostData { get; set; }
        public string AverageDownloadLink { get; set; }

        public List<SatelliteResult> SatelliteResults { get; set; }
        public List<StationResult> StationResults { get; set; }
        public ContactWindowsVector ScheduledContactWindows { get; set; }


        private ContactWindowsVector contacts;
        private List<Satellite.Satellite> sats;
        private List<Ground.Station> stats;
        private double maxDataGen = 0.0;
        private double lostData = 0.0;
        private double downData = 0.0;

        public OverallResult(ContactWindowsVector schedulingResult, List<Satellite.Satellite> satellites, List<Ground.Station> stations)
        {
            maxDataGen = 0.0;
            lostData = 0.0;
            downData = 0.0;

            contacts = schedulingResult;
            sats = satellites;
            stats = stations;
            NumberOfContacts = schedulingResult.Count();

            //GetFitnessValues();
            CalculateData();
            CalculateContacts();
            GetFitnessValues();
        }

        private void GetFitnessValues()
        {
            var objfunc = new ObjectiveFunction();
            objfunc.Initialize(contacts, sats, stats);
            objfunc.CalculateObjectiveFitness(contacts, false);
            FitnessFairStations = objfunc.getStationFairnessValue().ToString();
            FitnessFairSatellites = objfunc.getSatelliteFairnessValue().ToString();
            var fitFair = (objfunc.getSatelliteFairnessValue() + objfunc.getObjectiveResults()) / 2.0;
            FitnessFairness = fitFair.ToString();
            FitnessDuration = objfunc.getDurationValue().ToString();
            FitnessDataDownload = (downData / (maxDataGen + lostData)).ToString();
            FitnessValue = objfunc.getObjectiveResults().ToString();
        }

        private void CalculateData()
        {
            maxDataGen = 0.0;
            lostData = 0.0;
            downData = 0.0;
            for (int i = 0; i < sats.Count(); i++)
            {
                var satres = new SatelliteResult(contacts, sats[i].getName(), sats);
                downData += satres.GetDownedData();
                lostData += satres.GetLostData();
                maxDataGen += satres.GetGeneratedData();
            }
            MaxGeneratedData = string.Format("{0} {1}", Funktions.GetHumanReadableSize(maxDataGen), Funktions.getDataSizeToString(maxDataGen));
            DownloadedData = string.Format("{0} {1}", Funktions.GetHumanReadableSize(downData), Funktions.getDataSizeToString(downData));
            LostData = string.Format("{0} {1}", Funktions.GetHumanReadableSize(lostData), Funktions.getDataSizeToString(lostData));
        }

        private void CalculateContacts()
        {
            NumberOfSatellites = sats.Count;
            NumberOfGenerations = 0;
            NumberOfContacts = contacts.Count();
            NumberOfStation = stats.Count();
            var count = 0;
            var maxDuration = 0.0;
            var schedDuration = 0.0;
            var avgDuration = 0.0;
            for (int i = 0; i < contacts.Count(); i++)
            {
                if (contacts.getAt(i).IsScheduled)
                {
                    count++;
                    schedDuration += contacts.getAt(i).ContactDuration();
                }
                maxDuration += contacts.getAt(i).ContactDuration();
            }
            NumberOfScheduledContacts = count;
            NumberOfCollisions = getNrOfConflicts(contacts);
            ScheduledContactDuration = string.Format("{0} sec.", schedDuration);
            MaxDurationContacts = string.Format("{0} sec.", maxDuration);
            avgDuration = avgDuration / count;
            AverageContactWindowDuration = string.Format("{0} sec", avgDuration);

        }

        private int getNrOfConflicts(ContactWindowsVector contacts)
        {
            int nrOfConflicts = 0;
            HashSet<string> hashConflict = new HashSet<string>();

            for (int i = 0; i < contacts.Count(); i++)
            {
                for (int k = 0; k < contacts.Count(); k++)
                {
                    if (i != k && contacts.getAt(i).getSheduledInfo() &&
                        contacts.getAt(k).getSheduledInfo() &&
                        contacts.getAt(i).checkConflikt(contacts.getAt(k)))
                    {
                        if (contacts.getAt(k).StationName == contacts.getAt(i).StationName
                            || contacts.getAt(k).StationName == contacts.getAt(i).StationName)
                        {
                            if (!hashConflict.Contains(contacts.getAt(k).Id))
                            {
                                nrOfConflicts++;
                                hashConflict.Add(contacts.getAt(i).Id);
                            }
                        }
                    }
                }
            }
            hashConflict.Clear();
            return nrOfConflicts;
        }

        public void saveJsonResult(string output)
        {
            SatelliteResults = new List<SatelliteResult>();
            StationResults = new List<StationResult>();

            foreach (var sat in sats)
            {
                var res = new SatelliteResult(contacts, sat.getName(), sats);
                var rawPlotData = res.GetPlotDataOfSatellite();
                using (StreamWriter file = new StreamWriter(output + sat.getName() + "_storage.txt"))
                {
                    foreach (MemPoint p in rawPlotData)
                    {
                        file.WriteLine(p.ToString());
                    }
                }
                SatelliteResults.Add(res);
                
            }
            foreach (var stat in stats)
            {
                StationResults.Add(new StationResult(contacts, stat.getName(), sats, stats));
            }
            ScheduledContactWindows = contacts.getScheduledContacts();
            File.WriteAllText(output, JsonConvert.SerializeObject(this, Formatting.Indented));
        }
    }
}
