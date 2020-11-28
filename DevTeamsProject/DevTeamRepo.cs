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
        //DevTeam Create - create a team/ add user to team
        public void CreateNewTeam(DevTeam devTeam)
        {
            _devTeams.Add(devTeam);
        }

        public void AddDeveloperToTeam(DevTeam developerListForDevTeams) //(may be wrong)
        {
            _devTeams.Add(developerListForDevTeams);
        }

        //DevTeam Read  - list of teams
        public List<DevTeam> GetDevTeamList()
        {
            return _devTeams;
        }

        //DevTeam Update



        //DevTeam Delete - remove members from team 
        public bool RemoveDeveloperFromTeam(string developerIdNumber)
        {
            DevTeam developerOnTeam = GetDeveloperByIDNumber(developerIdNumber);

            if(developerOnTeam == null)
            {
                return false;
            }

            int initialCount = _devTeams.Count;
            _devTeams.Remove(developerOnTeam);
            
            if(initialCount > _devTeams.Count)
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
        //
        //Helper for get developer list above by Id number ??
        public DevTeam GetDeveloperByIDNumber(string developerIdNumber)
        {
            foreach (DevTeam developerOnTeam in _devTeams)
            {
               if (developerOnTeam.DeveloperIdNumber == developerIdNumber)
                {
                    return developerOnTeam;
                }

           }

            return null;

        }

    }
}

//You must remove the field: _developerRepo from the DevTeamRepo class.

//you will need to access your pool of Developers from outside of the DevTeamRepo class; 
//utilize parameters to pass in Developer objects when adding or removing Developers from a Team.
