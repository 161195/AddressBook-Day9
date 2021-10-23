using System;

namespace AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            ContactDetails contact = new ContactDetails();
            contact.firstName = "Mayuri";
            contact.lastName = "salunkhe";
            contact.phoneNumber = "9881815815";
            contact.address = "shahupuri ,satara";
            contact.state = "Maharashtra";
            contact.email = "mayurisalunkhe01@gmail.com";
            contact.city = "satara";
            contact.zip = "415002";

            Console.WriteLine("\n First Name: {0} \n Last Name: {1} \n Address: {2} \n Phone Number: {3}\n Email: {4} \n City: {5} \n State: {6}\n ZipCode: {7}", contact.firstName, contact.lastName, contact.address, contact.phoneNumber, contact.email, contact.city, contact.state, contact.zip);
        }
    }
}

