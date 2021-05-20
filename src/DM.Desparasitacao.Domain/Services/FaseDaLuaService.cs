using System;
using DM.Desparasitacao.Domain.Interfaces.Repository;
using DM.Desparasitacao.Domain.Interfaces.Service;
using DM.Desparasitacao.Domain.Models;
using DM.Desparasitacao.Domain.Validations.FasesDaLua;

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

            faseDaLua.ValidationResult =
                new FaseDaLuaEstaAptoParaCadastroValidation(_faseDaLuaRepository).Validate(faseDaLua);

            if (faseDaLua.ValidationResult.IsValid) _faseDaLuaRepository.Adicionar(faseDaLua);
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