using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephony
{
    public class StationaryPhone : ICaller
    {
       
        public string Call(string phoneNum)
        {
            if (IsPhoneValid(phoneNum))
                return $"Dialing... {phoneNum}";
            return "Invalid number!";
        }
        private bool IsPhoneValid(string s) => s.All(x => char.IsDigit(x));
    }
}
