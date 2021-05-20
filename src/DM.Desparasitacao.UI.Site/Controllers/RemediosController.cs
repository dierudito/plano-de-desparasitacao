using System;
using System.Web.Mvc;
using DM.Desparasitacao.Application.Interfaces;
using DM.Desparasitacao.Application.ViewModels;

namespace DM.Desparasitacao.UI.Site.Controllers
{
    [RoutePrefix("remedio")]
    public class RemediosController : BaseController
    {
        private readonly IRemedioAppService _remedioAppService;

        public RemediosController(IRemedioAppService remedioAppService)
        {
            _remedioAppService = remedioAppService;
        }


        [Route("")]
        [Route("listar-todos")]
        public ActionResult Index()
        {
            return View(_remedioAppService.ObterTodos());
        }

        [Route("{id:guid}/detalhes")]
        public ActionResult Details(Guid id)
        {
            var remedioViewModel = _remedioAppService.ObterPorId(id);

            if (remedioViewModel == null) return HttpNotFound();

            return View(remedioViewModel);
        }

        [Route("criar-novo")]
        public ActionResult Create()
        {
            return View();
        }
        
        [Route("criar-novo")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RemedioViewModel remedio)
        {
            if (!ModelState.IsValid) return View(remedio);

            remedio = _remedioAppService.Adicionar(remedio);
            if (remedio.ValidationResult.IsValid) return RedirectToAction("Index");

            PopularModelStateComErros(remedio.ValidationResult);
            return View(remedio);
        }

        [Route("{id:guid}/editar")]
        public ActionResult Edit(Guid id)
        {
            var remedioViewModel = _remedioAppService.ObterPorId(id);

            if (remedioViewModel == null) return HttpNotFound();
            return View(remedioViewModel);
        }

        [Route("{id:guid}/editar")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RemedioViewModel remedio)
        {
            if (!ModelState.IsValid) return View(remedio);

            _remedioAppService.Atualizar(remedio);

            return RedirectToAction("Index");
        }

        [Route("{id:guid}/excluir")]
        public ActionResult Delete(Guid id)
        {
            var remedioViewModel = _remedioAppService.ObterPorId(id);

            if (remedioViewModel == null) return HttpNotFound();
            return View(remedioViewModel);
        }

        [Route("{id:guid}/excluir")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _remedioAppService.Remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _remedioAppService.Dispose();
        }
    }
}
