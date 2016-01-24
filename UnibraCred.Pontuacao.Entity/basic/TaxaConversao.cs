using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnibraCred.Pontuacao.Entity.basic
{
    public class TaxaConversao
    {
        public int Id { get; set; }
        public decimal taxa { get; set; }
        public DateTime DtValidade { get; set; }
    }
}
