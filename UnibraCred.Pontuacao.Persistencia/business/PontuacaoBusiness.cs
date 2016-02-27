using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnibraCred.Pontuacao.Entity;
using UnibraCred.Pontuacao.Persistencia.basic;
using UnibraCred.Pontuacao.Persistencia.dao;

namespace UnibraCred.Pontuacao.Persistencia.business
{
    public class PontuacaoBusiness
    {
        PontuacaoDAO pd = new PontuacaoDAO();
        TaxaConversaoDAO tc = new TaxaConversaoDAO();
        DebitoPontosDAO dbP = new DebitoPontosDAO();

        public string validarJson(string value)
        {
            string retorno = "{status:0, response:";

            try
            {
                if (value == null)
                    retorno += "a consulta nao pode ser vazia" + "}";
                else if (value.Trim().StartsWith("{cartao_Id:") && value.Trim().EndsWith("}"))
                    retorno = null;
                else
                    retorno = "formato de entrada do JSON invalido}";
            }
            catch (Exception ex)
            {
                ex.ToString();
                retorno += "erro interno. desculpe, tente novamente" + "}";
            }
            return retorno;
        }

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

        public List<FaturaDetalhada> LitartodosDetalhes(int cartaoId)
        {

            pd = new PontuacaoDAO();
            dbP = new DebitoPontosDAO();
            List<PontuacaoFatura> listFatura = null;
            List<DebitoPontos> listDebito = null;
            List<FaturaDetalhada> faturadetalhada = new List<FaturaDetalhada>();
            try
            {
                //Falta implementar para converter em JSON
                listFatura = pd.obterTotalPontos(cartaoId);
                var minData = listFatura.Min(a => a.dtInclusao);
                listDebito = dbP.listaTotalDebitos(minData);
                FaturaDetalhada fat;

                foreach (var item in listFatura)
                {
                    fat = new FaturaDetalhada();
                    fat.cartao_id = item.cartao_id;
                    fat.fatura_id = item.fatura_id;
                    fat.dtVigencia = item.dtVigencia;
                    fat.pontosQtd = item.pontosQtd;
                    fat.tipo = "acumulo";
                    faturadetalhada.Add(fat);
                }

                foreach (var item in listDebito)
                {
                    fat = new FaturaDetalhada();
                    fat.cartao_id = item.cartao_id;
                    fat.fatura_id = item.fatura_id;
                    fat.dtVigencia = item.dtUtilizacao;
                    fat.pontosQtd = item.pontosQtd;
                    fat.tipo = "debito";
                    faturadetalhada.Add(fat);
                }

                return faturadetalhada;

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return faturadetalhada;
        }

        //Verifica quantos pontos uma fatura gerou
        public PontuacaoFatura pontosPorFatura(Fatura fatura)
        {
            PontuacaoFatura pontuacao = new PontuacaoFatura();
            if (faturaCadastrada(fatura.id))
            {
                pontuacao = pd.obterPontuacaoPorFatura(fatura.id);
                return pontuacao;
            }
            else
            {
                throw new Exception("Fatura não pontuada");
            }

        }

        public void pontuarFatura(Fatura fatura)
        {
            PontuacaoFatura pontuacao = new PontuacaoFatura();
            if (!faturaCadastrada(fatura.id))
            {
                FaturaDAO faturaDAO = new FaturaDAO();
                fatura = faturaDAO.obterFatura(fatura.id);
                if (fatura != null)
                {
                    gerarPontos(fatura);
                }
                else
                {
                    throw new Exception("Fatura não encontrada");
                }
            }
            else
            {
                throw new Exception("Pontuação já efetuada anteriormente para esta fatura");

            }
        }

        //Gera pontos e solicita inserção no BD;
        public PontuacaoFatura gerarPontos(Fatura fatura)
        {
            PontuacaoFatura pontuacaoCalculada = new PontuacaoFatura();
            TaxaConversao taxaConversao = tc.obterTaxaConversaoAtual();
            if (taxaConversao == null)
            {
                throw new Exception("Não há taxa de conversão cadastrada");
            }
            int pontos = Convert.ToInt16(taxaConversao.taxaValor * fatura.valor);
            pontuacaoCalculada.pontosQtd = pontos;
            //pontuacaoCalculada. = fatura.valor;
            pontuacaoCalculada.TaxaConversao = taxaConversao;
            pontuacaoCalculada.dtInclusao = DateTime.Now;
            pontuacaoCalculada.dtVigencia = DateTime.Now.AddDays(365);
            pontuacaoCalculada.cartao_id = fatura.cartaoId;
            pontuacaoCalculada.fatura_id = fatura.id;


            return pd.inserirPontuacao(pontuacaoCalculada);
        }

        //Verifica se já houve pontuação para a fatura solicitada.
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
