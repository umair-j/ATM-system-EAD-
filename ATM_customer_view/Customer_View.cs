using ATM_BO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM_view
{
    public class Customer_View
    {
        public void MainMenu()
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
                    Transfer();
                    break;
                case 3:
                    //Deposit function call
                    Deposit();
                    break;
                case 4:
                    //Display function call
                    Display();
                    break;
                case 5:
                    //Exit function call
                    break;
                default:
                    Console.WriteLine("Please enter a valid option");
                    break;
            }
        }
        public void Display()
        {
            int accountNo = default;
            int balance = default;
            Console.WriteLine($"Account number : {accountNo}");
            Console.WriteLine($"Balance : {balance}");
        }
        public void Deposit()
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
                //deposit
                Console.WriteLine("Cash deposited sucessfully");
                Console.Write("do you wish to print a receipt (Y/N) ? : ");
                string confirm = Console.ReadLine();
                if (confirm == "Y")
                {


                    //Display account number
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

        }
        public void Transfer()
        {
            int accountNo = default;
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
                    accountNo = System.Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.Write($"You wish to deposit Rs {amount} in account held by Mr. {name} ; If this information is correct then please re-enter the account number: ");
                try
                {
                    accountNoRe = System.Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                if (accountNo == accountNoRe)
                {
                    //call transaction function
                    transferred = true;
                }
                if (transferred)
                {
                    Console.WriteLine("Transaction confirmed");
                }
                Console.Write("do you wish to print a receipt (Y/N) ? : ");
                string confirm = Console.ReadLine();
                if (confirm == "Y")
                {


                    //Display account number
                    //Display Transferred:amount
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
