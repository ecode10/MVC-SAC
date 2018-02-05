using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSAC.Models;
using MVCSAC.DAL;

namespace MVCSAC.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        iSACContext db = new iSACContext();

        // GET: /Usuario/

        public ActionResult Index()
        {
            var usuario = db.Usuarios.ToList();
            return View(usuario);
        }

        //
        // GET: /Usuario/Details/5

        public ActionResult Details(int id)
        {
            var usu = db.Usuarios.Find(id);
            return View(usu);
        }

        //
        // GET: /Usuario/Create

        public ActionResult Create()
        {
            //IEnumerable<SelectListItem> items = siteDb.Sites
            //    .Select(c => new SelectListItem
            //    {
            //        Value = c.CHSite.ToString(),
            //        Text = c.NOSite
            //    });

            //ViewBag.ListSites = items;
            
            //criando select
            var query = db.Sites.Select(c => new { c.CHSite, c.NOSite });
            ViewBag.ListSites = new SelectList(query.AsEnumerable(), "CHSite", "NOSite");

            return View();
        }

        //
        // POST: /Usuario/Create

        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            db.Usuarios.Add(usuario);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        //
        // GET: /Usuario/Edit/5

        public ActionResult Edit(int id)
        {
            var usuarios = db.Usuarios.Find(id);

            var query = db.Sites.Where(e => e.CHSite == usuarios.CHSite);
            ViewBag.ListSites = new SelectList(query.AsEnumerable(), "CHSite", "NOSite");

            return View(usuarios);
        }

        //
        // POST: /Usuario/Edit/5

        [HttpPost]
        public ActionResult Edit(Usuario usuarios)
        {
            //var usuario = db.Usuarios.Find(id);
            db.Entry(usuarios).State = System.Data.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
            
        }

        //
        // GET: /Usuario/Delete/5

        public ActionResult Delete(int id)
        {
            var usuario = db.Usuarios.Find(id);
            return View(usuario);
        }

        //
        // POST: /Usuario/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Usuario usuarios)
        {
            var usuario = db.Usuarios.Find(id);
            db.Entry(usuario).State = System.Data.EntityState.Deleted;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
