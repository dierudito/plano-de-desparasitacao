using System;
using System.ComponentModel.DataAnnotations;

namespace DM.Desparasitacao.Application.ViewModels
{
    public class ProtocoloLuaViewModel
    {
        public ProtocoloLuaViewModel()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Preencha o campo Lua")]
        public LuaViewModel Lua { get; set; }
        
        [Display(Name = "Número")]
        public int Numero { get; set; }
        public int QuantidadeDia { get; set; }
        public int DiasDeAntecipacao { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

    }
}