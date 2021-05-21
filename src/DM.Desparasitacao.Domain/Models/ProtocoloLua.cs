using System.Collections.Generic;

namespace DM.Desparasitacao.Domain.Models
{
    public class ProtocoloLua : Entity
    {
        public ProtocoloLua()
        {
            DiasProtocoloLua = new List<DiaProtocoloLua>();
        }
        public Lua Lua { get; set; }
        public int Numero { get; set; }
        public int QuantidadeDia { get; set; }
        public int DiasDeAntecipacao { get; set; }
        public virtual ICollection<DiaProtocoloLua> DiasProtocoloLua { get; set; }

        public void AdicionarDiaProtocoloLua(DiaProtocoloLua diaProtocoloLua)
        {
            if (!diaProtocoloLua.EhValido())
            {
                AdicionarErrosValidacao(diaProtocoloLua.ValidationResult);
                return;
            }
            DiasProtocoloLua.Add(diaProtocoloLua);
        }
        public override bool EhValido()
        {
            return true;
        }
    }
}