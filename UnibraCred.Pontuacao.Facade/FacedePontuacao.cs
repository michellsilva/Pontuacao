using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnibraCred.Pontuacao.Persistencia.business;

namespace UnibraCred.Pontuacao.Facade
{
    public partial class Fachada
    {
        private PontuacaoBusiness business;

        public String obterTotalPontos(int numFatura)
        {
            business = new PontuacaoBusiness();
            String retorno = null;

            try
            {
                return business.obterTotalPontos(numFatura);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return retorno;
        }
    }
}
