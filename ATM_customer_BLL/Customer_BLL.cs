using ATM_BO;
using ATM_DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM_BLL
{
    public class Customer_BLL
    {
        public static List<Customer_BO> record = new List<Customer_BO>();
        BaseDAL bDAL = new BaseDAL();
        public int CheckLogin(string login, int pin)
        {
            record = bDAL.load();
            //default value 
            int accNo = -1;
            foreach(Customer_BO bo in record)
            {
                if(bo.Login == login && bo.Pin == pin)
                {
                    accNo = bo.AccountNumber;
                } 
            }
            return accNo;
        }

        public Customer_BO display(int accountNo)
        {
            Customer_BO boToReturn = new Customer_BO();
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
            foreach(Customer_BO bo in record)
            {
                if(bo.AccountNumber == accountNo)
                {
                    bo.Balance += amount;
                    boToReturn = bo;
                }
            }
            bDAL.save(record);
            return boToReturn;
        }
    }
}
