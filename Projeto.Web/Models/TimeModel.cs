using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Web.Models
{
    public class TimeModelCadastro
    {
        [Required(ErrorMessage = "Por favor, informe o nome do time.")]
        [Display(Name = "Nome:")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data de fundação do time.")]
        [Display(Name = "Data de Fundação:")]
        public DateTime DataFundacao { get; set; }
    }

    public class TimeModelConsulta
    {
        public int IdTime { get; set; }
        public string Nome { get; set; }
        public string DataFundacao { get; set; }
    }

    public class TimeModelEdicao
    {
        [Required(ErrorMessage = "Por favor, informe o nome do time.")]
        [Display(Name = "Nome:")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data de fundação do time.")]
        [Display(Name = "Data de Fundação:")]
        public DateTime DataFundacao { get; set; }
    }
}