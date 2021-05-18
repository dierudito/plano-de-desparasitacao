using System.Collections.Generic;

namespace DM.Desparasitacao.Domain.Models
{
    public class Remedio : Entity
    {
        public string Nome { get; set; }
        public Unidade Unidade { get; set; }
        public ICollection<AdministracaoRemedio> AdministracaoRemedios { get; set; }
        public override bool EhValido()
        {
            return true;
        }
    }
}