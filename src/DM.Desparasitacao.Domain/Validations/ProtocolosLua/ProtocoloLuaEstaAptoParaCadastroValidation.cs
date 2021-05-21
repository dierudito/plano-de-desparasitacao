using DM.Desparasitacao.Domain.Interfaces.Repository;
using DM.Desparasitacao.Domain.Models;
using DomainValidation.Validation;

namespace DM.Desparasitacao.Domain.Validations.ProtocolosLua
{
    public class ProtocoloLuaEstaAptoParaCadastroValidation : Validator<ProtocoloLua>
    {
        public ProtocoloLuaEstaAptoParaCadastroValidation(IProtocoloLuaRepository protocoloLuaRepository)
        {
            
        }
    }
}