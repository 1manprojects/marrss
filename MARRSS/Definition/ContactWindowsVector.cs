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
using System.Runtime.Serialization;

using MARRSS.Scheduler;
using MARRSS.Global;

namespace MARRSS.Definition
{
/**
* \brief Contact Windows Vector Class
*
* This class handles the contact windows for all satellite at any given time.
* Adding new elements deleting them or sorting the list.
*/
    class ContactWindowsVector : ISerializable
    {

        private List<ContactWindow> contactsList; //!< List of all contactwindows
        private List<string> stationNameList; //!< List of all stations by name
        private List<string> satelliteNameList; //!< List of all satellites by name

        private One_Sgp4.EpochTime starttime; //!< Starting time and date for Schedule
        private One_Sgp4.EpochTime stoptime; //!< Stop time and date for Schedule

        private double contactTime; //!< time of all contact windows in seconds

        //Serialization function.
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            //You can use any custom name for your name-value pair. But make sure you
            // read the values with the same name. For ex:- If you write EmpId as "EmployeeId"
            // then you should read the same with "EmployeeId"
            info.AddValue("ContactList", contactsList);
            info.AddValue("StationList", stationNameList);
            info.AddValue("SatelliteList", satelliteNameList);
        }

        //! ContactWindowsVector constructor.
        /*!
            Creates new Object to store ContactWindows
        */
        public ContactWindowsVector()
        {
            contactsList = new List<ContactWindow>();
            stationNameList = new List<string>();
            satelliteNameList = new List<string>();
            contactTime = 0.0;
        }

        //! ContactWindowsVector constructor.
        /*!
            \param ContactWindowsVector 
            Creates a new object from a ContactWindowsVector
        */
        public ContactWindowsVector(ContactWindowsVector contacts)
        {
            contactsList = new List<ContactWindow>(contacts.getAllContacts());
            satelliteNameList = new List<string>(contacts.getSatelliteNames());
            stationNameList = new List<string>(contacts.getStationNames());
            starttime = new One_Sgp4.EpochTime(contacts.getStartTime());
            stoptime = new One_Sgp4.EpochTime(contacts.getStopTime());
            calcualteTimesOfAllContacst();
        }

        //! Update Names
        /*!
            Updated the name lists for satellites and groundstations
        */
        private void updateNamesList()
        {
            stationNameList = new List<string>();
            satelliteNameList = new List<string>();

            for (int i = 0; i < contactsList.Count(); i++)
            {
                //satNames
                bool found = false;
                int pos = 0;
                for (int k = 0; k < satelliteNameList.Count(); k++)
                {
                    if (satelliteNameList[k] == contactsList[i].getSatName())
                    {
                        found = true;
                        pos = k;
                        break;
                    }
                }
                if (!found)
                {
                    satelliteNameList.Add(contactsList[i].getSatName());
                }
                //Stations Names
                found = false;
                pos = 0;
                for (int k = 0; k < stationNameList.Count(); k++)
                {
                    if (stationNameList[k] == contactsList[i].getStationName())
                    {
                        found = true;
                        pos = k;
                        break;
                    }
                }
                if (!found)
                {
                    stationNameList.Add(contactsList[i].getStationName());
                }
            }
        }

        //! get Satellite Names
        /*!
            \return List<string> of all satellites names
        */
        public List<string> getSatelliteNames()
        {
            return satelliteNameList;
        }

        //! get Stations Names
        /*!
            \return List<string> of all stations names
        */
        public List<string> getStationNames()
        {
            return stationNameList;
        }

        //! get Number of Satellites
        /*!
            \return int number of satellites
        */
        public int getNumberOfSatellites()
        {
            return satelliteNameList.Count(); ;
        }

        //! get Number of Stations
        /*!
            \return int number of sations
        */
        public int getNumberOfStation()
        {
            return stationNameList.Count();
        }

        //! clear 
        /*!
            Clears all stored Data
        */
        public void clear()
        {
            contactsList.Clear();
            stationNameList.Clear();
            satelliteNameList.Clear();
            contactTime = 0.0;
        }

        //! set the start time 
        /*!
            \param TimeDate starting time for schedule
        */
        public void setStartTime(One_Sgp4.EpochTime start)
        {
            starttime = start;
        }

        //! set the stop time 
        /*!
            \param TimeDate stoping time for schedule
        */
        public void setStopTime(One_Sgp4.EpochTime stop)
        {
            stoptime = stop;
        }

        //! get the start time 
        /*!
            \return TimeDate starting time for schedule
        */
        public One_Sgp4.EpochTime getStartTime()
        {
            return starttime;
        }

        //! get the stop time 
        /*!
            \return TimeDate stoping time for schedule
        */
        public One_Sgp4.EpochTime getStopTime()
        {
            return stoptime;
        }

        //! add ContactWindow
        /*!
            \param ContactWindow adds a ContactWindow
        */
        public void add(ContactWindow contact, bool updateInfo = true)
        {
            contactsList.Add(contact);
            contactTime += contact.getDuration();
            if (updateInfo)
                updateNamesList();
        }

        //! add ContactWindows
        /*!
            \param List<ContactWindow> adds a list of ContactWindows
        */
        public void add(List<ContactWindow> contacts)
        {
            if (contacts.Count > 0)
                contactsList.AddRange(contacts);
            updateNamesList();
            calcualteTimesOfAllContacst();
        }

        //! add ContactWindows
        /*!
            \param ContactWindowsVector adds a ContactsWindowsVector
        */
        public void add(ContactWindowsVector contacts)
        {
            if (!contacts.isEmpty())
                for(int i = 0; i < contacts.Count(); i++)
                {
                    contactsList.Add(contacts.getAt(i));
                }
            updateNamesList();
            calcualteTimesOfAllContacst();
        }

        //! Get All ContactWindows
        /*!
            \return List<ContactWindow> returns all Contactwindows
        */
        public List<ContactWindow> getAllContacts()
        {
            return contactsList;
        }

        //! Count
        /*!
            \return int number of Contacts
        */
        public int Count()
        {
            return contactsList.Count();
        }

        //! Get contact at pos
        /*! 
            \param int position in List
            \return ContactWindow 
        */
        public ContactWindow getAt(int pos)
        {
            return contactsList[pos];
        }

        //! Delete contact at pos
        /*! 
            \param int position in List to be deleted
            \return bool true if item could be deleted
        */
        public bool deleteAt(int pos)
        {
            if (pos >= 0)
            {
                contactTime -= contactsList[pos].getDuration();
                contactsList.RemoveAt(pos);
                updateNamesList();
                
                return true;
            }
            else
            {
                return false;
            }
        }

        //! Is Empty
        /*! 
            \return bool if ContactWindowsVector is empty 
        */
        public bool isEmpty()
        {
            return contactsList.Count() == 0;
        }

        //! Get contact in range
        /*! 
            \param int starting point in list
            \param int count number of items
            \return ContactWindowsVector of items in range
        */
        public ContactWindowsVector getRange(int start, int count)
        {
            ContactWindowsVector result = new ContactWindowsVector();
            for(int i = start; i <= count; i++)
            {
                result.add(contactsList[i]);
            }
            return result;
        }

        //! Delete contact in range
        /*! 
            \param int starting point in list
            \param int count number of items
            Deletes nr of Contacts from starting point 
        */
        public void deleteRange(int start, int count)
        {
            contactsList.RemoveRange(start, count);
            calcualteTimesOfAllContacst();
        }

        //! Get number of Scheduled Contacts
        /*! 
            \param int Nr of Scheduled
        */
        public int getNrOfScheduled()
        {
            int result = 0;
            for (int i = 0; i < contactsList.Count(); i++)
            {
                if (contactsList[i].getSheduledInfo())
                {
                    result++;
                }
            }
            return result;
        }

        //! getLast entry of vector
        /*! 
            \return ContactWindows the last element of the Vector
        */
        public ContactWindow getLast()
        {
            if (contactsList.Count > 0)
            {
                return contactsList[contactsList.Count - 1];
            }
            else
            {
                return null;
            }
        }

        //! getFirst entry of vector
        /*! 
            \return ContactWindows the first element of the Vector
        */
        public ContactWindow getFirst()
        {
            if (contactsList.Count > 0)
            {
                return contactsList[0];
            }
            else
            {
                return null;
            }
        }

        //! Sort ContacWindowsVector
        /*! 
            \param SortByField defines what to sort for
            Sorts all the ContactWindows by Time/Name/Station/..
        */
        public void sort(Structs.sortByField toSort)
        {
            int size = contactsList.Count();
            int hSort = 1;
            while (hSort < size / 3)
                hSort = (3 * hSort) + 1;

            while (hSort >= 1)
            {
                for (int i = hSort; i < size; i++)
                {
                    for (int l = i; l >= hSort; l -= hSort)
                    {
                        if (toSort == Structs.sortByField.TIME)
                        { 
                            double epoch1 = contactsList[l].getStartTime().getEpoch();
                            int year1 = contactsList[l].getStartTime().getYear();
                            double epoch2 = contactsList[l - hSort].getStartTime().getEpoch();
                            int year2 = contactsList[l - hSort].getStartTime().getYear();
                            if (year1 <= year2 && epoch1 < epoch2)
                            {
                                ContactWindow t = contactsList[l];
                                contactsList[l] = contactsList[l - hSort];
                                contactsList[l - hSort] = t;
                            }
                        }
                        if (toSort == Structs.sortByField.GROUNDSTATION)
                        {
                            string st1 = contactsList[l].getStationName();
                            string st2 = contactsList[l - hSort].getStationName();
                            if (st1.CompareTo(st2) < 1 )
                            {
                                ContactWindow t = contactsList[l];
                                contactsList[l] = contactsList[l - hSort];
                                contactsList[l - hSort] = t;
                            }
                        }
                    }
                }
                hSort /= 3;
            }
        }

        //! get Number of Scheduled contacts in Set
        /*! 
            \return int numver of contacts that have their scheduled flag set to true
        */
        public int getNumberOfScheduledContacts()
        {
            int scheduled = 0;
            for (int i = 0; i < contactsList.Count; i++)
            {
                if (contactsList[i].getSheduledInfo())
                    scheduled++;
            }
            return scheduled;
        }

        private void calcualteTimesOfAllContacst()
        {
            contactTime = 0.0;
            for (int i = 0; i < contactsList.Count; i++)
            {
                contactTime += contactsList[i].getDuration();
            }
        }

        public double getCompleteContactTime()
        {
            return contactTime;
        }

        //! Randomize ContactWindowsVector
        /*! 
            \param int random seed to randomize set
        */
        public void randomize(int seed = 0)
        {
            Random rnd;
            if (seed == 0)
                rnd = new Random();
            else
                rnd = new Random(seed);

            for (int i = 0; i < contactsList.Count() ; i++)
            {
                int item1 = rnd.Next(0,contactsList.Count()-1);
                int item2 = rnd.Next(0,contactsList.Count()-1);
                ContactWindow t = contactsList[item1];
                contactsList[item1] = contactsList[item2];
                contactsList[item2] = t;
            }
        }
    }
}
