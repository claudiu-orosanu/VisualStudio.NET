using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee e1 = new Employee("Ionescu", "Andrei", new DateTime(1994,5,12), new DateTime(2009,11,2), 2360.00, 30);
            e1.DisplayInfo();
            Leave l1 = new Leave(new DateTime(2016,07,15), 12, LeaveTypeEnum.Holiday);
            Leave l2 = new Leave(new DateTime(2016, 08, 05), 17, LeaveTypeEnum.Holiday);
            Leave l3 = new Leave(new DateTime(2016,09,20), 7, LeaveTypeEnum.Medical);
            e1.AddNewLeave(l1);
            e1.AddNewLeave(l2);
            //e1.AddNewLeave(l3);  //arunca exceptia NegativeLeaveException
            e1.DisplayInfo();
            Console.WriteLine("\nConcediile din anul 2016 sunt: ");
            e1.DisplayLeaves(2016);
            Console.ReadKey();
        }
    }
}
