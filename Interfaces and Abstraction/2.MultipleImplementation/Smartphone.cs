using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephony
{
    public class Smartphone : ICaller, IBrowser
    {
       

        public string Call(string phoneNum)
        {

            if (IsPhoneValid(phoneNum))
            return ("Calling... " + phoneNum);
                
            return "Invalid number!";
            

        }
        public string SurfTheNet(string url)
        {
            if (isURLValid(url))
                return $"Browsing: {url}!";
            return "Invalid URL!";
        }

        private bool IsPhoneValid(string s) => s.All(x => char.IsDigit(x));
        private bool isURLValid(string s)=>s.All(x => !char.IsDigit(x));
       
    }
}
