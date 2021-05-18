﻿using System.Data.Entity.ModelConfiguration;
using DM.Desparasitacao.Domain.Models;

namespace DM.Desparasitacao.Infra.Data.Mappings
{
    public class AdministracaoRemedioMapping : EntityTypeConfiguration<AdministracaoRemedio>
    {
        public AdministracaoRemedioMapping()
        {
            HasKey(a => a.Id);

            Property(a => a.Horario).IsRequired();
            Property(a => a.Dose).IsRequired();

            HasRequired(a => a.Remedio)
                .WithMany(r => r.AdministracaoRemedios)
                .HasForeignKey(a => a.RemedioId);

            HasRequired(a => a.DiaProtocoloLua)
                .WithMany(r => r.AdministracaoRemedios)
                .HasForeignKey(a => a.DiaProtocoloLuaId);

            ToTable("AdministracaoRemedios");
        }
    }
    public class DiaProtocoloLuaMapping : EntityTypeConfiguration<DiaProtocoloLua>
    {
        public DiaProtocoloLuaMapping()
        {
            HasKey(d => d.Id);

            Property(d => d.Dia).IsRequired();
            Property(d => d.Enema).IsRequired();

            HasRequired(a => a.Remedio)
                .WithMany(r => r.AdministracaoRemedios)
                .HasForeignKey(a => a.RemedioId);

            HasRequired(a => a.DiaProtocoloLua)
                .WithMany(r => r.AdministracaoRemedios)
                .HasForeignKey(a => a.DiaProtocoloLuaId);

            ToTable("DiasProtocoloLua");
        }
    }
    public class AdministracaoRemedioMapping : EntityTypeConfiguration<AdministracaoRemedio>
    {
        public AdministracaoRemedioMapping()
        {
            HasKey(a => a.Id);

            Property(a => a.Horario).IsRequired();
            Property(a => a.Dose).IsRequired();

            HasRequired(a => a.Remedio)
                .WithMany(r => r.AdministracaoRemedios)
                .HasForeignKey(a => a.RemedioId);

            HasRequired(a => a.DiaProtocoloLua)
                .WithMany(r => r.AdministracaoRemedios)
                .HasForeignKey(a => a.DiaProtocoloLuaId);

            ToTable("AdministracaoRemedios");
        }
    }
    public class AdministracaoRemedioMapping : EntityTypeConfiguration<AdministracaoRemedio>
    {
        public AdministracaoRemedioMapping()
        {
            HasKey(a => a.Id);

            Property(a => a.Horario).IsRequired();
            Property(a => a.Dose).IsRequired();

            HasRequired(a => a.Remedio)
                .WithMany(r => r.AdministracaoRemedios)
                .HasForeignKey(a => a.RemedioId);

            HasRequired(a => a.DiaProtocoloLua)
                .WithMany(r => r.AdministracaoRemedios)
                .HasForeignKey(a => a.DiaProtocoloLuaId);

            ToTable("AdministracaoRemedios");
        }
    }
    public class AdministracaoRemedioMapping : EntityTypeConfiguration<AdministracaoRemedio>
    {
        public AdministracaoRemedioMapping()
        {
            HasKey(a => a.Id);

            Property(a => a.Horario).IsRequired();
            Property(a => a.Dose).IsRequired();

            HasRequired(a => a.Remedio)
                .WithMany(r => r.AdministracaoRemedios)
                .HasForeignKey(a => a.RemedioId);

            HasRequired(a => a.DiaProtocoloLua)
                .WithMany(r => r.AdministracaoRemedios)
                .HasForeignKey(a => a.DiaProtocoloLuaId);

            ToTable("AdministracaoRemedios");
        }
    }
}