using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnibraCred.Pontuacao.Entity;

namespace UnibraCred.Pontuacao.Persistencia.dao
{
    public class PontuacaoDAO
    {
        Store context;

        public List<PontuacaoFatura> obterTotalPontos(int cartaoId)
        {
            List<PontuacaoFatura> retorno = null;
            try
            {
                using (var db = new Store())
                {
                    return db.PontuacaoFatura.Where(x => x.cartao_id == cartaoId && x.dtVigencia >= DateTime.Now).ToList();
                }

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
                using (var db = new Store())
                {
                    retorno = db.PontuacaoFatura.Include("TaxaConversao").Where(x => x.cartao_id == cartaoId).ToList();
                 //   retorno = db.PontuacaoFatura.Where(x => x.cartao_id == cartaoId).ToList();
                }

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return retorno;
        }



        public string pontosPorFatura(int faturaId)
        {
            return "não implementado";
        }

        public PontuacaoFatura obterPontuacaoPorFatura(int faturaId)
        {
            context = new Store();

            try
            {
                using (context)
                {
                    var query = from p in context.PontuacaoFatura where p.fatura_id == faturaId select p;
                    foreach (var item in query)
                    {
                        return item;
                    }
                    context.Dispose();
                    return null;
                }
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                context.Dispose();
            }
        }

        public PontuacaoFatura obterPontuacao(int pontuacaoId)
        {
            context = new Store();

            try
            {
                using (context)
                {
                    var query = from p in context.PontuacaoFatura where p.fatura_id == pontuacaoId select p;
                    foreach (var item in query)
                    {
                        return item;
                    }
                    context.Dispose();
                    return null;
                }
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                context.Dispose();
            }
        }



    }
}
