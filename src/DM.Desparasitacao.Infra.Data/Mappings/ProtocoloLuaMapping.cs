using System.Data.Entity.ModelConfiguration;
using DM.Desparasitacao.Domain.Models;

namespace DM.Desparasitacao.Infra.Data.Mappings
{
    public class ProtocoloLuaMapping : EntityTypeConfiguration<ProtocoloLua>
    {
        public ProtocoloLuaMapping()
        {
            HasKey(p => p.Id);

            Property(p => p.QuantidadeDia).IsRequired();
            Property(p => p.DiasDeAntecipacao).IsRequired();

            ToTable("ProtocolosDaLua");
        }
    }
}