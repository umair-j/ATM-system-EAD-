using System;
using System.Collections.Generic;
using System.Text;

namespace ATM_view
{
    class Admin_View
    {
        public void Admin_menu()
        {
            Console.WriteLine("------WELCOME TO ADMIN VIEW------");
            Console.WriteLine("-----PLEASE CHOOSE AN OPTION-----\n" +
                "1----CREATE NEW ACCOUNT\n" +
                "2----DELETE EXISTING ACCOUNT\n" +
                "3----UPDATE ACCOUNT INFORMATION\n" +
                "4----SEARCH FOR ACCOUNT ACCOUNT\n" +
                "5----VIEW REPORTS\n" +
                "6----EXIT");
            int option = System.Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    //call new account function
                    break;
                case 2:
                    //call delete existing account function
                    break;
                case 3:
                    //call update account information function
                    break;
                case 4:
                    //call search account function
                    break;
                case 5:
                    //call view reports function
                    break;
                case 6:
                    //call exit function
                    break;

                default:
                    //call update account information function
                    Console.WriteLine("PLEASE ENTER A VALID OPTION (1-6)");
                    break;
            }

        }
    }
}
