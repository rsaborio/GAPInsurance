using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GAP.Insurace.MVC.Models
{
    public class ClientModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "This File is required")]
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
}