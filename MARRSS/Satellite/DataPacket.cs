using MARRSS.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using One_Sgp4;

namespace MARRSS.Satellite
{
    public class DataPacket
    {
        private int priority;
        private long packetDataSize; //ammount of stored data per timeframe
        private int packetTimeFrame; //in seconds

        private EpochTime timeStamp;

        public DataPacket()
        {
            priority = 4;
            packetDataSize = 0;
            packetTimeFrame = 60;
        }

        public DataPacket(long dataInByte, int dataPriority, EpochTime time, int timeFrameOfPacket = 60)
        {
            packetTimeFrame = timeFrameOfPacket;
            packetDataSize = dataInByte * timeFrameOfPacket;
            priority = dataPriority;
            timeStamp = time;
        }

        public long getStoredData()
        {
            return packetDataSize;
        }

        public EpochTime getTimeStamp()
        {
            return timeStamp;
        }

        public int getDurationInSec()
        {
            return packetTimeFrame;
        }

        public void setStoredData(long newData)
        {
            packetDataSize = newData;
        }
    }
}
