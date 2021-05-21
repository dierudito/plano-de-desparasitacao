using System;
using DM.Desparasitacao.Domain.Interfaces.Repository;
using DM.Desparasitacao.Domain.Interfaces.Service;
using DM.Desparasitacao.Domain.Models;
using DM.Desparasitacao.Domain.Validations.ProtocolosLua;

namespace DM.Desparasitacao.Domain.Services
{
    public class ProtocoloLuaService : IProtocoloLuaService
    {
        private readonly IProtocoloLuaRepository _protocoloLuaRepository;

        public ProtocoloLuaService(IProtocoloLuaRepository protocoloLuaRepository)
        {
            _protocoloLuaRepository = protocoloLuaRepository;
        }
        public ProtocoloLua Adicionar(ProtocoloLua protocoloLua)
        {
            if (!protocoloLua.EhValido()) return protocoloLua;

            protocoloLua.ValidationResult =
                new ProtocoloLuaEstaAptoParaCadastroValidation(_protocoloLuaRepository).Validate(protocoloLua);

            if (protocoloLua.ValidationResult.IsValid) _protocoloLuaRepository.Adicionar(protocoloLua);
            return protocoloLua;
        }

        public ProtocoloLua Atualizar(ProtocoloLua protocoloLua)
        {
            if (!protocoloLua.EhValido()) return protocoloLua;

            _protocoloLuaRepository.Atualizar(protocoloLua);
            return protocoloLua;
        }

        public void Remover(Guid id)
        {
            _protocoloLuaRepository.Remover(id);
        }

        public void Dispose()
        {
            _protocoloLuaRepository.Dispose();
        }
    }
}