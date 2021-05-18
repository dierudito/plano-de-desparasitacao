using System;
using System.Collections.Generic;

namespace DM.Desparasitacao.Domain.Models
{
    public class ProtocoloLua : Entity
    {
        public Guid FaseDaLuaId { get; set; }
        public virtual FaseDaLua FaseDaLua { get; set; }
        public int QuantidadeDia { get; set; }
        public int DiasDeAntecipacao { get; set; }
        public virtual ICollection<DiaProtocoloLua> DiasProtocoloLua { get; set; }
        public override bool EhValido()
        {
            return true;
        }
    }
}