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
using System.Linq;

namespace MARRSS.Global
{
    public class DataStorage
    {
        private long MaxStorageCapacity;

        private Structs.DataSize dataSizeOfStorage;
        private const long Kb = 1024;
        private const long Mb = Kb * 1024;
        private const long Gb = Mb * 1024;
        private const long Tb = Gb * 1024;

        private long maxStoredData; //in Byte
        private long maxFreedData; //in Byte
        private long currentData; //in Byte

        public List<DataPacket> internalAddedStorage;


        private int internalPos;
        public List<DataPacket> MemoryStorage { get; set; }
        public long MemorySize { get; set; }
        public long MaxPosibleData { get; set; }
        public long DownloadedData { get; set; }
        public long LostMemorySize { get; set; }
        public double AllDownlinkDuration { get; set; }


        private List<DataPacket> internalRemovedStorage;


        private long alreadyCleardData;
        private long addedData;
        private long removedData;

        //! Data Konstructor
        /*!
            \param long Max available Storage
            \param Structs.DataSize Byte, KByte, MByte, GByte, TByte
        */
        public DataStorage(long maxStorage = 0, Structs.DataSize size = Structs.DataSize.BYTE)
        {
            maxStoredData = 0;
            maxFreedData = 0;
            MaxStorageCapacity = getByte(maxStorage, size);
            internalAddedStorage = new List<DataPacket>();
            internalRemovedStorage = new List<DataPacket>();
            alreadyCleardData = 0;
            addedData = 0;
            internalPos = 0;
            MemoryStorage = new List<DataPacket>();
            MemorySize = 0;
            LostMemorySize = 0;
            MaxPosibleData = 0;
            DownloadedData = 0;
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

        public void AddDataPacketToDataList(DataPacket packet)
        {
            internalAddedStorage.Add(packet);
            MaxPosibleData += packet.getStoredData();
        }

        public void DownloadDataFromStorage(DataPacket packet)
        {
            for (int i = internalPos; i < internalAddedStorage.Count; i++)
            {                
                var p = internalAddedStorage[i];
                if (p.getTimeStamp().getEpoch() <= packet.getTimeStamp().getEpoch())
                {
                    if (MemorySize + p.getStoredData() <= MaxStorageCapacity)
                    {
                        MemoryStorage.Add(p);
                        MemorySize += p.getStoredData();
                    }
                    else
                    {
                        if (MemorySize + packet.getStoredData() <= MaxStorageCapacity)
                        {
                            MemoryStorage.Add(packet);
                            MemorySize += packet.getStoredData();                            
                        }
                        else
                        {
                            LostMemorySize += MemorySize + packet.getStoredData() - MaxStorageCapacity;
                        }                        
                    }
                }
                else
                {
                    internalPos = i;
                    break;
                }
            }

            if (MemorySize - packet.getStoredData() >= 0)
            {
                DownloadedData += packet.getStoredData();
                MemorySize -= packet.getStoredData();
            }
            else
            {
                DownloadedData += MemorySize;
                MemorySize = 0;
            }
            AllDownlinkDuration += packet.getDurationInSec();
        }


        public void InitializeBevorScheduling()
        {
            internalAddedStorage = internalAddedStorage.OrderBy(o => o.getTimeStamp().getEpoch()).ToList();
        }


        public void AddDataPacketToStorage(DataPacket packet)
        {
            internalAddedStorage.Add(packet);
            //internalAddedStorage = internalAddedStorage.OrderBy(o => o.getTimeStamp().getEpoch()).ToList();
            addedData += packet.getStoredData();

        }

        public void QickDownloadData(DataPacket packet)
        {
            if (addedData >= packet.getStoredData())
            {
                removedData += packet.getStoredData();
                internalAddedStorage.Add(packet);
            }
            else
            {
                removedData += addedData;
                internalAddedStorage.Add(
                    new DataPacket(addedData, 0, packet.getTimeStamp(), packet.getDurationInSec()));
            }

        }

        public void RemoveDataFromStorage(DataPacket packet)
        {
            var curr = CalculateCurrentStorageCapcity(packet.getTimeStamp());
            if (curr >= packet.getStoredData())
            {
                alreadyCleardData += packet.getStoredData();
                internalRemovedStorage.Add(packet);
            }
            else
            {
                if (curr > 0)
                {
                    alreadyCleardData += curr;
                    internalRemovedStorage.Add(new DataPacket(curr, 0, packet.getTimeStamp(), packet.getDurationInSec()));
                }
            }
        }

        private long CalculateCurrentStorageCapcity(One_Sgp4.EpochTime timePoint)
        {
            long currentStorage = 0;
            for (int i = 0; i < internalAddedStorage.Count(); i++)
            {
                var pack = internalAddedStorage[i];
                var time = new One_Sgp4.EpochTime(pack.getTimeStamp());
                var time2 = new One_Sgp4.EpochTime(pack.getTimeStamp());
                time2.addTick(pack.getDurationInSec());
                if (time.getEpoch() <= timePoint.getEpoch())
                {
                    if (time2.getEpoch() > timePoint.getEpoch())
                    {
                        double sec = Funktions.GetDuration(time2, timePoint);
                        currentStorage += (long)((pack.getStoredData() / pack.getDurationInSec()) * sec);
                    }
                    else
                        currentStorage += pack.getStoredData();
                }
                else
                    break;
            }
            return currentStorage - alreadyCleardData;
        }


        //! Get Maximum Storage
        /*!
            \return long max Storage space on satellite
        */
        public long getMaxDataSize()
        {
            return MaxStorageCapacity;
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
        public void addToDataStorage(DataPacket packet)
        {
            maxStoredData += packet.getStoredData();
            internalAddedStorage.Add(packet);
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
            return alreadyCleardData;
        }

        public void setMaxData(long maxOnboardStorage, Structs.DataSize datasize)
        {
            dataSizeOfStorage = datasize;
            MaxStorageCapacity = getByte(maxOnboardStorage, datasize);
        }

        public void reset()
        {
            //maxStoredData = 0;
            maxFreedData = 0;
            alreadyCleardData = 0;
            removedData = 0;
            //internalAddedStorage = new List<DataPacket>();
            internalRemovedStorage = new List<DataPacket>();
            MemoryStorage = new List<DataPacket>();
            MemorySize = 0;
            LostMemorySize = 0;
            DownloadedData = 0;
            internalPos = 0;
            AllDownlinkDuration = 0;
        }
    }
}
