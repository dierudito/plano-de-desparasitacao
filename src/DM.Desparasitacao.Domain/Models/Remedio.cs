using System.Collections.Generic;

namespace DM.Desparasitacao.Domain.Models
{
    public class Remedio : Entity
    {
        public Remedio()
        {
            AdministracaoRemedios = new List<AdministracaoRemedio>();
        }
        public string Nome { get; set; }
        public Unidade Unidade { get; set; }
        public virtual ICollection<AdministracaoRemedio> AdministracaoRemedios { get; set; }

        public void AdicionarAdministracaoRemedio(AdministracaoRemedio administracaoRemedio)
        {
            if (!administracaoRemedio.EhValido())
            {
                AdicionarErrosValidacao(administracaoRemedio.ValidationResult);
                return;
            }
            AdministracaoRemedios.Add(administracaoRemedio);
        }
        public override bool EhValido()
        {
            return true;
        }
    }
}