using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl
{
    public class Citizen:IDeteinable, IBirthdatable,IBuyer
    {
        public Citizen(string name, int age, string iD, string birthday)
        {
            Name = name;
            Age = age;
            ID = iD;
            Birthday = birthday;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string ID { get; set; }
        public string Birthday { get; set; }
        public int Food { get; set; } = 0;

        public void BirthdayMatch(string year)
        {
            if (Birthday.Split("/")[2]==year)
            {
                Console.WriteLine(Birthday);
            }
        }


        public void Detain(int a)
        {
            if (IsDetained(a))
                Console.WriteLine(ID);
           
        }


        public void BuyFood()
        {
            Food += 10;
        }

        public bool IsDetained(int a) => ID.EndsWith(a.ToString());
    }
    
}
