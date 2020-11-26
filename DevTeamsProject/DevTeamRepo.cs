using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DevTeamRepo
    {
        
        private readonly List<DevTeam> _devTeams = new List<DevTeam>();

        //DevTeam Create - create a team
        public void CreateNewTeam(DevTeam devTeam)
        {
            _devTeams.Add(devTeam);
        }


        //DevTeam Read  - list of teams
        public List<DevTeam> GetDevTeamList()
        {
            return _devTeams;
        }

        //DevTeam Update- add users to team
        public void AddDeveloperToTeam(Developer developer)
        {

        }


        //DevTeam Delete - remove members from team




        //DevTeam Helper (Get Team by ID) - team IDs

    }

   
}
