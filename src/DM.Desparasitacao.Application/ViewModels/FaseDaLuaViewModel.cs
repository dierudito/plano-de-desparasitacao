using System;
using System.ComponentModel.DataAnnotations;
using DM.Desparasitacao.CrossCutting.Filters.Helpers;

namespace DM.Desparasitacao.Application.ViewModels
{
    public class FaseDaLuaViewModel
    {
        public FaseDaLuaViewModel()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Data da Ocorrência")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataOcorrencia { get; set; }
        [Required(ErrorMessage = "Preencha o campo Lua")]
        public LuaViewModel Lua { get; set; }

        [Display(Name = "Lua")]
        public string LuaDescricao => EnumHelper.GetDescription(Lua);

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
    }
}