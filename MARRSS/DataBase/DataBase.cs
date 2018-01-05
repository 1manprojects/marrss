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
using System.Data.SQLite;

using System.IO;
using System.Windows.Forms;
using System.Threading;

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
            _dbName = Properties.Settings.Default.db_path;
            //m_dbConnection
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
            isConnected = false;
            if (!File.Exists(string.Format(_dbName)))
            {
                errorCode = 000;
                Properties.Settings.Default.db_version = Constants.dbVersion;
                createNewDatabases();
            }
            else
            {
                //get Database Version
                if (getDbVersion() < Constants.dbVersion)
                {
                    if (getDbVersion() == 0)
                    {
                        DialogResult result = MessageBox.Show("The database needs to be Updated. \nThis will add 500 MB storage to all satellites in the database.",
                            "DataBase Update",
                            MessageBoxButtons.YesNo);
                        //Update Database
                        if (result == DialogResult.Yes)
                        {
                            updateDBToVersion1();
                        }
                        else
                        {
                            MessageBox.Show("The database has not been updated!\nThis programm might not function correctly please restart the application and begin the update",
                                "WARNING!!",
                            MessageBoxButtons.OK);
                            //Application.Exit();
                        }
                    }
                    if (getDbVersion() == 1)
                    {
                        DialogResult result = MessageBox.Show("The database needs to be Updated. \nThis will add 1024Kbps Up and Downlink speeds to all stations in the database.",
                            "DataBase Update",
                            MessageBoxButtons.YesNo);
                        //Update Database
                        if (result == DialogResult.Yes)
                        {
                            updateDBToVersion2();
                        }
                        else
                        {
                            MessageBox.Show("The database has not been updated!\nThis programm might not function correctly please restart the application and begin the update",
                                "WARNING!!",
                            MessageBoxButtons.OK);
                            //Application.Exit();
                        }
                    }
                }
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
            command.CommandText = Constants.creVersionTab;
            command.ExecuteNonQuery();
            command.CommandText = String.Format(
                "INSERT INTO {0} (version, versionNum) Values ('{1}', '{2}')",
                Constants.verDB, "dbVersion", Constants.dbVersion);
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
        public void writeTleData(One_Sgp4.Tle tleData, long dataSize, int datatype)
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
                    Constants.insertSatWithData,
                    Constants.SatDB, tleData.getName(), tleData.getNoradID(), dataSize, datatype);
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

                //SQLiteCommand delcommand = new SQLiteCommand(m_dbConnection);
                //delcommand.CommandText = String.Format(
                //        Constants.deleteSatellite2,
                //        Constants.SatDB,
                //        tleData.getNoradID());
                //delcommand.ExecuteNonQuery();

                //addSatCommand.CommandText = String.Format(
                //    Constants.insertSatNoData,
                //    Constants.SatDB, tleData.getName(), tleData.getNoradID());
                //addSatCommand.ExecuteNonQuery();
            }
        }
        //! Write TLE-Data to DataBase
        /*! 
           \param tleData TLEData to be writen in DataBase.
        */
        public void UpdateTleData(One_Sgp4.Tle tleData)
        {
            if (!isConnected)
            {
                connectDB();
            }
            SQLiteCommand command = new SQLiteCommand(m_dbConnection);
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
                     Constants.insertSatWithData,
                     Constants.SatDB, sat.getName(), sat.getTleData().getNoradID(), 1, 0);
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
                     station.getLongitude(), station.getHeight());
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
           \return station or NULL
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
           \return satellite else NULL
        */
        public Satellite.Satellite getSatelliteFromDB(string satName)
        {
            if (!isConnected)
            {
                connectDB();
            }
            One_Sgp4.Tle tle = getTleDataFromDB(satName);
            SQLiteCommand command = new SQLiteCommand(m_dbConnection);
            Satellite.Satellite satellite;
            command.CommandText = String.Format("SELECT * FROM {0} WHERE name='{1}';",
                Constants.SatDB, satName);
            using (SQLiteDataReader read = command.ExecuteReader())
            {
                while (read.Read())
                {
                    satellite = new Satellite.Satellite(
                            read.GetString(0),
                            tle,
                            read.GetInt32(2),
                            read.GetInt32(3) );
                    return satellite;
                }
            }
            return null;
        }

        //! Update Satellite Storage
        /*! 
           \param string NoradID of Satellite
        */
        public void updateSatelliteStorage(string satName, long storageSize, int StorageType)
        {
            if (!isConnected)
            {
                connectDB();
            }
            SQLiteCommand command = new SQLiteCommand(m_dbConnection);
            command.CommandText = String.Format(
                Constants.updateSingleSatellitStorage, storageSize, StorageType, satName);
            command.ExecuteNonQuery();
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

        //! check DatabaseVersion
        /*! 
           \return int version number
        */
        public int getDbVersion()
        {
            if (!isConnected)
            {
                connectDB();
            }
            int version = 0;
            try
            {
                SQLiteCommand command = new SQLiteCommand(m_dbConnection);
                command.CommandText = String.Format(
                    "SELECT versionNum FROM {0} WHERE version='dbVersion'",
                    Constants.verDB,
                    Constants.SatDB);
                using (SQLiteDataReader read = command.ExecuteReader())
                {
                    while (read.Read())
                    {
                        version = read.GetInt32(0);
                    }
                }
                return version;
            }
            catch
            {
                return version;
            }
        }

        //! check if database is connected
        /*! 
           \return bool true if database connection is oben
        */
        public bool connected()
        {
            return isConnected;
        }

        public void updateDBToVersion1()
        {
            if (!isConnected)
            {
                connectDB();
            }
            //dataBase Version 0 update to Version 1
            SQLiteCommand command1 = new SQLiteCommand(m_dbConnection);
            command1.CommandText = String.Format(
                Constants.updateDB1_1);
            command1.ExecuteNonQuery();
            SQLiteCommand command2 = new SQLiteCommand(m_dbConnection);
            command2.CommandText = String.Format(
                Constants.updateDB1_2);
            command2.ExecuteNonQuery();
            SQLiteCommand command = new SQLiteCommand(m_dbConnection);
            command.CommandText = Constants.creVersionTab;
            command.ExecuteNonQuery();
            command.CommandText = String.Format(
                "INSERT INTO {0} (version, versionNum) Values ('{1}', '{2}')",
                Constants.verDB, "dbVersion", Constants.dbVersion);
            command.ExecuteNonQuery();
            command = new SQLiteCommand(m_dbConnection);
            command.CommandText = String.Format(
                Constants.updateALLSatellitStorage,
                512, 2);
            command.ExecuteNonQuery();

            Properties.Settings.Default.db_version = Constants.dbVersion;
        }

        public void updateDBToVersion2()
        {
            if (!isConnected)
            {
                connectDB();
            }
            //dataBase Version 0 update to Version 1
            SQLiteCommand command1 = new SQLiteCommand(m_dbConnection);
            command1.CommandText = String.Format(
                Constants.updateDB2_1);
            command1.ExecuteNonQuery();
            SQLiteCommand command2 = new SQLiteCommand(m_dbConnection);
            command2.CommandText = String.Format(
                Constants.updateDB2_2);
            command2.ExecuteNonQuery();

            SQLiteCommand command3 = new SQLiteCommand(m_dbConnection);
            command3.CommandText = String.Format(
                Constants.updateDB2_3);
            command3.ExecuteNonQuery();
            SQLiteCommand command4 = new SQLiteCommand(m_dbConnection);
            command4.CommandText = String.Format(
                Constants.updateDB2_4);
            command4.ExecuteNonQuery();

            SQLiteCommand command = new SQLiteCommand(m_dbConnection);
            //set up and Downlink to 1024Kbps for Stations
            command = new SQLiteCommand(m_dbConnection);
            command.CommandText = String.Format(
                Constants.updateAllStationsUpDownLink,
                1024, 1024);
            command.ExecuteNonQuery();

            //set up and Downlink to 1024Kbps for Satellites
            command = new SQLiteCommand(m_dbConnection);
            command.CommandText = String.Format(
                Constants.updateAllSatsUpDownLink,
                1024, 1024);
            command.ExecuteNonQuery();

            Properties.Settings.Default.db_version = Constants.dbVersion;
        }

    }
}
