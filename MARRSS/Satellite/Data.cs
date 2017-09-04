/**
* ----------------------------------------------------------------
* Nikolai Jonathan Reed 
*
* 
* Copyright (c) 2017, Nikolai Reed, 1manprojects.de
* All rights reserved.
*
* Licensed under
* Creative Commons Attribution NonCommercial (CC-BY-NC)
*/

using System;

namespace MARRSS.Global
{
    class Data
    {
        private const long Kb = 1024;
        private const long Mb = Kb * 1024;
        private const long Gb = Mb * 1024;
        private const long Tb = Gb * 1024;
        private int type = 0;

        private long dataCount;
        private long maxDataStorage;


        //! Data Konstructor
        /*!
            \param long Max available Storage
            \param Structs.DataSize Byte, KByte, MByte, GByte, TByte
        */
        public Data(long maxStorage = 0, Structs.DataSize size = Structs.DataSize.BYTE)
        {
            dataCount = 0;
            type = Convert.ToInt32(size);
            maxDataStorage = maxStorage;
        }

        //! Data Konstructor
        /*!
            \param long used Storage
            \param long Max available Storage
            \param Structs.DataSize Byte, KByte, MByte, GByte, TByte
        */
        public Data(long dataSize = 0, long maxStorage = 0, Structs.DataSize size = Structs.DataSize.BYTE)
        {
            if (dataSize < 0)
                dataCount = 0;
            else
                dataCount = dataSize;
            type = Convert.ToInt32(size);
            maxDataStorage = maxStorage;
        }

        //! Get Human Readable storage in use 
        /*!
            \return string used Storage on satellite
        */
        public string getHumanReadableStoredData()
        {
            Structs.DataSize ds = (Structs.DataSize)type;
            return dataCount.ToString() + " " + ds.ToString();
        }

        //! Get Used Storage in Byte
        /*!
            \return long data storage in use on satellite in Byte
        */
        public long getStoredDataInByte()
        {
            if (type > 0)
            {
                switch (type)
                {
                    case 1: return Kb * dataCount;
                    case 2: return Mb * dataCount;
                    case 3: return Gb * dataCount;
                    case 4: return Tb * dataCount;
                }
                
            }
            return dataCount;
        }

        //! Get Maximum Storage
        /*!
            \return long max Storage space on satellite
        */
        public long getMaxDataSize()
        {
            return maxDataStorage;
        }

        //! Get Storage Type
        /*!
            \return int type 0=B,1=kB,2=MB,3=GB,4=TB
        */
        public int getSizeType()
        {
            return type;
        }

        //! Get Maximum Storage in Byte
        /*!
            \return long max Storage space on satellite in Byte
        */
        public long getMaxDataSizeInByte()
        {
            if (type > 0)
            {
                switch (type)
                {
                    case 1: return Kb * maxDataStorage;
                    case 2: return Mb * maxDataStorage;
                    case 3: return Gb * maxDataStorage;
                    case 4: return Tb * maxDataStorage;
                }

            }
            return maxDataStorage;
        }

        //! Add Data to Satellite Storage
        /*!
            \param long data to add
            \return bool true if maxStorage overflow
        */
        public bool addToDataStorage(long data)
        {
            dataCount += data;
            if (dataCount > maxDataStorage)
            {
                dataCount = maxDataStorage;
                return true;
            }
            else
                return false;
        }

        //! Download data from Satellite
        /*!
            \param long data to Download
            \return bool true if storage reached zero
        */
        public bool getDataFromSatellite(long data)
        {
            dataCount -= data;
            if (dataCount < 0)
            {
                dataCount = 0;
                return true;
            }
            return false;
        }
    }
}
