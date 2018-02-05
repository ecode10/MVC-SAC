using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCSAC.Models
{
    public class Chamado
    {
        [Key]
        public int CHChamado { get; set; }

        [Required(ErrorMessage=("Digite o título."))]
        [Display(Name=("Título"))]
        public string TITChamado { get; set; }

        [Required(ErrorMessage=("Digite a descrição."))]
        [Display(Name=("Descrição"))]
        public string DESCChamado { get; set; }

        [Display(Name=("Data"))]
        [DisplayFormat(DataFormatString="{0:dd/MM/yyyy}")]
        public DateTime DTChamado { get; set; }

        [Display(Name=("Situação"))]
        [Required(ErrorMessage=("Digite a situação."))]
        public string SITChamado { get; set; }

        [Display(Name=("Usuario"))]
        public int CHUsu { get; set; }
    }
}