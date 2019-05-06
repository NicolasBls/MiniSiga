using MiniSIGA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MiniSIGA.Controllers
{
    public class LoginController : Controller
    {
        MiniSigaEntities bd = new MiniSigaEntities();
        [HttpPost]
        public ActionResult Login(string usuario, string senha)
        {
            var usu = bd.Pessoa.FirstOrDefault(x => x.Email == usuario && x.Senha == senha);
            if (usu!= null)
            {
                FormsAuthentication.SetAuthCookie(usu.PessoaId.ToString(), true);
                return RedirectToAction("Relatorio","Home",null);
            };
            
             return RedirectToAction("Index", "Home");

           
        }
    }
}