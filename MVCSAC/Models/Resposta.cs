using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCSAC.Models
{
    public class Resposta
    {
        [Key]
        public int CHRes { get; set; }

        [Display(Name="Resposta")]
        [Required(ErrorMessage="Digie a resposta.")]
        public string DESCRes { get; set; }

        [Display(Name="Data")]
        [DisplayFormat(DataFormatString="{0:dd/MM/yyyy}")]
        public DateTime DTRes { get; set; }

        public int CHUsu { get; set; }

        public int CHChamado { get; set; }

        //public string NOUsu { get; set; }

        //public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}