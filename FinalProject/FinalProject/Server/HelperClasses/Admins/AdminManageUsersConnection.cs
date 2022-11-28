using FinalProject;
using FinalProject.Models;
using Server.RequestHandler.Admins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.HelperClasses
{
    class AdminManageUsersConnection
    {
        public static IEnumerable<User> HandleReadRequests(AdminManageUsersHandler handler, Message received)
        {
            if (received.Content.Equals("GetModelById", StringComparison.InvariantCultureIgnoreCase))
            {
                return handler.GetModelById(received.ValuePairs, received.UserId);
            }
            else if (received.Content.Equals("GetAllModels", StringComparison.InvariantCultureIgnoreCase))
            {
                return handler.GetAllModels(received.ValuePairs, received.UserId);
            }

            return null;
        }

        public static void HandleCommandRequests(AdminManageUsersHandler handler, Message received)
        {
            if (received.Content.Equals("UpdateModel", StringComparison.InvariantCultureIgnoreCase))
            {
                handler.UpdateModel(received.ValuePairs, received.UserId);
            }

            if (received.Content.Equals("AddNewModel", StringComparison.InvariantCultureIgnoreCase))
            {
                handler.AddNewModel(received.ValuePairs, received.UserId);
            }
            
            //aici aveam greseala, deaia imi stergea user inainte, nu stiam de ce imi sare peste id-uri, found it, fixed it
            if (received.Content.Equals("DeleteModel", StringComparison.InvariantCultureIgnoreCase)) //DeleteModel
            {
                handler.DeleteModel(received.ValuePairs, received.UserId);
            }

            if (received.Content.Equals("UpdateSubscription", StringComparison.InvariantCultureIgnoreCase))
            {
                handler.UpdateSubscription(received.ValuePairs, received.UserId);
            }
        }
    }
}
