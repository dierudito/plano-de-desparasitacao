using DM.Desparasitacao.Application.Interfaces;
using DM.Desparasitacao.Application.Services;
using DM.Desparasitacao.Domain.Interfaces;
using DM.Desparasitacao.Domain.Services;
using DM.Desparasitacao.Infra.Data.Context;
using DM.Desparasitacao.Infra.Data.Repository;
using DM.Desparasitacao.Infra.Data.UoW;
using SimpleInjector;

namespace DM.Desparasitacao.Infra.CrossCutting
{
    public class SimpleInjectionBootstrapper
    {
        // Lifestyle.Transient => Uma instancia para cada solicitacao;
        // Lifestyle.Singleton => Uma instancia unica para a classe (para o servidor)
        // Lifestyle.Scoped => Uma instancia unica para o request

        public static void Register(Container container)
        {
            // APP
            container.Register<IFaseDaLuaAppService, FaseDaLuaAppService>(Lifestyle.Scoped);

            // Domain
            container.Register<IAdministracaoRemedioService, AdministracaoRemedioService>(Lifestyle.Scoped);
            container.Register<IDiaProtocoloLuaService, DiaProtocoloLuaService>(Lifestyle.Scoped);
            container.Register<IFaseDaLuaService, FaseDaLuaService>(Lifestyle.Scoped);
            container.Register<IProtocoloLuaService, ProtocoloLuaService>(Lifestyle.Scoped);
            container.Register<IRemedioService, RemedioService>(Lifestyle.Scoped);

            // Infra
            container.Register<IAdministracaoRemedioRepository, AdministracaoRemedioRepository>(Lifestyle.Scoped);
            container.Register<IDiaProtocoloLuaRepository, DiaProtocoloLuaRepository>(Lifestyle.Scoped);
            container.Register<IFaseDaLuaRepository, FaseDaLuaRepository>(Lifestyle.Scoped);
            container.Register<IProtocoloLuaRepository, ProtocoloLuaRepository>(Lifestyle.Scoped);
            container.Register<IRemedioRepository, RemedioRepository>(Lifestyle.Scoped);

            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<DesparasitacaoContext>(Lifestyle.Scoped);
        }
    }
}
