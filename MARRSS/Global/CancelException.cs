using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARRSS.Global
{
    public class CancelException : Exception
    {

        public CancelException()
        {
        }

        public CancelException(string message) : base(message)
        {
        }

        public CancelException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
