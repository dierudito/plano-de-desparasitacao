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
    public class ProtocoloLuaAppService: AppServiceBase, IProtocoloLuaAppService
    {
        private readonly IProtocoloLuaRepository _protocoloLuaRepository;
        private readonly IProtocoloLuaService _protocoloLuaService;

        public ProtocoloLuaAppService(IUnitOfWork uow, IProtocoloLuaService protocoloLuaService, IProtocoloLuaRepository protocoloLuaRepository) : base(uow)
        {
            _protocoloLuaService = protocoloLuaService;
            _protocoloLuaRepository = protocoloLuaRepository;
        }



        public ProtocoloLuaViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<ProtocoloLuaViewModel>(_protocoloLuaRepository.ObterPorId(id));
        }

        public int ObterProximoNumeroDaLua(LuaViewModel lua)
        {
            var protocolos = ObterPorLua(lua).ToList();
            if (!protocolos.Any()) return 1;

            var ultimoNumero = protocolos.Max(p => p.Numero);

            return ++ultimoNumero;
        }

        public IEnumerable<ProtocoloLuaViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<ProtocoloLuaViewModel>>(_protocoloLuaRepository.ObterTodos().OrderBy(p => p.Lua));
        }

        public IEnumerable<ProtocoloLuaViewModel> ObterPorLua(LuaViewModel lua)
        {
            var luaModel = Mapper.Map<Lua>(lua);
            return Mapper.Map<IEnumerable<ProtocoloLuaViewModel>>(_protocoloLuaRepository.ObterPorLua(luaModel));
        }

        public ProtocoloLuaTratamentoViewModel Adicionar(ProtocoloLuaTratamentoViewModel protocoloLuaTratamentoViewModel)
        {
            var protocoloLua = Mapper.Map<ProtocoloLua>(protocoloLuaTratamentoViewModel.ProtocoloLua);

            foreach (var tratamentoDoDiaDoProtocoloDaLuaViewModel in protocoloLuaTratamentoViewModel.DiasDoProtocolo)
            {
                var diaProtocolo = Mapper.Map<DiaProtocoloLua>(tratamentoDoDiaDoProtocoloDaLuaViewModel.DiaProtocolo);

                foreach (var remedioParaAdministrarViewModel in tratamentoDoDiaDoProtocoloDaLuaViewModel.RemediosParaAdministrar)
                {
                    var remedio = Mapper.Map<Remedio>(remedioParaAdministrarViewModel.Remedio);
                    var administracao =
                        Mapper.Map<AdministracaoRemedio>(remedioParaAdministrarViewModel.AdministracaoRemedio);
                    remedio.AdicionarAdministracaoRemedio(administracao);
                    diaProtocolo.AdicionarAdministracaoRemedio(administracao);
                }
                protocoloLua.AdicionarDiaProtocoloLua(diaProtocolo);
            }

            var protocoloLuaReturn = _protocoloLuaService.Adicionar(protocoloLua);
            if (protocoloLuaReturn.ValidationResult.IsValid)
            {
                if(!SaveChanges()) AdicionarErrosValidacao(protocoloLua.ValidationResult, "Ocorreu um erro no momento de salvar os dados no banco");
            }

            protocoloLuaTratamentoViewModel.ProtocoloLua.ValidationResult = protocoloLuaReturn.ValidationResult;
            return protocoloLuaTratamentoViewModel;
        }
        public ProtocoloLuaViewModel Atualizar(ProtocoloLuaViewModel protocoloLuaViewModel)
        {
            var protocoloLua = Mapper.Map<ProtocoloLua>(protocoloLuaViewModel);

            if (!protocoloLua.EhValido()) return protocoloLuaViewModel;

            var protocoloLuaReturn = _protocoloLuaService.Atualizar(protocoloLua);

            if (protocoloLuaReturn.ValidationResult.IsValid)
            {
                if(!SaveChanges()) AdicionarErrosValidacao(protocoloLua.ValidationResult, "Ocorreu um erro no momento de salvar os dados no banco");
            }

            protocoloLuaViewModel.ValidationResult = protocoloLuaReturn.ValidationResult;
            return protocoloLuaViewModel;
        }

        public void Remover(Guid id)
        {
            _protocoloLuaService.Remover(id);
            
        }

        public void Dispose()
        {
            _protocoloLuaRepository.Dispose();
        }
    }
}