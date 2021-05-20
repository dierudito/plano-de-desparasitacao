using System;
using DM.Desparasitacao.Domain.Interfaces;
using DM.Desparasitacao.Domain.Models;

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

            _remedioRepository.Adicionar(cliente);
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