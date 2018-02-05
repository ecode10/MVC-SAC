using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCSAC.Models
{
    public class Estado
    {
        [Key]
        public Int64 CHEstado { get; set; }

        public Int64 CHPais { get; set; }

        [Display(Name="Estado")]
        public String NOEstado { get; set; }
    }
}