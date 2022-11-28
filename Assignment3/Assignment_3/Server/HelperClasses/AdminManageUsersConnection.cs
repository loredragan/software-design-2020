using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_3;
using Assignment_3.Models;
using Server.RequestHandler.Admins;

namespace Server.HelperClasses
{
    static class AdminManageUsersConnection
    {
        public static IEnumerable<User> HandleReadRequests(AdminManageUsersHandler handler, Message received)
        {
            if (received.Content.Equals("GetModelById", StringComparison.InvariantCultureIgnoreCase))
            {
                return handler.GetModelById(received.ValuePairs);
            }
            else if (received.Content.Equals("GetAllModels", StringComparison.InvariantCultureIgnoreCase))
            {
                return handler.GetAllModels(received.ValuePairs);
            }

            return null;
        }

        public static void HandleCommandRequests(AdminManageUsersHandler handler, Message received)
        {
            if (received.Content.Equals("UpdateModel", StringComparison.InvariantCultureIgnoreCase))
            {
                handler.UpdateModel(received.ValuePairs);
            }

            if (received.Content.Equals("AddNewModel", StringComparison.InvariantCultureIgnoreCase))
            {
                handler.AddNewModel(received.ValuePairs);
            }

            if (received.Content.Equals("GetAllModels", StringComparison.InvariantCultureIgnoreCase)) //DeleteModel
            {
                handler.DeleteModel(received.ValuePairs);
            }
        }
    }
}
