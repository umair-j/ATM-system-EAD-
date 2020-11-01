using ATM_view;
using System;

namespace ATM_system__EAD_
{
    class Program
    {
        static void Main(string[] args)
        {
            //adminView object created
            Admin_View adV = new Admin_View();
            //customerView object created 
            Customer_View csV = new Customer_View();

            //asking user to choose between admin menu and customer menu(made for easy of testing)
            Console.WriteLine("Enter 1 for Admin menu : ");
            Console.WriteLine("Enter 2 for Customer menu : ");
            string choice = Console.ReadLine();
            //checking user input
            if(choice == "1")
            {
                adV.Admin_menu();
            }
            else if (choice == "2")
            {
                csV.CheckLogin();
            }
            else
            {
                Console.WriteLine("Enter a valid choice (1 or 2)");
            }
            
        }
    }
}
