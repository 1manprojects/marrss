using MARRSS.Definition;
using MARRSS.Global;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARRSS.Results
{
    public class SatelliteResult
    {
        public string GeneratedData { get; set; }
        public string LostData { get; set; }
        public string DownloadedData { get; set; }
        public int NumberOfContacts { get; set; }
        public int NumberOfScheduledContacts { get; set; }
        public string AverageDownlinkRate { get; set; }
        public string AverageContactWindowDuration { get; set; }
        public string OverallContactsDuration { get; set; }
        public string SatelliteName { get; set; }
        public string MaxDataStorage { get; set; }

        private ContactWindowsVector contacts;
        private List<Satellite.Satellite> sats;
        private List<Ground.Station> stats;
        private Satellite.Satellite currentSat;
        private List<Point> DataStorageSet;


        public SatelliteResult(ContactWindowsVector schedulingResult, string Satellitename, List<Satellite.Satellite> satellites, List<Ground.Station> stations)
        {
            contacts = schedulingResult;
            SatelliteName = Satellitename;
            sats = satellites;
            stats = stations;
            NumberOfContacts = schedulingResult.Count();
            currentSat = satellites.Where(a => a.getName() == SatelliteName).First();

            CalculateData();
            CalculateContacts();
        }

        private void CalculateData()
        {
            var maxDataInByte = currentSat.getDataStorage().MaxPosibleData;
            GeneratedData = string.Format("{0} {1}", Funktions.GetHumanReadableSize(maxDataInByte), Funktions.getDataSizeToString(maxDataInByte));

            var lostDataInByte = currentSat.getDataStorage().LostMemorySize;
            LostData = string.Format("{0} {1}", Funktions.GetHumanReadableSize(lostDataInByte), Funktions.getDataSizeToString(lostDataInByte));

            var downPackets = currentSat.getDataStorage().GetDownloadedDataPackets();
            var averageDown = 0.0;
            var downpack = currentSat.getDataStorage().DownloadedData;
            DownloadedData = string.Format("{0} {1}", Funktions.GetHumanReadableSize(downpack), Funktions.getDataSizeToString(downpack));
            averageDown = downpack / currentSat.getDataStorage().AllDownlinkDuration;
            AverageDownlinkRate = string.Format("{0} {1} per sec.", Funktions.GetHumanReadableSize(averageDown), Funktions.getDataSizeToString(averageDown));
            var maxStorage = currentSat.getDataStorage().getMaxDataSize();
            MaxDataStorage = string.Format("{0} {1}", Funktions.GetHumanReadableSize(maxStorage), Funktions.getDataSizeToString(maxStorage));
        }

        private void CalculateContacts()
        {
            var countCon = 0;
            var duration = 0.0;

            for (int i = 0; i < contacts.Count(); i++)
            {
                var con = contacts.getAt(i);
                if (con.SatelliteName == SatelliteName)
                {
                    countCon++;
                    duration += con.ContactDuration();
                }
            }
            var avDura = duration / countCon;
            NumberOfScheduledContacts = countCon;
            AverageContactWindowDuration = string.Format("{0} sec.", avDura);
            OverallContactsDuration = string.Format("{0} sec.", duration);
        }

        private void GeneratePlotData()
        {
            DataStorageSet = new List<Point>();
            var downPackets = currentSat.getDataStorage().GetDownloadedDataPackets();
            var genPackets = currentSat.getDataStorage().GetCreatedDataPackets();
            var max = currentSat.getDataStorage().getMaxDataSize();

            var allPackest = new List<Satellite.DataPacket>();
            allPackest.AddRange(downPackets);
            allPackest.AddRange(genPackets);
            List<Satellite.DataPacket> SortedList = allPackest.OrderBy(o => o.getTimeStamp().getEpoch()).ToList();

            DataStorageSet.Add(new Point(0, 0));
            for (int i = 0; i < SortedList.Count; i++)
            {
                DataStorageSet.Add(new Point(Convert.ToInt32((SortedList[i].getTimeStamp().getEpoch())), 0));
                var time = SortedList[i].getTimeStamp();
                time.addTick(SortedList[i].getDurationInSec());
                var x = Convert.ToInt32(time.getEpoch());
                var y = Convert.ToInt32(SortedList[i].getStoredData());
                if (y >= currentSat.getDataStorage().getMaxDataSize())
                    y = Convert.ToInt32(currentSat.getDataStorage().getMaxDataSize());
                DataStorageSet.Add(new Point(x, y));
            }

        }
    }
}
