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
        List<Developer> _developerDirectory = new List<Developer>();

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
        public bool RemoveDeveloperTeam(string teamIdNumber)
        {
            DevTeam devTeam = GetDevTeamByIdNumber(teamIdNumber);

            if (devTeam == null)
            {
                return false;
            }

            int initialCount = _devTeams.Count;
            _devTeams.Remove(devTeam);

            if (initialCount > _devTeams.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

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


