using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ATM_DAL
{
    public class BaseDAL
    {
        public void Save(string Text,string Filename)
        {
            string PathName = Path.Combine(Environment.CurrentDirectory, Filename);
            StreamWriter sw = new StreamWriter(PathName, append : true);
            sw.WriteLine(Text);
            sw.Close();

        }
    }
}
