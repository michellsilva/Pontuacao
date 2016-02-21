﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnibraCred.Pontuacao.Entity;
using UnibraCred.Pontuacao.Persistencia;
using UnibraCred.Pontuacao.Persistencia.business;

namespace UnibraCred.Pontuacao.Facade
{
    public partial class Fachada
    {
        private PontuacaoBusiness pontuacaoBusiness;

        public Fachada()
        {
            pontuacaoBusiness = new PontuacaoBusiness();
        }



        public int obterTotalPontos(int cartaoId)
        {
            int retorno = 0;
            try
            {
                return pontuacaoBusiness.obterTotalPontos(cartaoId);
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
                retorno = pontuacaoBusiness.LitartodosDetalhes(cartaoId);
            }
            catch (Exception ex)
            {

                ex.ToString();
            }
            return retorno;
        }



        public PontuacaoFatura pontosPorFatura(int faturaId)
        {
            return pontuacaoBusiness.pontosPorFatura(faturaId);
        }
    }
}
