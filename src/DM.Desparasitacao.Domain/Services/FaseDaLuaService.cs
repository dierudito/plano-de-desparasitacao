using System;
using DM.Desparasitacao.Domain.Interfaces;
using DM.Desparasitacao.Domain.Models;

namespace DM.Desparasitacao.Domain.Services
{
    public class FaseDaLuaService : IFaseDaLuaService
    {
        private readonly IFaseDaLuaRepository _faseDaLuaRepository;

        public FaseDaLuaService(IFaseDaLuaRepository faseDaLuaRepository)
        {
            _faseDaLuaRepository = faseDaLuaRepository;
        }
        public FaseDaLua Adicionar(FaseDaLua faseDaLua)
        {
            if (!faseDaLua.EhValido()) return faseDaLua;

            _faseDaLuaRepository.Adicionar(faseDaLua);
            return faseDaLua;
        }

        public FaseDaLua Atualizar(FaseDaLua faseDaLua)
        {
            if (!faseDaLua.EhValido()) return faseDaLua;

            _faseDaLuaRepository.Atualizar(faseDaLua);
            return faseDaLua;
        }

        public void Remover(Guid id)
        {
            _faseDaLuaRepository.Remover(id);
        }

        public void Dispose()
        {
            _faseDaLuaRepository.Dispose();
        }
    }
}