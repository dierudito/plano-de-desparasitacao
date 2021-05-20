using System;
using System.ComponentModel.DataAnnotations;

namespace DM.Desparasitacao.Application.ViewModels
{
    public class DiaProtocoloLuaViewModel
    {
        public DiaProtocoloLuaViewModel()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }
        public Guid ProtocoloLuaId { get; set; }
        public bool Enema { get; set; }
        public int Dia { get; set; }
    }
}