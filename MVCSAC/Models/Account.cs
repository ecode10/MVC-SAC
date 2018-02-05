using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCSAC.Models
{
    public class Account
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name="Usuário")]
        public string Usuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name="Senha")]
        public string Senha { get; set; }
    }
}