using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAP.Insurace.MVC.Models
{
    public class ClientPolicyBaseModel
    {
        public int id { get; set; }
        public int clientid { get; set; }

        public int policyid { get; set; }
    }
}