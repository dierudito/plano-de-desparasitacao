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
    public class RemedioAppService : AppServiceBase, IRemedioAppService
    {
        private readonly IRemedioRepository _remedioRepository;
        private readonly IRemedioService _remedioService;

        public RemedioAppService(IUnitOfWork uow, IRemedioRepository remedioRepository, IRemedioService remedioService) : base(uow)
        {
            _remedioRepository = remedioRepository;
            _remedioService = remedioService;
        }

        public RemedioViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<RemedioViewModel>(_remedioRepository.ObterPorId(id));
        }

        public IEnumerable<RemedioViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<RemedioViewModel>>(_remedioRepository.ObterTodos().OrderBy(r => r.Nome));
        }

        public RemedioViewModel Adicionar(RemedioViewModel remedioViewModel)
        {
            var remedio = Mapper.Map<Remedio>(remedioViewModel);

            var clienteReturn = _remedioService.Adicionar(remedio);

            if (clienteReturn.ValidationResult.IsValid)
            {
                if (!SaveChanges())
                {
                    AdicionarErrosValidacao(remedio.ValidationResult, "Ocorreu um erro no momento de salvar os dados no banco.");
                }
            }

            remedioViewModel.ValidationResult = clienteReturn.ValidationResult;
            return remedioViewModel;
        }

        public RemedioViewModel Atualizar(RemedioViewModel remedioViewModel)
        {
            var remedio = Mapper.Map<Remedio>(remedioViewModel);

            var clienteReturn = _remedioService.Atualizar(remedio);
            
            if (!SaveChanges())
            {
                AdicionarErrosValidacao(remedio.ValidationResult, "Ocorreu um erro no momento de salvar os dados no banco.");
            }
            return remedioViewModel;
        }

        public void Remover(Guid id)
        {
            _remedioService.Remover(id);
        }

        public void Dispose()
        {
            _remedioRepository.Dispose();
        }
    }
}