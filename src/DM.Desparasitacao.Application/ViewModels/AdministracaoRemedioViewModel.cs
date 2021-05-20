using System;
using System.ComponentModel.DataAnnotations;

namespace DM.Desparasitacao.Application.ViewModels
{
    public class AdministracaoRemedioViewModel
    {
        public AdministracaoRemedioViewModel()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }
        public Guid RemedioId { get; set; }
        public Guid AdministracaoRemedioCorrelacaoId { get; set; }
        public decimal Dose { get; set; }
        public bool Receita { get; set; }
        public Guid DiaProtocoloLuaId { get; set; }
    }
}