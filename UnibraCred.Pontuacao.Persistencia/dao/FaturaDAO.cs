using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnibraCred.Pontuacao.Persistencia.basic;
using UnibraCred.Pontuacao.Persistencia.interfaces;

namespace UnibraCred.Pontuacao.Persistencia.dao
{
    public class FaturaDAO : IFaturaDAO
    {
        public Fatura obterFatura(int idFatura)
        {
            //Consumir webService de Fatura para obter informações da fatura
            IList faturas = new List<Fatura>();
            Fatura fatura1 = new Fatura { valor = 10, id = 1 };
            Fatura fatura2 = new Fatura { valor = 30, id = 2 };
            Fatura fatura3 = new Fatura { valor = 5, id = 3 };
            Fatura fatura4 = new Fatura { valor = 6, id = 4 };
            Fatura fatura5 = new Fatura { valor = 8, id = 5 };
            Fatura fatura6 = new Fatura { valor = 15, id = 6 };
            Fatura fatura7 = new Fatura { valor = 25, id = 7 };

            faturas.Add(fatura1);
            faturas.Add(fatura2);
            faturas.Add(fatura3);
            faturas.Add(fatura4);
            faturas.Add(fatura5);
            faturas.Add(fatura6);
            faturas.Add(fatura7);

            foreach (Fatura fatura in faturas)
            {
                if (fatura.id == idFatura)
                {
                    return fatura;
                }
            }

            return null;

        }
    }
}
