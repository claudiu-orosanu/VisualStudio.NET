using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomework
{
    public class Leave
    {
        private DateTime startingDate;
        private int duration;  //nr de zile
        private LeaveTypeEnum leaveType;
        private Employee employee;

        public Leave(DateTime startingDate, int duration, LeaveTypeEnum leaveType)
        {
            this.startingDate = startingDate;
            this.duration = duration;
            this.leaveType = leaveType;
        }

        public DateTime StartingDate
        {
            get
            {
                return startingDate;
            }
            set
            {
                startingDate = value;
            }
        }
        public int Duration
        {
            get
            {
                return duration;
            }
            set
            {
                duration = value;
            }
        }
        public LeaveTypeEnum LeaveType
        {
            get
            {
                return leaveType;
            }
            set
            {
                leaveType = value;
            }
        }
        public Employee Employee
        {
            get
            {
                return employee;
            }
            set
            {
                employee = value;
            }
        }

        public override string ToString()
        {
            return String.Format("Starting date: {0}, Duration: {1}, Leave type: {2}", startingDate, duration, leaveType);
        }
    }
}
