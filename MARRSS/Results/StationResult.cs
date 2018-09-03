using MARRSS.Definition;
using MARRSS.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARRSS.Results
{
    public class StationResult
    {
        public string StationName { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Height { get; set; }
        public int NumberOfContacts { get; set; }
        public int NumberOfScheduledContacts { get; set; }
        public string ContactDurations { get; set; }
        public string IdleTime { get; set; }
        public string DownloadedData { get; set; }
        public string AverageDownlink { get; set; }
        public string MaxDownlink { get; set; }


        private ContactWindowsVector contacts;
        private List<Satellite.Satellite> sats;
        private List<Ground.Station> stats;
        private Ground.Station currentStation;

        public StationResult(ContactWindowsVector schedulingResult, string Stationname, List<Satellite.Satellite> satellites, List<Ground.Station> stations)
        {
            StationName = Stationname;
            sats = satellites;
            stats = stations;
            currentStation = stats.Where(a => a.getName() == StationName).First();
            Latitude = currentStation.getLatitude().ToString();
            Longitude = currentStation.getLongitude().ToString();
            Height = currentStation.getHeight().ToString();
            contacts = schedulingResult;
            CalculateContacts();
            CalculateData();

        }

        private void CalculateData()
        {
            double dataDown = 0.0;
            double timedown = 0;
                        
            for (int i = 0; i < contacts.Count(); i++)
            {
                var con = contacts.getAt(i);
                if (con.StationName == StationName && con.IsScheduled)
                {
                    var currentSat = sats.Where(a => a.getName() == con.SatelliteName).First();
                    var pack = currentSat.getDataStorage().GetDownloadedDataPackets().Where(a => a.getTimeStamp().getEpoch() == con.StartTime.getEpoch()).FirstOrDefault();
                    if (pack != null)
                    {
                        dataDown += pack.getStoredData();
                        timedown += pack.getDurationInSec();
                    }
                }
            }
            var avDown = dataDown / timedown;
            AverageDownlink = string.Format("{0} {1} per sec.", Funktions.GetHumanReadableSize(avDown), Funktions.getDataSizeToString(avDown));
            DownloadedData = string.Format("{0} {1}", Funktions.GetHumanReadableSize(dataDown), Funktions.getDataSizeToString(dataDown));
        }

        private void CalculateContacts()
        {
            var countCon = 0;
            var duration = 0.0;
            var schedTime = contacts.EndTime.getEpoch() - contacts.StartTime.getEpoch();
            for (int i = 0; i < contacts.Count(); i++)
            {
                var con = contacts.getAt(i);
                if (con.StationName == StationName && con.IsScheduled)
                {
                    countCon++;
                    duration += con.ContactDuration();
                }
            }
            NumberOfContacts = contacts.Count();
            NumberOfScheduledContacts = countCon;
            ContactDurations = string.Format("{0} sec", Math.Round(duration, 4));
            double idleTime = (schedTime * 86400) - duration;
            IdleTime = idleTime.ToString();
        }
    }
}
