﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ATM_BO
{
    //customer business object
    public class Customer_BO
    {
        //getter and setter for Login
        public string Login { get; set; }
        //getter and setter for Pin
        public int Pin { get; set; }
        //getter and setter for Balance
        public int Balance { get; set; }
    }
}