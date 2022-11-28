using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject;
using Server.RequestHandler.Admins;

namespace Server.HelperClasses
{
    //inainte era statica
    class AdminManageRatingsConnection
    {
        public static IEnumerable<BaseModel> HandleReadRequests(AdminManageRatingsHandler handler, Message received)
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

        public static void HandleCommandRequests(AdminManageRatingsHandler handler, Message received)
        {
            if (received.Content.Equals("UpdateModel", StringComparison.InvariantCultureIgnoreCase))
            {
                handler.UpdateModel(received.ValuePairs, received.UserId);
            }
        }
    }
}
