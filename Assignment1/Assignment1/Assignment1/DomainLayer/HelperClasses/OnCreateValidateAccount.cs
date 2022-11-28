using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Assignment1.DomainLayer.HelperClasses
{
    public static class OnCreateValidateAccount
    {
        public static bool CheckIfAmountIsValid(double amount) => amount > 0;

        public static bool CheckIfTypeIsValid(string type) =>
            type.Equals("ron", StringComparison.InvariantCultureIgnoreCase) ||
            type.Equals("euro", StringComparison.InvariantCultureIgnoreCase) ||
            type.Equals("usd", StringComparison.InvariantCultureIgnoreCase);

        public static bool IsEntityValid(double amount, string type)
        {
            //var validDate = CheckIfDateIsValid(date);
            var validType = CheckIfTypeIsValid(type);
            var validAmount = CheckIfAmountIsValid(amount);

            return validAmount &&  validType;
        }
    }
}
