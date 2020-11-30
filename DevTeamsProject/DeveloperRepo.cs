using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DeveloperRepo
    {
        private readonly List<Developer> _developerDirectory = new List<Developer>();
        //Developer Create

        public void AddDeveloper(Developer developer)
        {
            _developerDirectory.Add(developer);
        }


        //Developer Read
        public List<Developer> GetDeveloperList()
        {
            return _developerDirectory;
        }

        //Developer Update
        public bool UpdateExistingDeveloper(string originalDeveloperInfo, Developer newDeveloperInfo)
        {
            Developer oldDeveloperInfo = GetDeveloperByIDNumber(originalDeveloperInfo);

            if (oldDeveloperInfo != null)
            {
                oldDeveloperInfo.FirstName = newDeveloperInfo.FirstName;
                oldDeveloperInfo.LastName = newDeveloperInfo.LastName;
                oldDeveloperInfo.IdNumber = newDeveloperInfo.IdNumber;
                oldDeveloperInfo.PluralsightAccess = newDeveloperInfo.PluralsightAccess;

                return true;
            }
            else
            {
                return false;
            }

        }

        //Developer Delete
        public bool RemoveDeveloperFromList(string idNumber)
        {
            Developer developer = GetDeveloperByIDNumber(idNumber);

            if(developer == null)
            {
                return false;
            }

            int initialCount = _developerDirectory.Count;
            _developerDirectory.Remove(developer);

            if(initialCount > _developerDirectory.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Developer Helper (Get Developer by ID)
        public Developer GetDeveloperByIDNumber(string idNumber)
        {
            foreach (Developer developer in _developerDirectory)
            {
                if (developer.IdNumber == idNumber)
                {
                    return developer;
                }

            }

            return null;
        }
    }
}
