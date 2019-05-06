using MiniSIGA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniSIGA.Controllers
{
    [Authorize]
    public class GradeController : Controller
    {
        MiniSigaEntities db = new MiniSigaEntities();
        [HttpGet]
        public ActionResult Lista()
        {
            return View();
        }

        // Curso
        [HttpGet]
        public ActionResult ListarCurso()
        {
            var lista = db.Curso.ToList();

            return View(lista);
        }
        [HttpGet]
        public ActionResult CriarCurso()
        {

            return View();
        }
        [HttpPost]
        public ActionResult CriarCurso(Curso curso)
        {
            curso.PessoaId = Convert.ToInt32(HttpContext.User.Identity.Name);
            db.Curso.Add(curso);
            db.SaveChanges();
            return RedirectToAction("ListarCurso");
        }



        //Disciplina
        [HttpGet]
        public ActionResult ListarDisciplina()
        {
            var lista = db.Disciplina.ToList();

            return View(lista);
        }
        [HttpGet]
        public ActionResult CriarDisciplina()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CriarDisciplina(Disciplina disciplina)
        {
            //var b = Convert.ToDouble(disciplina.Valor);
            //disciplina.Valor = b;
            var b = Convert.ToInt32(HttpContext.User.Identity.Name);
            disciplina.PessoaId = Convert.ToInt32(HttpContext.User.Identity.Name);
            db.Disciplina.Add(disciplina);
            db.SaveChanges();

            return RedirectToAction("ListarDisciplina");
        }


        //Matriz
        [HttpGet]
        public ActionResult ListarMatriz(int? CursoId)
        {
            var lista = db.DisciplinaCurso.ToList();
            return View(lista);
        }
        [HttpGet]
        public ActionResult CriarMatriz(int CursoId)
        {

            ViewBag.Nome = db.Curso.FirstOrDefault(x => x.CursoId == CursoId).Descricao;
            ViewBag.Curso = CursoId;
            var Disciplinas = new SelectList(db.Disciplina, "DisciplinaId", "Descricao");

            return View();
        }
        [HttpPost]
        public ActionResult CriarMatriz(DisciplinaCurso disciplinaCurso)
        {
            return RedirectToAction("ListarMatriz");
        }
    }
}
