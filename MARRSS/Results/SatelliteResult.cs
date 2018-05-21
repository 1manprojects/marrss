using MARRSS.Definition;
using MARRSS.Global;
using MARRSS.Satellite;
using OxyPlot;
using OxyPlot.Series;
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
        public string StorageCapacityAtEnd { get; set; }

        private ContactWindowsVector contacts;
        private List<Satellite.Satellite> sats;
        private List<Ground.Station> stats;
        private Satellite.Satellite currentSat;
        private OxyPlot.PlotModel datamodel;

        private double raw_GeneratedData;
        private double raw_LostData;
        private double raw_DownData;

        public double GetGeneratedData() { return raw_GeneratedData; }
        public double GetLostData() { return raw_LostData; }
        public double GetDownedData() { return raw_DownData; }

        public SatelliteResult(ContactWindowsVector schedulingResult, string Satellitename, List<Satellite.Satellite> satellites)
        {
            contacts = schedulingResult;
            SatelliteName = Satellitename;
            sats = satellites;
            NumberOfContacts = schedulingResult.Count();
            currentSat = satellites.Where(a => a.getName() == SatelliteName).First();

            CalcuateStorageDetails();
            CalculateContacts();
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
            AverageContactWindowDuration = string.Format("{0} sec.", Math.Round(avDura,3));
            OverallContactsDuration = string.Format("{0} sec.", Math.Round(duration,4));
        }

        public PlotModel GeneratePlotData()
        {
            datamodel = new PlotModel { Title = "Storage" };
            LineSeries dataSeries = new LineSeries(); 
            var downPackets = currentSat.getDataStorage().GetDownloadedDataPackets();
            var genPackets = currentSat.getDataStorage().GetCreatedDataPackets();
            var max = currentSat.getDataStorage().getMaxDataSize();

            var allPackest = new List<Satellite.DataPacket>();
            allPackest.AddRange(downPackets);
            allPackest.AddRange(genPackets);
            List<Satellite.DataPacket> SortedList = allPackest.OrderBy(o => o.getTimeStamp().getEpoch()).ToList();

            dataSeries.Points.Add(new DataPoint(0, 0));
            //DataStorageSet.Add(new Point(0, 0));
            for (int i = 0; i < SortedList.Count; i++)
            {
                //DataStorageSet.Add(new Point(Convert.ToInt32((SortedList[i].getTimeStamp().getEpoch())), 0));
                //dataSeries.Points.Add(new DataPoint(Convert.ToInt32((SortedList[i].getTimeStamp().getEpoch())), 0));
                //var time = SortedList[i].getTimeStamp();
                //time.addTick(SortedList[i].getDurationInSec());
                //var x = Convert.ToInt32(time.getEpoch());
                //var y = Convert.ToInt32(SortedList[i].getStoredData());
                //if (y >= currentSat.getDataStorage().getMaxDataSize())
                //    y = Convert.ToInt32(currentSat.getDataStorage().getMaxDataSize());
                //dataSeries.Points.Add(new DataPoint(x, y));
            }
            datamodel.Series.Add(dataSeries);
            return datamodel;
        }

        private void CalcuateStorageDetails()
        {
            var maxDataInByte = currentSat.getDataStorage().getMaxDataSize();
            List<DataPacket> removedPackets = new List<DataPacket>(currentSat.getDataStorage().GetDownloadedDataPackets());
            List<DataPacket> createdPackets = new List<DataPacket>(currentSat.getDataStorage().GetCreatedDataPackets());

            removedPackets = removedPackets.OrderBy(o => o.getTimeStamp().getEpoch()).ToList();
            createdPackets = createdPackets.OrderBy(o => o.getTimeStamp().getEpoch()).ToList();

            var memorySize = 0.0;
            var lostMemorySize = 0.0;
            var downloadedData = 0.0;
            var maxMemGen = 0.0;
            for (int i = 0; i < removedPackets.Count(); i++)
            {
                var removed = removedPackets[i];
                var counted = 0;
                for (int j = 0; j < createdPackets.Count(); j++)
                {
                    var added = createdPackets[j];
                    maxMemGen += added.getStoredData();
                    if (added.getTimeStamp().getEpoch() <= removed.getTimeStamp().getEpoch())
                    {
                        counted++;
                        if (memorySize + added.getStoredData() <= maxDataInByte)
                        {
                            memorySize += added.getStoredData();
                        }
                        else
                        {
                            lostMemorySize += (memorySize + added.getStoredData()) - maxDataInByte;
                            memorySize = maxDataInByte;
                        }
                    }
                    else
                    {
                        createdPackets.RemoveRange(0, counted);
                        break;
                    }
                }

                if (memorySize - removed.getStoredData() >= 0)
                {
                    memorySize -= removed.getStoredData();
                    downloadedData += removed.getStoredData();
                }
                else
                {
                    if (memorySize > 0)
                    {
                        var dif = removed.getStoredData() - memorySize;
                        downloadedData += dif;
                        memorySize = 0;
                    }

                }
            }

            for (int j = 0; j < createdPackets.Count(); j++)
            {
                var added = createdPackets[j];
                maxMemGen += added.getStoredData();
                if (memorySize + added.getStoredData() <= maxDataInByte)
                {
                    memorySize += added.getStoredData();
                }
                else
                {
                    lostMemorySize += memorySize + added.getStoredData() - maxDataInByte;
                    memorySize = maxDataInByte;
                }

            }

            maxMemGen = 0.0;
            foreach (var i in currentSat.getDataStorage().GetCreatedDataPackets())
            {
                maxMemGen += i.getStoredData();
            }

            raw_GeneratedData = maxMemGen;
            raw_LostData = lostMemorySize;
            raw_DownData = downloadedData;

            MaxDataStorage = string.Format("{0} {1}", Funktions.GetHumanReadableSize(maxDataInByte), Funktions.getDataSizeToString(maxDataInByte));
            GeneratedData = string.Format("{0} {1}", Funktions.GetHumanReadableSize(maxMemGen), Funktions.getDataSizeToString(maxMemGen));
            LostData = string.Format("{0} {1}", Funktions.GetHumanReadableSize(lostMemorySize), Funktions.getDataSizeToString(lostMemorySize));
            DownloadedData = string.Format("{0} {1}", Funktions.GetHumanReadableSize(downloadedData), Funktions.getDataSizeToString(downloadedData));
            StorageCapacityAtEnd = string.Format("{0} {1}", Funktions.GetHumanReadableSize(memorySize), Funktions.getDataSizeToString(memorySize));
        }
    }
}
