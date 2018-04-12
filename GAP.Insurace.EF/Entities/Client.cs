using System;
using System.ComponentModel.DataAnnotations;

namespace GAP.Insurace.EF
{
    public class Client
    {
        public Client()
        {
        }

        /// <summary>
        /// Primary key of the client
        /// </summary>
        [Required]
        public int id { get; set; }

        /// <summary>
        /// Client First Name
        /// </summary>
        [Required]
        [StringLength(50)]
        public string firstName { get; set; }

        /// <summary>
        /// Client Last Name
        /// </summary>
        [Required]
        [StringLength(50)]
        public string lastName { get; set; }


    }
}
