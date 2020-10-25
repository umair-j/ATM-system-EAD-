using ATM_BO;
using System.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Data.Common;

namespace ATM_DAL
{
    public class Admin_DAL : BaseDAL
    {
        public Customer_BO bo = new Customer_BO();
        public void SaveCustomer(Customer_BO bo)
        {
            string JsonOutput = JsonSerializer.Serialize(bo);
            Save(JsonOutput, "CustomerData.txt", true);
        }
        public void Search(string name,string Filename)
        {
            Customer_BO cbo = new Customer_BO();
            bool found = false;
            string PathName = Path.Combine(Environment.CurrentDirectory, Filename);
            StreamReader sr = new StreamReader(PathName);
            ArrayList ar = new ArrayList();
            string JSonStr = sr.ReadLine();
            while (sr.ReadLine() != null)
            {
                cbo = JsonSerializer.Deserialize<Customer_BO>(JSonStr);
                if (cbo.Name == name)
                {

                    found = true; 
                    continue;
                   
                }
                ar.Add(cbo);
            }
            if (found != true)
            {
                Console.WriteLine("record not found!");
            }
            else {
                string JsonOutput = JsonSerializer.Serialize(bo);
                Save(JsonOutput, "CustomerData.txt",false);
            }
            //Console.WriteLine(bo);
           


        }

        public Customer_BO SearchRecord(string name)
        {
            bool found = false;
            Customer_BO cbo = new Customer_BO();
            string PathName = Path.Combine(Environment.CurrentDirectory, "CustomerData.txt");
            List<string> records = new List<string>();
            records = File.ReadAllLines(PathName).ToList();
            foreach(string record in records)
            {
                //Console.WriteLine(record);
                cbo = JsonSerializer.Deserialize<Customer_BO>(record);
                if (cbo.Name == name)
                {
                    found = true;
                }
                if (found)
                {
                    break;
                }
            }
            if (found == false)
            {
                cbo = null;
            }
            
            return cbo;
            /*
             bool found = false;
             string PathName = Path.Combine(Environment.CurrentDirectory, "CustomerData.txt");
             StreamReader sr = new StreamReader(PathName);
             //ArrayList ar = new ArrayList();
             
             while (sr.ReadLine() != null)
             {
                 string JSonStr = sr.ReadLine();


                 cbo = JsonSerializer.Deserialize<Customer_BO>(JSonStr);
                 if (cbo.Name.Equals(name))
                 {

                     found = true;
                     break;

                 }
                 //ar.Add(bo);
             }
             if (found)
             {
                 return cbo;
             }
             else
             {
                 return null;
             }

            */
        }
    }
}
