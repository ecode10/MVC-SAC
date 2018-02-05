using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCSAC.Models
{
    public class Cidade
    {
        [Key]
        public Int64 CHCidade { get; set; }

        public Int64 CHEstado { get; set; }

        [Display(Name="Cidade")]
        public String NOCidade { get; set; }
    }
}