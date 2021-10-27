using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    class AddressBook
    {
        //declaring a list with the class Contacts.
        public static List<ContactDetails> contacts1 = new List<ContactDetails>();
        //declaring dictionary with the already declared list inside of it as the value pair
        public static Dictionary<string, List<ContactDetails>> addressBook = new Dictionary<string, List<ContactDetails>>();
        //declaring it static so that we dont need to create an object in the program.cs
        public static void AddTo(string name)              //this method is used to pass the new address book name to the dictionary
        {
            addressBook.Add(name, contacts1);
        }
        public void AddContact()
        {
            //creating object of ContactDetails class

            ContactDetails contact = new ContactDetails();
            Console.WriteLine("Enter First Name");
            contact.firstName = Console.ReadLine();

            Console.WriteLine("Enter Last Name");
            contact.lastName = Console.ReadLine();

            Console.WriteLine("Enter address Name");
            contact.address = Console.ReadLine();

            Console.WriteLine("Enter phone number");
            contact.phoneNumber = Console.ReadLine();

            Console.WriteLine("Enter email ID");
            contact.email = Console.ReadLine();

            Console.WriteLine("Enter city Name");
            contact.city = Console.ReadLine();

            Console.WriteLine("Enter state Name");
            contact.state = Console.ReadLine();

            Console.WriteLine("Enter zip");
            contact.zip = Console.ReadLine();

            contacts1.Add(contact);  //adding to the list
        }
        public void View()
        {
            if (contacts1.Count == 0)                                       // this if statement shows that there is nothing in the list
            {
                Console.WriteLine("Currently there are no people added in your addressbook.");
            }
            else
            {
                Console.WriteLine("Here is the list and details of all the contacts in your addressbook.");

                foreach (var Detailing in contacts1)                  //this foreacch loops iterates through all the contacts objects in the contacts class
                {

                    Console.WriteLine("first name = " + Detailing.firstName);
                    Console.WriteLine("last name = " + Detailing.lastName);
                    Console.WriteLine("address = " + Detailing.address);
                    Console.WriteLine("state = " + Detailing.state);
                    Console.WriteLine("city = " + Detailing.city);
                    Console.WriteLine("zip no = " + Detailing.zip);
                    Console.WriteLine("phone number = " + Detailing.phoneNumber);
                    Console.WriteLine("email ID = " + Detailing.email);
                }
            }
        }
        public void Edit()                          //this method lets the user edit the details based on their firstname
        {
            Console.WriteLine("Enter the first name of the contact you want to Modify.");
            Console.WriteLine();
            string fName = Console.ReadLine();      // taking the input of first name
            foreach (var Details in contacts1)
            {
                if (fName == Details.firstName)
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
        public void Delete()
        {
            Console.WriteLine("Enter the first name of the contact you want to Remove.");
            Console.WriteLine();
            string fname = Console.ReadLine();      // take the input of first name
            foreach (var Details in contacts1)
            {
                if (fname == Details.firstName)
                {
                    Console.WriteLine("Do you want to delete this Contact? (y/n).");
                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        contacts1.Remove(Details);
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
    }
}
