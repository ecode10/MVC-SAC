using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using MVCSAC.DAL;

namespace MVCSAC.Models
{
    public class Usuario
    {
        [Key]
        public int CHUsu { get; set; }

        [Required(ErrorMessage=("Digite o nome do usuário"))]
        [Display(Name=("Nome"))]
        public string NOUsu { get; set; }

        [Display(Name=("Email"))]
        [Required(ErrorMessage=("Digite o e-mail do usuário"))]
        public string EMUsu { get; set; }

        [Display(Name=("Data Nascimento"))]
        public DateTime DTNascUsu { get; set; }

        //[ForeignKey("CHSite")]
        public int CHSite { get; set; }

        [Required]
        [Display(Name=("Senha"))]
        [DataType(DataType.Password)]
        public string PWUsu { get; set; }

        public string PerfilUsu { get; set; }

        public virtual ICollection<Site> Sites { get; set; }
    }

    public class Login
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Usuário")]
        public string Usuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }
    }

    //public class UsuarioContext : iSACContext
    //{
    //    public DbSet<Usuario> Usuarios { get; set; }
    //}
}