using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAP.Insurace.MVC.Models
{
    public class ClientPolicyListModel
    {
        public IEnumerable<ClientModel> clientList { get; set; }

        public  IEnumerable<ClientPolicyModel> clientPolicyList { get; set; }
    }
}