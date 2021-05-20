using System;
using DM.Desparasitacao.Domain.Interfaces;
using DM.Desparasitacao.Domain.Interfaces.Repository;
using DM.Desparasitacao.Domain.Interfaces.Service;
using DM.Desparasitacao.Domain.Models;

namespace DM.Desparasitacao.Domain.Services
{
    public class DiaProtocoloLuaService : IDiaProtocoloLuaService
    {
        private readonly IDiaProtocoloLuaRepository _diaProtocoloLuaRepository;

        public DiaProtocoloLuaService(IDiaProtocoloLuaRepository diaProtocoloLuaRepository)
        {
            _diaProtocoloLuaRepository = diaProtocoloLuaRepository;
        }

        public DiaProtocoloLua Adicionar(DiaProtocoloLua diaProtocoloLua)
        {
            if (!diaProtocoloLua.EhValido()) return diaProtocoloLua;

            _diaProtocoloLuaRepository.Adicionar(diaProtocoloLua);

            return diaProtocoloLua;
        }

        public DiaProtocoloLua Atualizar(DiaProtocoloLua diaProtocoloLua)
        {
            if (!diaProtocoloLua.EhValido()) return diaProtocoloLua;

            _diaProtocoloLuaRepository.Atualizar(diaProtocoloLua);

            return diaProtocoloLua;
        }

        public void Remover(Guid id)
        {
            _diaProtocoloLuaRepository.Remover(id);
        }

        public void Dispose()
        {
            _diaProtocoloLuaRepository.Dispose();
        }
    }
}