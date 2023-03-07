using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl
{
    public class Pet: IBirthdatable
    {
        public Pet(string name, string birthday)
        {
            Birthday = birthday;
            Name = name;
        }
        public string Name { get; set; }
        public string Birthday { get; set; }

        public void BirthdayMatch(string year)
        {
            if (Birthday.Split("/")[2] == year)
            {
                Console.WriteLine(Birthday);
            }
        }
    }
}
