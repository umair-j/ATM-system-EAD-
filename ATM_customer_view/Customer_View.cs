using ATM_BO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM_view
{
    class Customer_View
    {
        public void getInput() {
            Console.WriteLine("Enter your ID");
            string customerId = Console.ReadLine();
            Console.WriteLine("Enter Pin");
            int customerPin = System.Convert.ToInt32(Console.ReadLine());
            Customer_BO bo = new Customer_BO { Login = customerId, Pin = customerPin };
                }
    }
}
