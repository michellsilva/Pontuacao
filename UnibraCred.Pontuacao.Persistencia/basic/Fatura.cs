using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnibraCred.Pontuacao.Persistencia.basic
{
    public class Fatura
    {
        public int id;
        public decimal valor;

        //Necessário para busca por cartão onde não se tem uma fatura específica.
        public int cartaoId;

    }
}
