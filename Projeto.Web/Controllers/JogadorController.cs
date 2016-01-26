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
            var model = new List<JogadorModelConsulta>();

            try
            {
                JogadorDal d = new JogadorDal();

                foreach (Jogador j in d.FindAll())
                {
                    var item = new JogadorModelConsulta();

                    item.IdJogador = j.IdJogador;
                    item.Nome = j.Nome;
                    item.Apelido = j.Apelido;
                    item.DataNascimento = j.DataNascimento.ToString("dd/MM/yyyy");
                    item.Posicao = j.Posicao;
                    item.Time = j.Time.Nome;

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
        public ActionResult Cadastro(JogadorModelCadastro model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Jogador j = new Jogador();
                    JogadorDal d = new JogadorDal();

                    j.Nome = model.Nome;
                    j.Apelido = model.Apelido;
                    j.DataNascimento = model.DataNascimento;
                    j.Posicao = model.Posicao;
                    j.IdTime = model.IdTime;

                    d.Insert(j);

                    ViewBag.Mensagem = "O jogador " + j.Nome + ", foi cadastrado com sucesso.";
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
            return View(new JogadorModelCadastro());
        }

        public ActionResult Editar(int id)
        {
            var model = new JogadorModelEdicao();

            try
            {
                JogadorDal d = new JogadorDal();
                Jogador j = d.FindById(id);

                if (j != null)
                {
                    model.IdJogador = j.IdJogador;
                    model.Nome = j.Nome;
                    model.Apelido = j.Apelido;
                    model.DataNascimento = j.DataNascimento;
                    model.Posicao = j.Posicao;
                    model.IdTime = j.IdTime;
                }
            }
            catch (Exception e)
            {
                ViewBag.Mensagem = e.Message;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(JogadorModelEdicao model)
        {
            try
            {
                Jogador j = new Jogador();
                JogadorDal d = new JogadorDal();

                j.IdJogador = model.IdJogador;
                j.Nome = model.Nome;
                j.Apelido = model.Apelido;
                j.DataNascimento = model.DataNascimento;
                j.Posicao = model.Posicao;
                j.IdTime = model.IdTime;

                d.Update(j);

                ViewBag.Mensagem = "Jogador atualizado com sucesso.";
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
                JogadorDal d = new JogadorDal();
                d.Delete(d.FindById(id));

                ViewBag.Mensagem = "Jogador excluído com sucesso.";
            }
            catch (Exception e)
            {
                ViewBag.Mensagem = e.Message;
            }

            return RedirectToAction("Consulta");
        }
    }
}