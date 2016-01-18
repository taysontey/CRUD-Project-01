using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entity.Entities
{
    public class Jogador
    {
        public int IdJogador { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Posicao { get; set; }
        public int IdTime { get; set; }

        #region Relacionamentos

        public virtual Time Time { get; set; }

        #endregion
    }
}
