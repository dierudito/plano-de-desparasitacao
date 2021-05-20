using DM.Desparasitacao.Domain.Models;

namespace DM.Desparasitacao.Domain.Interfaces.Repository
{
    public interface IRemedioRepository : IRepositoryRead<Remedio>, IRepositoryWrite<Remedio>
    {
        Remedio ObterRemedio(string nome, Unidade unidadeDeMedida);

    }
}