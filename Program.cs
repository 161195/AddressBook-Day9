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
            contact.email = "mayurisalunkhe01@gmail.com";
            contact.city = "satara";
            Console.WriteLine("first name = " + contact.firstName);
        }
    }
}
