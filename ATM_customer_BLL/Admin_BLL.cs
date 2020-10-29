
using ATM_BO;
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
            Console.WriteLine(bo.Name + bo.Login + bo.Balance + bo.AccountNumber);
            return temp;
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


        public void SearchAccount(string accountIdInput, string userIdInput, string nameInput, string typeInput, string balanceInput, string statusInput)
        {


            /*

            int accountIdInput1 = default;
            int balanceInput1 = default;
            if (accountIdInput == "")
            {
                accountIdInput1 = -1;
            }
            else
            {
                accountIdInput1 = System.Convert.ToInt32(accountIdInput);
            }
            if (balanceInput == "")
            {
                balanceInput1 = -1;
            }
            else
            {
                balanceInput1 = System.Convert.ToInt32(balanceInput);
            }

            if (accountIdInput1 != -1)
            {
                if(userIdInput == "")
                {

                    if(nameInput == "")
                    {
                        if (typeInput == "")
                        {
                            if (balanceInput1 == -1)
                            {
                                if (statusInput == "")
                                {

                                }
                                else
                                {

                                }
                            }
                            else
                            {

                            }
                        }
                        else
                        {

                        }
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }
            else
            {

            }


            */








            int accountIdInput1 = default;
            int balanceInput1 = default;
            if (accountIdInput == "")
            {
                accountIdInput1 = -1;
            }
            else
            {
                accountIdInput1 = System.Convert.ToInt32(accountIdInput);
            }
            if (balanceInput == "")
            {
                balanceInput1 = -1;
            }
            else
            {
                balanceInput1 = System.Convert.ToInt32(balanceInput);
            }
            if (accountIdInput1 == -1) {
                if (userIdInput == "")
                {
                    if (nameInput == "")
                    {
                        if (typeInput == "")
                        {
                            if (balanceInput1 == -1)
                            {
                                if (statusInput == "")
                                {
                                    Console.WriteLine("No record found!");
                                }
                                else
                                {
                                    var item = record.FirstOrDefault(bo => bo.AccountStatus == statusInput);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("not found");
                                    }
                                }
                            }
                            else
                            {
                                if (statusInput == "")
                                {
                                    var item = record.FirstOrDefault(bo => bo.Balance == balanceInput1);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("not found");
                                    }
                                }
                                else
                                {
                                    var item = record.FirstOrDefault(bo => bo.AccountStatus == statusInput && bo.Balance == balanceInput1);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("not found");
                                    }
                                }
                            }

                        }
                        else
                        {
                            if (balanceInput1 == -1)
                            {
                                if (statusInput == "")
                                {
                                    var item = record.FirstOrDefault(bo => bo.AccountType == typeInput);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("not found");
                                    }
                                }
                                else
                                {
                                    var item = record.FirstOrDefault(bo => bo.AccountStatus == statusInput && bo.AccountType == typeInput);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("not found");
                                    }
                                }
                            }
                            else
                            {
                                if (statusInput == "")
                                {
                                    var item = record.FirstOrDefault(bo => bo.Balance == balanceInput1 && bo.AccountType == typeInput);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("not found");
                                    }
                                }
                                else
                                {
                                    var item = record.FirstOrDefault(bo => bo.AccountStatus == statusInput && bo.Balance == balanceInput1 && bo.AccountType == typeInput);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("not found");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (typeInput == "")
                        {
                            if (balanceInput1 == -1)
                            {
                                if (statusInput == "")
                                {
                                    var item = record.FirstOrDefault(bo => bo.Name == nameInput);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("not found");
                                    }
                                }
                                else
                                {
                                    var item = record.FirstOrDefault(bo => bo.AccountStatus == statusInput && bo.Name == nameInput);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("not found");
                                    }
                                }
                            }
                            else
                            {
                                if (statusInput == "")
                                {
                                    var item = record.FirstOrDefault(bo => bo.Balance == balanceInput1 && bo.Name == nameInput);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        item = record.FirstOrDefault(bo => bo.Name == nameInput);
                                        if (item != null)
                                        {
                                            Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("not found");
                                        }
                                    }
                                }
                                else
                                {
                                    var item = record.FirstOrDefault(bo => bo.AccountStatus == statusInput && bo.Balance == balanceInput1 && bo.Name == nameInput);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        item = record.FirstOrDefault(bo => bo.Name == nameInput);
                                        if (item != null)
                                        {
                                            Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("not found");
                                        }
                                    }
                                }
                            }

                        }
                        else
                        {
                            if (balanceInput1 == -1)
                            {
                                if (statusInput == "")
                                {
                                    Console.WriteLine("No record found!");
                                }
                                else
                                {
                                    var item = record.FirstOrDefault(bo => bo.AccountStatus == statusInput && bo.AccountType == typeInput && bo.Name == nameInput);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        item = record.FirstOrDefault(bo => bo.Name == nameInput);
                                        if (item != null)
                                        {
                                            Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("not found");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (statusInput == "")
                                {
                                    var item = record.FirstOrDefault(bo => bo.Balance == balanceInput1 && bo.AccountType == typeInput && bo.Name == nameInput);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        item = record.FirstOrDefault(bo => bo.Name == nameInput);
                                        if (item != null)
                                        {
                                            Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("not found");
                                        }
                                    }
                                }
                                else
                                {
                                    var item = record.FirstOrDefault(bo => bo.AccountStatus == statusInput && bo.Balance == balanceInput1 && bo.AccountType == typeInput && bo.Name == nameInput);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("not found");
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (nameInput == "")
                    {
                        if (typeInput == "")
                        {
                            if (balanceInput1 == -1)
                            {
                                if (statusInput == "")
                                {
                                    var item = record.FirstOrDefault(bo => bo.Login == userIdInput);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("not found");
                                    }
                                }
                                else
                                {
                                    var item = record.FirstOrDefault(bo => bo.AccountStatus == statusInput && bo.Login == userIdInput);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        item = record.FirstOrDefault(bo => bo.Login == userIdInput);
                                        if (item != null)
                                        {
                                            Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("not found");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (statusInput == "")
                                {
                                    var item = record.FirstOrDefault(bo => bo.Balance == balanceInput1 && bo.Login == userIdInput);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        item = record.FirstOrDefault(bo => bo.Login == userIdInput);
                                        if (item != null)
                                        {
                                            Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("not found");
                                        }
                                    }
                                }
                                else
                                {
                                    var item = record.FirstOrDefault(bo => bo.AccountStatus == statusInput && bo.Balance == balanceInput1 && bo.Login == userIdInput);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        item = record.FirstOrDefault(bo => bo.Login == userIdInput);
                                        if (item != null)
                                        {
                                            Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("not found");
                                        }
                                    }
                                }
                            }

                        }
                        else
                        {
                            if (balanceInput1 == -1)
                            {
                                if (statusInput == "")
                                {
                                    Console.WriteLine("No record found!");
                                }
                                else
                                {
                                    var item = record.FirstOrDefault(bo => bo.AccountStatus == statusInput && bo.AccountType == typeInput && bo.Login == userIdInput);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        item = record.FirstOrDefault(bo => bo.Login == userIdInput);
                                        if (item != null)
                                        {
                                            Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("not found");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (statusInput == "")
                                {
                                    var item = record.FirstOrDefault(bo => bo.Balance == balanceInput1 && bo.AccountType == typeInput && bo.Login == userIdInput);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        item = record.FirstOrDefault(bo => bo.Login == userIdInput);
                                        if (item != null)
                                        {
                                            Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("not found");
                                        }
                                    }
                                }
                                else
                                {
                                    var item = record.FirstOrDefault(bo => bo.AccountStatus == statusInput && bo.Balance == balanceInput1 && bo.AccountType == typeInput && bo.Login == userIdInput);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        item = record.FirstOrDefault(bo => bo.Login == userIdInput);
                                        if (item != null)
                                        {
                                            Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("not found");
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (typeInput == "")
                        {
                            if (balanceInput1 == -1)
                            {
                                if (statusInput == "")
                                {
                                    var item = record.FirstOrDefault(bo => bo.Login == userIdInput);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("not found");
                                    }
                                }
                                else
                                {
                                    var item = record.FirstOrDefault(bo => bo.AccountStatus == statusInput && bo.Name == nameInput && bo.Name == nameInput && bo.Login == userIdInput);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("not found");
                                    }
                                }
                            }
                            else
                            {
                                if (statusInput == "")
                                {
                                    var item = record.FirstOrDefault(bo => bo.Balance == balanceInput1 && bo.Name == nameInput && bo.Name == nameInput && bo.Login == userIdInput);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        item = record.FirstOrDefault(bo => bo.Login == userIdInput);
                                        if (item != null)
                                        {
                                            Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("not found");
                                        }
                                    }
                                }
                                else
                                {
                                    var item = record.FirstOrDefault(bo => bo.AccountStatus == statusInput && bo.Balance == balanceInput1 && bo.Name == nameInput && bo.Name == nameInput && bo.Login == userIdInput);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        item = record.FirstOrDefault(bo => bo.Login == userIdInput);
                                        if (item != null)
                                        {
                                            Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("not found");
                                        }
                                    }
                                }
                            }

                        }
                        else
                        {
                            if (balanceInput1 == -1)
                            {
                                if (statusInput == "")
                                {
                                    Console.WriteLine("No record found!");
                                }
                                else
                                {
                                    var item = record.FirstOrDefault(bo => bo.AccountStatus == statusInput && bo.AccountType == typeInput && bo.Name == nameInput && bo.Name == nameInput && bo.Login == userIdInput);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        item = record.FirstOrDefault(bo => bo.Login == userIdInput);
                                        if (item != null)
                                        {
                                            Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("not found");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (statusInput == "")
                                {
                                    var item = record.FirstOrDefault(bo => bo.Balance == balanceInput1 && bo.AccountType == typeInput && bo.Name == nameInput && bo.Name == nameInput && bo.Login == userIdInput);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        item = record.FirstOrDefault(bo => bo.Login == userIdInput);
                                        if (item != null)
                                        {
                                            Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("not found");
                                        }
                                    }
                                }
                                else
                                {
                                    var item = record.FirstOrDefault(bo => bo.AccountStatus == statusInput && bo.Balance == balanceInput1 && bo.AccountType == typeInput && bo.Name == nameInput && bo.Login == userIdInput);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        item = record.FirstOrDefault(bo => bo.Login == userIdInput);
                                        if (item != null)
                                        {
                                            Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("not found");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (userIdInput == "")
                {
                    if (nameInput == "")
                    {
                        if (typeInput == "")
                        {
                            if (balanceInput1 == -1)
                            {
                                if (statusInput == "")
                                {
                                    var item = record.FirstOrDefault(bo => bo.AccountNumber == accountIdInput1);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("not found");
                                    }
                                }
                                else
                                {
                                    var item = record.FirstOrDefault(bo => bo.AccountStatus == statusInput && bo.AccountNumber == accountIdInput1);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        item = record.FirstOrDefault(bo => bo.AccountNumber == accountIdInput1);
                                        if (item != null)
                                        {
                                            Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("not found");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (statusInput == "")
                                {
                                    var item = record.FirstOrDefault(bo => bo.Balance == balanceInput1 && bo.AccountNumber == accountIdInput1);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        item = record.FirstOrDefault(bo => bo.AccountNumber == accountIdInput1);
                                        if (item != null)
                                        {
                                            Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("not found");
                                        }
                                    }
                                }
                                else
                                {
                                    var item = record.FirstOrDefault(bo => bo.AccountStatus == statusInput && bo.Balance == balanceInput1 && bo.AccountNumber == accountIdInput1);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        item = record.FirstOrDefault(bo => bo.AccountNumber == accountIdInput1);
                                        if (item != null)
                                        {
                                            Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("not found");
                                        }
                                    }
                                }
                            }

                        }
                        else
                        {
                            if (balanceInput1 == -1)
                            {
                                if (statusInput == "")
                                {
                                    var item = record.FirstOrDefault(bo => bo.AccountType == typeInput && bo.AccountNumber == accountIdInput1);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        item = record.FirstOrDefault(bo => bo.AccountNumber == accountIdInput1);
                                        if (item != null)
                                        {
                                            Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("not found");
                                        }
                                    }
                                }
                                else
                                {
                                    var item = record.FirstOrDefault(bo => bo.AccountStatus == statusInput && bo.AccountType == typeInput && bo.AccountNumber == accountIdInput1);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        item = record.FirstOrDefault(bo => bo.AccountNumber == accountIdInput1);
                                        if (item != null)
                                        {
                                            Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("not found");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (statusInput == "")
                                {
                                    var item = record.FirstOrDefault(bo => bo.Balance == balanceInput1 && bo.AccountType == typeInput && bo.AccountNumber == accountIdInput1);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        item = record.FirstOrDefault(bo => bo.AccountNumber == accountIdInput1);
                                        if (item != null)
                                        {
                                            Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("not found");
                                        }
                                    }
                                }
                                else
                                {
                                    var item = record.FirstOrDefault(bo => bo.AccountStatus == statusInput && bo.Balance == balanceInput1 && bo.AccountType == typeInput && bo.AccountNumber == accountIdInput1);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        item = record.FirstOrDefault(bo => bo.AccountNumber == accountIdInput1);
                                        if (item != null)
                                        {
                                            Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("not found");
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (typeInput == "")
                        {
                            if (balanceInput1 == -1)
                            {
                                if (statusInput == "")
                                {
                                    var item = record.FirstOrDefault(bo => bo.Name == nameInput && bo.AccountNumber == accountIdInput1);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        item = record.FirstOrDefault(bo => bo.AccountNumber == accountIdInput1);
                                        if (item != null)
                                        {
                                            Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("not found");
                                        }
                                    }
                                }
                                else
                                {
                                    var item = record.FirstOrDefault(bo => bo.AccountStatus == statusInput && bo.Name == nameInput && bo.AccountNumber == accountIdInput1);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        item = record.FirstOrDefault(bo => bo.AccountNumber == accountIdInput1);
                                        if (item != null)
                                        {
                                            Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("not found");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (statusInput == "")
                                {
                                    var item = record.FirstOrDefault(bo => bo.Balance == balanceInput1 && bo.Name == nameInput && bo.AccountNumber == accountIdInput1);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        item = record.FirstOrDefault(bo => bo.Name == nameInput && bo.AccountNumber == accountIdInput1);
                                        if (item != null)
                                        {
                                            Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                        }
                                        else
                                        {
                                            item = record.FirstOrDefault(bo => bo.AccountNumber == accountIdInput1);
                                            if (item != null)
                                            {
                                                Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                            }
                                            else
                                            {
                                                Console.WriteLine("not found");
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    var item = record.FirstOrDefault(bo => bo.AccountStatus == statusInput && bo.Balance == balanceInput1 && bo.Name == nameInput && bo.AccountNumber == accountIdInput1);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        item = record.FirstOrDefault(bo => bo.Name == nameInput && bo.AccountNumber == accountIdInput1);
                                        if (item != null)
                                        {
                                            Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                        }
                                        else
                                        {
                                            item = record.FirstOrDefault(bo => bo.AccountNumber == accountIdInput1);
                                            if (item != null)
                                            {
                                                Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                            }
                                            else
                                            {
                                                Console.WriteLine("not found");
                                            }
                                        }
                                    }
                                }
                            }

                        }
                        else
                        {
                            if (balanceInput1 == -1)
                            {
                                if (statusInput == "")
                                {
                                    var item = record.FirstOrDefault(bo => bo.AccountNumber == accountIdInput1);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("not found");
                                    };
                                }
                                else
                                {
                                    var item = record.FirstOrDefault(bo => bo.AccountStatus == statusInput && bo.AccountType == typeInput && bo.Name == nameInput && bo.AccountNumber == accountIdInput1);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        item = record.FirstOrDefault(bo => bo.Name == nameInput && bo.AccountNumber == accountIdInput1);
                                        if (item != null)
                                        {
                                            Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                        }
                                        else
                                        {
                                            item = record.FirstOrDefault(bo => bo.AccountNumber == accountIdInput1);
                                            if (item != null)
                                            {
                                                Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                            }
                                            else
                                            {
                                                Console.WriteLine("not found");
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (statusInput == "")
                                {
                                    var item = record.FirstOrDefault(bo => bo.Balance == balanceInput1 && bo.AccountType == typeInput && bo.Name == nameInput && bo.AccountNumber == accountIdInput1);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        item = record.FirstOrDefault(bo => bo.Name == nameInput && bo.AccountNumber == accountIdInput1);
                                        if (item != null)
                                        {
                                            Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                        }
                                        else
                                        {
                                            item = record.FirstOrDefault(bo => bo.AccountNumber == accountIdInput1);
                                            if (item != null)
                                            {
                                                Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                            }
                                            else
                                            {
                                                Console.WriteLine("not found");
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    var item = record.FirstOrDefault(bo => bo.AccountStatus == statusInput && bo.Balance == balanceInput1 && bo.AccountType == typeInput && bo.Name == nameInput && bo.AccountNumber == accountIdInput1);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        item = record.FirstOrDefault(bo => bo.AccountNumber == accountIdInput1);
                                        if (item != null)
                                        {
                                            Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("not found");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (nameInput == "")
                    {
                        if (typeInput == "")
                        {
                            if (balanceInput1 == -1)
                            {
                                if (statusInput == "")
                                {
                                    var item = record.FirstOrDefault(bo => bo.Login == userIdInput && bo.AccountNumber == accountIdInput1);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        item = record.FirstOrDefault(bo => bo.AccountNumber == accountIdInput1);
                                        if (item != null)
                                        {
                                            Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("not found");
                                        }
                                    }
                                }
                                else
                                {
                                    var item = record.FirstOrDefault(bo => bo.AccountStatus == statusInput && bo.Login == userIdInput && bo.AccountNumber == accountIdInput1);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        item = record.FirstOrDefault(bo => bo.Login == userIdInput && bo.AccountNumber == accountIdInput1);
                                        if (item != null)
                                        {
                                            Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                        }
                                        else
                                        {
                                            item = record.FirstOrDefault(bo => bo.AccountNumber == accountIdInput1);
                                            if (item != null)
                                            {
                                                Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                            }
                                            else
                                            {
                                                Console.WriteLine("not found");
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (statusInput == "")
                                {
                                    var item = record.FirstOrDefault(bo => bo.Balance == balanceInput1 && bo.Login == userIdInput && bo.AccountNumber == accountIdInput1);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        item = record.FirstOrDefault(bo => bo.Login == userIdInput && bo.AccountNumber == accountIdInput1);
                                        if (item != null)
                                        {
                                            Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                        }
                                        else
                                        {
                                            item = record.FirstOrDefault(bo => bo.AccountNumber == accountIdInput1);
                                            if (item != null)
                                            {
                                                Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                            }
                                            else
                                            {
                                                Console.WriteLine("not found");
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    var item = record.FirstOrDefault(bo => bo.AccountStatus == statusInput && bo.Balance == balanceInput1 && bo.Login == userIdInput && bo.AccountNumber == accountIdInput1);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        item = record.FirstOrDefault(bo => bo.Login == userIdInput && bo.AccountNumber == accountIdInput1);
                                        if (item != null)
                                        {
                                            Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                        }
                                        else
                                        {
                                            item = record.FirstOrDefault(bo => bo.AccountNumber == accountIdInput1);
                                            if (item != null)
                                            {
                                                Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                            }
                                            else
                                            {
                                                Console.WriteLine("not found");
                                            }
                                        }
                                    }
                                }
                            }

                        }
                        else
                        {
                            if (balanceInput1 == -1)
                            {
                                if (statusInput == "")
                                {
                                    Console.WriteLine("No record found!");
                                }
                                else
                                {
                                    var item = record.FirstOrDefault(bo => bo.AccountStatus == statusInput && bo.AccountType == typeInput && bo.Login == userIdInput && bo.AccountNumber == accountIdInput1);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        item = record.FirstOrDefault(bo => bo.Login == userIdInput && bo.AccountNumber == accountIdInput1);
                                        if (item != null)
                                        {
                                            Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                        }
                                        else
                                        {
                                            item = record.FirstOrDefault(bo => bo.AccountNumber == accountIdInput1);
                                            if (item != null)
                                            {
                                                Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                            }
                                            else
                                            {
                                                Console.WriteLine("not found");
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (statusInput == "")
                                {
                                    var item = record.FirstOrDefault(bo => bo.Balance == balanceInput1 && bo.AccountType == typeInput && bo.Login == userIdInput && bo.AccountNumber == accountIdInput1);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        item = record.FirstOrDefault(bo => bo.Login == userIdInput && bo.AccountNumber == accountIdInput1);
                                        if (item != null)
                                        {
                                            Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                        }
                                        else
                                        {
                                            item = record.FirstOrDefault(bo => bo.AccountNumber == accountIdInput1);
                                            if (item != null)
                                            {
                                                Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                            }
                                            else
                                            {
                                                Console.WriteLine("not found");
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    var item = record.FirstOrDefault(bo => bo.AccountStatus == statusInput && bo.Balance == balanceInput1 && bo.AccountType == typeInput && bo.Login == userIdInput && bo.AccountNumber == accountIdInput1);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        item = record.FirstOrDefault(bo => bo.Login == userIdInput && bo.AccountNumber == accountIdInput1);
                                        if (item != null)
                                        {
                                            Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                        }
                                        else
                                        {
                                            item = record.FirstOrDefault(bo => bo.AccountNumber == accountIdInput1);
                                            if (item != null)
                                            {
                                                Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                            }
                                            else
                                            {
                                                Console.WriteLine("not found");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (typeInput == "")
                        {
                            if (balanceInput1 == -1)
                            {
                                if (statusInput == "")
                                {
                                    var item = record.FirstOrDefault(bo => bo.Login == userIdInput && bo.AccountNumber == accountIdInput1);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        item = record.FirstOrDefault(bo => bo.AccountNumber == accountIdInput1);
                                        if (item != null)
                                        {
                                            Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("not found");
                                        }
                                    }
                                }
                                else
                                {
                                    var item = record.FirstOrDefault(bo => bo.AccountStatus == statusInput && bo.Name == nameInput && bo.Name == nameInput && bo.Login == userIdInput && bo.AccountNumber == accountIdInput1);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        item = record.FirstOrDefault(bo => bo.AccountNumber == accountIdInput1);
                                        if (item != null)
                                        {
                                            Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("not found");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (statusInput == "")
                                {
                                    var item = record.FirstOrDefault(bo => bo.Balance == balanceInput1 && bo.Name == nameInput && bo.Name == nameInput && bo.Login == userIdInput && bo.AccountNumber == accountIdInput1);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        item = record.FirstOrDefault(bo => bo.Login == userIdInput && bo.AccountNumber == accountIdInput1);
                                        if (item != null)
                                        {
                                            Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                        }
                                        else
                                        {
                                            item = record.FirstOrDefault(bo => bo.AccountNumber == accountIdInput1);
                                            if (item != null)
                                            {
                                                Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                            }
                                            else
                                            {
                                                Console.WriteLine("not found");
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    var item = record.FirstOrDefault(bo => bo.AccountStatus == statusInput && bo.Balance == balanceInput1 && bo.Name == nameInput && bo.Name == nameInput && bo.Login == userIdInput && bo.AccountNumber == accountIdInput1);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        item = record.FirstOrDefault(bo => bo.Login == userIdInput && bo.AccountNumber == accountIdInput1);
                                        if (item != null)
                                        {
                                            Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                        }
                                        else
                                        {
                                            item = record.FirstOrDefault(bo => bo.AccountNumber == accountIdInput1);
                                            if (item != null)
                                            {
                                                Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                            }
                                            else
                                            {
                                                Console.WriteLine("not found");
                                            }
                                        }
                                    }
                                }
                            }

                        }
                        else
                        {
                            if (balanceInput1 == -1)
                            {
                                if (statusInput == "")
                                {
                                    Console.WriteLine("No record found!");
                                }
                                else
                                {
                                    var item = record.FirstOrDefault(bo => bo.AccountStatus == statusInput && bo.AccountType == typeInput && bo.Name == nameInput && bo.Name == nameInput && bo.Login == userIdInput && bo.AccountNumber == accountIdInput1);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        item = record.FirstOrDefault(bo => bo.Login == userIdInput && bo.AccountNumber == accountIdInput1);
                                        if (item != null)
                                        {
                                            Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                        }
                                        else
                                        {
                                            item = record.FirstOrDefault(bo => bo.AccountNumber == accountIdInput1);
                                            if (item != null)
                                            {
                                                Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                            }
                                            else
                                            {
                                                Console.WriteLine("not found");
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (statusInput == "")
                                {
                                    var item = record.FirstOrDefault(bo => bo.Balance == balanceInput1 && bo.AccountType == typeInput && bo.Name == nameInput && bo.Name == nameInput && bo.Login == userIdInput && bo.AccountNumber == accountIdInput1);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        item = record.FirstOrDefault(bo => bo.Login == userIdInput && bo.AccountNumber == accountIdInput1);
                                        if (item != null)
                                        {
                                            Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                        }
                                        else
                                        {
                                            item = record.FirstOrDefault(bo => bo.AccountNumber == accountIdInput1);
                                            if (item != null)
                                            {
                                                Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                            }
                                            else
                                            {
                                                Console.WriteLine("not found");
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    var item = record.FirstOrDefault(bo => bo.AccountStatus == statusInput && bo.Balance == balanceInput1 && bo.AccountType == typeInput && bo.Name == nameInput && bo.Login == userIdInput && bo.AccountNumber == accountIdInput1);
                                    if (item != null)
                                    {
                                        Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                    }
                                    else
                                    {
                                        item = record.FirstOrDefault(bo => bo.Login == userIdInput && bo.AccountNumber == accountIdInput1);
                                        if (item != null)
                                        {
                                            Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                        }
                                        else
                                        {
                                            item = record.FirstOrDefault(bo => bo.AccountNumber == accountIdInput1);
                                            if (item != null)
                                            {
                                                Console.WriteLine($"name : {item.Name} , login : {item.Login} , balance : {item.Balance}");
                                            }
                                            else
                                            {
                                                Console.WriteLine("not found");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

    }
}

    













        /*
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
        }*/
