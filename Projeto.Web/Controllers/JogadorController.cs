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
    public class JogadorController : Controller
    {
        [AllowAnonymous]
        public ActionResult Cadastro()
        {
            return View(new JogadorModelCadastro());
        }

        [AllowAnonymous]
        public ActionResult Consulta()
        {
            return View();
        }
    }
}