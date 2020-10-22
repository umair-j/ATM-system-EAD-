using ATM_BO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM_DAL
{
    public class Admin_DAL : BaseDAL
    {
        public void SaveCustomer(Customer_BO bo)
        {
            Save(bo.Name + bo.Login + bo.Pin + bo.Balance + bo.AccountType + bo.AccountStatus,"CustomerData.csv");
        }
    }
}
