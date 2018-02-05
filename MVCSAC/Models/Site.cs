using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCSAC.Models
{
    public class Site
    {
        [Key]
        public int CHSite { get; set; }

        [Required(ErrorMessage=("Digite o nome do site."))]
        [Display(Name="Nome do Site")]
        public string NOSite { get; set; }

        [Required(ErrorMessage=("Digite a situação"))]
        [Display(Name="Situação")]
        public string SITSite { get; set; }

        //[ForeignKey("Usuario_CHUsu")]
        //public virtual Usuario Usuario { get; set; }
    }
}