using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DevTeamRepo
    {
        private readonly DeveloperRepo _developerRepo = new DeveloperRepo(); // this gives you access to the _developerDirectory so you can access existing Developers and add them to a team
        private readonly List<DevTeam> _devTeams = new List<DevTeam>();

        //DevTeam Create
        //DevTeam Read
        //DevTeam Update
        //DevTeam Delete

        //DevTeam Helper (Get Team by ID)

    }

    //You must remove the field: _developerRepo from the DevTeamRepo class.
    //You will need to access your pool of Developers from outside of the DevTeamRepo class; utilize parameters to pass in Developer objects when adding or removing Developers from a Team.
}
