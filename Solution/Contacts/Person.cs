using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB201_Prac_7
{
    internal class Person
    {

        // Fields
        private string name;
        private string phone;
        private string email;

        // Properties
        public string Name
        {
            get
            {
                return name;
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
        }

        // Constructors

        /// <summary>
        /// Create an entry for a list of contacts
        /// </summary>
        /// <param name="name">the person's name</param>
        /// <param name="phone">the person's phone number</param>
        /// <param name="email">the person's email</param>
        /// <exception cref="ArgumentNullException">Throw an ArgumentNullException if any of the 
        ///                                         inputs are null or whitespace</exception>
        public Person(string name, string phone, string email)
        {
            // Check all three inputs to see if any are null or white space
            if (String.IsNullOrWhiteSpace(name) || String.IsNullOrWhiteSpace(phone) || String.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException("One of the string provided was empty or white space");
            }
            this.name = name;
            this.phone = phone;
            this.email = email;
        }

    }
}
