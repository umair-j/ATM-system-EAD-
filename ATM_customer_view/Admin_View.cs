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
        Admin_BLL adminBLL = new Admin_BLL();
        public void Admin_menu()
        {
                int option = default;
                 Console.WriteLine("------WELCOME TO ADMIN VIEW------");
                 Console.WriteLine(
                "1----CREATE NEW ACCOUNT\n" +
                "2----DELETE EXISTING ACCOUNT\n" +
                "3----UPDATE ACCOUNT INFORMATION\n" +
                "4----SEARCH FOR ACCOUNT ACCOUNT\n" +
                "5----VIEW REPORTS\n" +
                "6----EXIT");
                try
                {
                    option = System.Convert.ToInt32(Console.ReadLine());
                }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            switch (option)
            {
               
                case 1:
                    //call new account function
                    bool b = NewAccount();
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
        public bool NewAccount()
        {
            bool created = false;
            int accountNo = default;
            Console.Write("Login : ");
            string CustomerId = Console.ReadLine();
            Console.Write("Pin Code : ");
            try
            {
                int CustomerPin = System.Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                created = false;
                return created;
            }
            Console.Write("Holder's name : ");
            string CustomerName = Console.ReadLine();
            Console.Write("Type (savings/current) : ");
            string Type = Console.ReadLine();
            Console.WriteLine(Type);
            if (!(Type.Equals("savings")) && !(Type.Equals("current")))
            {
                Console.WriteLine("Invalid type entered!");
                created = false;
                return created;
            }
            else
            {
                Console.Write("Starting Balance : ");
                try
                {
                    int CustomerBalance = System.Convert.ToInt32(Console.ReadLine());
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    created = false;
                    return created;
                }
                Console.WriteLine("Status (active/inactive) : ");
                string Status = Console.ReadLine();
                if(!(Status.Equals("active")) && !(Type.Equals("inactive")))
                {
                    Console.WriteLine("Invalid Status entered!");
                    created = false;
                    return created;
                }
                else
                {
                    //create new account
                    Console.WriteLine($"Account Successfully Created - the account number assigned is: {accountNo} ");
                   
                }
               
                //adminBLL.NewAccount(CustomerId, CustomerPin, CustomerBalance, CustomerName, CustomerStatus, CustomerAccountType);
            }
            return created;
        }


    }
}
