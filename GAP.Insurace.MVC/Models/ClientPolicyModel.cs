using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAP.Insurace.MVC.Models
{
    public class ClientPolicyModel
    {
        public int id { get; set; }

        public bool toDelete { get; set; }

        public ClientModel client { get; set; }

        public PolicyModel policy { get; set; }
    }
}