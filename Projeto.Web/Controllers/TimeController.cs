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
            var model = new List<TimeModelConsulta>();

            try
            {
                TimeDal d = new TimeDal();

                foreach (Time t in d.FindAll())
                {
                    var item = new TimeModelConsulta();
                    item.IdTime = t.IdTime;
                    item.Nome = t.Nome;
                    item.DataFundacao = t.DataFundacao.ToString("dd/MM/yyyy");

                    model.Add(item);
                }
            }
            catch (Exception e)
            {
                ViewBag.Mensagem = e.Message;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Cadastro(TimeModelCadastro model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Time t = new Time();
                    TimeDal d = new TimeDal();

                    t.Nome = model.Nome;
                    t.DataFundacao = model.DataFundacao;

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
    }
}