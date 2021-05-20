using DM.Desparasitacao.Domain.Interfaces;
using DM.Desparasitacao.Domain.Interfaces.Repository;
using DM.Desparasitacao.Domain.Models;
using DM.Desparasitacao.Infra.Data.Context;

namespace DM.Desparasitacao.Infra.Data.Repository
{
    public class AdministracaoRemedioRepository : Repository<AdministracaoRemedio>, IAdministracaoRemedioRepository
    {
        public AdministracaoRemedioRepository(DesparasitacaoContext context) : base(context)
        {
        }
    }
}