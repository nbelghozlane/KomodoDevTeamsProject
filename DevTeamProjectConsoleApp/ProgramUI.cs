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


        //Method to start application (UI part)
        public void Run()
        {
            Menu();
        }

        //Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {


                //Display options
                Console.WriteLine("Hello! Please select a menu option(type in number):\n" +
                    "1. Create New Developer\n" +
                    "2. View All Developers\n" +
                    "3. View Developer By ID Number\n" +
                    "4. Update Existing Developer Information\n" +
                    "5. Delete Existing Developer\n" +
                    "6. View Developers That Need Pluralsight License\n" +
                    "7. Exit");

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
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    //need bool
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
            newDeveloper.PluralsightAccess = bool.Parse(pluralsightAccessString);

            if(pluralsightAccessString == "yes")
            {
                newDeveloper.PluralsightAccess = true;
            }
            else
            {
                newDeveloper.PluralsightAccess = false;
            }

            _developerRepo.AddDeveloperToList(newDeveloper);


        }

        private void ViewAllDevelopers()
        {

        }

        private void ViewDeveloperByIdNumber()
        {

        }

        private void UpdateExistingDeveloperInfo()
        {

        }

        private void DeleteExistingDeveloper()
        {

        }

        private void ViewDevelopersWithoutPluralsight()
        {

        }

    }
}
