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

        public PontuacaoFatura inserirPontuacao(PontuacaoFatura pontuacao)
        {

            try
            {
                Store context = new Store();

                //Retirando milisegundos para evitar problema entre datetime2(app) e datetime(sql)                
                pontuacao.dtVigencia = pontuacao.dtVigencia.AddMilliseconds(-pontuacao.dtVigencia.Millisecond);
                
                PontuacaoFatura pontuacaoInserida = context.PontuacaoFatura.Add(pontuacao);
                context.SaveChanges();
                context.Dispose();
                return pontuacaoInserida;
            }
            catch (Exception ex)
            {
                throw;
            }

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
