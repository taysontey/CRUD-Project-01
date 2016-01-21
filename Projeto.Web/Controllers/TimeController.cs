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
            return View();
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