using System;
using System.ComponentModel.DataAnnotations;

namespace GAP.Insurace.EF
{
    public class Policy
    {
        public Policy()
        {
        }

        /// <summary>
        /// Primary key of insurance policy
        /// </summary>
        [Required]
        public int id { get; set; }

        /// <summary>
        /// policy First Name
        /// </summary>
        [Required]
        [StringLength(50)]
        public string name { get; set; }
        /// <summary>
        /// Description of insurance policy
        /// </summary>
        [StringLength(50)]
        public string description { get; set; }

        /// <summary>
        /// Porcentage of covege of insurance policy
        /// </summary>
        [Required]
        public float porcentage { get; set; }

        /// <summary>
        /// Initial date of covege of insurance policy
        /// </summary>
        [Required]
        public DateTime initDate { get; set; }

        /// <summary>
        /// Number of months that the insurace  will coverage
        /// </summary>
        [Required]
        public int monthsCoverage { get; set; }

        /// <summary>
        /// Fee of the  insurace 
        /// </summary>
        [Required]
        public float fee { get; set; }

        /// <summary>
        /// Risk type of  insurace 
        /// </summary>
        [Required]
        public RiskType riskType { get; set; }
        
        /*
        /// <summary>
        /// Relation between Client - Policy
        /// </summary>
        [Required]
        public Client client { get; set; }
        */
        /// <summary>
        /// Relation between Client - CoverageType
        /// </summary>
        [Required]
        public CoverageTypeEnum coverageType { get; set; }
    }

    public enum RiskType
    {
        bajo,
        medio,
        medioAlto,
        alto
    }

    public enum CoverageTypeEnum
    {
        Terremoto,
        Incendio,
        Robo,
        Perdida,
        Desempleo,
        Enfermedad,
        Muerte
    }
    


}
