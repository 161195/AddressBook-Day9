using System;

namespace AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            int num;
            //guide to user 
            Console.WriteLine("__Welcome to the address book program__");
            Console.WriteLine();
            Console.WriteLine("Enter the number of Address Books you want to add:");
            Console.WriteLine();
            
            int numAddBook = Convert.ToInt32(Console.ReadLine());          //taking user inputs about the number of add books needed
            int numberBook = 0;
            Console.WriteLine();
            while (numberBook < numAddBook)                                //this while loop runs till the favourable no. of add books are created
            {
                Console.WriteLine("Enter the name of the address book");
                string book = Console.ReadLine();                         //taking the add book name as input
                Console.WriteLine("Select the option that you would like to perform.");
                Console.WriteLine();
                //declaring address book object to be used in the below cases
                AddressBook AddObj = new AddressBook();
                string keyPress = "o";

                while (keyPress != "n")
                {
                    Console.WriteLine("1- Add contact, 2- View contact,3-edit contact,4-delete contact");
                    num = Convert.ToInt32(Console.ReadLine());

                    switch (num)               //switch case 
                    {
                        case 1:
                            AddObj.AddContact();
                            break;

                        case 2:
                            AddObj.View();
                            break;

                        case 3:
                            AddObj.Edit();
                            break;

                        case 4:
                            AddObj.Delete();                                  //method to delete the contacts
                            break;
                    }
                    Console.WriteLine("Do you wish to continue? Press (y/n)");
                    keyPress = Console.ReadLine();
                }
                AddressBook.AddTo(book);                         //calling the AddTo method to add the new address book in the dictionary
                numberBook++;                                    //incrementing the variable
            }
        }
    }
}
