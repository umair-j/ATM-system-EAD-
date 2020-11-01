using System;
using System.Collections.Generic;

using System.Text;

namespace ATM_BO
{
    //customer business object
    public class Customer_BO
    {
        public int AccountNumber { get; set; }
        //getter and setter for Login
        public string Login { get; set; }
        //getter and setter for Pin
        public int Pin { get; set; }
        //getter and setter for Balance
        public int Balance { get; set; }
        public string Name { get; set; }
        public string AccountStatus { get; set; }
        public string AccountType { get; set; }
        public DateTime datetime { get; set; }
        public Customer_BO()
        {
            datetime = DateTime.Now;
        }
    }
}
