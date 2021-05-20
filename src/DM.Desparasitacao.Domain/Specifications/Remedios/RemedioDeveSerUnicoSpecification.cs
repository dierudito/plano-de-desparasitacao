using DM.Desparasitacao.Domain.Interfaces.Repository;
using DM.Desparasitacao.Domain.Models;
using DomainValidation.Interfaces.Specification;

namespace DM.Desparasitacao.Domain.Specifications.Remedios
{
    public class RemedioDeveSerUnicoSpecification : ISpecification<Remedio>
    {
        private readonly IRemedioRepository _remedioRepository;

        public RemedioDeveSerUnicoSpecification(IRemedioRepository remedioRepository)
        {
            _remedioRepository = remedioRepository;
        }

        public bool IsSatisfiedBy(Remedio entity)
        {
            return _remedioRepository.ObterRemedio(entity.Nome, entity.Unidade) == null;
        }
    }
}