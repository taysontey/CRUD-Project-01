using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using Projeto.Entity.Entities;
using Projeto.DAL.Persistence;

namespace Projeto.Web.Models
{
    public class JogadorModelCadastro
    {
        [Required(ErrorMessage = "Por favor, informe o nome do jogador.")]
        [Display(Name = "Nome:")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe o apelido do jogador.")]
        [Display(Name = "Apelido:")]
        public string Apelido { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data de nascimento do jogador.")]
        [Display(Name = "Data de Nascimento:")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Por favor, informe a posição do jogador.")]
        [Display(Name = "Posição:")]
        public string Posicao { get; set; }

        [Required(ErrorMessage = "Selecione o time desejado.")]
        [Display(Name = "Selecione um Time:")]
        public int IdTime { get; set; }

        //dropdown para escolher os times
        public List<SelectListItem> DropDownTimes
        {
            get
            {
                try
                {
                    List<SelectListItem> lista = new List<SelectListItem>();
                    TimeDal d = new TimeDal();

                    foreach (Time t in d.FindAll())
                    {
                        SelectListItem item = new SelectListItem();
                        item.Value = t.IdTime.ToString();
                        item.Text = t.Nome;

                        lista.Add(item);
                    }
                    return lista;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }
    }

    public class JogadorModelConsulta
    {
        public int IdJogador { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string DataNascimento { get; set; }
        public string Posicao { get; set; }
        public string Time { get; set; }
    }
}