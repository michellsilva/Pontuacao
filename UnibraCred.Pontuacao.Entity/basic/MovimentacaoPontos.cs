using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnibraCred.Pontuacao.Entity
{
    public class MovimentacaoPontos
    {
        public int Id { get; set; }
        public int Fatura { get; set; }
        public int Tipo { get; set; }
        public int Valor { get; set; }
        public DateTime DtInclusao { get; set; }
        public DateTime? DtVencimento { get; set; }
    }
}
