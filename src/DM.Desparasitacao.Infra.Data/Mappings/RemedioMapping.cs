using System.Data.Entity.ModelConfiguration;
using DM.Desparasitacao.Domain.Models;

namespace DM.Desparasitacao.Infra.Data.Mappings
{
    public class RemedioMapping : EntityTypeConfiguration<Remedio>
    {
        public RemedioMapping()
        {
            HasKey(r => r.Id);

            Property(r => r.Nome).IsRequired();
            Property(r => r.Unidade).IsRequired();

            ToTable("Remedios");
        }
    }
}