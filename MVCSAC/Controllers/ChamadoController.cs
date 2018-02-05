using MVCSAC.DAL;
using MVCSAC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSAC.Controllers
{
    [Authorize]
    public class ChamadoController : Controller
    {
        iSACContext db = new iSACContext();


        //
        // GET: /Chamado/All
        public ActionResult All()
        {
            var chamado = db.Chamados.OrderByDescending(x => x.CHChamado).ToList();
            return View(chamado);
        }

        //
        // GET: /Chamado/
        public ActionResult Index()
        {
            var chaveUsuario = Convert.ToInt32(Session["ChaveUsuario"]);

            var chamado = db.Chamados.Where(e => e.CHUsu == chaveUsuario).OrderByDescending(x => x.CHChamado).ToList();
            return View(chamado);
        }

        //
        // GET: /Chamado/Details/5

        public ActionResult Details(int id)
        {
            var chamados = db.Chamados.Find(id);
            return View(chamados);
        }

        //
        // GET: /Chamado/Create

        public ActionResult Create()
        {
            /*IList<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "Ativo", Value = "A" });
            items.Add(new SelectListItem { Text = "Inativo", Value = "I" });
            */

            /*var item = new SelectList(new List<Object> {
                new { value = 0, text = "Red" },
                new { value = 1, text="Blue" }
            }, "Valor", "Descricao");
            */

            IList<string> items = new List<string>();
            items.Add("--Selecione--");
            items.Add("Ativo");
            items.Add("Inativo");

            ViewBag.ListSituacao = new SelectList(items);
            ViewBag.Usuario = (String)Session["Usuario"];


            return View();
        }

        //
        // POST: /Chamado/Create

        [HttpPost]
        public ActionResult Create(Chamado chamado)
        {
            if (chamado.SITChamado.Equals("Ativo"))
                chamado.SITChamado = "A";
            else
                chamado.SITChamado = "I";

            chamado.CHUsu = Convert.ToInt32(Session["ChaveUsuario"]);

            // TODO: Add insert logic here
            db.Chamados.Add(chamado);
            db.SaveChanges();

            if (Session["PerfilUsu"] != null && Session["PerfilUsu"].Equals("A"))
                return RedirectToAction("All");
            else
                return RedirectToAction("Index");
        }

        //
        // GET: /Chamado/Edit/5

        public ActionResult Edit(int id)
        {
            ViewBag.Usuario = (String)Session["Usuario"];

            var chamados = db.Chamados.Find(id);
            return View(chamados);
        }

        //
        // POST: /Chamado/Edit/5

        [HttpPost]
        public ActionResult Edit(Chamado chamado)
        {
            try
            {
                chamado.CHUsu = Convert.ToInt32(Session["ChaveUsuario"]);

                // TODO: Add update logic here
                db.Entry(chamado).State = System.Data.EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        //
        // GET: /Chamado/Delete/5

        public ActionResult Delete(int id)
        {
            var chamados = db.Chamados.Find(id);
            return View(chamados);
        }

        //
        // POST: /Chamado/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Chamado _chamados)
        {
            try
            {
                // TODO: Add delete logic here
                var chamado = db.Chamados.Find(id);
                db.Entry(chamado).State = System.Data.EntityState.Deleted;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
