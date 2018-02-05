using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCSAC.Models
{
    public class Pais
    {
        [Key]
        [Display(Name="Chave")]
        public Int64 CHPais { get; set; }

        [Display(Name="Pais")]
        public String NOPais { get; set; }
    }
}