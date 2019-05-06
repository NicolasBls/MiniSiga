using MiniSIGA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniSIGA.Controllers
{
    public class PessoaController : Controller
    {
        MiniSigaEntities db = new MiniSigaEntities();

        [Authorize]
        public ActionResult Listar()
        {
            var lista = db.Pessoa.ToList();

            return View(lista);
        }
        [Authorize]
        public ActionResult Criar()
        {
        
            return View();
        }
        [HttpPost]
        public ActionResult Criar(Pessoa pessoa)
        {
            pessoa.PessoaAcessoId = Convert.ToInt32(HttpContext.User.Identity.Name);
            pessoa.DataCadastro = DateTime.Now.Date;
            db.Pessoa.Add(pessoa);
            db.SaveChanges();
            return RedirectToAction("Documento", new { pessoa.PessoaId } );
        }
        [Authorize]
        public ActionResult Documento (int PessoaId)
        {
            var pessoa = db.Pessoa.FirstOrDefault(x => x.PessoaId == PessoaId);
            ViewBag.nome = pessoa.Nome;
            ViewBag.id = PessoaId;
            return View();
        }

        [HttpPost]
        public ActionResult Documento(string numeroRg, DateTime DataExpedicao, string OrgaoExpedidor, string numeroCPF, int pessoaId)
        {
            Documento documento1 = new Documento {
                DataExpedicao = DataExpedicao,
                Numero = numeroRg,
                OrgaoExpedidor = OrgaoExpedidor,
                PessoaId = pessoaId,
                StatusId = 2,
                DocumentoTipoId =2
                
            };
            Documento documento2 = new Documento {
                Numero = numeroCPF,
                PessoaId = pessoaId,
                StatusId = 2,
                DocumentoTipoId = 3
            };

            db.Documento.Add(documento1);
            db.Documento.Add(documento2);
            db.SaveChanges();
            return RedirectToAction("Listar");

        }
    }
}