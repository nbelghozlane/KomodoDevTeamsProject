using DevTeamsProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamProjectConsoleApp
{
    class ProgramUI
    {
        private DeveloperRepo _developerRepo = new DeveloperRepo();
        private DevTeamRepo _devTeams = new DevTeamRepo();

        //Method to start application (UI part)
        public void Run()
        {
            SeedContentList();
            SeedTeamList();
            Menu();
        }

        //Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                //Display options
                Console.WriteLine("Hello! Welcome to Komodo Insurance Developer Team Application!\n" +
                    "Please select a menu option(type in number):\n" +
                    " \n" +
                    "DEVELOPERS:\n" +
                    "1. Create New Developer\n" +
                    "2. View All Developers\n" +
                    "3. View Developer By ID Number\n" +
                    "4. Update Existing Developer Information\n" +
                    "5. Delete Existing Developer\n" +
                    "6. View Developers That Need Pluralsight License\n" +
                    " \n" +
                    "DEVELOPER TEAMS:\n" +
                    
                    "7. Create New Developer Team\n" +
                    "8. View All Teams\n" +
                    "9. View Team By Team ID Number\n" +
                    "10. Update Teams\n" +
                    "11. Add Developer To Team\n" +
                    "12. Remove Developer From Team\n" +
                    "13. Exit");

                //update teams -  do you want to add or remove devs?
                // add multiple devs to team at once

                //Get user input
                string input = Console.ReadLine();

                //Evaluate user input
                switch (input)
                {
                    case "1":
                        CreateNewDeveloper();
                        break;
                    case "2":
                        ViewAllDevelopers();
                        break;
                    case "3":
                        ViewDeveloperByIdNumber();
                        break;
                    case "4":
                        UpdateExistingDeveloperInfo();
                        break;
                    case "5":
                        DeleteExistingDeveloper();
                        break;
                    case "6":
                        ViewDevelopersWithoutPluralsight();
                        break;
                    case "7":
                        CreateNewDeveloperTeam();  //get id what the team id
                        break;
                    case "8":
                        ViewAllTeams();
                        break;
                    case "9":
                        ViewTeamByTeamIDNumber();
                        break;
                    case "10":
                        UpdateExistingTeams();
                        break;
                    case "11":
                        AddDeveloperToTeam();
                        break;
                    case "12":
                        RemoveDeveloperFromTeam();
                        break;
                    case "13":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;

                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }

                Console.WriteLine("Please press any key to continue.");
                Console.ReadKey();
                Console.Clear();
            }

        }

        private void CreateNewDeveloper()
        {
            Console.Clear();
            Developer newDeveloper = new Developer();

            //firstname
            Console.WriteLine("Enter the developer's first name:");
            newDeveloper.FirstName = Console.ReadLine();
            //lastname
            Console.WriteLine("Enter the developer's last name:");
            newDeveloper.LastName = Console.ReadLine();
            //idnumber
            Console.WriteLine("Enter the developer's ID number:");
            newDeveloper.IdNumber = Console.ReadLine();
            //pluralsight
            Console.WriteLine("Does the developer have access to Pluralsight? (Enter yes or no)");
            string pluralsightAccessString = Console.ReadLine().ToLower();

            if(pluralsightAccessString == "yes")
            {
                newDeveloper.PluralsightAccess = true;
            }
            else
            {
                newDeveloper.PluralsightAccess = false;
            }

            _developerRepo.AddDeveloper(newDeveloper);
        }

        private void ViewAllDevelopers()
        {
            Console.Clear();
            List<Developer> listOfDevelopers = _developerRepo.GetDeveloperList();

            foreach(Developer developer in listOfDevelopers)
            {
                Console.WriteLine($"Full Name: {developer.FirstName} {developer.LastName}\n" +
                    $"ID Number: {developer.IdNumber}\n" +
                    $"Pluralsight Access: {developer.PluralsightAccess}\n" +
                    $" ");     
            }
                   
        }

        private void ViewDeveloperByIdNumber()
        {
            Console.Clear();
            Console.WriteLine("Enter the developer's ID number:");

            string idNumber = Console.ReadLine();

            Developer developer = _developerRepo.GetDeveloperByIDNumber(idNumber);

            if (developer != null)
            {
                Console.WriteLine($"First Name: {developer.FirstName}\n" +
                    $"Last Name: {developer.LastName}\n" +
                    $"ID Number: {developer.IdNumber}\n" +
                    $"Pluralsight Access: {developer.PluralsightAccess}\n" +
                    $" ");
            }
            else
            {
                Console.WriteLine("There is no developer assigned to that ID Number.");
            }

        }

        private void UpdateExistingDeveloperInfo()
        {
            ViewAllDevelopers();

            Console.WriteLine("Enter the developer ID Number to update his/her information:");

            string oldDeveloperInfo = Console.ReadLine();

            Developer newDeveloper = new Developer();

            //firstname
            Console.WriteLine("Enter the developer's first name:");
            newDeveloper.FirstName = Console.ReadLine();
            //lastname
            Console.WriteLine("Enter the developer's last name:");
            newDeveloper.LastName = Console.ReadLine();
            //idnumber
            Console.WriteLine("Enter the developer's ID number:");
            newDeveloper.IdNumber = Console.ReadLine();
            //pluralsight
            Console.WriteLine("Does the developer have access to Pluralsight? (Enter yes or no)"); 
            string pluralsightAccessString = Console.ReadLine().ToLower();
            
            if (pluralsightAccessString == "yes")
            {
                newDeveloper.PluralsightAccess = true;
            }
            else
            {
                newDeveloper.PluralsightAccess = false;
            }

            bool wasUpdated = _developerRepo.UpdateExistingDeveloper(oldDeveloperInfo, newDeveloper);

            if (wasUpdated)
            {
                Console.WriteLine("Success! The developer's information has been updated.");
            }
            else
            {
                Console.WriteLine("The developer's information could not be updated. Please try again.");
            }
        }

        private void DeleteExistingDeveloper()
        {
            ViewAllDevelopers();

            Console.WriteLine("Enter the ID Number of the developer you want to remove:");
            string input = Console.ReadLine();

            bool wasRemoved = _developerRepo.RemoveDeveloperFromList(input);

            if (wasRemoved)
            {
                Console.WriteLine("The developer was successfully deleted from the application.");
            }
            else
            {
                Console.WriteLine("The developer could not be deleted from the application. Please try again.");
            }

        }

        private void ViewDevelopersWithoutPluralsight()
        {
            Console.Clear();
            List<Developer> listOfDevelopers = _developerRepo.GetDeveloperList();
            

            foreach (Developer developer in listOfDevelopers)
            {
                if (developer.PluralsightAccess == false)
                {
                    Console.WriteLine($"Full Name: {developer.FirstName} {developer.LastName}\n" +
                        $"ID Number: {developer.IdNumber}\n" +
                        $" ");
                }
                else
                {
                    
                }
            }
        }

        //Developer Teams:
        private void CreateNewDeveloperTeam()
        {
            
            Console.Clear();
            DevTeam newDevTeam = new DevTeam();

            Console.WriteLine("Enter the developer team name:");
            newDevTeam.TeamName= Console.ReadLine();

            Console.WriteLine("Enter the team ID number:");
            newDevTeam.TeamIdNumber = Console.ReadLine();


            Console.WriteLine("Do you want to add a developer to this team? (y/n)");  //bool get yes or no, then while loop , new developer = createnew dev; call new .addteammember from dev repo (
            bool addDeveloper = GetYesNoAnswer();

            while (addDeveloper)
            {
                Console.Clear();
                Developer newDeveloper = CreateNewDev();
                newDevTeam.AddDeveloper(newDeveloper);
                Console.WriteLine("Would you like to add another developer? (y/n)");
                addDeveloper = GetYesNoAnswer();
                
            }


            _devTeams.CreateNewTeam(newDevTeam);
            
        }
        private Developer CreateNewDev()
        {
            Developer newDev = new Developer();

            Console.WriteLine("Enter the new developer's ID:");
            newDev.IdNumber = Console.ReadLine();

            Console.WriteLine("Enter the new developer's First Name:");
            newDev.FirstName = Console.ReadLine();

            Console.WriteLine("Enter the new developer's Last Name:");
            newDev.LastName = Console.ReadLine();

            Console.WriteLine($"Does {newDev.FirstName} have access to a Pluralsight account? (Y/N)");
            newDev.PluralsightAccess = GetYesNoAnswer();

            return newDev;

        }
        private bool GetYesNoAnswer()
        {
            while (true)
            {
                string input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "yes":
                    case "y":
                        return true;
                    case "no":
                    case "n":
                        return false;
                }
                Console.WriteLine("Please enter valid input");
            }
        }


        private void ViewAllTeams()
        {
            Console.Clear();

            List<DevTeam> listOfDevTeams = _devTeams.GetDevTeamList();

            foreach (DevTeam devTeam in listOfDevTeams)
            {
                Console.WriteLine($"Team Name: {devTeam.TeamName}\n" +
                    $"Team ID Number: {devTeam.TeamIdNumber}"); 
                Console.WriteLine($"Developers On This Team: \n");



            }

        }

        private void ViewTeamByTeamIDNumber()
        {
            Console.Clear();
            Console.WriteLine("Enter the Team ID number:");

            string teamIdNumber = Console.ReadLine();

            DevTeam devTeam = _devTeams.GetDevTeamByIdNumber(teamIdNumber);
                //_developerRepo.GetDeveloperByIDNumber(idNumber);

            if (devTeam != null)
            {
                Console.WriteLine($"Team Name: {devTeam.TeamName}\n" +
                    $"Developers On This Team: \n" +
                    $" ");
            }
            else
            {
                Console.WriteLine("There is no team assigned to that ID Number.");
            }

        }
    
        private void UpdateExistingTeams()
        {
            


        }

        /*private void AddDeveloperToTeam()
        {
            
            //List<Developer> _developerDirectory = new List<Developer>();
            Console.Clear();
            List<Developer> newList = _developerRepo.GetDeveloperList();
            foreach (Developer developer in newList)
            {
                Console.WriteLine($"Full Name: {developer.FirstName} {developer.LastName}\n" +
                    $"ID Number: {developer.IdNumber}\n" +
                    $" ");

                /* Need user input: type in ID number and send to list of teams
                //string input = Console.ReadLine();
                 
            }
            
            DevTeam newDevTeam = new DevTeam();
            Console.WriteLine("Enter the Team ID number for the team you'd like to add developer to:");
            newDevTeam.TeamIdNumber = Console.ReadLine();
            _devTeams.GetDevTeamByIdNumber(newDevTeam.TeamIdNumber);

            Developer newDeveloper = new Developer();
            Console.WriteLine("Enter the developer ID for the developer you'd like to add to the team:");
            newDeveloper.IdNumber = Console.ReadLine();
            _developerRepo.AddDeveloper(newDeveloper);
          
           
        }*/

        private void RemoveDeveloperFromTeam()
        {

        }
                     
        //seed method
        private void SeedContentList()
        {
            Developer developer1 = new Developer("Nadia", "Belghozlane", "81992","", true);
            Developer developer2 = new Developer("John", "Smith", "81993","", true);
            Developer developer3 = new Developer("Harry", "Potter", "81994","", false);
            Developer developer4 = new Developer("Ron", "Weasley", "81995","", false);   //maybe add this to below segment to connect id numbers

            _developerRepo.AddDeveloper(developer1);
            _developerRepo.AddDeveloper(developer2);
            _developerRepo.AddDeveloper(developer3);
            _developerRepo.AddDeveloper(developer4);
        }

        private void SeedTeamList()
        {
          
            DevTeam team1 = new DevTeam("Team 1", "T1234");
            DevTeam team2 = new DevTeam("Team 2", "T4567");

            _devTeams.CreateNewTeam(team1);
            _devTeams.CreateNewTeam(team2);
        }
    }
}
