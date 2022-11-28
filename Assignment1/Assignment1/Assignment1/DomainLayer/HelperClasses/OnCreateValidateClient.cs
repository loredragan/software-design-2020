using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.DomainLayer.HelperClasses
{
    static class OnCreateValidateClient
    {
        public static bool StartsWithCapitalLetter(string columnName) => columnName.ToCharArray()[0] >= 65 && columnName.ToCharArray()[0] <= 90;

        public static bool IsAgeValid(int ageInput) => (ageInput >= 18 && ageInput <= 100);

        public static bool IsCnpValid(long cnp)
        {
            var count = 0;

            while (cnp != 0)
            {
                cnp /= 10;
                ++count;
            }

            return count == 13 ? true : false;
        }

        public static bool IsEntityValid(string name, long cnp, int age, string address)
        {
            var validateName = StartsWithCapitalLetter(name);
            var validateCnp = IsCnpValid(cnp);
            var validateAge = IsAgeValid(age);

            return validateName && validateAge && validateCnp;
        }
    }
}
