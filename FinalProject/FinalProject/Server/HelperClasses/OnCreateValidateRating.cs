using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.HelperClasses
{
    class OnCreateValidateRating
    {
        public static bool CheckIfRatingIsValid(int rating) => rating > 0 && rating <= 5;
    }
}
