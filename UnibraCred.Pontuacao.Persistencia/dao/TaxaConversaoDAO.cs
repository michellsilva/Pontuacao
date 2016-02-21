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
                    var query = context.TaxaConversao.OrderByDescending(item => item.dtVigencia).First();
                    return query;
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
