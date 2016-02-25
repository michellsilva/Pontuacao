using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnibraCred.Pontuacao.Entity;

namespace UnibraCred.Pontuacao.Persistencia.dao
{
    public class TaxaConversaoDAO
    {
        public TaxaConversao obterTaxaConversaoAtual()
        {
            Store context = new Store();
            try
            {
                using (context)
                {
                    int qtdRegistros = context.TaxaConversao.Count();
                    if (qtdRegistros > 0)
                    {
                        var query = context.TaxaConversao.OrderByDescending(item => item.dtVigencia).First();
                        return query;
                    }
                    else
                    {
                        return null;
                    }                    
                }
            }
            catch (Exception ex)
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
