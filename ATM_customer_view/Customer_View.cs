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
                    //withdraw function call

                    break;
                case 2:
                    //Transfer function call
                    break;
                case 3:
                    //Deposit function call
                    break;
                case 4:
                    //Display function call
                    break;
                case 5:
                    //Exit function call
                    break;
                default:
                    Console.WriteLine("Please enter a valid option");
                    break;
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
                    Console.WriteLine("Withdrawing canceled");
                }
                else
                {
                    Console.WriteLine("Please enter a valid option");
                }
            }
        }
        public void NormalCash()
        {

        }
    }
}
