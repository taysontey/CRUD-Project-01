using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using Projeto.Entity.Entities;

namespace Projeto.DAL.Configuration
{
    public class TimeConfiguration : EntityTypeConfiguration<Time>
    {
        public TimeConfiguration()
        {
            ToTable("TB_TIME");

            HasKey(t => t.IdTime);

            Property(t => t.IdTime)
                .HasColumnName("IDTIME")
                .IsRequired();

            Property(t => t.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(50)
                .IsRequired();

            Property(t => t.DataFundacao)
                .HasColumnName("DATAFUNDACAO")
                .IsRequired();
        }
    }
}
