using ATM_BLL;
using ATM_BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ATM_view
{
    public class Customer_View
    {
        public static int tries = 0;
        //bool to check if user is authurized
        public static bool allow = false;
        //cystomer business logic layer object created
        Customer_BLL cBLL = new Customer_BLL();
        public void CheckLogin()
        {


            int accountNumber = default;
            string login = default;
            int pin = default;
            //get input from user
            Console.Write("Enter Login : ");
            login = Console.ReadLine();
            Console.Write("Enter Pin : ");
            try
            {
                pin = System.Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //check if login info is correct
            accountNumber = cBLL.CheckLogin(login, pin);
            if (accountNumber == -1)
            {
                //if not then increment tries
                tries++;
                Console.WriteLine("Login failed!\nTry again");

            }
            else
            {
                //if login info is correct then let user go to menu
                MainMenu(accountNumber);
            }

        }
            
        public void MainMenu(int accountNumber)
        {
            
                //create variable to store option of operation user wants to perform 
                int option = default;
                Console.WriteLine("1----Withdraw Cash\n2----Cash Transfer\n3----Deposit Cash\n4----Display Balance\n5----Exit");
                Console.WriteLine("Please select one of the above options:");
                try
                {
                    //get option input from user
                    option = System.Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                switch (option)
                {
                    case 1:
                        Console.WriteLine("a)Fast Cash\nb)Normal Cash");
                        Console.Write("Please select a mode of withdrawal:");
                        string ch = Console.ReadLine();
                        switch (ch)
                        {
                            case "a":
                                //go to fast cash function
                                FastCash(accountNumber);
                                break;
                            case "b":
                                //go to normal cash function
                                NormalCash(accountNumber);
                                break;
                            default:
                                Console.WriteLine("Please enter a valid option        (**Either a or b)");
                                break;
                        }


                        break;
                    case 2:
                        //Transfer function call
                        Transfer(accountNumber);
                        break;
                    case 3:
                        //Deposit function call
                        Deposit(accountNumber);
                        break;
                    case 4:
                        //Display function call
                        Display(accountNumber);
                        break;
                    case 5:
                        //Exit function call
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option");
                        break;
                }
            
        }
        public void Display(int accountNo)
        {
            //create customer business object
            Customer_BO bo = new Customer_BO();
            //call display function in business logic layer and return value to business object bo
            bo = cBLL.display(accountNo);
            //display the details
            Console.Write($"Account # {bo.AccountNumber}");
            string date = bo.datetime.ToString("dd/MM/yyyy");
            Console.WriteLine("\n");
            Console.Write(date);
            Console.WriteLine("\n");

            Console.Write($"Balance : {bo.Balance}\n");
            //return to main menu
            MainMenu(accountNo);
        }
        public void Deposit(int accountNo)
        {

            int amount = default;
            Console.Write("Enter the cash amount to deposit : ");
            try
            {
                //get amount input from user
                amount = System.Convert.ToInt32(Console.ReadLine());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //if amount is a negative value or zero the display error message
            if(amount < 1)
            {
                Console.WriteLine("Enter a valid amount");
            }
            else
            {
                //create customer business object bo 
                Customer_BO bo = new Customer_BO();
                //call deposit function and return the value to bo
                bo = cBLL.deposit(accountNo,amount);
                

                Console.WriteLine("Cash deposited sucessfully");
                //ask if user wants to print reciept
                Console.Write("do you wish to print a receipt (Y/N) ? : ");
                string confirm = Console.ReadLine();
                if (confirm == "Y")
                {
                    Console.WriteLine("\n");

                    //Display account number
                    Console.Write($"Account # {bo.AccountNumber}");
                    string date = bo.datetime.ToString("dd/MM/yyyy");
                    Console.WriteLine("\n");
                    Console.Write(date);
                    Console.WriteLine("\n");
                    Console.WriteLine($"Depostited : {amount }");
                    Console.Write($"Balance : {bo.Balance}\n");
                    //Display Deposited amount:amount
                    //Display balance

                }
                else if (confirm == "N")
                {
                    Console.WriteLine("Receipt will not be printed!");
                }
                else
                {
                    Console.WriteLine("No valid option chosen");
                }
            }
            //return to main menu
            MainMenu(accountNo);
        }
        public void Transfer(int accountNo)
        {
            //create variables for values to get user input in 
            string recAccountNo = default;
            int recieverAccountNo = default;
            int accountNoRe = default;
            int amount = default;
            
            bool transferred = false;
            Console.Write("Enter amount in multiples of 500 : ");
            try
            {
                amount = System.Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (amount % 500 != 0)
            {
                Console.WriteLine("Please make sure to enter the amount in MULTIPLES OF 500!");
            }
            else
            {
                Console.Write("Enter the account number to which you want to transfer : ");
                try
                {
                    recAccountNo = Console.ReadLine();
                    recieverAccountNo = System.Convert.ToInt32(recAccountNo);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                //create a list to hold customer business objects
                List<Customer_BO> found = new List<Customer_BO>();
                //create a list to hold arguments to pass to search function
                List<string> list = new List<string>();
                //add only accountnumber so it can search based on only that
                list.Add("AccountNumber");
                Admin_BLL adminBLL = new Admin_BLL();
                found = adminBLL.SearchAccount(recAccountNo, "", "", "", "", "",list);
                if (found.Count != 0)
                {
                    Customer_BO recieverObj = found.First();
                    Console.Write($"You wish to deposit Rs {amount} in account held by Mr. {recieverObj.Name} ; If this information is correct then please re-enter the account number: ");
                    try
                    {
                        accountNoRe = System.Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    if (recieverAccountNo == accountNoRe)
                    {
                        //call transaction function
                        transferred = cBLL.Transfer(accountNo, recieverAccountNo, amount);

                    }
                    if (transferred)
                    {
                        Console.WriteLine("Transaction confirmed");

                        Console.Write("do you wish to print a receipt (Y/N) ? : ");
                        string confirm = Console.ReadLine();
                        if (confirm == "Y")
                        {
                            List<Customer_BO> senderlist = new List<Customer_BO>();
                            List<string> listTemp = new List<string>();
                            listTemp.Add("AccountNumber");

                            senderlist = adminBLL.SearchAccount(accountNo.ToString(), "", "", "", "", "", listTemp);
                            Customer_BO sender = senderlist.First();

                            Console.WriteLine("\n");

                            //Display account number
                            Console.Write($"Account # {sender.AccountNumber}");
                            string date = sender.datetime.ToString("dd/MM/yyyy");
                            Console.WriteLine("\n");
                            Console.Write(date);
                            Console.WriteLine("\n");
                            Console.WriteLine($"Depostited : {amount }");
                            Console.Write($"Balance : {sender.Balance}\n");
                            //Display Deposited amount:amount
                            //Display balance

                        }
                        else if (confirm == "N")
                        {
                            Console.WriteLine("Receipt will not be printed!");
                        }
                        else
                        {
                            Console.WriteLine("No valid option chosen");
                        }



                    }


                    else if (transferred == false)
                    {
                        Console.WriteLine("Transfer failed");
                    }
                }
                else
                {
                    Console.WriteLine("No record found");
                }
            }
            //return to main menu
            MainMenu(accountNo);
        }
        public void FastCash(int accountNo)
        {
            int ch = default;
            int amount = default;
            Console.WriteLine("1----500\n2----1000\n3----2000\n4----5000\n5----10000\n6----15000\n7----20000");
            Console.Write("Select one of the denominations of money: ");
            
            try
            {
                //get input from user
                ch = System.Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if(ch < 1 || ch > 7)
            {
                Console.WriteLine("Please enter a valid option");
            }
            else
            {
                //check input and assign amount variable appropriate value
                switch (ch)
                {
                    case 1:
                        amount = 500;
                        break;
                    case 2:
                        amount = 1000;
                        break;
                    case 3:
                        amount = 2000;
                        break;
                    case 4:
                        amount = 5000;
                        break;
                    case 5:
                        amount = 10000;
                        break;
                    case 6:
                        amount = 15000;
                        break;
                    case 7:
                        amount = 20000;
                        break;
                }
                string choice = default;
                Console.Write($"Are you sure you want to withdraw Rs.{amount} (Y/N)?");
                string confirm = Console.ReadLine();
                if(confirm == "Y")
                {
                    //call withdraw function in business logic layer and return value to "bo" customer business object
                    Customer_BO bo = cBLL.Withdraw(accountNo, amount);
                    if (bo.AccountNumber!=-1)
                    {
                        Console.WriteLine("Cash successfully withdrawn!");
                        Console.Write("do you wish to print a receipt (Y/N) ? : ");
                        choice = Console.ReadLine();
                        if (choice == "Y")
                        {
                            Console.WriteLine("\n");

                            //Display account number
                            Console.Write($"Account # {accountNo}");
                            string date = bo.datetime.ToString("dd/MM/yyyy");
                            Console.WriteLine("\n");
                            Console.Write(date);
                            Console.WriteLine("\n");
                            Console.WriteLine($"Withdrawn : {amount }");
                            Console.Write($"Balance : {bo.Balance}\n");
                            

                        }
                        else if (choice == "N")
                        {
                            Console.WriteLine("Receipt will not be printed!");
                        }
                        else
                        {
                            Console.WriteLine("No valid option chosen");
                        }
                    }
                    else
                    {
                        
                        Console.WriteLine("Withdrawal failed");
                    }

                }
                else if(choice == "N")
                {
                    Console.WriteLine("Withdrawal canceled");
                }
                else
                {
                    Console.WriteLine("Please enter a valid option");
                }
            }
            MainMenu(accountNo);
        }
        public void NormalCash(int accountNo)
        {
            
            int amount = default;
            
            Console.Write("Enter the withdrawal amount : ");

            try
            {
                //get user input and assign to amount
                amount = System.Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (amount < 1)
            {
                Console.WriteLine("Invalid amount entered");
            }
            else
            {
                string choice = default;
                Console.Write($"Are you sure you want to withdraw Rs.{amount} (Y/N)?");
                string confirm = Console.ReadLine();
                if (confirm == "Y")
                {
                    //call withdraw function with amount
                    Customer_BO bo = cBLL.Withdraw(accountNo, amount);
                    if (bo.AccountNumber != -1)
                    {
                        Console.WriteLine("Cash successfully withdrawn!");
                        Console.Write("do you wish to print a receipt (Y/N) ? : ");
                        choice = Console.ReadLine();
                        if (choice == "Y")
                        {
                            Console.WriteLine("\n");

                            //Display account number
                            Console.Write($"Account # {accountNo}");
                            string date = bo.datetime.ToString("dd/MM/yyyy");
                            Console.WriteLine("\n");
                            Console.Write(date);
                            Console.WriteLine("\n");
                            Console.WriteLine($"Withdrawn : {amount }");
                            Console.Write($"Balance : {bo.Balance}\n");


                        }
                        else if (choice == "N")
                        {
                            Console.WriteLine("Receipt will not be printed!");
                        }
                        else
                        {
                            Console.WriteLine("No valid option chosen");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Withdrawal failed");
                    }

                }
                else if (choice == "N")
                {
                    Console.WriteLine("Withdrawal canceled");
                }
                else
                {
                    Console.WriteLine("Please enter a valid option");
                }
            }
            //return to main menu
            MainMenu(accountNo);
        }
    }
}
