using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomework
{
    class Leave
    {
        public string startingDate;
        public int duration;  //nr de zile
        public string leaveType;
        public Employee employee;

        public Leave(string StartingDate, int Duration, string LeaveType)
        {
            startingDate = StartingDate;
            duration = Duration;
            leaveType = LeaveType;
        }

        public override string ToString()
        {
            return String.Format("Starting date: {0}, Duration: {1}, Leave type: {2}", startingDate, duration, leaveType);
        }
    }
}
