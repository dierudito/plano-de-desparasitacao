using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using DM.Desparasitacao.Domain.Models;
using DM.Desparasitacao.Infra.Data.Mappings;
using DomainValidation.Validation;

namespace DM.Desparasitacao.Infra.Data.Context
{
    public class DesparasitacaoContext : DbContext
    {
        public DesparasitacaoContext() : base("DefaultConnection")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.AutoDetectChangesEnabled = false;
        }

        public DbSet<AdministracaoRemedio> AdministracaoRemedios { get; set; }
        public DbSet<DiaProtocoloLua> DiasProtocoloLua { get; set; }
        public DbSet<FaseDaLua> FasesDaLua { get; set; }
        public DbSet<ProtocoloLua> ProtocolosDaLua { get; set; }
        public DbSet<Remedio> Remedios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            //modelBuilder.HasDefaultSchema("Sistema1");

            modelBuilder.Configurations.Add(new AdministracaoRemedioMapping());
            modelBuilder.Configurations.Add(new DiaProtocoloLuaMapping());
            modelBuilder.Configurations.Add(new FaseDaLuaMapping());
            modelBuilder.Configurations.Add(new ProtocoloLuaMapping());
            modelBuilder.Configurations.Add(new RemedioMapping());

            modelBuilder.Ignore<ValidationResult>();

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries()
                .Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;

                if (entry.State == EntityState.Modified)
                    entry.Property("DataCadastro").IsModified = false;
            }

            return base.SaveChanges();
        }
    }
}