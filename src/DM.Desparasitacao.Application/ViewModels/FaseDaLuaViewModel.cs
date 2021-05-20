using System;
using System.ComponentModel.DataAnnotations;

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
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataOcorrencia { get; set; }
        [Required(ErrorMessage = "Preencha o campo Lua")]
        public LuaViewModel Lua { get; set; }
    }
}