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
                    "7. Create New Developer Team/ Add Developers To Team\n" +
                    "8. View All Teams\n" +
                    "9. View Team By Team ID Number\n" +
                    "10. Remove Developer From Team\n" +
                    "11. Exit");

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
                        CreateNewDeveloperTeam();  
                        break;
                    case "8":
                        ViewAllTeams();
                        break;
                    case "9":
                        ViewTeamByTeamIDNumber();
                        break;
                    case "10":
                        RemoveDeveloperFromTeam();
                        break;
                    case "11":
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
                    $"Team: {developer.TeamName}\n" +
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

            Console.WriteLine("Do you want to add a developer to this team? (y/n)");   
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
                Console.WriteLine("Please enter valid input.");
            }
        }

        private void ViewAllTeams()
        {
            Console.Clear();

            List<DevTeam> listOfDevTeams = _devTeams.GetDevTeamList();
            Developer newDev = new Developer();

            foreach (DevTeam devTeam in listOfDevTeams)
            {
                Console.WriteLine($"\n" +
                $"Team Name: {devTeam.TeamName}\n" +
                $"Team ID Number: {devTeam.TeamIdNumber}");

                foreach (Developer developer in devTeam.DeveloperListForDevTeams)
                {
                    Console.WriteLine($"Developers On This Team (by ID #): {developer.IdNumber}");
                }
            }
        }

        private void ViewTeamByTeamIDNumber()
        {
            Console.Clear();
            Console.WriteLine("Enter the Team ID number:");

            string teamIdNumber = Console.ReadLine();

            DevTeam devTeam = _devTeams.GetDevTeamByIdNumber(teamIdNumber);

            if (devTeam != null)
            {
                Console.WriteLine($"\n" +
                    $"Team Name: {devTeam.TeamName}\n" +
                    $"Developers On This Team: \n" +
                    $" ");
                foreach (Developer developer in devTeam.DeveloperListForDevTeams)
                {
                    Console.WriteLine($"Developers On This Team (by ID #): {developer.IdNumber}");
                }
            }
            else
            {
                Console.WriteLine("There is no team assigned to that ID Number.");
            }
        }

        private void RemoveDeveloperFromTeam()
        {

        }          
        //seed method
        private void SeedContentList()
        {
            Developer developer1 = new Developer("Nadia", "Belghozlane", "81992","Team 1", true);
            Developer developer2 = new Developer("John", "Smith", "81993","Team 2", true);
            Developer developer3 = new Developer("Harry", "Potter", "81994","Team 3", false);
            Developer developer4 = new Developer("Ron", "Weasley", "81995","Team 3", false);
            Developer developer5 = new Developer("Hermione", "Granger", "81996", "", false);

            _developerRepo.AddDeveloper(developer1);
            _developerRepo.AddDeveloper(developer2);
            _developerRepo.AddDeveloper(developer3);
            _developerRepo.AddDeveloper(developer4);
            _developerRepo.AddDeveloper(developer5);
        
            DevTeam team1 = new DevTeam("Team 1", "T1234", new List<Developer>() {developer1, developer2});
            DevTeam team2 = new DevTeam("Team 2", "T4567", new List<Developer>() {developer3});
            DevTeam team3 = new DevTeam("Team 3", "T6789", new List<Developer>() {developer4});

            _devTeams.CreateNewTeam(team1);
            _devTeams.CreateNewTeam(team2);
            _devTeams.CreateNewTeam(team3);
        }  
    }
}
