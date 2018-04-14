using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GAP.Insurace.MVC.Models
{
    public class PolicyModel
    {
        

        public int id { get; set; }


        [DisplayName("Name:")]
        [MaxLength(50, ErrorMessage = "Name cannot be longer than 40 characters.")]
        public string name { get; set; }

        [DisplayName("Description:")]
        [MaxLength(50, ErrorMessage = "Description cannot be longer than 40 characters.")]
        public string description { get; set; }

        [DisplayName("Coverage %:")]
        public float porcentage { get; set; }

        [DisplayName("Initial Date:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime initDate { get; set; }

        [DisplayName("Months of Coverage:")]
        public int monthsCoverage { get; set; }

        [DisplayName("Price:")]
        public float fee { get; set; }

        [DisplayName("Risk:")]
        public RiskType riskType { get; set; }

        [DisplayName("Coverage Type:")]
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