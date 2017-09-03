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
        private Data dataStorage;

        //! Satellite constructor.
        /*!
            \param string name of the satellite
            \param Data onboard stoarge data default NULL
        */
        public Satellite(string _name, Data onboardData = null)
        {
            name = _name;
            dataStorage = onboardData;
        }

        //! Satellite constructor.
        /*!
            \param string name of the satellite
            \param Tle Two Line Element data
        */
        public Satellite(string _name, One_Sgp4.Tle _tleData)
        {
            dataStorage = new Data(Properties.Settings.Default.global_defaultDataStorageSat,
                Properties.Settings.Default.global_defaultDataStorageSatSize);
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
            dataStorage = new Data(onBoardData, datasize);
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
            dataStorage = new Data(onBoardData, (Structs.DataSize)datasize);
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
            dataStorage = new Data(Properties.Settings.Default.global_defaultDataStorageSat,
                Properties.Settings.Default.global_defaultDataStorageSatSize);
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
        public Data getStoredData()
        {
            return dataStorage;
        }

    }
}
