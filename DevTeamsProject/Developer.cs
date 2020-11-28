using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    //POCO
    public class Developer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdNumber { get; set; }
        public string TeamName { get; set; }
        public bool PluralsightAccess { get; set; }

        public Developer() { }

        public Developer(string firstName, string lastName, string idNumber, string teamName, bool pluralsightAccess)
        {
            FirstName = firstName;
            LastName = lastName;
            IdNumber = idNumber;
            TeamName = teamName;
            PluralsightAccess = pluralsightAccess;
        }
       
    }

}
