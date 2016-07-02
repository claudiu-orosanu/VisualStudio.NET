using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomework
{
    class NegativeLeaveException : Exception
    {
        public NegativeLeaveException(string message) : base(message)
        {
        }
    }
}
