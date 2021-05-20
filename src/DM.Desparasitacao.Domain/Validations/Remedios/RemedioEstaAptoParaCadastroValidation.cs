using DM.Desparasitacao.Domain.Interfaces.Repository;
using DM.Desparasitacao.Domain.Models;
using DM.Desparasitacao.Domain.Specifications.Remedios;
using DomainValidation.Validation;

namespace DM.Desparasitacao.Domain.Validations.Remedios
{
    public class RemedioEstaAptoParaCadastroValidation : Validator<Remedio>
    {
        public RemedioEstaAptoParaCadastroValidation(IRemedioRepository remedioRepository)
        {
            var remedioUnico = new RemedioDeveSerUnicoSpecification(remedioRepository);

            Add("remedioUnico", new Rule<Remedio>(remedioUnico, "Já existe este remédio cadastrado!"));
        }
    }
}