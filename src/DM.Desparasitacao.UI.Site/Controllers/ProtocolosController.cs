using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DM.Desparasitacao.Application.Interfaces;
using DM.Desparasitacao.Application.ViewModels;

namespace DM.Desparasitacao.UI.Site.Controllers
{
    [RoutePrefix("protocolos")]
    public class ProtocolosController : BaseController
    {
        private readonly IProtocoloLuaAppService _protocoloLuaAppService;
        private readonly IRemedioAppService _remedioAppService;

        public ProtocolosController(IProtocoloLuaAppService protocoloLuaAppService, IRemedioAppService remedioAppService)
        {
            _protocoloLuaAppService = protocoloLuaAppService;
            _remedioAppService = remedioAppService;
        }

        [Route("")]
        [Route("listar-todos")]
        public ActionResult Index()
        {
            return View(_protocoloLuaAppService.ObterTodos());
        }

        [Route("{id:guid}/detalhes")]
        public ActionResult Details(Guid id)
        {
            var protocoloViewModel = _protocoloLuaAppService.ObterPorId(id);

            if (protocoloViewModel == null) return HttpNotFound();

            return View(protocoloViewModel);
        }

        [Route("AtualizarFiltros")]
        [HttpPost]
        public async Task<ActionResult> AtualizarFiltrosAsync(ProtocoloLuaTratamentoViewModel protocoloLuaTratamento)
        {
            if (protocoloLuaTratamento.ProtocoloLua.Lua == 0) return PartialView("_Form", protocoloLuaTratamento);
            var remedios = _remedioAppService.ObterTodos().ToList();

            var numeroProtocolo =
                _protocoloLuaAppService.ObterProximoNumeroDaLua(protocoloLuaTratamento.ProtocoloLua.Lua);
            protocoloLuaTratamento.ProtocoloLua.Numero = numeroProtocolo;
            protocoloLuaTratamento.InstanciaSelectListsRemedio(remedios);
            return PartialView("_Form", protocoloLuaTratamento);
        }

        [Route("criar-novo")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Protocolos/Create
        [Route("criar-novo")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProtocoloLuaTratamentoViewModel protocoloLuaTratamento)
        {
            if (!ModelState.IsValid) return View(protocoloLuaTratamento);

            protocoloLuaTratamento = _protocoloLuaAppService.Adicionar(protocoloLuaTratamento);

            if (protocoloLuaTratamento.ProtocoloLua.ValidationResult.IsValid) return RedirectToAction("Index");

            PopularModelStateComErros(protocoloLuaTratamento.ProtocoloLua.ValidationResult);
            return View(protocoloLuaTratamento);
        }

        // GET: Protocolos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Protocolos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Protocolos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Protocolos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
