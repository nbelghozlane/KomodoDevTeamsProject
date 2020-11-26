using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DevTeam
    {
        public string TeamName { get; set; }
        public string TeamIdNumber { get; set; }
        public string DeveloperIdNumber { get; set; }
    

        public DevTeam() { }

        public DevTeam(string teamName, string teamIdNumber, string developerIdNumber)
        {
            TeamName = teamName;
            TeamIdNumber = teamIdNumber;
            DeveloperIdNumber = developerIdNumber;
        }

        //Team name
        //Team id numbers
        //Developer id numbers/   
        //developer names?
    }
}
