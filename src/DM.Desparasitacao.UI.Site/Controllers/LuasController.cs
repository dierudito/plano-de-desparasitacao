using System;
using System.Web.Mvc;
using DM.Desparasitacao.Application.Interfaces;
using DM.Desparasitacao.Application.ViewModels;

namespace DM.Desparasitacao.UI.Site.Controllers
{
    [RoutePrefix("luas")]
    public class LuasController : BaseController
    {
        private readonly IFaseDaLuaAppService _faseDaLuaAppService;

        public LuasController(IFaseDaLuaAppService faseDaLuaAppService)
        {
            _faseDaLuaAppService = faseDaLuaAppService;
        }


        [Route("")]
        [Route("listar-todos")]
        public ActionResult Index()
        {
            return View(_faseDaLuaAppService.ObterTodos());
        }

        //[ClaimsAuthorize("Clientes", "DE")]
        [Route("{id:guid}/detalhes")]
        public ActionResult Details(Guid id)
        {
            var faseLuaViewModel = _faseDaLuaAppService.ObterPorId(id);

            if (faseLuaViewModel == null) return HttpNotFound();

            return View(faseLuaViewModel);
        }

        //[ClaimsAuthorize("Clientes", "IN")]
        [Route("criar-novo")]
        public ActionResult Create()
        {
            return View();
        }

        //[ClaimsAuthorize("Clientes", "IN")]
        [Route("criar-novo")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FaseDaLuaViewModel faseDaLua)
        {
            if (!ModelState.IsValid) return View(faseDaLua);

            faseDaLua = _faseDaLuaAppService.Adicionar(faseDaLua);

            if (faseDaLua.ValidationResult.IsValid) return RedirectToAction("Create");

            PopularModelStateComErros(faseDaLua.ValidationResult);
            return View(faseDaLua);
        }

        //[ClaimsAuthorize("Clientes", "ED")]
        [Route("{id:guid}/editar")]
        public ActionResult Edit(Guid id)
        {
            var faseLuaViewModel = _faseDaLuaAppService.ObterPorId(id);

            if (faseLuaViewModel == null) return HttpNotFound();

            return View(faseLuaViewModel);
        }

        //[ClaimsAuthorize("Clientes", "ED")]
        [Route("{id:guid}/editar")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FaseDaLuaViewModel faseLuaViewModel)
        {
            if (!ModelState.IsValid) return View(faseLuaViewModel);

            _faseDaLuaAppService.Atualizar(faseLuaViewModel);

            return RedirectToAction("Index");
        }

        //[ClaimsAuthorize("Clientes", "EX")]
        [Route("{id:guid}/excluir")]
        public ActionResult Delete(Guid id)
        {
            var faseLuaViewModel = _faseDaLuaAppService.ObterPorId(id);

            if (faseLuaViewModel == null) return HttpNotFound();

            return View(faseLuaViewModel);
        }

        //[ClaimsAuthorize("Clientes", "EX")]
        [Route("{id:guid}/excluir")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _faseDaLuaAppService.Remover(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _faseDaLuaAppService.Dispose();
        }
    }
}