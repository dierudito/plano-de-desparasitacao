using System;
using DM.Desparasitacao.Domain.Interfaces;
using DM.Desparasitacao.Domain.Models;

namespace DM.Desparasitacao.Domain.Services
{
    public class AdministracaoRemedioService: IAdministracaoRemedioService
    {
        private readonly IAdministracaoRemedioRepository _administracaoRemedioRepository;

        public AdministracaoRemedioService(IAdministracaoRemedioRepository administracaoRemedioRepository)
        {
            _administracaoRemedioRepository = administracaoRemedioRepository;
        }

        public AdministracaoRemedio Adicionar(AdministracaoRemedio administracaoRemedio)
        {
            if (!administracaoRemedio.EhValido()) return administracaoRemedio;
            

            if (administracaoRemedio.ValidationResult.IsValid) _administracaoRemedioRepository.Adicionar(administracaoRemedio);

            return administracaoRemedio;
        }

        public AdministracaoRemedio Atualizar(AdministracaoRemedio administracaoRemedio)
        {
            if (!administracaoRemedio.EhValido()) return administracaoRemedio;

            _administracaoRemedioRepository.Atualizar(administracaoRemedio);
            return administracaoRemedio;
        }

        public void Remover(Guid id)
        {
            _administracaoRemedioRepository.Remover(id);
        }

        public void Dispose()
        {
            _administracaoRemedioRepository.Dispose();
        }
    }
}