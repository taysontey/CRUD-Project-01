using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto.Entity.Entities;
using Projeto.DAL.Persistence;
using Projeto.Web.Models;

namespace Projeto.Web.Controllers
{
    public class TimeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Cadastro()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Consulta()
        {
            var list = new List<TimeModelConsulta>();

            try
            {
                TimeDal d = new TimeDal();

                foreach (Time t in d.FindAll())
                {
                    var model = new TimeModelConsulta();
                    model.IdTime = t.IdTime;
                    model.Nome = t.Nome;
                    model.DataFundacao = t.DataFundacao.ToString("dd/MM/yyyy");

                    list.Add(model);
                }
            }
            catch (Exception e)
            {
                ViewBag.Mensagem = e.Message;
            }

            return View(list);
        }

        [HttpPost]
        public ActionResult Cadastro(TimeModelCadastro model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Time t = new Time();
                    t.Nome = model.Nome;
                    t.DataFundacao = model.DataFundacao;

                    TimeDal d = new TimeDal();
                    d.Insert(t);

                    ViewBag.Mensagem = "Time " + t.Nome + ", cadastrado com sucesso.";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.Mensagem = "Preencha os campos corretamente.";
                }
            }
            catch (Exception e)
            {
                ViewBag.Mensagem = e.Message;
            }
            return View();
        }

        public ActionResult Editar(int id)
        {
            var model = new TimeModelEdicao();

            try
            {
                TimeDal d = new TimeDal();
                Time t = d.FindById(id);

                if (t != null)
                {
                    model.IdTime = t.IdTime;
                    model.Nome = t.Nome;
                    model.DataFundacao = t.DataFundacao;
                }
            }
            catch (Exception e)
            {
                ViewBag.Mensagem = e.Message;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(TimeModelEdicao model)
        {
            try
            {
                Time t = new Time();
                t.IdTime = model.IdTime;
                t.Nome = model.Nome;
                t.DataFundacao = model.DataFundacao;

                TimeDal d = new TimeDal();
                d.Update(t);
            }
            catch (Exception e)
            {
                ViewBag.Mensagem = e.Message;
            }

            return RedirectToAction("Consulta");
        }

        public ActionResult Excluir(int id)
        {
            try
            {
                TimeDal d = new TimeDal();
                d.Delete(d.FindById(id));

                ViewBag.Mensagem = "Time excluído com sucesso.";
            }
            catch (Exception e)
            {
                ViewBag.Mensagem = e.Message;
            }

            return RedirectToAction("Consulta");
        }
    }
}