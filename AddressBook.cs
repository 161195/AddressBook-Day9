using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    class AddressBook
    {
        public List<ContactDetails> contacts = new List<ContactDetails>();
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

            contacts.Add(contact);
        }
        public void View()
        {
            Console.WriteLine("This is your contact details :");

            foreach (var Detailing in contacts)
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
}
