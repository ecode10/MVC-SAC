using MVCSAC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSAC.Controllers
{
    public class CascadeController : Controller
    {
        iSACContext db = new iSACContext();

        //
        // GET: /Cascade/

        public ActionResult Index()
        {
            var query = db.Paises.Select(c => new { c.CHPais, c.NOPais });
            ViewBag.cmbPaises = new SelectList(query.AsEnumerable(), "CHPais", "NOPais");

            return View();
        }

        public ActionResult SearchEstado(String id)
        {
            long _chave = long.Parse(id);
            var estados = from s in db.Estados
                          where s.CHPais == _chave
                          select s;

            //ViewBag.cmbEstados = new SelectList(estados.AsEnumerable(), "CHEstado", "NOEstado");

            if (HttpContext.Request.IsAjaxRequest())
            {
                return Json(new SelectList(estados.ToArray(), "CHEstado", "NOEstado"),
                    JsonRequestBehavior.AllowGet);
            }
            return View("Index");
        }

        public ActionResult SearchCidade(String id)
        {
            long _chave = long.Parse(id);
            var cidades = from s in db.Cidades
                          where s.CHEstado == _chave
                          select s;

            //ViewBag.cmbCidade = new SelectList(cidades.AsEnumerable(), "CHCidade", "NOCidade");

            if (HttpContext.Request.IsAjaxRequest())
            {
                return Json(new SelectList(cidades.ToArray(), "CHCidade", "NOCidade"),
                    JsonRequestBehavior.AllowGet);
            }
            return View("Index");
        }

        //
        // GET: /Cascade/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Cascade/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Cascade/Create

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

        //
        // GET: /Cascade/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Cascade/Edit/5

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

        //
        // GET: /Cascade/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Cascade/Delete/5

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
