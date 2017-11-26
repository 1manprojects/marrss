﻿using MARRSS.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARRSS.Satellite
{
    class DataPacket
    {
        private int priority;
        //private Structs.DataSize packetSizeOfData; //TB,GB,MB,KB,B
        private long packetDataSize; //ammount of stored data per timeframe
        private int packetTimeFrame; //in seconds

        private const long Kb = 1024;
        private const long Mb = Kb * 1024;
        private const long Gb = Mb * 1024;
        private const long Tb = Gb * 1024;
        private int type = 0;

        public DataPacket()
        {
            priority = 4;
            type = 0;
            packetDataSize = 0;
            packetTimeFrame = 60;
        }

        public DataPacket(long dataPacketSize, int dataPriority, int timeFrameOfPacket = 60, Structs.DataSize dataSizeOfPacket = Structs.DataSize.BYTE)
        {
            packetTimeFrame = timeFrameOfPacket;
            packetDataSize = dataPacketSize;
            priority = dataPriority;
            type = Convert.ToInt32(dataSizeOfPacket);
        }

        public long getStoredData()
        {
            return packetDataSize;
        }

        public double getDataPerSecond()
        {
            return packetDataSize / (double)packetTimeFrame;
        }

        public long getStoredDataInByte()
        {
            if (type > 0)
            {
                switch (type)
                {
                    case 1: return Kb * packetDataSize;
                    case 2: return Mb * packetDataSize;
                    case 3: return Gb * packetDataSize;
                    case 4: return Tb * packetDataSize;
                }

            }
            return packetDataSize;
        }
    }
}
