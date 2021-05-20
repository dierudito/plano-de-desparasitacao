using System;
using DM.Desparasitacao.Domain.Interfaces;
using DM.Desparasitacao.Domain.Models;

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

            _protocoloLuaRepository.Adicionar(protocoloLua);
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