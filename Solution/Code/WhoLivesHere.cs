using System;
namespace CAB201_Prac_7
{
    class WhoLivesHere
    {        
        string name;
        string city;
        int age;
        
        WhoLivesHere(string myName, string myCity, int myAge)
        {
            if (myName == null)
            {
                throw new ArgumentNullException("Name cannot be null");
            }
            if (myAge < 0)
            {
                throw new ArgumentOutOfRangeException("Age cannot be negative");
            }
            if (myCity.Length == 0) // empty string
            {
                throw new ArgumentException("City cannot be empty");
            }
            name = myName;
            city = myCity;
            age = myAge;
        }
        
        static void Main(string[] args)
        {
            WhoLivesHere whom1 = new WhoLivesHere("Sally", "Brisbane", 80);
            Console.WriteLine(whom1.name + " " + whom1.city + " (" + whom1.age + ")");
            WhoLivesHere whom2 = new WhoLivesHere("Charlie", "New York", 25);
            Console.WriteLine(whom2.name + " " + whom2.city + " (" + whom2.age + ")");

            try {
                Console.WriteLine("Trying to create a person with null name");
                WhoLivesHere errorWhom = new WhoLivesHere(null, "Brisbane", 21);
            } catch (ArgumentNullException e)
            {
                Console.WriteLine("Something wrong happened! {0}", e.Message);
                Console.WriteLine("Type of exception: {0}", e.GetType());
            } catch (Exception e)
            {
                Console.WriteLine("Expecting System.ArgumentNullException but got: {0}", e.GetType());
            }
            try
            {
                Console.WriteLine("Trying to create a person with negative age");
                WhoLivesHere whom8 = new WhoLivesHere("Alice", "123", -10);
                Console.WriteLine("{0} ({1})", whom8.name, whom8.age);
            } catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Something wrong happened: {0}", ex.GetType());
            } catch (Exception ex)
            {
                Console.WriteLine("Expecting ArgumentOutOfRangeException but got {0}", ex.GetType());
            }

            try
            {
                Console.WriteLine("Creating a person with no address");
                WhoLivesHere whom = new WhoLivesHere("Karen", "", 20);
                Console.WriteLine("{0} ({1}): {2}", whom.name, whom.age, whom.city);
            } catch (ArgumentException ex)
            {
                Console.WriteLine("Something wrong happend: {0}", ex.GetType());
            } catch (Exception ex)
            {
                Console.WriteLine("Expecting an ArgumentException but got {0}", ex.GetType());
            }

            //try
            //{
            //    // throw an exception because of an empty argument
            //    WhoLivesHere whom = new WhoLivesHere("Karen", "", 20);
            //}
            //catch (ArgumentException)
            //{
            //    Console.WriteLine("Correct: the right exception type was thrown.");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("Error: The constructor generated the wrong type of exception!");
            //    Console.WriteLine(e.ToString());
            //}
        }
    }
}