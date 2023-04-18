using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB201_Prac_7
{
    internal class Contacts
    {
        // Fields
        private List<Person> People;

        // Constructor
        /// <summary>
        /// Create a new list of contacts
        /// </summary>
        public Contacts()
        {
            People = new List<Person>();
        }

        // Methods

        /// <summary>
        /// Add a person to the list of contacts
        /// </summary>
        /// <param name="name">their name</param>
        /// <param name="phone">their phone number</param>
        /// <param name="email">their email address</param>
        /// <exception cref="ArgumentException">Throws an ArgumentException if a person with 
        ///                                     that name is already in the list</exception>
        public void addPerson(string name, string phone, string email)
        {
            // Loop through list and check each name to see if they match the new entry
            foreach(Person entry in People)
            {
                if(entry.Name == name)
                {
                    // Throw an exception if one does
                    throw new ArgumentException("Duplicate name");
                }
            }

            Person newPerson = new Person(name, phone, email);
            People.Add(newPerson);
        }


        /// <summary>
        /// Removes a person with a specified name from the list of contacts
        /// </summary>
        /// <param name="name">the person to be removed</param>
        /// <returns>true if the removal was successful, false if it was not</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throws an ArgumentOutOfRangeException
        ///                                               if the contacts list is empty</exception>
        public bool removePerson(string name)
        {
            // If the list is empty, throw an exception
            if(People.Count == 0)
            {
                throw new ArgumentOutOfRangeException("Contacts list is empty");
            }

            int index = -1;
            for(int i = 0; i < People.Count; i++)
            {
                if (People[i].Name == name)
                {
                    index = i;
                    break;
                }
            }

            if(index != -1)
            {
                People.RemoveAt(index);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns the Person object with the specified name from the list of contacts
        /// </summary>
        /// <param name="name">the person's name</param>
        /// <returns>a Person object</returns>
        /// <exception cref="ArgumentException">Throws an ArgumentException if the person does not exist</exception>
        public Person getPerson(string name)
        {
            int index = -1;

            for(int i = 0; i < People.Count; i++)
            {
                if (People[i].Name == name)
                {
                    index = i;
                    break;
                }
            }

            if (index != -1)
            {
                return People[index];
            }

            // Add an exception here as if the person was in the list, then we would return on the line above
            // If they do not exist, then this line is run
            throw new ArgumentException($"Person {name} does not exist");

            // Removed the "return null" as it is no longer needed
        }

    }
}
