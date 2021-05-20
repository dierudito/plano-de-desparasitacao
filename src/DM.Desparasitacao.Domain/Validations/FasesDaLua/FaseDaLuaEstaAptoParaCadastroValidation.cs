using DM.Desparasitacao.Domain.Interfaces.Repository;
using DM.Desparasitacao.Domain.Models;
using DM.Desparasitacao.Domain.Specifications.FasesDaLua;
using DomainValidation.Validation;

namespace DM.Desparasitacao.Domain.Validations.FasesDaLua
{
    public class FaseDaLuaEstaAptoParaCadastroValidation : Validator<FaseDaLua>
    {
        public FaseDaLuaEstaAptoParaCadastroValidation(IFaseDaLuaRepository faseDaLuaRepository)
        {
            var faseDaLuaUnicaOcorrencia = new FaseDaLuaDeveTerOcorrenciaUnicaSpecification(faseDaLuaRepository);

            Add("fasedaLuaUnicaOcorrenia", new Rule<FaseDaLua>(faseDaLuaUnicaOcorrencia, "Já existe uma lua cadastrada para essa data!"));
        }
    }
}