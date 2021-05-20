using System;
using DM.Desparasitacao.Application.ViewModels;

namespace DM.Desparasitacao.Application.Interfaces
{
    public interface IAdministracaoRemedioAppService : IDisposable
    {
        AdministracaoRemedioViewModel ObterPorId(Guid id);
    }
}