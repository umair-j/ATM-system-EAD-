﻿using ATM_view;
using System;

namespace ATM_system__EAD_
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Admin_View adV = new Admin_View();
            while (adV.Exited == false)
            {
                
                adV.Admin_menu();
                //Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
            }

        }
    }
}
