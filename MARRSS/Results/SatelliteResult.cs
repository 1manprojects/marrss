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
        public string AverageTimeToDownlink { get; set; }

        private ContactWindowsVector contacts;
        private List<Satellite.Satellite> sats;
        private List<Ground.Station> stats;
        private Satellite.Satellite currentSat;
        private OxyPlot.PlotModel datamodel;

        private List<MemPoint> storageRawPlotData;

        private double raw_GeneratedData;
        private double raw_LostData;
        private double raw_DownData;
        private double raw_avgDownlinkTime;

        public double GetGeneratedData() { return raw_GeneratedData; }
        public double GetLostData() { return raw_LostData; }
        public double GetDownedData() { return raw_DownData; }
        public double GetAvgDownlinkTime() { return raw_avgDownlinkTime; }

        public SatelliteResult(ContactWindowsVector schedulingResult, string Satellitename, List<Satellite.Satellite> satellites)
        {
            datamodel = new PlotModel { Title = SatelliteName + " Storage" };
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
                if (con.SatelliteName == SatelliteName && con.IsScheduled)
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

        public PlotModel GetStoragePlotModel()
        {
            return datamodel;
        }

        private void CalcuateStorageDetails()
        {
            datamodel = new PlotModel { Title = "Storage" };
            LineSeries dataSeries = new LineSeries();
            storageRawPlotData = new List<MemPoint>();

            var maxDataInByte = currentSat.getDataStorage().getMaxDataSize();
            List<DataPacket> removedPackets = new List<DataPacket>(currentSat.getDataStorage().GetDownloadedDataPackets());
            List<DataPacket> createdPackets = new List<DataPacket>(currentSat.getDataStorage().GetCreatedDataPackets());

            removedPackets = removedPackets.OrderBy(o => o.getTimeStamp().getEpoch()).ToList();
            createdPackets = createdPackets.OrderBy(o => o.getTimeStamp().getEpoch()).ToList();

            List<DataPacket> packets = new List<DataPacket>();
            packets.AddRange(removedPackets);
            packets.AddRange(createdPackets);
            packets = packets.OrderBy(o => o.getTimeStamp().getEpoch()).ToList();

            long memorySize = 0;
            long lostMemorySize = 0;
            long downloadedData = 0;
            long maxMemGen = 0;
            double rawCompletionTime = 0.0;

            var timepoint = packets[0].getTimeStamp().getEpoch();
            dataSeries.Points.Add(new DataPoint(timepoint, 0));
            storageRawPlotData.Add(new MemPoint(timepoint, 0));

            var tempPos = 0;
            for (int i = 0; i < packets.Count; i ++)
            {              
                var packet = packets[i];
                timepoint = packet.getTimeStamp().getEpoch();
                if (packet.getType() == DataPacket.dataType.DOWNLOADED)
                {
                    if (memorySize > 0)
                    {
                        if (memorySize - packet.getStoredData() < 0)
                        {
                            downloadedData += memorySize;
                            memorySize = 0;
                        }
                        else
                        {
                            downloadedData += packet.getStoredData();
                            memorySize -= packet.getStoredData();
                        }
                    }
                    //set completion time for each packets
                    var toDownload = packet.getStoredData();
                    var counter = tempPos;
                    for (int j = tempPos +1; j <= i; j++)
                    {
                        if (packets[j].getType() != DataPacket.dataType.DOWNLOADED)
                        {
                            if (toDownload - packets[j].getStoredData() >= 0)
                            {
                                toDownload = toDownload - packets[j].getStoredData();
                                packets[j].setCompletiontime(packet.getTimeStamp());
                                rawCompletionTime += 24.0 * 60 * (packet.getTimeStamp().getEpoch() - packets[j].getTimeStamp().getEpoch());
                                counter++;
                            }
                        }
                    }
                    tempPos = counter;
                }
                else
                {
                    maxMemGen += packet.getStoredData();
                    if (memorySize + packet.getStoredData() > maxDataInByte)
                    {
                        lostMemorySize += memorySize + packet.getStoredData() - maxDataInByte;
                        memorySize = maxDataInByte;
                    }
                    else
                    {
                        memorySize += packet.getStoredData();
                    }                    
                }
                dataSeries.Points.Add(new DataPoint(timepoint, convertByteToSize(memorySize)));
                storageRawPlotData.Add(new MemPoint(timepoint, memorySize));
            }

            datamodel.Axes.Add(new OxyPlot.Axes.LinearAxis { Position = OxyPlot.Axes.AxisPosition.Bottom, Title = "EpochTime" });
            datamodel.Axes.Add(new OxyPlot.Axes.LinearAxis { Position = OxyPlot.Axes.AxisPosition.Left, Title = "Storage in " + Funktions.getDataSizeToString(maxDataInByte) });

            //dataSeries.XAxis.Title = "Epoch Time";
            //dataSeries.YAxis.Title = "Storage in " + Funktions.getDataSizeToString(maxDataInByte);
            datamodel.Series.Add(dataSeries);

            raw_LostData = lostMemorySize;
            raw_GeneratedData = maxMemGen;            
            raw_DownData = downloadedData;
            raw_avgDownlinkTime = rawCompletionTime / createdPackets.Count;

            MaxDataStorage = string.Format("{0} {1}", Funktions.GetHumanReadableSize(maxDataInByte), Funktions.getDataSizeToString(maxDataInByte));
            GeneratedData = string.Format("{0} {1}", Funktions.GetHumanReadableSize(maxMemGen), Funktions.getDataSizeToString(maxMemGen));
            LostData = string.Format("{0} {1}", Funktions.GetHumanReadableSize(raw_LostData), Funktions.getDataSizeToString(raw_LostData));
            DownloadedData = string.Format("{0} {1}", Funktions.GetHumanReadableSize(raw_DownData), Funktions.getDataSizeToString(raw_DownData));
            StorageCapacityAtEnd = string.Format("{0} {1}", Funktions.GetHumanReadableSize(memorySize), Funktions.getDataSizeToString(memorySize));
            AverageTimeToDownlink = string.Format("{0}", convertTimeToReadable(raw_avgDownlinkTime));
        }

        public List<MemPoint> GetPlotDataOfSatellite()
        {
            return storageRawPlotData;
        }

        private double convertByteToSize(long memory)
        {
            var maxDataInByte = currentSat.getDataStorage().getMaxDataSize();
            var maxSizeType = Funktions.getDataSize(maxDataInByte);

            double res = memory;
            for (int i = 0; i < maxSizeType; i++)
            {
                res = res / 1000.0;
            }
            return res;
        }

        private static string convertTimeToReadable(double avgTime)
        {
            var res = avgTime*60;
            if (res / 60 <= 1)
            {
                return string.Format("{0:0.000}", res) + " sec.";
            }
            if (res / (60 * 60) <= 1)
            {
                res = res / 60;
                return string.Format("{0:0.000}", res) + " min.";
            }
            if (res / (60 * 60 * 24) <= 1)
            {
                res = res / (60 * 60);
                return string.Format("{0:0.000}", res) + " hours";
            }
            res = res / (60 * 60 * 24);
            return string.Format("{0:0.000}", res) + " days";
        }
    }
}
