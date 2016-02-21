using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnibraCred.Pontuacao.Entity;
using UnibraCred.Pontuacao.Persistencia.dao;

namespace UnibraCred.Pontuacao.Persistencia.business
{
    public class PontuacaoBusiness
    {
        PontuacaoDAO pd = new PontuacaoDAO();
        TaxaConversaoDAO tc = new TaxaConversaoDAO();
        DebitoPontosDAO dbP = new DebitoPontosDAO();

        public int obterTotalPontos(int cartaoId)
        {
            pd = new PontuacaoDAO();
            int retorno = 0;

            try
            {
                List<PontuacaoFatura> pontuacao = pd.obterTotalPontos(cartaoId);
                var total = pontuacao.Sum(a => a.pontosQtd);
                var minData = pontuacao.Min(a => a.dtInclusao);
                retorno = total - dbP.totalDebitos(minData);
                return retorno;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return retorno;
        }

        public List<PontuacaoFatura> LitartodosDetalhes(int cartaoId)
        {
            pd = new PontuacaoDAO();
            List<PontuacaoFatura> retorno = null;
            try
            {
                //Falta implementar para converter em JSON
                retorno = pd.LitartodosDetalhes(cartaoId);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return retorno;
        }

        public PontuacaoFatura pontosPorFatura(int faturaId)
        {
            PontuacaoFatura pontuacao = new PontuacaoFatura();
            if (faturaCadastrada(faturaId))
            {
                pontuacao = pd.obterPontuacaoPorFatura(faturaId);
                return pontuacao;
            }
            else
            {
                //cadastra fatura e gerar pontos
            }
            return null;
        }

        public void gerarPontos()
        {
            TaxaConversao taxaConversao = tc.obterTaxaConversaoAtual();

        }

        public bool faturaCadastrada(int faturaId)
        {
            if (pd.obterPontuacaoPorFatura(faturaId) != null)
            {
                return true;
            }
            return false;
        }


    }
}
