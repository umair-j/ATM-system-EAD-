using ATM_BO;
using ATM_DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM_BLL
{
    public class Admin_BLL
    {
        public Customer_BO C_bo = new Customer_BO();
        public void NewAccount(string CustomerId, int CustomerPin, int CustomerBalance, string CustomerName, string CustomerStatus, string CustomerAccountType)
        {

            C_bo.Login = CustomerId;
            C_bo.Pin = CustomerPin;
            C_bo.Balance = CustomerBalance;
            C_bo.Name = CustomerName;
            C_bo.AccountStatus = CustomerStatus;
            C_bo.AccountType = CustomerAccountType;
            Admin_DAL adminDll = new Admin_DAL();
            adminDll.SaveCustomer(C_bo);
        }

        public void DeleteAccount(string accId)
        {

            //find id in file
            //If found
            Console.WriteLine("You wish to delete the account held by (found person)\nIf this information is correct please re-enter the account number:");
            if (accId != Console.ReadLine())
            {
                Console.WriteLine("Different ID entered, Account will not be deleted");
            }
            else
            {
                //delete 
            }

        }
    }
}
