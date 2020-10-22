using ATM_BO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM_BLL
{
    public class Admin_BLL
    {
        public Customer_BO C_bo = new Customer_BO();
        public void NewAccount()
        {
            Console.WriteLine("Enter Login ID");
            string CustomerId = Console.ReadLine();
            Console.WriteLine("Assign a pin to " + CustomerId);
            int CustomerPin = System.Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Balance");
            int CustomerBalance = System.Convert.ToInt32(Console.ReadLine());
            C_bo.Login = CustomerId;
            C_bo.Pin = CustomerPin;
            C_bo.Balance = CustomerBalance;

        }
    }
}
