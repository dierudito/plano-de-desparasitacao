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
        public Guid FaseDaLuaId { get; set; }
        public int QuantidadeDia { get; set; }
        public int DiasDeAntecipacao { get; set; }

    }
}