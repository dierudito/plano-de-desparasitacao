using DM.Desparasitacao.CrossCutting.Filters.Helpers;
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
        [ScaffoldColumn(false)]
        public Guid RemedioId { get; set; }
        [ScaffoldColumn(false)]
        public Guid AdministracaoRemedioCorrelacaoId { get; set; }
        [Display(Name ="Horário")]
        public HorarioViewModel Horario { get; set; }
        public string HorarioDescricao => EnumHelper.GetDescription(Horario);
        public decimal Dose { get; set; }
        public bool Receita { get; set; }
        [ScaffoldColumn(false)]
        public Guid DiaProtocoloLuaId { get; set; }
    }
}