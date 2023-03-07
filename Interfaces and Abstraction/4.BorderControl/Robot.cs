using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl
{
    public class Robot : IDeteinable
    {
        public Robot(string model, string iD)
        {
            Model = model;
            ID = iD;
        }

        public string  Model { get; set; }
        public string  ID { get; set; }
        public void Detain(int a)
        {
            if (IsDetained(a))
                Console.WriteLine(ID);
           
        }

        public bool IsDetained(int a) => ID.EndsWith(a.ToString());
    }
}
