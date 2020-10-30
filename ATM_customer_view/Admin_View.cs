using ATM_BLL;
using ATM_BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATM_view
{
    public class Admin_View
    {
        

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
                Admin_menu();
            }

            if (option < 1 || option > 6)
            {
                //call update account information function
                Console.WriteLine("PLEASE ENTER A VALID OPTION (1-6)");
                option = 0;
            }
            else
            {
                switch (option)
                {
                    case 1:
                        //call new account function
                        bool b = NewAccount();
                        break;
                    case 2:
                        //call delete existing account function
                        Console.Write("Enter the account number to which you want to delete : ");
                        try
                        {
                            int accountNo = System.Convert.ToInt32(Console.ReadLine());
                            DeleteAccount(accountNo);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Admin_menu();
                        }

                        break;
                    case 3:
                        //call update account information function
                        Console.Write("Enter the account number : ");
                        
                            string accountNum = Console.ReadLine();
                            Update(accountNum);
                        
                        break;
                    case 4:
                        //call search account function
                        Search();
                        break;
                    case 5:
                        //call view reports function
                        ViewReports();
                        break;
                    case 6:
                        //call exit function
                        System.Environment.Exit(1);
                        break;

                }
            }
            Admin_menu();
        }
        public void ViewReports()
        {
            int ch = default;
            
            Console.WriteLine("Enter the type of report");
            Console.WriteLine("1---Accounts by Amount");
            Console.WriteLine("2---Accounts by Date");
            try
            {
                ch = System.Convert.ToInt32(Console.ReadLine());
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if(ch < 1 || ch > 2)
            {
                Console.WriteLine("Please enter a valid option (1 or 2) ");
            }
            else
            {
                if(ch == 1)
                {
                    ReportByAmount();
                }
                else if(ch == 2)
                {
                    ReportByDate();
                }
            }
        }
        public void ReportByAmount()
        {
            
            int min = default;
            int max = default;
            Console.Write("Enter the maximum amount : ");
            try
            {
                max = System.Convert.ToInt32(Console.ReadLine());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                //return to break out of function in case of error
                return;
            }
            Console.Write("Enter the minimum amount : ");
            try
            {
                min = System.Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //return to break out of function in case of error
                return;
            }
            //apply calculations to find data
            Console.WriteLine("\n==== SEARCH RESULTS ====\n");
            //display users' data in required format
            Console.WriteLine("Account ID \t User ID \t Holder's Name \t Type \t Balance \t Status\n");

        }
        public void ReportByDate()
        {
            string startDate = default;
            string endDate = default;
            Console.Write("Enter the starting date : ");
            try
            {
                startDate = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //return to break out of function in case of error
                return;
            }
            Console.Write("Enter the ending date : ");
            try
            {
                endDate = Console.ReadLine();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                //return to break out of function in case of error
                return;
            }
            //apply calculations to find data
            Console.WriteLine("\n==== SEARCH RESULTS ====\n");
            //display users' data in required format
            Console.WriteLine("Transaction Type \t User ID \t Holder's Name \t Amount \t Date\n");

        }
        public void Search()
        {
            //default value
            string balanceInput = default;
            string accountIdInput = default;
            string userIdInput = default;
            string nameInput = default;
            string typeInput = default;
            string statusInput = default;

            List<string> arguments = new List<string>();

            Console.WriteLine("SEARCH MENU\n");
            Console.Write("Account ID : ");
            accountIdInput = Console.ReadLine();

            Console.Write("User ID : ");
            userIdInput = Console.ReadLine();
            
            Console.Write("Holder's Name : ");
            nameInput = Console.ReadLine();
            
            Console.Write("Type (savings/current) : ");
            typeInput = Console.ReadLine();
            
            Console.Write("Balance : ");
            balanceInput = Console.ReadLine();
            
            
            Console.Write("Status : ");
            statusInput = Console.ReadLine();

            if (accountIdInput != "") arguments.Add("AccountNumber");

            if (userIdInput != "") arguments.Add("Login");

            if (nameInput != "") arguments.Add("Name");

            if (typeInput != "") arguments.Add("AccountType");

            if (balanceInput != "") arguments.Add("Balance");

            if (statusInput != "") arguments.Add("AccountStatus");

            List<Customer_BO> list = adminBLL.SearchAccount(accountIdInput,userIdInput,nameInput,typeInput,balanceInput,statusInput,arguments);

            Console.WriteLine("\n==== SEARCH RESULTS ====\n");
            //display users' data in required format
            Console.WriteLine("Account ID \t\t User ID \t\t Holder's Name \t\t Type \t\tBalance \t\tStatus\n");
            foreach (Customer_BO b in list)
            {
                Console.WriteLine($"{b.AccountNumber}\t\t\t{b.Login}\t\t\t{b.Name}\t\t\t{b.AccountType}\t\t\t{b.Balance}\t\t\t{b.AccountStatus}\n");
            }
            Admin_menu();
        }
        public void Update(string accountNum)
        {
            bool exists = false;
            List<string> arguments = new List<string>();
            arguments.Add("AccountNumber");
            List<Customer_BO> accountFound = adminBLL.SearchAccount(accountNum, "", "", "", "", "", arguments);
            if (accountFound.Count == 0) exists = false;
            else
            {
                exists = true;
            }
            if (exists)
            {
                Customer_BO bo = accountFound.First();
            
            Console.WriteLine($"Account # {bo.AccountNumber}");
            Console.WriteLine($"Type : {bo.AccountType}");
            Console.WriteLine($"Holder : {bo.Name}");
            Console.WriteLine($"Balance : {bo.Balance}");
            Console.WriteLine($"Status : {bo.AccountStatus}");

            Console.WriteLine("Please enter in the fields you wish to update (leave blank otherwise) : ");

            Console.Write("Login : ");
            string loginInput = Console.ReadLine();
            Console.Write("Pin code : ");
            string pinInput = Console.ReadLine();
                
            Console.Write("Holder's name : ");
            string nameInput = Console.ReadLine();
            Console.Write("Status : ");
            string statusInput = Console.ReadLine();

                //update in business logic layer
                adminBLL.Update(loginInput,pinInput,nameInput,statusInput,bo.AccountNumber); 
            //if successful
            Console.WriteLine("Your account has been successfully updated");
            }
            else
            {
                Console.WriteLine("No record found");
            }
        }
        public void DeleteAccount(int AccountNo)
        {
            bool deleted = default;
            string name = default;
            Console.Write($"You wish to delete the account held by Mr {name}; If this information is correct please re-enter the account number : ");
            int input = System.Convert.ToInt32(Console.ReadLine());
            if (AccountNo == input)
            {
                //delete function called in business logic layer
                deleted = adminBLL.DeleteAccount(AccountNo);
                if (deleted)
                {
                    Console.WriteLine("Account Deleted Successfully");
                }
                else
                {
                    Console.WriteLine("Account not found");
                }
            }
            else
            {
                Console.WriteLine("Deletion canceled");
            }
            Admin_menu();
        }
        public bool NewAccount()
        {
            string CustomerId = default;
            int CustomerPin = default;
            string CustomerName = default;
            string Type = default;
            string Status = default;
            int CustomerBalance = default;

            bool created = false;
            int accountNo = default;
            Console.Write("Login : ");
            CustomerId = Console.ReadLine();
            Console.Write("Pin Code : ");
            try
            {
                CustomerPin = System.Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                created = false;
            
                return created;
            }
            Console.Write("Holder's name : ");
            CustomerName = Console.ReadLine();
            Console.Write("Type (savings/current) : ");
            Type = Console.ReadLine();
            
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
                    CustomerBalance = System.Convert.ToInt32(Console.ReadLine());
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    created = false;
                    return created;
                }
                Console.WriteLine("Status (active/inactive) : ");
                Status = Console.ReadLine();
                if(!(Status.Equals("active")) && !(Status.Equals("inactive")))
                {
                    Console.WriteLine("Invalid Status entered!");
                    created = false;
                    return created;
                }
                else
                {
                    //create new account
                    accountNo = adminBLL.createNewAccount(CustomerId, CustomerPin, CustomerName, Type, CustomerBalance, Status);
                    
                    Console.WriteLine($"Account Successfully Created - the account number assigned is: {accountNo} ");
                   
                }
               
                
            }
            Admin_menu();
            return created;
        }


    }
}
