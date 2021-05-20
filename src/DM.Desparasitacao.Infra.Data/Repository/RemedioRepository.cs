using DM.Desparasitacao.Domain.Interfaces;
using DM.Desparasitacao.Domain.Models;
using DM.Desparasitacao.Infra.Data.Context;

namespace DM.Desparasitacao.Infra.Data.Repository
{
    public class RemedioRepository : Repository<Remedio>, IRemedioRepository
    {
        public RemedioRepository(DesparasitacaoContext context) : base(context)
        {
        }
    }
}