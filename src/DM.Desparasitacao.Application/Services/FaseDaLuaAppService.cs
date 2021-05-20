using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DM.Desparasitacao.Application.Interfaces;
using DM.Desparasitacao.Application.ViewModels;
using DM.Desparasitacao.Domain.Interfaces;
using DM.Desparasitacao.Domain.Interfaces.Repository;
using DM.Desparasitacao.Domain.Interfaces.Service;
using DM.Desparasitacao.Domain.Models;

namespace DM.Desparasitacao.Application.Services
{
    public class FaseDaLuaAppService : AppServiceBase, IFaseDaLuaAppService
    {
        private readonly IFaseDaLuaRepository _faseDaLuaRepository;
        private readonly IFaseDaLuaService _faseDaLuaService;

        public FaseDaLuaAppService(IUnitOfWork uow, IFaseDaLuaRepository faseDaLuaRepository, IFaseDaLuaService faseDaLuaService) : base(uow)
        {
            _faseDaLuaRepository = faseDaLuaRepository;
            _faseDaLuaService = faseDaLuaService;
        }

        public FaseDaLuaViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<FaseDaLuaViewModel>(_faseDaLuaRepository.ObterPorId(id));
        }

        public IEnumerable<FaseDaLuaViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<FaseDaLuaViewModel>>(_faseDaLuaRepository.ObterTodos().OrderBy(f => f.DataOcorrencia));
        }

        public FaseDaLuaViewModel Adicionar(FaseDaLuaViewModel faseDaLuaViewModel)
        {
            var faseDaLua = Mapper.Map<FaseDaLua>(faseDaLuaViewModel);

            var clienteReturn = _faseDaLuaService.Adicionar(faseDaLua);

            if (clienteReturn.ValidationResult.IsValid)
            {
                if (!SaveChanges())
                {
                    AdicionarErrosValidacao(faseDaLua.ValidationResult, "Ocorreu um erro no momento de salvar os dados no banco.");
                }
            }

            faseDaLuaViewModel.ValidationResult = clienteReturn.ValidationResult;
            return faseDaLuaViewModel;
        }

        public FaseDaLuaViewModel Atualizar(FaseDaLuaViewModel faseDaLuaViewModel)
        {
            var faseDaLua = Mapper.Map<FaseDaLua>(faseDaLuaViewModel);

            var clienteReturn = _faseDaLuaService.Atualizar(faseDaLua);

            if (!clienteReturn.ValidationResult.IsValid) return faseDaLuaViewModel;
            if (!SaveChanges())
            {
                AdicionarErrosValidacao(faseDaLua.ValidationResult, "Ocorreu um erro no momento de salvar os dados no banco.");
            }
            return faseDaLuaViewModel;
        }

        public void Remover(Guid id)
        {
            _faseDaLuaService.Remover(id);
        }

        public void Dispose()
        {
            _faseDaLuaRepository.Dispose();
        }
    }
}