using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Configuration;
using Projeto.Entity.Entities;
using Projeto.DAL.Configuration;

namespace Projeto.DAL.DataSource
{
    public class Conexao : DbContext
    {
        public Conexao()
            : base(ConfigurationManager.ConnectionStrings["projeto"].ConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new JogadorConfiguration());
            modelBuilder.Configurations.Add(new TimeConfiguration());
        }

        public DbSet<Jogador> Jogador { get; set; }
        public DbSet<Time> Time { get; set; }
    }
}
