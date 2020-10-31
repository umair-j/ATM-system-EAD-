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
       
        /*        public Customer_BO bo = new Customer_BO();
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
                Save(JsonOutput, "CustomerData.txt",true);
            }
            //Console.WriteLine(bo);
           


        }
        public bool Delete(string name)
        {
            Customer_BO cbo = new Customer_BO();
            bool found = false;
            string PathName = Path.Combine(Environment.CurrentDirectory, "CustomerData.txt");
            StreamReader sr = new StreamReader(PathName);
            List<string> records = new List<string>();

            string PathNameNew = Path.Combine(Environment.CurrentDirectory, "CustomerDataNew.txt");
            StreamWriter sw = new StreamWriter(PathNameNew,append:true);
            string JsonOutputNew;

            records = File.ReadAllLines(PathName).ToList();
            foreach(string record in records)
            {

                
                 cbo = JsonSerializer.Deserialize<Customer_BO>(record);

                 if (cbo.Name == name)
                 {
                     found = true;
                    Console.WriteLine("found");
                 }
                else
                {
                    JsonOutputNew = JsonSerializer.Serialize<Customer_BO>(cbo);
                    
                    
                    sw.WriteLine(JsonOutputNew);
                    sw.Close();
                }
                
                 
                
                Console.WriteLine(record + "\n");
            }
            
            return found;
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
            

        }
*/
    }
}
