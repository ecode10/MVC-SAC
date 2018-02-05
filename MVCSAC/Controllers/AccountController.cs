using MVCSAC.DAL;
using MVCSAC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCSAC.Controllers
{
    public class AccountController : Controller
    {
        private iSACContext db = new iSACContext();

        //
        // GET: /Account/

        public ActionResult Index()
        {
            return View();
        }

      
        //GET: /Account/LogOut
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            return RedirectToAction("Index", "Home");
        }



        // GET: /Account/LogOn
        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(Account model, string returnUrl)
        {
            var resposta = consultaLogOn(model);
            if (resposta.Count == 0)
            {
                ViewBag.Mensagem = "Usuário ou senha inválida, tente novamente!";
                return View();
            }
            else
            {
                //consulta perfil
                var perfil = consultaPerfil(resposta);

                if (perfil != null)
                    Session.Add("PerfilUsu", perfil[0]);

                FormsAuthentication.SetAuthCookie(model.Usuario, false /* createPersistentCookie */);

                Session.Add("Usuario", model.Usuario);
                Session.Add("ChaveUsuario", resposta[0].ToString());


                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        private List<string> consultaPerfil(List<int> resposta)
        {
            StringBuilder str = new StringBuilder();
            str.Append(@"SELECT PerfilUsu FROM Usuarios WHERE CHUsu = @CHUsu");

            IDataParameter parameter = new SqlParameter();
            parameter.DbType = DbType.String;
            parameter.ParameterName = "@CHUsu";
            parameter.Value = resposta[0];

            var perfil = db.Database.SqlQuery<String>(str.ToString(), parameter).ToList();
            return perfil;
        }

        private List<int> consultaLogOn(Account model)
        {
            StringBuilder str = new StringBuilder();
            str.Append(@"SELECT CHUsu FROM Usuarios WHERE EMUsu = @EMUsu AND PWUsu = @PWUsu");

            IDataParameter parameter = new SqlParameter();
            parameter.DbType = DbType.String;
            parameter.ParameterName = "@EMUsu";
            parameter.Value = model.Usuario;

            IDataParameter parameter1 = new SqlParameter();
            parameter1.DbType = DbType.String;
            parameter1.ParameterName = "@PWUsu";
            parameter1.Value = model.Senha;

            var resposta = db.Database.SqlQuery<Int32>(str.ToString(), parameter, parameter1).ToList();
            return resposta;
        }


        //
        // GET: /Account/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Account/Create

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

    }
}
