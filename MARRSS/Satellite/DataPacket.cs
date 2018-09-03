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
        private double packetTimeFrame; //in seconds

        private EpochTime timeStamp;
        private dataType type;

        public enum dataType
        {
            CREATED,
            DOWNLOADED
        }

        public DataPacket()
        {
            priority = 4;
            packetDataSize = 0;
            packetTimeFrame = 60.0;
        }

        public DataPacket(long dataInByte, int dataPriority, EpochTime time, double timeFrameOfPacket)
        {
            packetTimeFrame = timeFrameOfPacket;
            packetDataSize = (long) (dataInByte * timeFrameOfPacket);
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

        public double getDurationInSec()
        {
            return packetTimeFrame;
        }

        public void setStoredData(long newData)
        {
            packetDataSize = newData;
        }

        public dataType getType()
        {
            return type;
        }

        public void setType(dataType datatype)
        {
            this.type = datatype;
        }
    }
}
