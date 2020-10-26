﻿using ATM_BLL;
using ATM_BO;
using Microsoft.VisualBasic.FileIO;
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
                    Console.Write("Enter the account number to which you want to delete : ");
                    try
                    {
                        int accountNo = System.Convert.ToInt32(Console.ReadLine());
                        DeleteAccount(accountNo);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                        
                    break;
                case 3:
                    //call update account information function
                    Console.Write("Enter the account number : ");
                    try
                    {
                        int accountNo = System.Convert.ToInt32(Console.ReadLine());
                        Update(accountNo);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case 4:
                    //call search account function
                    Search();
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
        public void Search()
        {
            Console.WriteLine("SEARCH MENU\n");
            Console.Write("Account ID : ");
            string accountIdInput = Console.ReadLine();
            Console.Write("User ID : ");
            string userIdInput = Console.ReadLine();
            Console.Write("Holder's Name : ");
            string nameInput = Console.ReadLine();
            Console.Write("Type (savings/current) : ");
            string typeInput = Console.ReadLine();
            Console.Write("Balance : ");
            string balanceInput = Console.ReadLine();
            Console.Write("Status : ");
            string statusInput = Console.ReadLine();

            Console.WriteLine("\n==== SEARCH RESULTS ====\n");
            //display users' data in required format
        }
        public void Update(int accountNo)
        {
            string type = default;
            string holder = default;
            string balance = default;
            string status = default;
            Console.WriteLine($"Account # {accountNo}");
            Console.WriteLine($"Type : {type}");
            Console.WriteLine($"Holder : {holder}");
            Console.WriteLine($"Balance : {balance}");
            Console.WriteLine($"Status : {status}");

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

            //if successful
            Console.WriteLine("Your account has been successfully updated");
        }
        public void DeleteAccount(int AccountNo)
        {
            string name = default;
            Console.Write($"You wish to delete the account held by Mr {name}; If this information is correct please re-enter the account number : ");
            int input = System.Convert.ToInt32(Console.ReadLine());
            if(AccountNo == input){
                //delete function called in business logic layer
                Console.WriteLine("Account Deleted Successfully");
            }
            else
            {
                Console.WriteLine("Deletion canceled");
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
