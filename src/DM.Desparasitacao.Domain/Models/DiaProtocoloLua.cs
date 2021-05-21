using System;
using System.Collections.Generic;

namespace DM.Desparasitacao.Domain.Models
{
    public class DiaProtocoloLua : Entity
    {
        public DiaProtocoloLua()
        {
            AdministracaoRemedios = new List<AdministracaoRemedio>();
        }
        public Guid ProtocoloLuaId { get; set; }
        public virtual ProtocoloLua ProtocoloLua { get; set; }
        public bool Enema { get; set; }
        public int Dia { get; set; }
        public virtual ICollection<AdministracaoRemedio> AdministracaoRemedios { get; set; }

        public bool AdicionarAdministracaoRemedio(AdministracaoRemedio administracaoRemedio)
        {
            if (!administracaoRemedio.EhValido())
            {
                AdicionarErrosValidacao(administracaoRemedio.ValidationResult);
                return false;
            }
            AdministracaoRemedios.Add(administracaoRemedio);
            return true;
        }
        public override bool EhValido()
        {
            return true;
        }
    }
}