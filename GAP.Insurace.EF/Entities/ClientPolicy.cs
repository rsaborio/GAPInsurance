using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Insurace.EF
{
    public class ClientPolicy
    {
        [Required]
        public int id { get; set; }
        /// <summary>
        /// Relation between Client
        /// </summary>
        public int clientid { get; set; }
        public virtual Client client { get; set; }

        /// <summary>
        /// Relation between Client - Policy
        /// </summary>
        public int policyid { get; set; }
        public virtual Policy policy { get; set; }

    }
}
