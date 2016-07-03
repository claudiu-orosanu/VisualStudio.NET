using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomework
{
    public class Person
    {
        protected string firstName;
        protected string lastName;
        protected DateTime dateOfBirth;
        
        public Person(string firstName,string lastName,DateTime dateOfBirth)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
        }
    }
}
