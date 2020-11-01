
using ATM_BO;
using ATM_DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATM_BLL
{
    
    public class Admin_BLL
    {
        //list will contain all customer data while application is running
        public static List<Customer_BO> record = new List<Customer_BO>();
        BaseDAL bDAL = new BaseDAL();
        public int createNewAccount(string login, int pin, string name, string type, int balance, string status)
        {
            Customer_BO bo = new Customer_BO { Login = login, Pin = pin, Name = name, AccountType = type, Balance = balance, AccountStatus = status };
            int temp = record.Count;
            if (record.Count == 0)
            {
                temp = 1;
            }
            else
            {

                temp = record.Last().AccountNumber + 1;


            }
            bo.AccountNumber = temp;
            record.Add(bo);
            //Console.WriteLine(bo.Name + bo.Login + bo.Balance + bo.AccountNumber);
            return temp;
        }

        public void loadrecords()
        {
            record = bDAL.load();
        }

        public bool DeleteAccount(int AccountNo)
        {
            bool deleted = false;
            foreach (Customer_BO bo in record.ToList())
            {
                if (bo.AccountNumber == AccountNo)
                {

                    try
                    {
                        record.Remove(bo);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error occured " + ex.Message);
                    }
                    Console.WriteLine($"deleted {bo.Name}");
                    deleted = true;
                }
            }
            return deleted;
        }


        public List<Customer_BO> SearchAccount(string accountIdInput, string userIdInput, string nameInput, string typeInput, string balanceInput, string statusInput, List<string> arguments)
        {
            List<Customer_BO> l1 = new List<Customer_BO>();

            List<Customer_BO> l2 = new List<Customer_BO>();
            List<Customer_BO> l3 = new List<Customer_BO>();
            List<Customer_BO> l4 = new List<Customer_BO>();
            List<Customer_BO> l5 = new List<Customer_BO>();
            List<Customer_BO> l6 = new List<Customer_BO>();
            bool accNo = default;
            bool Log = default;
            bool name = default;
            bool type = default;
            bool bal = default;
            bool stat = default;

            for (int i = 0; i < arguments.Count; i++)
            {
                if (arguments[i] == "AccountNumber") accNo = true;
                if (arguments[i] == "Login") Log = true;
                if (arguments[i] == "Balance") bal = true;
                if (arguments[i] == "Name") name = true;
                if (arguments[i] == "AccountType") type = true;
                if (arguments[i] == "AccountStatus") stat = true;
            }
            int accInput = default;
            int balInput = default;
            try
            {
                accInput = System.Convert.ToInt32(accountIdInput);
            }
            catch(Exception ex)
            {
                if (accNo)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            try
            {
                balInput = System.Convert.ToInt32(balanceInput);
            }
            catch(Exception ex)
            {
                if (bal)
                {
                    Console.WriteLine(ex.Message);
                }
            }



            if (accNo)
            {
                foreach (Customer_BO i in record)
                {
                    if (accInput == i.AccountNumber) l1.Add(i);
                }
            }
            else
            {
                l1 = new List<Customer_BO>(record);
            }

            if (Log)
            {
                foreach (Customer_BO i in record)
                {
                    if (userIdInput == i.Login) l2.Add(i);
                }
            }
            else
            {
                l2 = new List<Customer_BO>(record);
            }
            if (name)
            {
                foreach (Customer_BO i in record)
                {
                    if (nameInput == i.Name) l3.Add(i);
                }
            }
            else
            {
                l3 = new List<Customer_BO>(record);
            }
            if (type)
            {
                foreach (Customer_BO i in record)
                {
                    if (typeInput == i.AccountType) l4.Add(i);
                }
            }
            else
            {
                l4 = new List<Customer_BO>(record);
            }
            if (stat)
            {
                foreach (Customer_BO i in record)
                {
                    if (statusInput == i.AccountStatus) l5.Add(i);
                }
            }
            else
            {
                l5 = new List<Customer_BO>(record);
            }
            if (bal)
            {
                foreach (Customer_BO i in record)
                {
                    if (balInput == i.Balance) l6.Add(i);
                }
            }
            else
            {
                l6 = new List<Customer_BO>(record);
            }
            List<Customer_BO> finalList = new List<Customer_BO>();
            finalList = l1.Intersect(l2).Intersect(l3).Intersect(l4).Intersect(l5).Intersect(l6).ToList();


            return finalList;
        }

        public void save()
        {
            bDAL.save(record);
        }

        public void Update(string login, string pin, string name, string status, int accNum)
        {
            int pin1 = default;
            if (pin != "")
            {
                try
                {
                    pin1 = System.Convert.ToInt32(pin);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            foreach (Customer_BO bo in record)
            {
                if (accNum == bo.AccountNumber)
                {
                    if (login != "") bo.Login = login;
                    if (pin != "")
                    {

                        bo.Pin = pin1;
                    }
                    if (name != "") bo.Name = name;
                    if (status != "") bo.AccountStatus = status;

                }
            }
            
            
        }

        public List<Customer_BO> ReportByDate(DateTime startDate, DateTime endDate)
        {
            List<Customer_BO> list = new List<Customer_BO>();
            foreach(Customer_BO bo in record)
            {
                if(bo.datetime>=startDate && bo.datetime <= endDate)
                {
                    list.Add(bo);
                }
            }
            return list;
        }

        public List<Customer_BO> ReportByBalance(int min,int max)
        {
            List<Customer_BO> list = new List<Customer_BO>();
            foreach(Customer_BO bo in record)
            {
                if(bo.Balance>=min && bo.Balance <= max)
                {
                    list.Add(bo);
                }
            }
            return list;
        }
    }

}