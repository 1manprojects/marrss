using MARRSS.Global;
using MARRSS.Interface2;
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
    }
}
