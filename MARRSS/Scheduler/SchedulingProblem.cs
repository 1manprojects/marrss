/**
* ----------------------------------------------------------------
* Nikolai Jonathan Reed 
*
* 
* Copyright (c) 2015, Nikolai Reed, 1manprojects.de
* All rights reserved.
*
* Licensed under
* Creative Commons Attribution NonCommercial (CC-BY-NC)
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MARRSS.Interface2;
using MARRSS.Interface1;
using MARRSS.Definition;
using MARRSS.Global;
using One_Sgp4;

namespace MARRSS.Scheduler
{
    /**
    * \brief Scheduling Problem
    *
    * This class defines the problem to solve for the scheduler. Herby the Contact
    * windows are checked if they meet the necesary requirements. For example
    * long enough contact time.
    */
    class SchedulingProblem : ScheduleProblemInterface
    {
        private ContactWindowsVector schedulerContacts; //!< ContactWindowsVector all contact windows
        private List<RequestInterface> schedulerRequests; //!< List<RequestInterface> list of all Requests
        private ObjectiveFunction objectives; //!< Objectives to solve Problem with
        private List<Satellite.Satellite> satellites; //!< List<Satellite.Satellite> list of all Included Satellites
        private List<Ground.Station> stations; //!< List<Station> list of all Included Ground Stations

        //! SchedulingProblem constructor.
        /*!
            empty constructor
        */
        public SchedulingProblem()
        {

        }

        //! Get the Objective-Function of the current Problem
        /*!
            \return ObjectiveFunction
        */
        public ObjectiveFunction getObjectiveFunction()
        {
            return objectives;
        }

        //! Set Objective-Function to current Problem
        /*!
            \pram ObjectiveFunction objectives for the problem
        */
        public void setObjectiveFunction(ObjectiveFunction objectiveFunction)
        {
            objectives = objectiveFunction;
        }

        //! Set ContactWindows to current Problem
        /*!
            \pram ContactWindowsVector all contacts
        */
        public void setContactWindows(ContactWindowsVector contacts)
        {
            schedulerContacts = contacts;
        }

        //! Sets the Request List
        /*!
            \pram List<RequestInterface> all Requestst to consider
        */
        public void setRequests(List<RequestInterface> requestsList)
        {
            schedulerRequests = requestsList;
        }

        //! Sets the Requests to ContactWindows
        /*!
            
        */
        public void setRequestToContact()
        {
            //toDo asign requests to Contacts
            //remove all Contacts that are not asigned a request
        }

        //! Returns the ContactWindows 
        /*!
            \return ContactWindowsVector
        */
        public ContactWindowsVector getContactWindows()
        {
            return schedulerContacts;
        }

        public void setSatellites(List<Satellite.Satellite> sats)
        {
            satellites = sats;
        }

        public void setGroundStations(List<Ground.Station> stats)
        {
            stations = stats;
        }

        public List<Satellite.Satellite> getSatellites()
        {
            return satellites;
        }
        public List<Ground.Station> getGroundStations()
        {
            return stations;
        }

        //! Remove unwanted contact windows 
        /*!
            \param int Min. Duration window
            Deletes all contact windows whitch contact times are lower then min duration
        */
        public void removeUnwantedContacts(int minDuration)
        {
            for (int i = 0; i < schedulerContacts.Count(); i++ )
            {
                if (schedulerContacts.getAt(i).getDuration() < minDuration)
                {
                    schedulerContacts.deleteAt(i);
                    i--;
                }
            }
        }

        //------------------------Create Scenarios-----------------------------
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------

        public void Generate100MbPerMinuteScenario()
        {
            //LOAD Plan FIle
            //Fill satellite wiht data from Start to Finisch
            foreach (Satellite.Satellite sat in satellites)
            {
                EpochTime startT = new EpochTime(schedulerContacts.getStartTime());
                EpochTime stopT = new EpochTime(schedulerContacts.getStopTime());
                while(startT.toDateTime() < stopT.toDateTime())
                {
                    startT.addTick(60);
                    sat.AddDataPacket(new Satellite.DataPacket(100, 4, 60, Structs.DataSize.MBYTE));
                }
            }
        }


        //      Load Scenario Here and setUp
        //---------------------------------------------------------------------

        public void GenerateSzenarioA()
        {
            for (int i = 0; i < schedulerContacts.Count(); i++)
            {
                schedulerContacts.getAt(i).setPriority(Global.Structs.priority.NONE);
            }
        }
        
        public void GenerateSzenarioC(int seed = 0)
        { 
            Random rnd;
            if (seed == 0)
                rnd = new Random();
            else
                rnd = new Random(seed);

            for (int i= 0; i < schedulerContacts.Count(); i++)
            {
                if (schedulerContacts.getAt(i).getSatName() == "UWE-3")
                {
                    schedulerContacts.getAt(i).setPriority(0);
                }
                else
                {
                    int p = rnd.Next(0, 5); 
                    Global.Structs.priority pr;
                    pr = (Structs.priority)p;
                    schedulerContacts.getAt(i).setPriority(pr);
                }
            }
        }

        public void GenerateSzenarioB(int seed = 0)
        {
            Random rnd;
            if (seed == 0)
                rnd = new Random();
            else
                rnd = new Random(seed);

            for (int i = 0; i < schedulerContacts.Count(); i++)
            {
                int p = rnd.Next(0, 5);
                Global.Structs.priority pr;
                pr = (Structs.priority)p;
                schedulerContacts.getAt(i).setPriority(pr);
            }
        }

        public void GenerateSzenarioD(int seed = 0)
        {
            Random rnd;
            if (seed == 0)
                rnd = new Random();
            else
                rnd = new Random(seed);

            for (int i = 0; i < schedulerContacts.Count(); i++)
            {
                bool found = false;
                //------------1
                if (schedulerContacts.getAt(i).getSatName() == "UWE-3"
                    && schedulerContacts.getAt(i).getStationName() == 
                    "Würzburg (Computer Science Institute)")
                {
                    schedulerContacts.getAt(i).setPriority(Structs.priority.CRITICAL);
                    found = true;
                }
                //------------2
                if (schedulerContacts.getAt(i).getSatName() == "AAUSAT3"
                    && schedulerContacts.getAt(i).getStationName() ==
                    "Aalborg (Aalborg University)")
                {
                    schedulerContacts.getAt(i).setPriority(Structs.priority.CRITICAL);
                    found = true;
                }
                //------------3
                if (schedulerContacts.getAt(i).getSatName() == "ITUPSAT 1"
                   && schedulerContacts.getAt(i).getStationName() ==
                   "Istanbul (Istanbul Technical University)")
                {
                    schedulerContacts.getAt(i).setPriority(Structs.priority.CRITICAL);
                    found = true;
                }
                //------------4
                if (schedulerContacts.getAt(i).getSatName() == "LITUANICASAT 1"
                   && schedulerContacts.getAt(i).getStationName() ==
                   "Lithuania(Vilnius University)")
                {
                    schedulerContacts.getAt(i).setPriority(Structs.priority.CRITICAL);
                    found = true;
                }
                //------------5
                if (schedulerContacts.getAt(i).getSatName() == "TIGRISAT"
                   && schedulerContacts.getAt(i).getStationName() ==
                   "Roma (La Sapienza University of Rome)")
                {
                    schedulerContacts.getAt(i).setPriority(Structs.priority.CRITICAL);
                    found = true;
                }
                //------------6
                if (schedulerContacts.getAt(i).getSatName() == "CUBESAT XI-IV"
                   && schedulerContacts.getAt(i).getStationName() ==
                   "Tokyo University")
                {
                    schedulerContacts.getAt(i).setPriority(Structs.priority.CRITICAL);
                    found = true;
                }
                //------------7
                if (schedulerContacts.getAt(i).getSatName() == "CUBESAT XI-V"
                  && schedulerContacts.getAt(i).getStationName() ==
                  "Sapporo (Hokkaido Institute of Technology)")
                {
                    schedulerContacts.getAt(i).setPriority(Structs.priority.CRITICAL);
                    found = true;
                }

                if (!found)
                {
                    int p = rnd.Next(1, 5);
                    Global.Structs.priority pr;
                    pr = (Structs.priority)p;
                    schedulerContacts.getAt(i).setPriority(pr);
                }

            }
        }
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
    }
}
