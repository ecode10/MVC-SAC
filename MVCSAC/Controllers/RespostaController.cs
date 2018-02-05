using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSAC.Models;
using MVCSAC.DAL;
using System.Text;
using System.Data.SqlClient;

namespace MVCSAC.Controllers
{
    [Authorize]
    public class RespostaController : Controller
    {
        private iSACContext db = new iSACContext();

        //
        // GET: /Resposta/

        public ActionResult Index()
        {
            return View(db.Respostas.ToList());
        }

        //
        // GET: /Resposta/Details/5

        public ActionResult Details(int id = 0)
        {
            Chamado chamado = db.Chamados.Find(id);

            StringBuilder str = new StringBuilder();
            str.Append(@"SELECT * FROM Respostas, Usuarios WHERE Respostas.CHUsu = Usuarios.CHUsu and CHChamado = @chamado");

            IDataParameter parameter = new SqlParameter();
            parameter.DbType = DbType.Int32;
            parameter.ParameterName = "@chamado";
            parameter.Value = chamado.CHChamado;

            var resposta = db.Database.SqlQuery<Resposta>(str.ToString(), parameter).ToList();
            if (resposta == null)
            {
                return HttpNotFound();
            }
            return View(resposta);
        }

        //
        // GET: /Resposta/Create

        public ActionResult Create(int id)
        {
            var chamado = db.Chamados.Find(id);
            ViewBag.ChaveChamado = id;

            return View();
        }
        
        /*public ActionResult Create(int id)
        {
            var chamado = db.Chamados.Find(id);
            Resposta r = new Resposta();
            r.CHChamado = chamado.CHChamado;
            return View();
        }*/

        //
        // POST: /Resposta/Create

        [HttpPost]
        public ActionResult Create(Resposta resposta)
        {
            db.Respostas.Add(resposta);
            db.SaveChanges();
            return RedirectToAction("../Chamado");
        }

        //
        // GET: /Resposta/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Resposta resposta = db.Respostas.Find(id);
            if (resposta == null)
            {
                return HttpNotFound();
            }
            return View(resposta);
        }

        //
        // POST: /Resposta/Edit/5

        [HttpPost]
        public ActionResult Edit(Resposta resposta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resposta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(resposta);
        }

        //
        // GET: /Resposta/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Resposta resposta = db.Respostas.Find(id);
            if (resposta == null)
            {
                return HttpNotFound();
            }
            return View(resposta);
        }

        //
        // POST: /Resposta/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Resposta resposta = db.Respostas.Find(id);
            db.Respostas.Remove(resposta);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}