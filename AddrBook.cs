using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook01
{
    /// <summary>
    /// This is the main address book class that has all the methods defined in it.
    /// </summary>
    class AddressBook
    {
        //declaring a list with the class Contacts as the type
        //declaring adictionary with the already declared list inside of it as the value pair
        public static List<Contacts> contact = new List<Contacts>();
        public static Dictionary<string, List<Contacts>> addressBook = new Dictionary<string, List<Contacts>>();
        //the citybook and statebook dictionaries are basically to store person details along with key as city/state 
        public static Dictionary<string, List<Contacts>> cityBook = new Dictionary<string, List<Contacts>>();
        public static Dictionary<string, List<Contacts>> stateBook = new Dictionary<string, List<Contacts>>();

        //declaring it static so that we dont need to create an object in the program.cs
        public static void AddTo(string name)              //this method is used to pass the new address book name to the dictionary
        {
            addressBook.Add(name, contact);
        }
        public void AddAddress()
        {
            //creating a new object contactBook of the class Contacts to add addressess
            Contacts contactBook = new Contacts();
            Console.Write("Enter First Name - ");
            contactBook.firstName = Console.ReadLine();
            int check = SearchDuplicate(contact, contactBook);
            //after enterring the first name, we check by invoking the Searchduplicate method and obtain the result in check variable.
            if (check == 0)                //when its not duplicate. [0- no duplicate, 1- duplicate, no entry]
            {
                Console.Write("Enter Last Name - ");
                contactBook.lastName = Console.ReadLine();
                Console.Write("Enter Address - ");
                contactBook.address = Console.ReadLine();
                Console.Write("Enter Phone number - ");
                contactBook.phoneNumber = Console.ReadLine();
                Console.Write("Enter Email ID - ");
                contactBook.email = Console.ReadLine();
                Console.Write("Enter City - ");
                contactBook.city = Console.ReadLine();
                Console.Write("Enter State - ");
                contactBook.state = Console.ReadLine();
                Console.Write("Enter ZIP code - ");
                contactBook.zip = Console.ReadLine();

                //Addidng to the list
                contact.Add(contactBook);
            }
            else
            {
                Console.WriteLine("This conatct already exists with firstname- " + contactBook.firstName);
            }
        }

        public void View()                                              //this is  the method to view all the contacts stored currently
        {
            if (contact.Count == 0)                                       // this if statement shows that there is nothing in the list
            {
                Console.WriteLine("Currently there are no people added in your addressbook.");
            }
            else
            {
                Console.WriteLine("Here is the list and details of all the contacts in your addressbook.");

                foreach (var Details in contact)                  //this foreacch loops iterates through all the contacts objects in the contacts class
                {
                    //this returns the variables that we have stored 
                    Console.WriteLine("First Name -" + Details.firstName);
                    Console.WriteLine("Last Name -" + Details.lastName);
                    Console.WriteLine("Address -" + Details.address);
                    Console.WriteLine("Phone Number - " + Details.phoneNumber);
                    Console.WriteLine("Email ID -" + Details.email);
                    Console.WriteLine("City -" + Details.city);
                    Console.WriteLine("State -" + Details.state);
                    Console.WriteLine("ZIP code -" + Details.zip);
                    Console.WriteLine("-----------------------------------------------------------");
                }
            }

        }

        public void Edit()                          //this method lets the user edit the details based on their firstname
        {
            Console.WriteLine("Enter the first name of the contact you want to Modify.");
            Console.WriteLine();
            string fname = Console.ReadLine();      // taking the input of first name
            foreach (var Details in contact)
            {
                if (fname == Details.firstName)         //checking the equality of the first name
                {
                    // below codes are similar to that of adding a contact.
                    Console.Write("Enter First Name - ");
                    Details.firstName = Console.ReadLine();
                    Console.Write("Enter Last Name - ");
                    Details.lastName = Console.ReadLine();
                    Console.Write("Enter Address - ");
                    Details.address = Console.ReadLine();
                    Console.Write("Enter Phone number - ");
                    Details.phoneNumber = Console.ReadLine();
                    Console.Write("Enter Email ID - ");
                    Details.email = Console.ReadLine();
                    Console.Write("Enter City - ");
                    Details.city = Console.ReadLine();
                    Console.Write("Enter State - ");
                    Details.state = Console.ReadLine();
                    Console.Write("Enter ZIP code - ");
                    Details.zip = Console.ReadLine();
                    break;
                }
                else
                {
                    Console.WriteLine("No such entry found. Please check and try again!");
                    break;
                }
            }


        }

        //below method is for deleting the contact in the address book based on the search result of the firstname
        public void Delete()
        {
            Console.WriteLine("Enter the first name of the contact you want to Remove.");
            Console.WriteLine();
            string fname = Console.ReadLine();      // taking the input of first name
            foreach (var Details in contact)
            {
                if (fname == Details.firstName)
                {
                    Console.WriteLine("Are you sure you want to delete this Contact? (y/n).");
                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        contact.Remove(Details);
                        Console.WriteLine("\nContact is Deleted.");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Contact is not present.Please enter correct contact firstname.");
                }
            }

        }
        /// <summary>
        /// Searches for duplicate name entry while entering in the addressbook
        /// </summary>
        /// <param name="contact">The contact.</param>
        /// <param name="contactBook">The contact book.</param>
        /// <returns></returns>
        /// we are returning integer values which we check at add address method to check for duplicate entries.

        public static int SearchDuplicate(List<Contacts> contact, Contacts contactBook)            //this method takes the list and contactbook object of contacts class
        {
            foreach (var Details in contact)                     //iterating through all the elements in contact list 
            {
                var person = contact.Find(p => p.firstName.Equals(contactBook.firstName));       //using lambda and using the equals method
                if (person != null)
                {
                    //Console.WriteLine("Already this contact exist  with current first name -" + person.firstName);
                    return 1;
                }
                else
                { //nothing to put in else block as we dont wanrt to insert here
                    return 0;
                }

            }
            return 0;
        }
        //method of searching with city
        public static void SearchWithCity()
        {
            Console.WriteLine("Please enter the name of the city");
            string city = Console.ReadLine();
            //foreach (KeyValuePair<string, List<Contacts>> item in addressBook)    //(will work if we can permenantly store data somewhere like and not temporary heap memory"
            //{
            foreach (var Details in contact)
            {
                var person = contact.Find(p => p.city.Equals(city));
                if (person != null)
                {
                    Console.WriteLine("{0} person resides in the {1}", Details.firstName, city);
                }
                else
                {
                    //pass
                }
            }
            //}
        }
        //method of searching with state
        public static void SearchWithState()
        {
            Console.WriteLine("Please enter the name of the state");
            string state = Console.ReadLine();
            //foreach (KeyValuePair<string, List<Contacts>> item in addressBook)    //(will work if we can permenantly store data somewhere like and not temporary heap memory"
            //{
            foreach (var Details in contact)
            {
                var person = contact.Find(p => p.state.Equals(state));
                if (person != null)
                {
                    Console.WriteLine("{0} person resides in the {1}", Details.firstName, state);
                }
                else
                {
                    //pass
                }
            }
            //}
        }
        /// <summary>
        /// This method inserts the list of person and all their details based on their city
        /// </summary>
        public void AddByCity()
        {
            foreach (var Detail in contact)
            {
                string city = Detail.city;
                if (cityBook.ContainsKey(city))
                {
                    List<Contacts> exists = cityBook[city];
                    int i = SearchDuplicate(exists, Detail);                   //uncluded this to avoid duplicies.
                    if (i != 1)
                    {
                        exists.Add(Detail);
                    }
                    else { }
                }
                else
                {
                    List<Contacts> cityContact = new List<Contacts>();
                    cityContact.Add(Detail);
                    cityBook.Add(city, cityContact);
                }
            }
        }
        /// <summary>
        /// this method simply stores the person details of contacts along with their states in the dictionary
        /// </summary>
        public void AddByState()
        {
            foreach (var Detail in contact)
            {
                string state = Detail.state;
                if (stateBook.ContainsKey(state))
                {
                    List<Contacts> exists = stateBook[state];
                    int i = SearchDuplicate(exists, Detail);                   //uncluded this to avoid duplicies.
                    if (i != 1)
                    {
                        exists.Add(Detail);
                    }
                    else { }
                }
                else
                {
                    List<Contacts> stateContact = new List<Contacts>();
                    stateContact.Add(Detail);
                    stateBook.Add(state, stateContact);
                }
            }
        }
        /// <summary>
        /// Views the by the selected option whther chosen to view by state or city
        /// if the user selects to choose city, he has to selct 1 and 2 for statewise display of contacts
        /// this method displayes city and all the common persons residing in that place
        /// </summary>
        public void ViewBy()
        {
            Console.WriteLine("Please select your option- 1- To view all contacts by city, 2- To view all contacts by state.");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                int cityCount = cityBook.Count();
                if (cityCount != 0)
                {
                    foreach (KeyValuePair<string, List<Contacts>> item in cityBook)
                    {
                        Console.WriteLine("\n Following are the Person details residing in the city -" + item.Key);
                        foreach (var items in item.Value)
                        {
                            //this returns the variables that we have stored 
                            Console.WriteLine("\n First Name -" + items.firstName);
                            Console.WriteLine("Last Name -" + items.lastName);
                            Console.WriteLine("Address -" + items.address);
                            Console.WriteLine("Phone Number - " + items.phoneNumber);
                            Console.WriteLine("Email ID -" + items.email);
                            Console.WriteLine("City -" + items.city);
                            Console.WriteLine("State -" + items.state);
                            Console.WriteLine("ZIP code -" + items.zip);
                        }
                        Console.WriteLine("-----------------------------------------------------------");
                    }
                }
                else
                {
                    Console.WriteLine("Currently no entries are inserted.");
                }
            }
            else if (choice == 2)
            {

                int stateCount = stateBook.Count();
                if (stateCount != 0)
                {
                    foreach (KeyValuePair<string, List<Contacts>> item in stateBook)
                    {
                        Console.WriteLine("\n Following are the Person details residing in the state -" + item.Key);
                        foreach (var items in item.Value)
                        {
                            //this returns the variables that we have stored 
                            Console.WriteLine("First Name -" + items.firstName);
                            Console.WriteLine("Last Name -" + items.lastName);
                            Console.WriteLine("Address -" + items.address);
                            Console.WriteLine("Phone Number - " + items.phoneNumber);
                            Console.WriteLine("Email ID -" + items.email);
                            Console.WriteLine("City -" + items.city);
                            Console.WriteLine("State -" + items.state);
                            Console.WriteLine("ZIP code -" + items.zip);

                        }
                        Console.WriteLine("-----------------------------------------------------------");
                    }
                }
                else
                {
                    Console.WriteLine("Currently no entries are inserted.");
                }

            }
            else
            {
                Console.WriteLine("Wrong entry, Please choose between 1 and 2");
            }
        }
        /// <summary>
        /// Counts the by The number of person in each city or state
        /// </summary>
        public void CountBy()
        {
            Console.WriteLine("Select 1- count person by city, 2- Count person by state");                 //We have used this method to describe the people count by city or state
            int num = Convert.ToInt32(Console.ReadLine());
            void CountByCity()                       //method inside of a method
            {
                foreach (var item in cityBook)
                {
                    int count = item.Value.Count();
                    Console.WriteLine("There are {0} number of people in City- {1}", count, item.Key);
                }
            }
            void CountBystate()                //method insisde of a method
            {
                foreach (var item in stateBook)
                {
                    int count = item.Value.Count();
                    Console.WriteLine("There are {0} number of people in City- {1}", count, item.Key);
                }
            }

            if (num == 1)
            {
                if (cityBook.Count != 0)    //When there are atleast 1 entry
                {
                    CountByCity();
                }
                else
                {
                    Console.WriteLine("Currently no entries stored");
                }
            }
            else if (num == 2)
            {
                if (stateBook.Count != 0)
                {
                    CountBystate();
                }
                else
                {
                    Console.WriteLine("Currently no entries stored");
                }
            }
            else
            {
                Console.WriteLine("Invalid selection, please select between 1 and 2");
            }


        }
        public static void WriteAddressBookUsingStreamWriter()
        {
            //provide file path
            string path = @"C:\Users\91992\Desktop\c# Assignments\AddressBook\Files\AddressBook1.txt";
            // Appending the given texts using streamwriter class and inbuilt File class method.
            using (StreamWriter write = File.AppendText(path))       
            {
                //iterating each element from addressbook dictionary
                foreach (KeyValuePair<string, List<Contacts>> item in addressBook)  //creating keyvaluepair which belogs to generics class.
                {
                    foreach (var items in item.Value)
                    {
                        //writing in .txt file
                        write.WriteLine("First Name -" + items.firstName);
                        write.WriteLine("Last Name -" + items.lastName);
                        write.WriteLine("Address -" + items.address);
                        write.WriteLine("Phone Number - " + items.phoneNumber);
                        write.WriteLine("Email ID -" + items.email);
                        write.WriteLine("City -" + items.city);
                        write.WriteLine("State -" + items.state);
                        write.WriteLine("ZIP code -" + items.zip);
                    }
                    write.WriteLine("--------------------------------------------------------------");
                }
                write.Close();
                Console.WriteLine(File.ReadAllText(path));
            }
        }
        //This method for reading address book with person contact from .txt file using File IO
        public static void ReadAddressBookUsingStreamReader()
        {
            Console.WriteLine("The contact List using StreamReader method ");

            string path = @"C:\Users\91992\Desktop\c# Assignments\AddressBook\Files\AddressBook1.txt";
            // opening the given texts using streareader class and inbuilt File class method.
            using (StreamReader read = File.OpenText(path))
            {
                string s = " ";
                while ((s = read.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }

            }
        }
        //This method for writing address book with person contact into .csv file using File IO
        public static void CsvSerialise()
        {
            try
            {
                string csvPath = @"C:\Users\91992\Desktop\c# Assignments\AddressBook\Files\CSVFiles.csv";
                var writer = File.AppendText(csvPath);

                foreach (KeyValuePair<string, List<Contacts>> item in addressBook)
                {
                    foreach (var items in item.Value)
                    {
                        writer.WriteLine(items.firstName + ", " + items.lastName + ", " + items.phoneNumber + ", " + items.email + ", " + items.city + ", " + items.state + ", " + items.zip + ".");

                    }
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        //This method for reading address book with person contact from .csv file using File IO
        public static void CsvDeserialise()
        {
            string csvPath = @"C:\Users\91992\Desktop\c# Assignments\AddressBook\Files\CSVFiles.csv";
            using (var reader = new StreamReader(csvPath))

            {
                string s = " ";
                while ((s = reader.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }

            }


        }
        public void JsonSearialize()
        {
            string path = @"C:\Users\91992\Desktop\c# Assignments\AddressBook\Files\contact.json";

            Contacts person = new Contacts() { firstName = "Amit", lastName = "Salunkhe", address = "Satara", city = "Satara", state = "maharashtra", zip = "121212", email = "amit@gmail.com", phoneNumber = "1212121212" };
            string result = JsonConvert.SerializeObject(person);
            File.WriteAllText(path, result);
        }

        public void JsonDeSerialize()
        {
            try
            {
                string path = @"C:\Users\91992\Desktop\c# Assignments\AddressBook\Files\contact.json";
                string result = File.ReadAllText(path);
                Contacts res = JsonConvert.DeserializeObject<Contacts>(result);

                if (res != null)
                {
                    Console.WriteLine("Contact Details");
                    Console.WriteLine("FirstName={0}\tLastName={1}\t Address={2} City={3}\tState={4}\tZipcode={5}\t\tEmail={6} PhoneNumber={7}", res.firstName, res.lastName, res.address, res.city, res.state, res.zip, res.email, res.phoneNumber);
                }
                else
                {
                    Console.WriteLine("No Contact Details");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}

