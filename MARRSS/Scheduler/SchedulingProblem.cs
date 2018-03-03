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

        public Satellite.Satellite getSatelliteByName(string name)
        {
            foreach(var sat in satellites)
            {
                if (sat.getName().ToLower() == name.ToLower())
                {
                    return sat;
                }
            }
            return null;
        }

        public List<Ground.Station> getGroundStations()
        {
            return stations;
        }

        public Ground.Station getGroundStationByName(string name)
        {
            foreach (var sta in stations)
            {
                if (sta.getName().ToLower() == name.ToLower())
                {
                    return sta;
                }
            }
            return null;
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

        public EpochTime getStartTime()
        {
            return schedulerContacts.getStartTime();
        }

        public EpochTime getEndTime()
        {
            return schedulerContacts.getStopTime();
        }
    }
}
