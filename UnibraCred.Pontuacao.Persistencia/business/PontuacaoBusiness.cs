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
         MovimentacaoPontosDAO pd = new MovimentacaoPontosDAO();
        TaxaConversaoDAO td = new TaxaConversaoDAO();


        public String obterTotalPontos(int numFatura)
        {
            pd = new MovimentacaoPontosDAO();
            String retorno = null;

            try
            {
                return pd.obterTotalPontos(numFatura);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return retorno;
        }
       
        public PontuacaoSet pontosPorFatura(int faturaId)
        {
            PontuacaoSet pontuacao = new PontuacaoSet();
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
            TaxaConversaoSet taxaConversao = td.obterTaxaConversaoAtual();

        }

        public bool faturaCadastrada(int faturaId)
        {
            if(pd.obterPontuacaoPorFatura(faturaId)!=null){
                return true;
            }
            return false;
        }

       
    }
}
