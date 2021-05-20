using System.Data.Entity.ModelConfiguration;
using DM.Desparasitacao.Domain.Models;

namespace DM.Desparasitacao.Infra.Data.Mappings
{
    public class DiaProtocoloLuaMapping : EntityTypeConfiguration<DiaProtocoloLua>
    {
        public DiaProtocoloLuaMapping()
        {
            HasKey(d => d.Id);

            Property(d => d.Dia).IsRequired();
            Property(d => d.Enema).IsRequired();

            HasRequired(a => a.ProtocoloLua)
                .WithMany(r => r.DiasProtocoloLua)
                .HasForeignKey(a => a.ProtocoloLuaId);

            ToTable("DiasProtocoloLua");
        }
    }
}