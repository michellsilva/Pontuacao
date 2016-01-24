using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnibraCred.Pontuacao.Entity;
using UnibraCred.Pontuacao.Persistencia;
using UnibraCred.Pontuacao.Persistencia.business;

namespace UnibraCred.Pontuacao.Facade
{
    public partial class Fachada
    {
        private PontuacaoBusiness pontuacaoBusiness;

        public Fachada()
        {
            pontuacaoBusiness = new PontuacaoBusiness();
        }



        public String obterTotalPontos(int numFatura)
        {
            try
            {
                return pontuacaoBusiness.obterTotalPontos(numFatura);
            }
            catch (Exception ex)
            {

                ex.ToString();
            }
            return null;
        }

        public PontuacaoSet pontosPorFatura(int faturaId)
        {
            return pontuacaoBusiness.pontosPorFatura(faturaId);
        }
    }
}
