using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARRSS.Results
{
    public class MemPoint
    {
        public double time { get; }
        public long storage { get; }

        public MemPoint(double epochTime, long storageAtTime)
        {
            this.time = epochTime;
            this.storage = storageAtTime;
        }

        public override string ToString()
        {
            return time.ToString() + " " + storage.ToString();
        }
    }
}
