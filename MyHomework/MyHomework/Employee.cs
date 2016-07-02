using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomework
{
    class Employee : Person
    {
        //fields
        public string dateOfEmployment;
        public double salary;
        public int availableDaysOff;
        public List<Leave> leaveList = new List<Leave>();

        //constructor
        public Employee(string Lastname, string Firstname, string DateOfBirth, 
                        string DateOfEmployment, double Salary, int AvailableDaysOff)
        {
            lastname = Lastname;
            firstname = Firstname;
            dateOfBirth = DateOfBirth;
            dateOfEmployment = DateOfEmployment;
            salary = Salary;
            availableDaysOff = AvailableDaysOff;
        }
        
        //DisplayInfo
        public void DisplayInfo()
        {
            Console.WriteLine("Lastname: {0}, Firstname: {1}, Salary: {2}, Available days off: {3}",
                                lastname,firstname,salary,availableDaysOff);
        }

        //scadere zile de concediu
        private void SubtractDays(int numberOfDays)
        {
            availableDaysOff -= numberOfDays;
        }

        //adaugare concediu
        public void AddNewLeave(Leave leave)
        {
            try
            {
                if (availableDaysOff - leave.duration > 0)
                {
                    SubtractDays(leave.duration);
                    leave.employee = this;
                    leaveList.Add(leave);
                }
                else
                {
                    throw (new NegativeLeaveException("Numarul de zile disponibile nu poate fi mai mic decat durata concediului"));
                }
            }
            catch(NegativeLeaveException ex)
            {
                Console.WriteLine(ex.Message);
            }
            

        }
        
        //afiseaza concediile din anul "year" dat ca parametru
        public void DisplayLeaves(string year)
        {
            foreach (Leave leave in leaveList)
            {
                string Year = leave.startingDate.Substring(0, 4);
                if (Year.Equals(year))
                {
                    Console.WriteLine(leave);
                }
            }
        }

        //override ToString()
        public override string ToString()
        {
            return String.Format("Lastname: {0}, Firstname: {1}, Birthdate: {2}, Date of employment: {3} " +
                                "Salary: {4}, Available days off: {5}", lastname, firstname, dateOfBirth, dateOfEmployment,
                                salary, availableDaysOff);
        }
    }
}
