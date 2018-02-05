using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MVCSAC.Models;

namespace MVCSAC.DAL
{
    public class iSACContext : DbContext
    {
        //Tabelas
        public DbSet<Site> Sites { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Chamado> Chamados { get; set; }
        public DbSet<Resposta> Respostas { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Cidade> Cidades { get; set; }

        //classe de contexto construtor
        public iSACContext()
        {
            Database.SetInitializer<iSACContext>(null);
        }
    }
}