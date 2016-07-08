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
            var e1 = new Employee("Ionescu", "Andrei", new DateTime(1994,5,12), new DateTime(2009,11,2), 2360.00, 30);
            e1.DisplayInfo();

            var l5 = new Leave(new DateTime(2016, 12, 20), 15, LeaveTypeEnum.Medical);

            //adaugam 3 concedii
            e1.AddNewLeave(new Leave(new DateTime(2016, 07, 15), 12, LeaveTypeEnum.Holiday));
            e1.AddNewLeave(new Leave(new DateTime(2016, 08, 05), 17, LeaveTypeEnum.Holiday));
            e1.AddNewLeave(new Leave(new DateTime(2015, 09, 20), 7, LeaveTypeEnum.Medical));

            //afisam lista de concedii
            Console.WriteLine("\nLista dupa introducerea primelor 3 concedii:");
            foreach (var item in e1.LeaveList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            e1.DisplayInfo();

            //introducem al 4 lea concediu
            e1.AddNewLeave(new Leave(new DateTime(2016, 12, 31), 15, LeaveTypeEnum.Medical));

            //afisam lista de concedii
            Console.WriteLine("\nLista dupa introducerea primelor 4 concedii:");
            foreach (var item in e1.LeaveList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            // Concediul se suprapune cu altul (apare mesaj de eroare)
            //e1.AddNewLeave(new Leave(new DateTime(2016, 12, 20), 15, LeaveTypeEnum.Medical)); 

            //arunca exceptia NegativeLeaveException
            //e1.AddNewLeave(new Leave(new DateTime(2016, 02, 03), 4, LeaveTypeEnum.Medical));

            Console.WriteLine();
            e1.DisplayInfo();
            Console.WriteLine("\nConcediile din anul 2016 sunt: ");
            e1.DisplayLeaves(2016);
            Console.ReadKey();
        }
    }
}
