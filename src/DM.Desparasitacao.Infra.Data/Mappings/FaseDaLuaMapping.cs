using System.Data.Entity.ModelConfiguration;
using DM.Desparasitacao.Domain.Models;

namespace DM.Desparasitacao.Infra.Data.Mappings
{
    public class FaseDaLuaMapping : EntityTypeConfiguration<FaseDaLua>
    {
        public FaseDaLuaMapping()
        {
            HasKey(f => f.Id);

            Property(f => f.DataOcorrencia).IsRequired();
            Property(f => f.Lua).IsRequired();

            ToTable("FasesDaLua");
        }
    }
}