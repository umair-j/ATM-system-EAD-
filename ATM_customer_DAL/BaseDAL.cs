using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using ATM_BO;

namespace ATM_DAL
{
    public class BaseDAL
    {
        Customer_BO bo;
        public void Save(string Text,string Filename,bool app)
        {
            string PathName = Path.Combine(Environment.CurrentDirectory, Filename);
            StreamWriter sw = new StreamWriter(PathName, append : app);
            sw.WriteLine(Text);
            sw.Close();

        }
        public void ShowAll(string JSonStr)
        {

            bo = JsonSerializer.Deserialize<Customer_BO>(JSonStr);
            Console.WriteLine($"name : {bo.Name} and ID : {bo.Login}");
        }
        
    }
}
