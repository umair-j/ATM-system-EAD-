using ATM_BO;
using ATM_DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace ATM_BLL
{
    public class Customer_BLL
    {
        //create a list contains all customer data 
        public static List<Customer_BO> record = new List<Customer_BO>();
        //create data access layer object
        BaseDAL bDAL = new BaseDAL();
        public int CheckLogin(string login, int pin)
        {
            //load customer data from file and put in record list
            record = bDAL.load();
            //default value of account number
            int accNo = -1;
            //check all records for given login and pin
            foreach(Customer_BO bo in record)
            {
                if(bo.Login == login && bo.Pin == pin)
                {
                    accNo = bo.AccountNumber;
                } 
            }
            //return matched account number if there is a matched one else return -1
            return accNo;
        }

        public Customer_BO display(int accountNo)
        {
            Customer_BO boToReturn = new Customer_BO();
            //check if account number is found in record then put that business object in variable and return
            foreach(Customer_BO bo in record)
            {
                if (bo.AccountNumber == accountNo)
                {
                    boToReturn = bo;
                }
            }
            return boToReturn;
        }

        public Customer_BO deposit(int accountNo,int amount)
        {
            Customer_BO boToReturn = new Customer_BO();
            //check if account number is found in record then subtract balance and amount if sufficient balance is present
            foreach (Customer_BO bo in record)
            {
                if(bo.AccountNumber == accountNo)
                {
                    bo.Balance += amount;
                    boToReturn = bo;
                }
            }
            //save record list to file
            bDAL.save(record);
            //return business object 
            return boToReturn;
        }

        public bool Transfer(int accountNo, int receiverAccountNo, int amount)
        {
            bool transfered = false;
            Customer_BO sender = new Customer_BO();
            Customer_BO receiver = new Customer_BO();
            //check if sender is not equal to receiver
            
            foreach(Customer_BO bo in record)
            {
                if (bo.AccountNumber == accountNo)
                {
                    sender = bo;
                }
                if(bo.AccountNumber == receiverAccountNo)
                {
                    receiver = bo;
                }
            }
            if (receiver != sender)
            {
                //then check if balance is sufficient to transfer
                if (sender.Balance >= amount)
                {
                    sender.Balance -= amount;
                    receiver.Balance += amount;
                    transfered = true;
                }
                else
                {
                    transfered = false;
                }
            }
            else
            {
                transfered = false;
            }
            //save data to file
            bDAL.save(record);
            //return bool if amount is transfered or not
            return transfered;
        }

        public Customer_BO Withdraw(int accountNo, int amount)
        {
            bool found = false;
            //load data from file and put in records list
            record = bDAL.load();
            Customer_BO cbo = new Customer_BO();
            //check in record list if account number matches and balance is sufficient
            foreach(Customer_BO bo in record)
            {
                if (accountNo == bo.AccountNumber && amount <= bo.Balance)
                {

                    found = true;
                    bo.Balance -= amount;
                    //save record list in file
                    bDAL.save(record);
                    cbo = bo;
                }
                
            }
            if (!found)
            {
                cbo.AccountNumber = -1;
            }


            //return business object 
            return cbo;
            
        }
    }
}
