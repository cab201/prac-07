namespace CAB201_Prac_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing normal inputs...");
            TestNormalInputs();
            Console.WriteLine("\n\nTesting empty data for Person...");
            TestEmptyData();
            Console.WriteLine("\n\nTesting getting invalid entry...");
            TestGetInvalidEntry();
            Console.WriteLine("\n\nTesting adding duplicate entry...");
            TestDuplicateEntry();
        }

        // The following methods are testing methods and should not be altered
        public static void TestNormalInputs()
        {
            Contacts contactList = new Contacts();

            // These should all work correctly
            contactList.addPerson("Alice", "0123456789", "alice@gmail.com");
            contactList.addPerson("Bob", "9876543210", "bob@mail.com");

            Console.WriteLine("The contacts list contains these two people: ");

            Person Alice = contactList.getPerson("Alice");
            Person Bob = contactList.getPerson("Bob");

            Console.WriteLine($"{Alice.Name}\t{Alice.Phone}\t{Alice.Email}");
            Console.WriteLine($"{Bob.Name}\t{Bob.Phone}\t{Bob.Email}");
        }

        public static void TestGetInvalidEntry()
        {
            Contacts contactList = new Contacts();

            Console.WriteLine("Attempting to get an entry that does not exist: ");
            try
            {
                contactList.getPerson("Charlie");
                Console.WriteLine("No exception was thrown");
            }
            catch (ArgumentException E)
            {
                Console.WriteLine("The correct exception was thrown. The message is: ");
                Console.WriteLine(E.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("An incorrect exception was thrown");
            }
        }

        public static void TestDuplicateEntry()
        {
            Contacts contactList = new Contacts();

            Console.WriteLine("Attempt to add a person with the same name: ");
            try
            {
                contactList.addPerson("Alice", "0123456789", "alice@gmail.com");
                contactList.addPerson("Alice", "0123456789", "alice@gmail.com");

                Console.WriteLine("No exception was thrown");
            }
            catch (ArgumentException A)
            {
                Console.WriteLine("The correct exception was thrown. The message is: ");
                Console.WriteLine(A.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("An incorrect exception was thrown");
            }
        }

        public static void TestRemovingFromEmptyList()
        {
            Contacts contactList = new Contacts();

            Console.WriteLine("Attempting to remove an entry when the list of contacts is empty: ");
            try
            {
                contactList.removePerson("Alice");
            }
            catch (ArgumentOutOfRangeException E)
            {
                Console.WriteLine("The correct exception was thrown. The message is: ");
                Console.WriteLine(E.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("An incorrect exception");
            }
        }

        public static void TestEmptyData()
        {
            try
            {
                Person Blank = new Person("", "", "");
                Console.WriteLine("No exception was thrown");
            }
            catch (ArgumentNullException E)
            {
                Console.WriteLine("The correct exception was thrown. The message is: ");
                Console.WriteLine(E.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("The incorrect exception was thrown");
            }
        }
    }
}