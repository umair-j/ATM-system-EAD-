using ATM_BLL;
using ATM_BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATM_view
{
    public class Customer_View
    {
        public static bool allow = false;
        Customer_BLL cBLL = new Customer_BLL();
        public void CheckLogin()
        {
            int tries = 0;
            int accountNumber = default;
            string login = default;
            int pin = default;
            Console.Write("Enter Login : ");
            login = Console.ReadLine();
            Console.Write("Enter Pin : ");
            try
            {
                pin = System.Convert.ToInt32(Console.ReadLine());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            accountNumber = cBLL.CheckLogin(login, pin);
            if (accountNumber == -1)
            {
                tries++;
                Console.WriteLine("Login failed!\nTry again");

            }
            else {
                MainMenu(accountNumber);
            }
        }
        public void MainMenu(int accountNumber)
        {
            

                int option = default;
                Console.WriteLine("1----Withdraw Cash\n2----Cash Transfer\n3----Deposit Cash\n4----Display Balance\n5----Exit");
                Console.WriteLine("Please select one of the above options:");
                try
                {
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
                                //fast cash
                                FastCash();
                                break;
                            case "b":
                                //normal cash
                                NormalCash();
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
            Customer_BO bo = new Customer_BO();
            bo = cBLL.display(accountNo);
            Console.Write($"Account # {bo.AccountNumber}");
            string date = bo.datetime.ToString("dd/MM/yyyy");
            Console.WriteLine("\n");
            Console.Write(date);
            Console.WriteLine("\n");

            Console.Write($"Balance : {bo.Balance}\n");
            MainMenu(accountNo);
        }
        public void Deposit(int accountNo)
        {
            int amount = default;
            Console.Write("Enter the cash amount to deposit : ");
            try
            {
                amount = System.Convert.ToInt32(Console.ReadLine());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if(amount < 1)
            {
                Console.WriteLine("Enter a valid amount");
            }
            else
            {
                Customer_BO bo = new Customer_BO();
                bo = cBLL.deposit(accountNo,amount);
                //deposit
                Console.WriteLine("Cash deposited sucessfully");
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
            MainMenu(accountNo);
        }
        public void Transfer(int accountNo)
        {
            string recAccountNo = default;
            int recieverAccountNo = default;
            int accountNoRe = default;
            int amount = default;
            string name = default;
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
                List<Customer_BO> found = new List<Customer_BO>();
                List<string> list = new List<string>();
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
            MainMenu(accountNo);
        }
        public void FastCash()
        {
            int ch = default;
            int amount = default;
            Console.WriteLine("1----500\n2----1000\n3----2000\n4----5000\n5----10000\n6----15000\n7----20000");
            Console.Write("Select one of the denominations of money: ");
            
            try
            {
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
                Console.Write($"Are you sure you want to withdraw Rs.{amount} (Y/N)?");
                string confirm = Console.ReadLine();
                if(confirm == "Y")
                {
                    //carry out withdrawl
                    //Cash successfully withdrawn if there is money present
                    //Display account number
                    //Display Withdrawn:amount
                    //Display balance

                }
                else if(confirm == "N")
                {
                    Console.WriteLine("Withdrawal canceled");
                }
                else
                {
                    Console.WriteLine("Please enter a valid option");
                }
            }
        }
        public void NormalCash()
        {
            bool withdrawal = false;
            Console.Write("Enter the withdrawal amount : ");
            //call withdrawnormalcash method
            //display cash successfully withdrawn
            withdrawal = true;
            if (withdrawal)
            {
                Console.WriteLine("Cash successfully withdrawn!");
                Console.Write("do you wish to print a receipt (Y/N) ? : ");
                string confirm = Console.ReadLine();
                if (confirm == "Y")
                {
                    //carry out withdrawl
                    //Cash successfully withdrawn if there is money present
                    //Display account number
                    //Display Withdrawn:amount
                    //Display balance

                }
                else if (confirm == "N")
                {
                    Console.WriteLine("Withdrawal canceled");
                }
                else
                {
                    Console.WriteLine("Please enter a valid option");
                }
            }

        }
    }
}
