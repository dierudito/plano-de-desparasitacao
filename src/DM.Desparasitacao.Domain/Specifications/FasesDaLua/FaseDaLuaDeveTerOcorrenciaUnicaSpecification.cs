using DM.Desparasitacao.Domain.Interfaces.Repository;
using DM.Desparasitacao.Domain.Models;
using DomainValidation.Interfaces.Specification;

namespace DM.Desparasitacao.Domain.Specifications.FasesDaLua
{
    public class FaseDaLuaDeveTerOcorrenciaUnicaSpecification : ISpecification<FaseDaLua>
    {
        private readonly IFaseDaLuaRepository _faseDaLuaRepository;

        public FaseDaLuaDeveTerOcorrenciaUnicaSpecification(IFaseDaLuaRepository faseDaLuaRepository)
        {
            _faseDaLuaRepository = faseDaLuaRepository;
        }
        public bool IsSatisfiedBy(FaseDaLua faseDaLua)
        {
            return _faseDaLuaRepository.ObterPorDataOcorrencia(faseDaLua.DataOcorrencia) == null;
        }
    }
}