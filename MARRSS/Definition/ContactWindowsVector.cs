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

using MARRSS.Scheduler;
using MARRSS.Global;
using Newtonsoft.Json;

namespace MARRSS.Definition
{
/**
* \brief Contact Windows Vector Class
*
* This class handles the contact windows for all satellite at any given time.
* Adding new elements deleting them or sorting the list.
*/
    public class ContactWindowsVector
    {
        public List<ContactWindow> ContactWindows { get; set; } //!< List of all contactwindows
        public List<string> StationsNames { get; set; }
        public List<string> SatelliteNames { get; set; }

        [JsonConverter(typeof(ToStringJsonConverter))]
        public One_Sgp4.EpochTime StartTime { get; set; }
        [JsonConverter(typeof(ToStringJsonConverter))]
        public One_Sgp4.EpochTime EndTime { get; set; }
        public double ContactsDuration { get; set; }

        //! ContactWindowsVector constructor.
        /*!
            Creates new Object to store ContactWindows
        */
        public ContactWindowsVector()
        {
            ContactWindows = new List<ContactWindow>();
            StationsNames = new List<string>();
            SatelliteNames = new List<string>();
            ContactsDuration = 0.0;
        }

        //! ContactWindowsVector constructor.
        /*!
            \param ContactWindowsVector 
            Creates a new object from a ContactWindowsVector
        */
        public ContactWindowsVector(ContactWindowsVector contacts)
        {
            ContactWindows = new List<ContactWindow>(contacts.getAllContacts());
            SatelliteNames = new List<string>(contacts.SatelliteNames);
            StationsNames = new List<string>(contacts.StationsNames);
            StartTime = new One_Sgp4.EpochTime(contacts.StartTime);
            EndTime = new One_Sgp4.EpochTime(contacts.EndTime);
            calcualteTimesOfAllContacst();
        }

        public ContactWindowsVector getScheduledContacts()
        {
            ContactWindowsVector res = new ContactWindowsVector(this);
            res.RemoveUnscheduledContacts();
            return res;
        }

        private void RemoveUnscheduledContacts()
        {
            for (int i = 0; i < ContactWindows.Count; i++)
            {
                if (!ContactWindows[i].IsScheduled)
                {
                    ContactWindows.RemoveAt(i);
                    i--;
                }
            }
            calcualteTimesOfAllContacst();
        }

        //! Update Names
        /*!
            Updated the name lists for satellites and groundstations
        */
        private void updateNamesList()
        {
            StationsNames = new List<string>();
            SatelliteNames = new List<string>();

            for (int i = 0; i < ContactWindows.Count(); i++)
            {
                //satNames
                bool found = false;
                int pos = 0;
                for (int k = 0; k < SatelliteNames.Count(); k++)
                {
                    if (SatelliteNames[k] == ContactWindows[i].SatelliteName)
                    {
                        found = true;
                        pos = k;
                        break;
                    }
                }
                if (!found)
                {
                    SatelliteNames.Add(ContactWindows[i].SatelliteName);
                }
                //Stations Names
                found = false;
                pos = 0;
                for (int k = 0; k < StationsNames.Count(); k++)
                {
                    if (StationsNames[k] == ContactWindows[i].StationName)
                    {
                        found = true;
                        pos = k;
                        break;
                    }
                }
                if (!found)
                {
                    StationsNames.Add(ContactWindows[i].StationName);
                }
            }
        }

        //! get Number of Satellites
        /*!
            \return int number of satellites
        */
        public int getNumberOfSatellites()
        {
            return SatelliteNames.Count(); ;
        }

        //! get Number of Stations
        /*!
            \return int number of sations
        */
        public int getNumberOfStation()
        {
            return StationsNames.Count();
        }

        //! clear 
        /*!
            Clears all stored Data
        */
        public void clear()
        {
            ContactWindows.Clear();
            StationsNames.Clear();
            SatelliteNames.Clear();
            ContactsDuration = 0.0;
        }

        //! add ContactWindow
        /*!
            \param ContactWindow adds a ContactWindow
        */
        public void add(ContactWindow contact, bool updateInfo = true)
        {
            ContactWindows.Add(contact);
            ContactsDuration += contact.ContactDuration();
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
                ContactWindows.AddRange(contacts);
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
                    ContactWindows.Add(contacts.getAt(i));
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
            return ContactWindows;
        }

        //! Count
        /*!
            \return int number of Contacts
        */
        public int Count()
        {
            return ContactWindows.Count();
        }

        //! Get contact at pos
        /*! 
            \param int position in List
            \return ContactWindow 
        */
        public ContactWindow getAt(int pos)
        {
            return ContactWindows[pos];
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
                ContactsDuration -= ContactWindows[pos].ContactDuration();
                ContactWindows.RemoveAt(pos);
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
            return ContactWindows.Count() == 0;
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
                result.add(ContactWindows[i]);
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
            ContactWindows.RemoveRange(start, count);
            calcualteTimesOfAllContacst();
        }

        //! Get number of Scheduled Contacts
        /*! 
            \param int Nr of Scheduled
        */
        public int getNrOfScheduled()
        {
            int result = 0;
            for (int i = 0; i < ContactWindows.Count(); i++)
            {
                if (ContactWindows[i].getSheduledInfo())
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
            if (ContactWindows.Count > 0)
            {
                return ContactWindows[ContactWindows.Count - 1];
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
            if (ContactWindows.Count > 0)
            {
                return ContactWindows[0];
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
            int size = ContactWindows.Count();
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
                            double epoch1 = ContactWindows[l].StartTime.getEpoch();
                            int year1 = ContactWindows[l].EndTime.getYear();
                            double epoch2 = ContactWindows[l - hSort].StartTime.getEpoch();
                            int year2 = ContactWindows[l - hSort].StartTime.getYear();
                            if (year1 <= year2 && epoch1 < epoch2)
                            {
                                ContactWindow t = ContactWindows[l];
                                ContactWindows[l] = ContactWindows[l - hSort];
                                ContactWindows[l - hSort] = t;
                            }
                        }
                        if (toSort == Structs.sortByField.GROUNDSTATION)
                        {
                            string st1 = ContactWindows[l].StationName;
                            string st2 = ContactWindows[l - hSort].StationName;
                            if (st1.CompareTo(st2) < 1 )
                            {
                                ContactWindow t = ContactWindows[l];
                                ContactWindows[l] = ContactWindows[l - hSort];
                                ContactWindows[l - hSort] = t;
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
            for (int i = 0; i < ContactWindows.Count; i++)
            {
                if (ContactWindows[i].getSheduledInfo())
                    scheduled++;
            }
            return scheduled;
        }

        private void calcualteTimesOfAllContacst()
        {
            ContactsDuration = 0.0;
            for (int i = 0; i < ContactWindows.Count; i++)
            {
                ContactsDuration += ContactWindows[i].ContactDuration();
            }
        }

        public double getCompleteContactTime()
        {
            return ContactsDuration;
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

            for (int i = 0; i < ContactWindows.Count() ; i++)
            {
                int item1 = rnd.Next(0,ContactWindows.Count()-1);
                int item2 = rnd.Next(0,ContactWindows.Count()-1);
                ContactWindow t = ContactWindows[item1];
                ContactWindows[item1] = ContactWindows[item2];
                ContactWindows[item2] = t;
            }
        }
    }
}
