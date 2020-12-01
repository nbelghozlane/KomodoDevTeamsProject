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
        List<Developer> _developerDirectory = new List<Developer>(); //* think i need this??

        //DevTeam Create - create a team/ add user to team
        public void CreateNewTeam(DevTeam devTeam)
        {
            _devTeams.Add(devTeam);
        } 

        //DevTeam Read  - list of teams
        public List<DevTeam> GetDevTeamList()
        {
            return _devTeams;
        }

        //DevTeam Update

        //DevTeam Delete
        
        //DevTeam Helper (Get Team by ID)
        public DevTeam GetDevTeamByIdNumber(string TeamIdNumber)
        {
            foreach (DevTeam devTeam in _devTeams)
            {
                if (devTeam.TeamIdNumber == TeamIdNumber)
                {
                    return devTeam;
                }
            }
            return null;
        }
    }
}


