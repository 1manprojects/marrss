using MARRSS.Global;
using MARRSS.Interface2;
using One_Sgp4;
using System;
using System.Linq;

namespace MARRSS.Scenarios
{
    class ScenarioLoader
    {
        //      Load Scenario Here and setUp
        //---------------------------------------------------------------------

        public static void GenerateSzenarioA(ScheduleProblemInterface input)
        {
            for (int i = 0; i < input.getContactWindows().Count(); i++)
            {
                input.getContactWindows().getAt(i).Priority = Structs.priority.NONE;
            }
        }

        public static void GenerateSzenarioB(ScheduleProblemInterface input, int seed = 0)
        {
            Random rnd;
            if (seed == 0)
                rnd = new Random();
            else
                rnd = new Random(seed);

            for (int i = 0; i < input.getContactWindows().Count(); i++)
            {
                int p = rnd.Next(0, 5);
                Global.Structs.priority pr;
                pr = (Structs.priority)p;
                input.getContactWindows().getAt(i).Priority = pr;
            }
        }

        public static void GenerateSzenarioC(ScheduleProblemInterface input, int seed = 0)
        {
            Random rnd;
            if (seed == 0)
                rnd = new Random();
            else
                rnd = new Random(seed);

            for (int i = 0; i < input.getContactWindows().Count(); i++)
            {
                if (input.getContactWindows().getAt(i).SatelliteName == "UWE-3")
                {
                    input.getContactWindows().getAt(i).Priority = 0;
                }
                else
                {
                    int p = rnd.Next(0, 5);
                    Global.Structs.priority pr;
                    pr = (Structs.priority)p;
                    input.getContactWindows().getAt(i).Priority = pr;
                }
            }
        }

        public static void GenerateSzenarioD(ScheduleProblemInterface input, int seed = 0)
        {
            Random rnd;
            if (seed == 0)
                rnd = new Random();
            else
                rnd = new Random(seed);

            for (int i = 0; i < input.getContactWindows().Count(); i++)
            {
                bool found = false;
                //------------1
                if (input.getContactWindows().getAt(i).SatelliteName == "UWE-3"
                    && input.getContactWindows().getAt(i).StationName ==
                    "Würzburg (Computer Science Institute)")
                {
                    input.getContactWindows().getAt(i).Priority = Structs.priority.CRITICAL;
                    found = true;
                }
                //------------2
                if (input.getContactWindows().getAt(i).SatelliteName == "AAUSAT3"
                    && input.getContactWindows().getAt(i).StationName ==
                    "Aalborg (Aalborg University)")
                {
                    input.getContactWindows().getAt(i).Priority = Structs.priority.CRITICAL;
                    found = true;
                }
                //------------3
                if (input.getContactWindows().getAt(i).SatelliteName == "ITUPSAT 1"
                   && input.getContactWindows().getAt(i).StationName ==
                   "Istanbul (Istanbul Technical University)")
                {
                    input.getContactWindows().getAt(i).Priority = Structs.priority.CRITICAL;
                    found = true;
                }
                //------------4
                if (input.getContactWindows().getAt(i).SatelliteName == "LITUANICASAT 1"
                   && input.getContactWindows().getAt(i).StationName ==
                   "Lithuania (Vilnius University)")
                {
                    input.getContactWindows().getAt(i).Priority = Structs.priority.CRITICAL;
                    found = true;
                }
                //------------5
                if (input.getContactWindows().getAt(i).SatelliteName == "TIGRISAT"
                   && input.getContactWindows().getAt(i).StationName ==
                   "Roma (La Sapienza University of Rome)")
                {
                    input.getContactWindows().getAt(i).Priority = Structs.priority.CRITICAL;
                    found = true;
                }
                //------------6
                if (input.getContactWindows().getAt(i).SatelliteName == "CUBESAT XI-IV"
                   && input.getContactWindows().getAt(i).StationName ==
                   "Tokyo University")
                {
                    input.getContactWindows().getAt(i).Priority = Structs.priority.CRITICAL;
                    found = true;
                }
                //------------7
                if (input.getContactWindows().getAt(i).SatelliteName == "CUBESAT XI-V"
                  && input.getContactWindows().getAt(i).StationName ==
                  "Sapporo (Hokkaido Institute of Technology)")
                {
                    input.getContactWindows().getAt(i).Priority = Structs.priority.CRITICAL;
                    found = true;
                }

                if (!found)
                {
                    int p = rnd.Next(1, 5);
                    Global.Structs.priority pr;
                    pr = (Structs.priority)p;
                    input.getContactWindows().getAt(i).Priority = pr;
                }

            }
        }

        public static void Generate1MbPerMinuteScenario(ScheduleProblemInterface input)
        {
            //LOAD Plan FIle
            //Fill satellite wiht data from Start to Finisch
            foreach (Satellite.Satellite sat in input.getSatellites())
            {
                sat.getDataStorage().setMaxData(512, Structs.DataSize.MBYTE);
                EpochTime startT = new EpochTime(input.getContactWindows().StartTime);
                EpochTime stopT = new EpochTime(input.getContactWindows().EndTime);
                while (startT.toDateTime() < stopT.toDateTime())
                {
                    startT.addTick(60);
                    sat.AddDataPacket(new Satellite.DataPacket(1 *1024 *1204, 4, startT, 60));
                }
            }
        }

        public static void GenerateCustomDataScenario(ScheduleProblemInterface input, JPlan customPlan)
        {
            long globalCounter = 0;
            //get lowerBound VAlues only currently
            foreach (var timeline in customPlan.timelines)
            {
                //get Storage data
                if (timeline.name.component.Contains("STORAGE"))
                {
                    //get satellite assigned
                    var sat = input.getSatelliteByName(timeline.name.label);
                    sat.SetMaxDataStorage(16, Structs.DataSize.GBYTE);
                    if (sat != null)
                    {
                        //read values of timelines and generate Datapackets
                        //
                        foreach (var value in timeline.values)
                        {
                            var lowerBoundDuration = value.duration.LowerBoundToTimeSpan();
                            var storage = value.value.Substring(1, value.value.Length - 2);
                            string[] storages = storage.Split(',');
                            var lowerBoundStorage = Double.Parse(storages[1]);

                            var lowerBoundInMin = lowerBoundDuration.TotalMinutes;
                            var startTime = new One_Sgp4.EpochTime(value.time.lb);

                            if (startTime.toDateTime() >= input.getEndTime().toDateTime())
                                break;

                            int dataPacketSize = 0;
                            if (storages.Count() >= 3)
                            {
                                dataPacketSize = (int) (Double.Parse(storages[2])*1024*1024);

                                var counter = 0;
                                for (int i = 0; i < lowerBoundInMin*60; i+=60)
                                {
                                    startTime.addTick(60);
                                    var packet = new Satellite.DataPacket(dataPacketSize, 4, startTime, 60);
                                    sat.getDataStorage().AddDataPacketToDataList(packet);
                                    //sat.AddDataPacket(packet);
                                    globalCounter += packet.getStoredData();
                                    counter += 1;
                                }
                                if (counter < lowerBoundInMin*60)
                                {
                                    var rest = lowerBoundInMin*60 % 1;
                                    startTime.addTick(60 * rest);
                                    //sat.AddDataPacket(new Satellite.DataPacket(dataPacketSize, 4, startTime, 60));
                                    sat.getDataStorage().AddDataPacketToDataList(new Satellite.DataPacket(dataPacketSize, 4, startTime, 60));
                                }
                            }

                        }
                    }
                }
            }
        }
    }
}
