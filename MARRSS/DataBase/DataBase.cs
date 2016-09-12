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
using System.Data.SQLite;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Threading;

using System.Diagnostics;

using MARRSS.Scheduler;
using MARRSS.Definition;

namespace MARRSS.DataBase
{
 /**
* \brief SQLlite DataBase class
*
* This class defnies the callback functions for the SQLlite DataBase like
* reading and writing of the available data. Also Saving Schedules and loading
* previously saved ContactWindows and schedules
*/
    class DataBase
    {

        private SQLiteConnection m_dbConnection; //!< SQLlite connector
        private bool isConnected;   //!< bool if connected to DB
        private string _dbName = "SatData.mab"; //!< string Name of DatabaseFile
        private int errorCode = 0; //!< int Error number

        //! DataBase constructor
        /*!
            Opens Connection to Database file or creates it if it does not exist
        */
        public DataBase()
        {
            //m_dbConnection
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
            isConnected = false;
            if (!File.Exists(string.Format(_dbName)))
            {
                errorCode = 000;
                createNewDatabases();
            }
            else
            {
                try
                {
                    connectDB();
                    closeDB();
                }
                catch
                {
                    //ERROR could not connect to DB
                    //corrupt or unable to read
                    errorCode = 019;
                }
            }
        }


        //! Create new DataBase file
        /*! 
            Creates a new DataBase with emtpy Tables
        */
        public bool createNewDatabases()
        {
            SQLiteConnection.CreateFile(_dbName);
            m_dbConnection = new SQLiteConnection("Data Source=" + _dbName + ";Version=3;");
            m_dbConnection.Open();
            isConnected = true;
            SQLiteCommand command = new SQLiteCommand(m_dbConnection);
            command.CommandText = Constants.creSatTab;
            command.ExecuteNonQuery();
            command.CommandText = Constants.creStaTab;
            command.ExecuteNonQuery();
            command.CommandText = Constants.creTleTab;
            command.ExecuteNonQuery();
            m_dbConnection.Close();
            isConnected = false;
            return true;
        }

        //! Delete DataBase file
        /*! 
            Deletes the DataBase file
        */
        public void deleteDatabase()
        {
            
        }

        //! Connect to Database
        /*! 
            opens the Connection to the DataBase file
        */
        public bool connectDB()
        {
            //check if exists if not create it
            m_dbConnection = new SQLiteConnection("Data Source=" + _dbName + ";Version=3;");
            m_dbConnection.OpenAsync();
            isConnected = true;
            return true;
        }

        //! Closes connection to DataBase
        /*! 
            close connection
        */
        public bool closeDB()
        {
            if (isConnected)
            {
                m_dbConnection.Close();
                isConnected = false;
            }
            return true;
        }

        //! Write TLE-Data to DataBase
        /*! 
           \param tleData TLEData to be writen in DataBase.
        */
        public void writeTleData(One_Sgp4.Tle tleData)
        {
            if (!isConnected)
            {
                connectDB();
            }
            SQLiteCommand command = new SQLiteCommand(m_dbConnection);
            SQLiteCommand addSatCommand = new SQLiteCommand(m_dbConnection);

            int count = 0;
            command.CommandText = String.Format("SELECT count(*) FROM {0} WHERE noradID='{1}';",
                Constants.TleDB, tleData.getNoradID() );
            try
            {
                count = Convert.ToInt32(command.ExecuteScalar());
            }
            catch
            {
                count = 0;
            }
            
            if ( count == 0)
            {
                command.CommandText = String.Format(
                    Constants.insertTle,
                    Constants.TleDB, tleData.getName(), tleData.getNoradID(),
                tleData.getClassification(), tleData.getStartYear(),
                tleData.getStartNr(), tleData.getPice(), tleData.getEpochYear(),
                tleData.getEpochDay(), tleData.getFirstMeanMotion(),
                tleData.getSecondMeanMotion(), tleData.getDrag(),
                tleData.getEphemeris(), tleData.getSetNumber(), tleData.getFirstCheckSum(),
                tleData.getSatNumber(), tleData.getInclination(),
                tleData.getRightAscendingNode(), tleData.getEccentriciy(),
                tleData.getPerigee(), tleData.getMeanAnomoly(), tleData.getMeanMotion(),
                tleData.getRelevationNumber(), tleData.getSecCheckSum());
                command.ExecuteNonQuery();

                addSatCommand.CommandText = String.Format(
                    Constants.insertSat,
                    Constants.SatDB, tleData.getName(), tleData.getNoradID());
                addSatCommand.ExecuteNonQuery();
            }
            else
            {
                //delet old Entry
                command.CommandText = String.Format(
                    Constants.deleteTLE,
                    Constants.TleDB,
                    tleData.getNoradID());
                command.ExecuteNonQuery();

                //insert new Entry
                command.CommandText = String.Format(
                    Constants.insertTle,
                    Constants.TleDB, tleData.getName(), tleData.getNoradID(),
                tleData.getClassification(), tleData.getStartYear(),
                tleData.getStartNr(), tleData.getPice(), tleData.getEpochYear(),
                tleData.getEpochDay(), tleData.getFirstMeanMotion(),
                tleData.getSecondMeanMotion(), tleData.getDrag(),
                tleData.getEphemeris(), tleData.getSetNumber(), tleData.getFirstCheckSum(),
                tleData.getSatNumber(), tleData.getInclination(),
                tleData.getRightAscendingNode(), tleData.getEccentriciy(),
                tleData.getPerigee(), tleData.getMeanAnomoly(), tleData.getMeanMotion(),
                tleData.getRelevationNumber(), tleData.getSecCheckSum());
                command.ExecuteNonQuery();

                SQLiteCommand delcommand = new SQLiteCommand(m_dbConnection);
                delcommand.CommandText = String.Format(
                        Constants.deleteSatellite2,
                        Constants.SatDB,
                        tleData.getNoradID());
                delcommand.ExecuteNonQuery();

                addSatCommand.CommandText = String.Format(
                    Constants.insertSat,
                    Constants.SatDB, tleData.getName(), tleData.getNoradID());
                addSatCommand.ExecuteNonQuery();
            }
        }

        //! Write satellite data to Database
        /*! 
           \param Satellite sattellite data to write into DataBase
        */
        public void writeSatellite(Satellite.Satellite sat)
        {
            if (!isConnected)
            {
                connectDB();
            }
            SQLiteCommand command = new SQLiteCommand(m_dbConnection);
            int count = 0;
            command.CommandText = String.Format("SELECT count(*) FROM {0} WHERE noradID='{1}';",
                Constants.SatDB, sat.getTleData().getNoradID());
            count = Convert.ToInt32(command.ExecuteScalar());
            if (count == 0)
            {
                command.CommandText = String.Format(
                     Constants.insertSat,
                     Constants.SatDB, sat.getName(), sat.getTleData().getNoradID());
                command.ExecuteNonQuery();
            }
        }

        //! Write GroundStation data to Database
        /*! 
           \param Station groundstation data to write into DataBase
        */
        public void writeStation(Ground.Station station)
        {
            if (!isConnected)
            {
                connectDB();
            }
            SQLiteCommand command = new SQLiteCommand(m_dbConnection);
            int count = 0;
            command.CommandText = String.Format("SELECT count(*) FROM {0} WHERE name='{1}';",
                Constants.StationDB, station.getName());
            count = Convert.ToInt32(command.ExecuteScalar());
            if (count == 0)
            {
                command.CommandText = String.Format(
                     Constants.insertSta,
                     Constants.StationDB, station.getName(), station.getLatitude(),
                     station.getLongitude(), station.getHeight(), station.getNrOfAntennas());
                command.ExecuteNonQuery();
            }
        }

        //! Get all satellite data from DataBase
        /*! 
           \param DataGridView to display all satellite data from DB
        */
        public void displayAllSatellites(DataGridView dataView)
        {
            if (!isConnected)
            {
                connectDB();
            }
            SQLiteCommand command = new SQLiteCommand(m_dbConnection);
            command.CommandText = String.Format(
                "SELECT * FROM {0}",
                Constants.SatDB);
            dataView.DataSource = null;
            dataView.Rows.Clear();
            using (SQLiteDataReader read = command.ExecuteReader())
            {
                while (read.Read())
                {
                    dataView.Rows.Add(new object[] { 
                    read.GetValue(0),
                    read.GetValue(1)
                    });
                }
            }
            closeDB();
        }

        //! Get all GroundStation data from DataBase
        /*! 
           \param DataGridView to display all station data from DB
        */
        public void displayAllStations(DataGridView dataView)
        {
            if (!isConnected)
            {
                connectDB();
            }
            SQLiteCommand command = new SQLiteCommand(m_dbConnection);
            command.CommandText = String.Format(
                "SELECT * FROM {0}",
                Constants.StationDB);
            dataView.DataSource = null;
            dataView.Rows.Clear();
            using (SQLiteDataReader read = command.ExecuteReader())
            {
                while (read.Read())
                {
                    dataView.Rows.Add(new object[] { 
                    read.GetValue(0),
                    //read.GetValue(1),
                    //read.GetValue(2),
                    //read.GetValue(3),
                    //read.GetValue(4),
                    });
                }
            }
            closeDB();
        }

        //! Get all satellite data from DataBase
        /*! 
           \param CheckedListBox to display all satellite data from DB
        */
        public void displayAllSatellites(CheckedListBox list)
        {
            if (!isConnected)
            {
                connectDB();
            }
            SQLiteCommand command = new SQLiteCommand(m_dbConnection);
            command.CommandText = String.Format(
                "SELECT * FROM {0}",
                Constants.SatDB);
            list.Items.Clear();
            using (SQLiteDataReader read = command.ExecuteReader())
            {
                while (read.Read())
                {
                    list.Items.Add(read.GetValue(0));
                }
            }
            closeDB();
        }

        //! Get all stations data from DataBase
        /*! 
           \param DataGridView to display all groundstation data from DB
        */
        public void displayAllStations(CheckedListBox list)
        {
            if (!isConnected)
            {
                connectDB();
            }
            SQLiteCommand command = new SQLiteCommand(m_dbConnection);
            command.CommandText = String.Format(
                "SELECT * FROM {0}",
                Constants.StationDB);
            list.Items.Clear();
            using (SQLiteDataReader read = command.ExecuteReader())
            {
                while (read.Read())
                {
                    list.Items.Add(read.GetValue(0));
                }
            }
            closeDB();
        }

        //! Get TLE-data from satellite from DataBase
        /*! 
           \param string Name of the satellite to get TLE-data from DB
        */
        public One_Sgp4.Tle getTleDataFromDB(string SatName)
        {
            if (!isConnected)
            {
                connectDB();
            }
            SQLiteCommand command = new SQLiteCommand(m_dbConnection);
            One_Sgp4.Tle tleItem;
            command.CommandText = String.Format("SELECT * FROM {0} WHERE satName='{1}';",
                Constants.TleDB, SatName);
            using (SQLiteDataReader read = command.ExecuteReader())
            {
                while (read.Read())
                {
                    tleItem = new One_Sgp4.Tle(read.GetString(0),
                        read.GetString(1),
                        read.GetInt32(2),
                        read.GetInt32(3),
                        read.GetInt32(4),
                        read.GetString(5),
                        read.GetInt32(6),
                        read.GetDouble(7),
                        read.GetDouble(8),
                        read.GetDouble(9),
                        read.GetDouble(10),
                        read.GetDouble(11),
                        read.GetInt32(12),
                        read.GetInt32(13),
                        read.GetInt32(14),
                        read.GetDouble(15),
                        read.GetDouble(16),
                        read.GetDouble(17),
                        read.GetDouble(18),
                        read.GetDouble(19),
                        read.GetDouble(20),
                        read.GetDouble(21),
                        read.GetInt32(22));
                    return tleItem;
                }
            }
            return null;
        }

        //! Get station data for a groundstation from DataBase
        /*! 
           \param String name of the Station
        */
        public Ground.Station getStationFromDB(string StaName)
        {
            if (!isConnected)
            {
                connectDB();
            }
            SQLiteCommand command = new SQLiteCommand(m_dbConnection);
            Ground.Station station;
            command.CommandText = String.Format("SELECT * FROM {0} WHERE name='{1}';",
                Constants.StationDB, StaName);
            using (SQLiteDataReader read = command.ExecuteReader())
            {
                while (read.Read())
                {
                    station = new Ground.Station(
                        read.GetString(0),
                        read.GetDouble(1),
                        read.GetDouble(2),
                        read.GetDouble(3));
                    return station;
                }
            }
            return null;
        }

        //! Get satellite data for certain Satellite from DataBase
        /*! 
           depricated do not use
           \return null
        */
        public Satellite.Satellite getSatelliteFromDB()
        {
            return null;
        }

        //! Delete Satellite from Database
        /*! 
           \param string NoradID of Satellite
        */
        public void deleteTle(string NoradID)
        {
            if (!isConnected)
            {
                connectDB();
            }
            SQLiteCommand command = new SQLiteCommand(m_dbConnection);
            command.CommandText = String.Format(
                    Constants.deleteTLE,
                    Constants.TleDB,
                    NoradID);
            command.ExecuteNonQuery();
        }

        //! Delete Satellite from Database
        /*! 
           \param string Name of Satellite
        */
        public void deleteSatellite(string name)
        {
            if (!isConnected)
            {
                connectDB();
            }
            SQLiteCommand command = new SQLiteCommand(m_dbConnection);
            command.CommandText = String.Format(
                    Constants.deleteSatellite,
                    Constants.SatDB,
                    name);
            command.ExecuteNonQuery();
        }


        //! Delete ground station from database
        /*! 
           \param string name of station
        */
        public void deleteStation(string name)
        {
            if (!isConnected)
            {
                connectDB();
            }
            SQLiteCommand command = new SQLiteCommand(m_dbConnection);
            command.CommandText = String.Format(
                    Constants.deleteStation,
                    Constants.StationDB,
                    name);
            command.ExecuteNonQuery();
        }

        //! get List of all Norad IDs in Database
        /*! 
           \param List<string> NoradID
        */
        public List<string> getAllNoradID()
        {
            List<string> res = new List<string>();

            if (!isConnected)
            {
                connectDB();
            }
            SQLiteCommand command = new SQLiteCommand(m_dbConnection);
            command.CommandText = String.Format(
                "SELECT * FROM {0}",
                Constants.SatDB);
            using (SQLiteDataReader read = command.ExecuteReader())
            {
                while (read.Read())
                {
                    res.Add(read.GetValue(1).ToString());
                }
            }
            closeDB();

            return res;
        }

        public bool connected()
        {
            return isConnected;
        }
    }
}
