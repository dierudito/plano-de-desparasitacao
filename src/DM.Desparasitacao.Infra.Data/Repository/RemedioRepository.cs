using System.Linq;
using DM.Desparasitacao.Domain.Interfaces.Repository;
using DM.Desparasitacao.Domain.Models;
using DM.Desparasitacao.Infra.Data.Context;

namespace DM.Desparasitacao.Infra.Data.Repository
{
    public class RemedioRepository : Repository<Remedio>, IRemedioRepository
    {
        public RemedioRepository(DesparasitacaoContext context) : base(context)
        {
        }

        public Remedio ObterRemedio(string nome, Unidade unidadeDeMedida)
        {
            return Buscar(r => r.Nome == nome && r.Unidade == unidadeDeMedida).FirstOrDefault();
        }
    }
}