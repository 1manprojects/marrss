using MARRSS.Global;
using MARRSS.Interface2;
using MARRSS.Scheduler;
using One_Sgp4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                input.getContactWindows().getAt(i).setPriority(Global.Structs.priority.NONE);
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
                input.getContactWindows().getAt(i).setPriority(pr);
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
                if (input.getContactWindows().getAt(i).getSatName() == "UWE-3")
                {
                    input.getContactWindows().getAt(i).setPriority(0);
                }
                else
                {
                    int p = rnd.Next(0, 5);
                    Global.Structs.priority pr;
                    pr = (Structs.priority)p;
                    input.getContactWindows().getAt(i).setPriority(pr);
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
                if (input.getContactWindows().getAt(i).getSatName() == "UWE-3"
                    && input.getContactWindows().getAt(i).getStationName() ==
                    "Würzburg (Computer Science Institute)")
                {
                    input.getContactWindows().getAt(i).setPriority(Structs.priority.CRITICAL);
                    found = true;
                }
                //------------2
                if (input.getContactWindows().getAt(i).getSatName() == "AAUSAT3"
                    && input.getContactWindows().getAt(i).getStationName() ==
                    "Aalborg (Aalborg University)")
                {
                    input.getContactWindows().getAt(i).setPriority(Structs.priority.CRITICAL);
                    found = true;
                }
                //------------3
                if (input.getContactWindows().getAt(i).getSatName() == "ITUPSAT 1"
                   && input.getContactWindows().getAt(i).getStationName() ==
                   "Istanbul (Istanbul Technical University)")
                {
                    input.getContactWindows().getAt(i).setPriority(Structs.priority.CRITICAL);
                    found = true;
                }
                //------------4
                if (input.getContactWindows().getAt(i).getSatName() == "LITUANICASAT 1"
                   && input.getContactWindows().getAt(i).getStationName() ==
                   "Lithuania (Vilnius University)")
                {
                    input.getContactWindows().getAt(i).setPriority(Structs.priority.CRITICAL);
                    found = true;
                }
                //------------5
                if (input.getContactWindows().getAt(i).getSatName() == "TIGRISAT"
                   && input.getContactWindows().getAt(i).getStationName() ==
                   "Roma (La Sapienza University of Rome)")
                {
                    input.getContactWindows().getAt(i).setPriority(Structs.priority.CRITICAL);
                    found = true;
                }
                //------------6
                if (input.getContactWindows().getAt(i).getSatName() == "CUBESAT XI-IV"
                   && input.getContactWindows().getAt(i).getStationName() ==
                   "Tokyo University")
                {
                    input.getContactWindows().getAt(i).setPriority(Structs.priority.CRITICAL);
                    found = true;
                }
                //------------7
                if (input.getContactWindows().getAt(i).getSatName() == "CUBESAT XI-V"
                  && input.getContactWindows().getAt(i).getStationName() ==
                  "Sapporo (Hokkaido Institute of Technology)")
                {
                    input.getContactWindows().getAt(i).setPriority(Structs.priority.CRITICAL);
                    found = true;
                }

                if (!found)
                {
                    int p = rnd.Next(1, 5);
                    Global.Structs.priority pr;
                    pr = (Structs.priority)p;
                    input.getContactWindows().getAt(i).setPriority(pr);
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
                EpochTime startT = new EpochTime(input.getContactWindows().getStartTime());
                EpochTime stopT = new EpochTime(input.getContactWindows().getStopTime());
                while (startT.toDateTime() < stopT.toDateTime())
                {
                    startT.addTick(60);
                    sat.AddDataPacket(new Satellite.DataPacket(1, 4, startT, 60, Structs.DataSize.MBYTE));
                }
            }
        }

        public static void GenerateCustomDataScenario(ScheduleProblemInterface input, JPlan customPlan)
        {
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
                        foreach(var value in timeline.values)
                        {
                            var lowerBoundDuration = value.duration.LowerBoundToTimeSpan();
                            var storage = value.value.Substring(1, value.value.Length - 2);
                            string[] storages = storage.Split(',');
                            var lowerBoundStorage = Double.Parse(storages[1]);

                            var lowerBoundInMin = lowerBoundDuration.TotalMinutes;
                            var startTime = new One_Sgp4.EpochTime(value.time.lb);

                            int dataPacketSize = 0;
                            if (storages.Count() >= 3)
                            {
                                dataPacketSize = (int)(Double.Parse(storages[2]) * 1000);

                                var counter = 0;
                                for (int i = 0; i < lowerBoundInMin; i+=60)
                                {
                                    startTime.addTick(60);
                                    sat.AddDataPacket(new Satellite.DataPacket(dataPacketSize, 4, startTime, 60, Structs.DataSize.KBYTE));
                                    counter += 1;
                                }
                                if (counter < lowerBoundInMin)
                                {
                                    var rest = lowerBoundInMin % 1;
                                    startTime.addTick(60 * rest);
                                    var test = (int)(dataPacketSize * rest);
                                    sat.AddDataPacket(new Satellite.DataPacket(dataPacketSize, 4, startTime, 60, Structs.DataSize.KBYTE));
                                }
                            }

                        }
                    }
                }
            }
            
        }
    }
}
