using System;
using System.ComponentModel.DataAnnotations;

namespace GAP.Insurace.EF
{
    public class CoverageType
    {
        public CoverageType()
        {

        }

        /// <summary>
        /// Primary key of coverage type
        /// </summary>
        [Required]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [StringLength(50)]
        public string description { get; set; }

    }
}
