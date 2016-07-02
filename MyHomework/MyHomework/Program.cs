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
            Employee e1 = new Employee("Ionescu", "Andrei", "1990-09-23", "2012-05-20", 2360.00, 30);
            e1.DisplayInfo();
            Leave l1 = new Leave("2016-07-17", 12, "holiday");
            Leave l2 = new Leave("2015-08-10", 17, "holiday");
            Leave l3 = new Leave("2016-03-18", 7, "medical");
            e1.AddNewLeave(l1);
            e1.AddNewLeave(l2);
            //e1.AddNewLeave(l3);  //arunca exceptia NegativeLeaveException

            l1.employee.DisplayInfo(); // afisarea angajatului de pe concediul l1

            Console.WriteLine("\nConcediile din anul 2016 sunt: ");
            e1.DisplayLeaves("2016");
            Console.ReadKey();
        }
    }
}
