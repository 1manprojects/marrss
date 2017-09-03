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


namespace MARRSS.DataBase
{
/**
* \brief SQLlite Constants definition.
*
* This class defines the name of the database and the containing tables.
* Defines the names of the collums and the calls to create the tables and inserting data
*/
    class Constants
    {
        // Database version
        public const int dbVersion = 1;

        // Database Name and Table Names
        public const string DBName = "marrss.db";
        public const string SatDB = "SatelliteTable";
        public const string StationDB = "StationsTable";
        public const string TleDB = "TleTable";

        //Calls for creating Database and Tables
        //Satellite Name, Norad ID, Storage Size, enum DataSize : int
        public const string creSatTab = "create table SatelliteTable(name TEXT, noradID TEXT, storage INT, dataSize INT)";
        public const string creStaTab = "create table StationsTable(name TEXT, lat REAL, long REAL, hight REAL, nrOfSat INT)";
        public const string creTleTab = "create table TleTable(satName TEXT, noradID TEXT, clasification INT, startYear INT, startNr INT, piece TEXT, epochY INT, epochD REAL, firstMeanM REAL, secMeanM REAl, drag REAL, ephemeris REAL, setNr INT, check1 INT, satNr INT, inclination REAL, rightAscen REAL, eccent REAL, perigee REAL, meanAnomoly REAL, meanMotion REAL, relevation REAL, check2 INT)";

        //Calls for Inserting Data into Tables
        public const string insertTle = "INSERT INTO {0} (satName, noradID, clasification, startYear, startNr, piece, epochY, epochD, firstMeanM, secMeanM, drag, ephemeris, setNr, check1, satNr, inclination, rightAscen, eccent, perigee, meanAnomoly, meanMotion, relevation, check2) VALUES ('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}', '{23}' )";
        public const string insertSat = "INSERT INTO {0} (name, noradID, storage, dataSize) VALUES ('{1}', '{2}', '{3}', '{4}')";
        public const string insertSta = "INSERT INTO {0} (name, lat, long, hight, nrOfSat) VALUES ('{1}', '{2}', '{3}', '{4}', '{5}')";

        //Names of each colum of Database Table
        public const string rowsTle = "satName, noradID, clasification, startYear, startNr, piece, epochY, epochD, firstMeanM, secMeanM, drag, ephemeris, setNr, check1, satNr, inclination, rightAscen, eccent, perigee, meanAnomoly, meanMotion, relevation, check2";
        public const string rowsSat = "name, nordid, storage, dataSize";
        public const string rowsSta = "name, lat, long, hight, nrOfSat";

        //Deleting Items in DataBase
        public const string deleteTLE = "DELETE FROM {0} WHERE noradID='{1}'";
        public const string deleteStation = "DELETE FROM {0} WHERE name='{1}'";
        public const string deleteSatellite = "DELETE FROM {0} WHERE name='{1}'";
        public const string deleteSatellite2 = "DELETE FROM {0} WHERE noradID='{1}'";

        //Updating Database
        public const string updateDB1 = "ALTER TABLE " + SatDB + " ADD COLUMN storage INT";
        public const string updateDB2 = "ALTER TABLE " + SatDB + " ADD COLUMN dataSize INT";

        //updating Data
        public const string updateALLSatellitStorage = "UPDATE "+ SatDB + " SET storage = {0}, dataSize = {1}";
        public const string updateSingleSatellitStorage = "UPDATE " + SatDB + " SET storage = {0}, dataSize = {1} WHERE name='{2}'";

        //Saving schedules and Request etc.
        public const string ContactsVectorTable = "ContactsTable";
        public const string StationsTable = "StationTable";
        public const string SatelliteTable = "SatelliteTable";
        public const string TrackingTable = "TrackingTable";

        public const string createSaveContactTable = "create table ContactsTable(satName TEXT, staName TEXT, startTime REAL, stopTime REAL, duration REAL, scheduled INT, excluded INT, id TEXT, requestID TEXT)";
        public const string createSaveStationTable = "create table StationTable(staName TEXT)";
        public const string createSaveSatTable = "create table SatelliteTable(satName TEXT)";
        public const string createSaveTrackTable = "create table TrackingTable(id TEXT, azimuth REAL, elevation REAL, range REAL, rangeRate REAL, time TEXT)";

        public const string saveContact = "INSERT INTO {0} (satName, staName , startTime , stopTime , duration , scheduled , excluded , id , requestID ) VALUES ('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')";
        public const string saveSta = "INSERT INTO {0} (staName) VALUES ('{1}')";
        public const string saveSat = "INSERT INTO {0} (satName) VALUES ('{1}')";
        public const string saveTracking = "INSERT INTO {0} (id, azimuth, elevation, range, rangeRate, time) VALUES ('{1}', '{2}', '{3}', '{4}', '{5}', '{6}')";
    }
}
