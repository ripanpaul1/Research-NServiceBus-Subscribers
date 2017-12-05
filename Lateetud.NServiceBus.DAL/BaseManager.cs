using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lateetud.NServiceBus.DAL
{
    public class BaseManager
    {
        public GeneralAgentByGeneralAgentID_Select_Result Select(string GeneralAgentID)
        {
            using (var context = new NECGeneralAgentEntities())
            {
                return context.GeneralAgentByGeneralAgentID_Select(GeneralAgentID).FirstOrDefault();
            }
        }

        public void Insert(string GeneralAgentID, string message)
        {
            using(var context = new NECGeneralAgentEntities())
            {
                context.GeneralAgent_InsertUpdate("I", GeneralAgentID, message, "Pending");
            }
        }

        public void Update(string GeneralAgentID)
        {
            using (var context = new NECGeneralAgentEntities())
            {
                context.GeneralAgent_InsertUpdate("U", GeneralAgentID, null, "Received");
            }
        }

    }
}
