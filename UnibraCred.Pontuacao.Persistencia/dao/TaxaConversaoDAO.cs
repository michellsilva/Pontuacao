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
        public TaxaConversaoSet obterTaxaConversaoAtual()
        {
            PontuacaoEntities1 context = new PontuacaoEntities1();
            try
            {
                using (context)
                {
                    var query = context.TaxaConversaoSet.OrderByDescending(item => item.DataInicioVigencia).First();
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
