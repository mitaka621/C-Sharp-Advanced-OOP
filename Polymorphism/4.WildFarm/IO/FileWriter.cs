using Raiding.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.IO
{
    public class FileWriter : IWriter
    {
        public void WriteLine(string str)
        {
            using (StreamWriter sw = new StreamWriter(Environment.GetFolderPath(0) + @"\log.txt", true))
            {
                sw.WriteLine(str);
            }
        }
    }
}
