using System;
using DM.Desparasitacao.Domain.Interfaces;
using DM.Desparasitacao.Domain.Interfaces.Repository;
using DM.Desparasitacao.Domain.Interfaces.Service;
using DM.Desparasitacao.Domain.Models;
using DM.Desparasitacao.Domain.Validations.Remedios;

namespace DM.Desparasitacao.Domain.Services
{
    public class RemedioService : IRemedioService
    {
        private readonly IRemedioRepository _remedioRepository;

        public RemedioService(IRemedioRepository remedioRepository)
        {
            _remedioRepository = remedioRepository;
        }
        public Remedio Adicionar(Remedio cliente)
        {
            if (!cliente.EhValido()) return cliente;

            cliente.ValidationResult = new RemedioEstaAptoParaCadastroValidation(_remedioRepository).Validate(cliente);

            if(cliente.ValidationResult.IsValid) _remedioRepository.Adicionar(cliente);
            return cliente;
        }

        public Remedio Atualizar(Remedio cliente)
        {
            if (!cliente.EhValido()) return cliente;

            _remedioRepository.Atualizar(cliente);
            return cliente;
        }

        public void Remover(Guid id)
        {
            _remedioRepository.Remover(id);
        }

        public void Dispose()
        {
            _remedioRepository.Dispose();
        }
    }
}