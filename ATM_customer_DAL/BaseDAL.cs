using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using ATM_BO;
using System.Data.Common;
using System.Runtime.InteropServices.WindowsRuntime;

namespace ATM_DAL
{
    public class BaseDAL
    {
        public void save(List<Customer_BO> list)
        {
            string PathName = Path.Combine(Environment.CurrentDirectory, "record.txt");
            StreamWriter sw = new StreamWriter(PathName, append: false);
            foreach (Customer_BO bo in list) {
                string output = JsonSerializer.Serialize<Customer_BO>(bo);
                sw.WriteLine(output);
            }
            

            sw.Close();
        }
        
        
        public List<Customer_BO> load()
        {
            string[] data;
            List<Customer_BO> list = new List<Customer_BO>();
            if (!File.Exists(Path.Combine(Environment.CurrentDirectory, "record.txt")))
            {
                File.WriteAllText((Path.Combine(Environment.CurrentDirectory, "record.txt")), String.Empty);
            }
            else
            {
                data = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "record.txt"));
                foreach (string d in data)
                {
                    list.Add(JsonSerializer.Deserialize<Customer_BO>(d));
                }
            }
            
            return list;
        }
        
    }
}
