﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomework
{
    public class Employee : Person
    {
        //fields
        public DateTime DateOfEmployment { get; set; }
        public double Salary { get; set; }
        public int AvailableDaysOff { get; set; }
        private List<Leave> leaveList;

        //constructor
        public Employee(string firstName, string lastName, DateTime dateOfBirth,DateTime dateOfEmployment, 
                        double salary, int availableDaysOff) : base(firstName,lastName,dateOfBirth)
        {
            DateOfEmployment = dateOfEmployment;
            Salary = salary;
            AvailableDaysOff = availableDaysOff;
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
            Console.WriteLine("Lastname: {0}, Firstname: {1}, Salary: {2}, Available days off: {3}",lastName,firstName,Salary,AvailableDaysOff);
        }

        //scadere zile de concediu
        private void SubtractDays(int numberOfDays)
        {
            AvailableDaysOff -= numberOfDays;
        }

        //adaugare concediu
        public void AddNewLeave(Leave leave)
        {
            try
            {
                if (AvailableDaysOff - leave.Duration >= 0)
                {
                    SubtractDays(leave.Duration);
                    leave.Employee = this;
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
        public void DisplayLeaves(int year)
        {
            //foreach (var leave in leaveList)
            //{ 
            //    if (leave.StartingDate.Year == year)
            //    {
            //        Console.WriteLine(leave);
            //    }
            //}
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
                                lastName, firstName, dateOfBirth, DateOfEmployment, Salary, AvailableDaysOff);
        }
    }
}
