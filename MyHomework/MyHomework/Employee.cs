using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomework
{
    public class Employee : Person
    {
        //fields
        public DateTime dateOfEmployment;
        public double salary;
        public Dictionary<int, int> availableDaysOff = new Dictionary<int, int>();
        private List<Leave> leaveList;

        //proprietati
        public DateTime DateOfEmployment
        {
            get
            {
                return dateOfEmployment;
            }
            set
            {
                dateOfEmployment = value;
            }
        }
        public double Salary
        {
            get
            {
                return salary;
            }
            set
            {
                salary = value;
            }
        }
        public Dictionary<int,int> AvailableDaysOff
        {
            get
            {
                return availableDaysOff;
            }
            set
            {
                availableDaysOff = value;
            }
        }

        //constructor
        public Employee(string firstName, string lastName, DateTime dateOfBirth,DateTime dateOfEmployment, 
                        double salary, int availableDaysOff) : base(firstName,lastName,dateOfBirth)
        {
            this.dateOfEmployment = dateOfEmployment;
            this.salary = salary;
            //pentru anii 2010-2020 avem 30 de zile libere pe an
            for (int i = 0; i <= 10; i++)
            {
                this.availableDaysOff.Add(2010 + i, availableDaysOff);
            }
            leaveList = new List<Leave>();
        }

        public List<Leave> LeaveList
        {
            get
            {
                return leaveList;
            }
        }
        
        //DisplayInfo
        public void DisplayInfo()
        {
            var lines = availableDaysOff.Select(x => x.Key + ":" + x.Value);
            var availableDays = string.Join(", ", lines);
            
            Console.WriteLine("Lastname: {0}, Firstname: {1}, Salary: {2}\nAvailable days off: {3}",lastName,firstName,salary,availableDays);
        }

        //scadere zile de concediu
        private void SubtractDays(int numberOfDays,int year)
        {
            availableDaysOff[year] -= numberOfDays;
        }

        //adaugare concediu
        public void AddNewLeave(Leave leave)
        {
            try
            {

                //verifica daca intervalele se intersecteaza
                bool overlap = false;
                foreach (var l in leaveList)
                {
                    if (leave.StartingDate.Add(new TimeSpan(leave.Duration, 0, 0, 0)) > l.StartingDate &&
                        leave.StartingDate < l.StartingDate.Add(new TimeSpan(l.Duration, 0, 0, 0)))

                        overlap = true;
                }

                if (overlap == false)
                {
                    //daca concediul are zile in doi ani diferiti
                    if(leave.StartingDate.Year != leave.StartingDate.Add(new TimeSpan(leave.Duration, 0, 0, 0)).Year)
                    {
                        //aflam cate zile sunt in primul an
                        var days1 = (new DateTime(leave.StartingDate.Year + 1, 1, 1)).AddDays(-leave.StartingDate.Day).Day;
                        if (availableDaysOff[leave.StartingDate.Year] >= days1)
                            SubtractDays(days1, leave.StartingDate.Year);
                        else
                            throw (new NegativeLeaveException("Numarul de zile disponibile nu poate fi mai mic decat durata concediului"));
                        //aflam cate zile sunt in al doilea an
                        var days2 = leave.Duration - days1;
                        if (availableDaysOff[leave.StartingDate.Year+1] >= days2)
                            SubtractDays(days2, leave.StartingDate.Year + 1);
                        else
                            throw (new NegativeLeaveException("Numarul de zile disponibile nu poate fi mai mic decat durata concediului"));
                        leave.Employee = this;
                        leaveList.Add(leave);
                    }
                    else
                    if(availableDaysOff[leave.StartingDate.Year] >= leave.Duration)
                    {
                        SubtractDays(leave.Duration,leave.StartingDate.Year);
                        leave.Employee = this;
                        leaveList.Add(leave);
                    }
                    else
                    {
                        throw (new NegativeLeaveException("Numarul de zile disponibile nu poate fi mai mic decat durata concediului"));
                    }
                }
                else
                {
                    Console.WriteLine("Concediul introdus se suprapune cu altul deja existent");
                }
                
            }
            catch(NegativeLeaveException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        //afiseaza concediile din anul "year" dat ca parametru
        public void DisplayLeaves(int year)
        {
            IEnumerable<Leave> query = leaveList.Where(leave => leave.StartingDate.Year == year);
            foreach (var leave in query)
            {
                Console.WriteLine(leave);
            }
        } 

        //override ToString()
        public override string ToString()
        {
            return String.Format("Lastname: {0}, Firstname: {1}, Birthdate: {2}, Date of employment: {3} " +
                                "Salary: {4}, Available days off: {5}",
                                lastName, firstName, dateOfBirth, dateOfEmployment, salary, availableDaysOff);
        }
    }
}
