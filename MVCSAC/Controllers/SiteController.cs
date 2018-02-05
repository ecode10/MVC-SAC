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
    public class SiteController : Controller
    {
        iSACContext db = new iSACContext();

        //
        // GET: /Site/

        public ActionResult Index()
        {
            var site = db.Sites.ToList();
            return View(site);
        }

        //
        // GET: /Site/Details/5

        public ActionResult Details(int id)
        {
            var sites = db.Sites.Find(id);
            return View(sites);
        }

        //
        // GET: /Site/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Site/Create

        [HttpPost]
        public ActionResult Create(Site site)
        {
            db.Sites.Add(site);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        //
        // GET: /Site/Edit/5

        public ActionResult Edit(int id)
        {
            var site = db.Sites.Find(id);
            return View(site);
        }

        //
        // POST: /Site/Edit/5

        [HttpPost]
        public ActionResult Edit(Site site)
        {
            db.Entry(site).State = System.Data.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
            
        }

        //
        // GET: /Site/Delete/5

        public ActionResult Delete(int id)
        {
            var sites = db.Sites.Find(id);
            return View(sites);
        }

        //
        // POST: /Site/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Site site)
        {
            var sites = db.Sites.Find(id);
            db.Entry(sites).State = System.Data.EntityState.Deleted;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
