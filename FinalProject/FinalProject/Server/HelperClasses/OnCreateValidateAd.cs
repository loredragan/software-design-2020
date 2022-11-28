using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.HelperClasses
{
    public static class OnCreateValidateAd
    {
        private static bool CheckIfNumberPropertyIsValid(double number) => number > 0;

        private static bool CheckIfRatingIsInRange(int rating) => rating > 0 && rating <= 5;

        public static bool IsEntityValid(double size, double price)
        {
            return CheckIfNumberPropertyIsValid(size) &&
                   CheckIfNumberPropertyIsValid(price);
        }
    }
}
