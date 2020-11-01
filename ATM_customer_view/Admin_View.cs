using ATM_BLL;
using ATM_BO;
using ATM_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATM_view
{
    public class Admin_View
    {
        
        //customer business object created
        public Customer_BO C_bo = new Customer_BO();
        //admin business logic layer object created
        Admin_BLL adminBLL = new Admin_BLL();
        //Base Data Access layer object created
        BaseDAL bdal = new BaseDAL();
        public void Admin_menu()
        {
                //Load data from file
                adminBLL.loadrecords();
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
                    //get input from user 
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
                        //take user input
                        Console.Write("Enter the account number to which you want to delete : ");
                        try
                        {
                            string accountNo = Console.ReadLine();
                            //call delete function with user input
                            DeleteAccount(accountNo);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            //go back to admin menu function
                            Admin_menu();
                        }

                        break;
                    case 3:
                        //get user input
                        Console.Write("Enter the account number : ");
                        
                        string accountNum = Console.ReadLine();
                        //call update function with input    
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
                        //save data to file before exiting
                        adminBLL.save();
                        System.Environment.Exit(1);
                        break;
                }
            }
            //return to admin main menu
            Admin_menu();
        }
        public void ViewReports()
        {
            //initialize choice of user by default
            int ch = default;
            
            Console.WriteLine("Enter the type of report");
            Console.WriteLine("1---Accounts by Amount");
            Console.WriteLine("2---Accounts by Date");
            try
            {
                //get input about type of report to get by user
                ch = System.Convert.ToInt32(Console.ReadLine());
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if(ch < 1 || ch > 2)
            {
                //incase of invalid choice tell user
                Console.WriteLine("Please enter a valid option (1 or 2) ");
            }
            else
            {
                if(ch == 1)
                {
                    //call report by amount function
                    ReportByAmount();
                }
                else if(ch == 2)
                {
                    //call report by date function
                    ReportByDate();
                }
            }
        }
        public void ReportByAmount()
        {
            //initialize minimum value with default
            int min = default;
            //initialize maximum value with default
            int max = default;
            Console.Write("Enter the maximum amount : ");
            try
            {
                //get maximum amount input from user
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
                //get minimum amount input from user
                min = System.Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //return to break out of function in case of error
                return;
            }
            //create empty list that will contain customer business objects that match the requirement
            List<Customer_BO> list = new List<Customer_BO>();
            //get required customer business objects from function
            list = adminBLL.ReportByBalance(min, max);
            
            Console.WriteLine("\n==== SEARCH RESULTS ====\n");
            //display users' data in required format
            Console.WriteLine("Account ID \t User ID \t Holder's Name \t Type \t Balance \t Status\n");
            foreach (Customer_BO b in list)
            {
                Console.WriteLine($"{b.AccountNumber}\t\t\t{b.Login}\t\t\t{b.Name}\t\t\t{b.AccountType}\t\t\t{b.Balance}\t\t\t{b.AccountStatus}\n");
            }
            //return to admin main menu
            Admin_menu();
        }
        public void ReportByDate()
        {
            //initialize dates by default in two formats for ease in upcoming operations
            DateTime startDate = default;
            DateTime endDate = default;
            string startDatestr = default;
            string endDatestr = default;
            Console.Write("Enter the starting date : ");
            
            startDatestr = Console.ReadLine();
            try
            {
                //get starting date input from user
                startDate = DateTime.Parse(startDatestr);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
               
            Console.Write("Enter the ending date : ");
            endDatestr = Console.ReadLine();
            try
            {
                //get ending date input from user
                endDate = DateTime.Parse(endDatestr);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //put required customer business objects returned by function in list 
            List<Customer_BO> list = adminBLL.ReportByDate(startDate,endDate);
            
            Console.WriteLine("\n==== SEARCH RESULTS ====\n");
            //display users' data in required format
            Console.WriteLine("Transaction Type \t User ID \t Holder's Name \t Amount \t Date\n");
            foreach (Customer_BO b in list)
            {
                string date = b.datetime.ToString("dd/MM/yyyy");
                Console.WriteLine($"{b.AccountType}\t\t\t{b.Login}\t\t\t{b.Name}\t\t\t{b.Balance}\t\t\t{date}\n");
            }
            //return to admin main menu
            Admin_menu();

        }
        public void Search()
        {
            //initialize input variables with default value
            string balanceInput = default;
            string accountIdInput = default;
            string userIdInput = default;
            string nameInput = default;
            string typeInput = default;
            string statusInput = default;

            //create list of arguments to be sent that will have non empty values
            List<string> arguments = new List<string>();

            //get inputs from user and store in input variables
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

            //add only non empty string values to list i.e if some account number is entered then put "AccountNumber" string in list
            if (accountIdInput != "") arguments.Add("AccountNumber");

            if (userIdInput != "") arguments.Add("Login");

            if (nameInput != "") arguments.Add("Name");

            if (typeInput != "") arguments.Add("AccountType");

            if (balanceInput != "") arguments.Add("Balance");

            if (statusInput != "") arguments.Add("AccountStatus");

            //call search function with input variables and list as argument
            List<Customer_BO> list = adminBLL.SearchAccount(accountIdInput,userIdInput,nameInput,typeInput,balanceInput,statusInput,arguments);

            Console.WriteLine("\n==== SEARCH RESULTS ====\n");
            //display users' data in required format
            Console.WriteLine("Account ID \t\t User ID \t\t Holder's Name \t\t Type \t\tBalance \t\tStatus\n");
            foreach (Customer_BO b in list)
            {
                Console.WriteLine($"{b.AccountNumber}\t\t\t{b.Login}\t\t\t{b.Name}\t\t\t{b.AccountType}\t\t\t{b.Balance}\t\t\t{b.AccountStatus}\n");
            }
            //return to admin main menu
            Admin_menu();
        }

        public void Update(string accountNum)
        {
            //create bool variable to check if accountNumber entered is in record
            bool exists = false;
            //put only "AccountNumber string in list to search only with Account number"
            List<string> arguments = new List<string>();
            arguments.Add("AccountNumber");
            List<Customer_BO> accountFound = adminBLL.SearchAccount(accountNum, "", "", "", "", "", arguments);
            //if nothing in list then make exists bool false
            if (accountFound.Count == 0) exists = false;
            else
            {
                exists = true;
            }
            //if some record is found display its data
            if (exists)
            {
                Customer_BO bo = accountFound.First();
            
            Console.WriteLine($"Account # {bo.AccountNumber}");
            Console.WriteLine($"Type : {bo.AccountType}");
            Console.WriteLine($"Holder : {bo.Name}");
            Console.WriteLine($"Balance : {bo.Balance}");
            Console.WriteLine($"Status : {bo.AccountStatus}");

            Console.WriteLine("Please enter in the fields you wish to update (leave blank otherwise) : ");

            //get input to update from user
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
            //save data to file
            adminBLL.save();
            //return to admin main menu
            Admin_menu();
        }
        public void DeleteAccount(string AccountNo)
        {
            int accNo = default;
            try
            {
                accNo = System.Convert.ToInt32(AccountNo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            bool deleted = default;
            
            //create list of arguments to pass to search function and put only account number in it
            List<string> list = new List<string>();
            list.Add("AccountNumber");
            List<Customer_BO> list2 = new List<Customer_BO>();
            list2 = adminBLL.SearchAccount(AccountNo, "", "", "", "", "", list);
            //if some record is present with this account number
            if (list2.Count != 0)
            {
                Console.Write($"You wish to delete the account held by Mr {list2[0].Name}; If this information is correct please re-enter the account number : ");
                int input = System.Convert.ToInt32(Console.ReadLine());
                //match re-entered acount number with previous one
                if (accNo == input)
                {
                    //delete function called in business logic layer
                    deleted = adminBLL.DeleteAccount(accNo);
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
            }
            else
            {
                Console.WriteLine("Account not found");
            }
            //save data to file
            adminBLL.save();
            //return to admin main menu
            Admin_menu();
        }
        public bool NewAccount()
        {
            //create variables to hold input
            string CustomerId = default;
            int CustomerPin = default;
            string CustomerName = default;
            string Type = default;
            string Status = default;
            int CustomerBalance = default;

            bool created = false;
            int accountNo = default;
            //get data from admin and put in variables
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
            //check if option entered is valid
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
            //save to file
            adminBLL.save();
            //return to admin main menu
            Admin_menu();
            return created;
        }


    }
}
