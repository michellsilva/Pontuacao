using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnibraCred.Pontuacao.Persistencia.basic
{
    public class FaturaDetalhada
    {
        public int fatura_id { get; set; }
        public string tipo { get; set; }
        public int pontosQtd { get; set; }
        public int cartao_id { get; set; }
        public DateTime dtVigencia { get; set; }

    }
}
