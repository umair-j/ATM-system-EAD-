using ATM_BO;
using ATM_DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ATM_BLL
{
    public class Admin_BLL
    {

        public static int TotalAccounts;
        public ArrayList People = new ArrayList();
        public Customer_BO C_bo = new Customer_BO();
        public void NewAccount(string CustomerId, int CustomerPin, int CustomerBalance, string CustomerName, string CustomerStatus, string CustomerAccountType)
        {
            C_bo.AccountNumber = TotalAccounts + 1;
            C_bo.Login = CustomerId;
            C_bo.Pin = CustomerPin;
            C_bo.Balance = CustomerBalance;
            C_bo.Name = CustomerName;
            C_bo.AccountStatus = CustomerStatus;
            C_bo.AccountType = CustomerAccountType;
            Admin_DAL adminDal = new Admin_DAL();
            adminDal.SaveCustomer(C_bo);
            TotalAccounts = TotalAccounts + 1;
        }
        public void Display(string filename)
        {
            
        }

        public void DeleteAccount(string name)
        {
            Admin_DAL adminDal = new Admin_DAL();


            bool found = adminDal.Delete(name);
            if (found!=true)
            {
                Console.WriteLine("Record not found");
            }

            
            

        }

        public void Search(string name)
        {
            
            Admin_DAL adminDal = new Admin_DAL();

            if (adminDal.SearchRecord(name) == null)
            {
                Console.WriteLine("Record not found");
            }

            else
            {
                Console.WriteLine($"name : {adminDal.SearchRecord(name).Name} , ID : {adminDal.SearchRecord(name).Pin}");
            }

        }
        public void exit()
        {
            Console.WriteLine("Exiting");
            
           
            
            //application.exit();
        }
    }
}
