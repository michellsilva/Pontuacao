using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnibraCred.Pontuacao.Entity;
using UnibraCred.Pontuacao.Persistencia;
using UnibraCred.Pontuacao.Persistencia.basic;
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

        public string validarJson(string cartaoId)
        {
            string retorno = "";
            try
            {
                return pontuacaoBusiness.validarJson(cartaoId);
            }
            catch (Exception ex)
            {

                ex.ToString();
            }
            return retorno;
        }

        public int obterTotalPontos(int cartaoId)
        {
            int retorno = 0;
            try
            {
                return pontuacaoBusiness.obterTotalPontos(cartaoId);
            }
            catch (Exception ex)
            {

                ex.ToString();
            }
            return retorno;
        }

        public List<PontuacaoFatura> LitartodosDetalhes(int cartaoId)
        {
            List<PontuacaoFatura> retorno = null;
            try
            {
                retorno = pontuacaoBusiness.LitartodosDetalhes(cartaoId);
            }
            catch (Exception ex)
            {

                ex.ToString();
            }
            return retorno;
        }



        public PontuacaoFatura pontosPorFatura(Fatura fatura)
        {
            try
            {
                return pontuacaoBusiness.pontosPorFatura(fatura);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void pontuarFatura(Fatura fatura)
        {
            try
            {
                pontuacaoBusiness.pontuarFatura(fatura);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
