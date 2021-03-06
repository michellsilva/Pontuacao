﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnibraCred.Pontuacao.Entity;

namespace UnibraCred.Pontuacao.Persistencia.dao
{
    public class DebitoPontosDAO
    {
        Store context;

        public int totalDebitos(Nullable<DateTime> dtInicial)
        {
            int retorno = 0;

            try
            {
                using (var db = new Store())
                {
                    retorno = db.DebitoPontos.Where(x => x.dtUtilizacao >= dtInicial).Sum(a => a.pontosQtd);
                }
            }
            catch (Exception ex)
            {
                
                ex.ToString();
            }

            return retorno;
        }

        public List<DebitoPontos> listaTotalDebitos(Nullable<DateTime> dtInicial)
        {
            List<DebitoPontos> retorno = new List<DebitoPontos>();

            try
            {
                using (var db = new Store())
                {
                    retorno = db.DebitoPontos.Where(x => x.dtUtilizacao >= dtInicial).ToList();
                }
            }
            catch (Exception ex)
            {

                ex.ToString();
            }

            return retorno;
        }
    }
}
