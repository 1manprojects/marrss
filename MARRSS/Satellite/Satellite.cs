﻿/**
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
using MARRSS.Global;

namespace MARRSS.Satellite
{
    /**
    * \brief Satellite Class
    *
    * This class defines the satellite object containing of a name the NORAD-ID
    * and its two line element.
    */
    class Satellite
    {
        private string name; //!< string satellite name
        private One_Sgp4.Tle tleData; //!< TLE two line element data for the satellite
        private DataStorage dataStorage;
        private string homeStation;
        private Structs.priority globalPriority;

        //! Satellite constructor.
        /*!
            \param string name of the satellite
            \param Data onboard stoarge data default NULL
        */
        public Satellite(string _name)
        {
            name = _name;
            dataStorage = new DataStorage();
        }

        public void ResetDataStorage()
        {
            dataStorage = new DataStorage();
        }

        //! Satellite constructor.
        /*!
            \param string name of the satellite
            \param Tle Two Line Element data
        */
        public Satellite(string _name, One_Sgp4.Tle _tleData)
        {
            dataStorage = new DataStorage(Properties.Settings.Default.global_defaultDataStorageSat);
            name = _name;
            tleData = _tleData;
        }

        //! Satellite constructor.
        /*!
            \param string name of the satellite
            \param Tle Two Line Element data
            \param long onboard stoarge size
            \param Structs.DataSize onboard stoarge size B,kB,MB,GB,TB
        */
        public Satellite(string _name, One_Sgp4.Tle _tleData, long onBoardData, Structs.DataSize datasize)
        {
            dataStorage = new DataStorage(onBoardData, datasize);
            name = _name;
            tleData = _tleData;
        }

        //! Satellite constructor.
        /*!
            \param string name of the satellite
            \param Tle Two Line Element data
            \param long onboard stoarge size
            \param int onboard stoarge size B,kB,MB,GB,TB
        */
        public Satellite(string _name, One_Sgp4.Tle _tleData, long onBoardData, int datasize)
        {
            dataStorage = new DataStorage(onBoardData, (Structs.DataSize)datasize);
            name = _name;
            tleData = _tleData;
        }

        //! Sets the TLE-Data for this object
        /*!
            \pram tle TwoLineElement data 
            \return bool if successful
        */
        public bool setTleData(One_Sgp4.Tle _tleData)
        {
            //toDo
            //Check Tle Data if its newer
            tleData = _tleData;
            return true;
        }

        //! Returns the name of the satellite
        /*!
            \return string satellite name
        */
        public string getName()
        {
            return name;
        }

        //! Returns the TLE data of the satellite
        /*!
            \return Tle two line element data
        */
        public One_Sgp4.Tle getTleData()
        {
            return tleData;
        }

        //! Returns the stored data object of the satellite
        /*!
            \return Global.Data data storage used on satellite
        */
        public DataStorage getDataStorage()
        {
            return dataStorage;
        }

        public bool AddDataPacket(DataPacket packet)
        {
            return dataStorage.addToDataStorage(packet);
        }

        public bool RemoveDataPacket(DataPacket packet)
        {
            return dataStorage.removeDataFromStorage(packet);
        }

        public void setHomeStation(string nameOfStation)
        {
            homeStation = nameOfStation;
        }

        public string getHomeStation()
        {
            return homeStation;
        }

        public void SetMaxDataStorage(long maxStorageDataSize)
        {
            dataStorage.setMaxData(maxStorageDataSize);
        }

        public void setGlobalPriority(Structs.priority prio)
        {
            globalPriority = prio;
        }
    }
}
