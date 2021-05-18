using System;

namespace DM.Desparasitacao.Domain.Models
{
    public class FaseDaLua : Entity
    {
        public DateTime DataOcorrencia { get; set; }
        public Lua Lua { get; set; }
        public override bool EhValido()
        {
            return true;
        }
    }
}