using System;
using DM.Desparasitacao.Application.Interfaces;
using DM.Desparasitacao.Application.ViewModels;
using DM.Desparasitacao.Domain.Interfaces;

namespace DM.Desparasitacao.Application.Services
{
    public class AdministracaoRemedioAppService : AppServiceBase, IAdministracaoRemedioAppService
    {
        private readonly IAdministracaoRemedioRepository _administracaoRemedioRepository;
        private readonly IAdministracaoRemedioService _administracaoRemedioService;

        public AdministracaoRemedioAppService(IUnitOfWork uow, IAdministracaoRemedioRepository administracaoRemedioRepository, IAdministracaoRemedioService administracaoRemedioService) : base(uow)
        {
            _administracaoRemedioRepository = administracaoRemedioRepository;
            _administracaoRemedioService = administracaoRemedioService;
        }
        public AdministracaoRemedioAppService(IUnitOfWork uow) : base(uow)
        {
        }

        public AdministracaoRemedioViewModel ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}