using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using UnibraCred.Pontuacao.Facade;

namespace UnibraCred.Pontuacao.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service : IService
    {
        private Fachada fachada = new Fachada();


        public String obterTotalPontos(int numFatura)
        {
            String retorno = null;

            try
            {
                return fachada.obterTotalPontos(numFatura);
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
    }
}
