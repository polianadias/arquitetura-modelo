using ArquiteturaModelo.Aplicacao.Interfaces;
using ArquiteturaModelo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;

namespace ArquiteturaModelo.Apresentacao.UI.MVC.Controllers
{
    public class ProdutoController : Controller
    {

        // GET: Produto
        public ActionResult Index()
        {
            using (var _http = new HttpClient { BaseAddress = new Uri("http://localhost:60283/") })
            {
                var response = _http.GetAsync("api/produto").Result;
                if (!response.IsSuccessStatusCode) return View("Ops! Tente mais tarde!");
                return View(response.Content.ReadAsAsync<IEnumerable<Produto>>().Result);

            }
        }

        // GET: Produto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Produto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produto/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Produto/Edit/5
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

        // GET: Produto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Produto/Delete/5
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
