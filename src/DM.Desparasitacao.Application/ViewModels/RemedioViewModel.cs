using System;
using System.ComponentModel.DataAnnotations;
using DM.Desparasitacao.CrossCutting.Filters.Helpers;

namespace DM.Desparasitacao.Application.ViewModels
{
    public class RemedioViewModel
    {
        public RemedioViewModel()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Preencha o campo Nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Escolha a unidade")]
        public UnidadeViewModel Unidade { get; set; }
        [Display(Name = "Unidade")]
        public string UnidadeDescricao => EnumHelper.GetDescription(Unidade);

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
    }
}