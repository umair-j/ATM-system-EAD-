using ATM_BLL;
using ATM_BO;

using System;
using System.Collections.Generic;
using System.Text;

namespace ATM_view
{
    public class Admin_View
    {
        public bool Exited = false;

        public Customer_BO C_bo = new Customer_BO();
       
        public void Admin_menu()
        {
                int option = default;
                 Console.WriteLine("------WELCOME TO ADMIN VIEW------");
                 Console.WriteLine("-----PLEASE CHOOSE AN OPTION-----\n" +
                "1----CREATE NEW ACCOUNT\n" +
                "2----DELETE EXISTING ACCOUNT\n" +
                "3----UPDATE ACCOUNT INFORMATION\n" +
                "4----SEARCH FOR ACCOUNT ACCOUNT\n" +
                "5----VIEW REPORTS\n" +
                "6----EXIT");
                option = System.Convert.ToInt32(Console.ReadLine());
             Admin_BLL adminBLL = new Admin_BLL();
            switch (option)
            {
               
                case 1:
                    //call new account function
                    Console.WriteLine("Enter Login ID");
                    string CustomerId = Console.ReadLine();
                    Console.WriteLine("Assign a pin to " + CustomerId);
                    int CustomerPin = System.Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Holder's name");
                    string CustomerName = Console.ReadLine();
                    Console.WriteLine("Enter Account Type (savings/current)");
                    string CustomerAccountType = Console.ReadLine();
                    Console.WriteLine("Enter Balance");
                    int CustomerBalance = System.Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Customer Status (Active/Inactive)");
                    string CustomerStatus = Console.ReadLine();
                    adminBLL.NewAccount(CustomerId,CustomerPin,CustomerBalance,CustomerName,CustomerStatus,CustomerAccountType);
                    break;
                case 2:
                    //call delete existing account function
                    Console.WriteLine("Enter name to be deleted");
                    string name = Console.ReadLine();
                    adminBLL.DeleteAccount(name);
                    break;
                case 3:
                    //call update account information function
                    break;
                case 4:
                    //call search account function
                    Console.WriteLine("Enter the name of person you wish to search ");
                    string Customer_name = Console.ReadLine();
                    adminBLL.Search(Customer_name);
                    break;
                case 5:
                    //call view reports function
                    break;
                case 6:
                    //call exit function
                    Exited = true;
                   
                    break;

                default:
                    //call update account information function
                    Console.WriteLine("PLEASE ENTER A VALID OPTION (1-6)");
                    option = 0;
                    break;
            }

        }
        

    }
}
