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

using MARRSS.Satellite;
using System;
using System.Collections.Generic;

namespace MARRSS.Global
{
    public class DataStorage
    {
        private long maxDataStorageSize;

        private Structs.DataSize dataSizeOfStorage;
        private const long Kb = 1024;
        private const long Mb = Kb * 1024;
        private const long Gb = Mb * 1024;
        private const long Tb = Gb * 1024;

        private long maxStoredData; //in Byte
        private long maxFreedData; //in Byte
        private long currentData; //in Byte

        private List<DataPacket> internalAddedStorage;
        private List<DataPacket> internalRemovedStorage;


        //! Data Konstructor
        /*!
            \param long Max available Storage
            \param Structs.DataSize Byte, KByte, MByte, GByte, TByte
        */
        public DataStorage(long maxStorage = 0, Structs.DataSize size = Structs.DataSize.BYTE)
        {
            maxStoredData = 0;
            maxFreedData = 0;
            maxDataStorageSize = getByte(maxStorage, size);
            internalAddedStorage = new List<DataPacket>();
            internalRemovedStorage = new List<DataPacket>();
        }

        private static long getByte(long _byte, Structs.DataSize size)
        {
            int type = Convert.ToInt32(size);
            if (type > 0)
            {
                switch (type)
                {
                    case 1: return Kb * _byte;
                    case 2: return Mb * _byte;
                    case 3: return Gb * _byte;
                    case 4: return Tb * _byte;
                }
            }
            return _byte;
        }

        //! Get Human Readable storage in use 
        /*!
            \return string used Storage on satellite
        */
        public string getHumanReadableStoredData()
        {
            return currentData.ToString() + " " + dataSizeOfStorage.ToString();
        }

        //! Get Used Storage in Byte
        /*!
            \return long data storage in use on satellite in Byte
        */
        public long getCurrentStoredDataInByte()
        {
            return currentData;
        }

        //! Get Maximum Storage
        /*!
            \return long max Storage space on satellite
        */
        public long getMaxDataSize()
        {
            return maxDataStorageSize;
        }

        //! Get Storage Type
        /*!
            \return int type 0=B,1=kB,2=MB,3=GB,4=TB
        */
        public int getSizeType()
        {
            return Convert.ToInt32(dataSizeOfStorage);
        }

        //! Add Data to Satellite Storage
        /*!
            \param long data to add
            \return bool true if maxStorage overflow
        */
        public bool addToDataStorage(DataPacket packet)
        {
            //currentData += packet.getStoredData();
            maxStoredData += packet.getStoredData();
            //internalStorage.Add(packet);
            if (currentData + packet.getStoredData() > maxDataStorageSize)
                return false;
            currentData += packet.getStoredData();
            internalAddedStorage.Add(packet);
            return true;
        }

        //! Download data from Satellite
        /*!
            \param long data to Download
            \return bool true if storage reached zero
        */
        public bool removeDataFromStorage(DataPacket packet)
        {
            if (currentData - packet.getStoredData() <= 0)
            {
                currentData = 0;
                packet.setStoredData(packet.getStoredData() - currentData);
            }
            else
                currentData -= packet.getStoredData();
            maxFreedData = packet.getStoredData();
            if (currentData < 0)
            {
                currentData = 0;
                return true;
            }
            internalRemovedStorage.Add(packet);
            return false;
        }

        public List<DataPacket> GetCreatedDataPackets()
        {
            return internalAddedStorage;
        }

        public List<DataPacket> GetDownloadedDataPackets()
        {
            return internalRemovedStorage;
        }

        public long getMaxGeneratedData()
        {
            return maxStoredData;
        }

        public long getMaxDownladedData()
        {
            return maxFreedData;
        }

        public void setMaxData(long maxOnboardStorage, Structs.DataSize datasize)
        {
            dataSizeOfStorage = datasize;
            maxDataStorageSize = maxOnboardStorage;
        }

        public void reset()
        {
            //maxStoredData = 0;
            maxFreedData = 0;
            //internalAddedStorage = new List<DataPacket>();
            internalRemovedStorage = new List<DataPacket>();
        }
    }
}
