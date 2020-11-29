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
        List<Developer> DeveloperListForDevTeams { get; set; }
        public DevTeam() { }

        public DevTeam(string teamName, string teamIdNumber, string developerIdNumber)  //List<Developer> developerListForDevTeams
        {
            TeamName = teamName;
            TeamIdNumber = teamIdNumber;
            DeveloperIdNumber = developerIdNumber;
            //DeveloperListForDevTeams = developerListForDevTeams;
        }

        //Team name
        //Team id numbers
        //Developer id numbers/   
        //developer names?
    }
}
