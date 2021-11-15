using System;
using System.Collections.Generic;
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
                    Console.WriteLine("Already this contact exist  with current first name -" + person.firstName);
                    return 1;
                }
                else
                { //nothing to put in else block as we dont wanrt to insert here
                    return 0;
                }

            }
            return 0;
        }
        //method of starting with city
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

    }
}
