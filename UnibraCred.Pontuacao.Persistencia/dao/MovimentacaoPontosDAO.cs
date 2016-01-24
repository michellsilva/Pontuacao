using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnibraCred.Pontuacao.Entity;

namespace UnibraCred.Pontuacao.Persistencia.dao
{
    public class MovimentacaoPontosDAO
    {
        PontuacaoEntities1 context;

        public String obterTotalPontos(int numFatura)
        {
            context = new PontuacaoEntities1();
            String retorno = null;
            try
            {

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

        public PontuacaoSet obterPontuacaoPorFatura(int faturaId)
        {
            context = new PontuacaoEntities1();

            try
            {
                using (context)
                {
                    var query = from p in context.PontuacaoSet where p.FaturaId == faturaId select p;
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

        public PontuacaoSet obterPontuacao(int pontuacaoId)
        {
            context = new PontuacaoEntities1();

            try
            {
                using (context)
                {
                    var query = from p in context.PontuacaoSet where p.FaturaId == pontuacaoId select p;
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
