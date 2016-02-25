using System;
using System.Collections.Generic;
using UnibraCred.Pontuacao.Entity;
using UnibraCred.Pontuacao.Facade;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using UnibraCred.Pontuacao.Persistencia.basic;


namespace UnibraCred.Pontuacao.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service : IService
    {
        private Fachada fachada = new Fachada();

        public string obterTotalPontos(string value)
        {
            string json = "";
            try
            {
                json = fachada.validarJson(value);
                if (json == null)
                {
                    PontuacaoFatura pont = JsonConvert.DeserializeObject<PontuacaoFatura>(value);
                    var totalPontos = fachada.obterTotalPontos(pont.cartao_id);

                    JavaScriptSerializer jss = new JavaScriptSerializer();
                    json = "{status:1, return:" + totalPontos + "}";

                    //json = JsonConvert.SerializeObject(fachada.obterTotalPontos(pont.cartao_id), Formatting.Indented);

                    // serialize JSON to a string and then write string to a file
                    //    File.WriteAllText(@"C:\Users\Lenovo\Documents\Pos Engenharia Software\Pontuacao2.0\Pontuacao\movie.json", JsonConvert.SerializeObject(json));

                    // serialize JSON directly to a file
                    //using (StreamWriter file = File.CreateText(@"C:\Users\Lenovo\Documents\Pos Engenharia Software\Pontuacao2.0\Pontuacao\movie.json"))
                    //{
                    //    JsonSerializer serializer = new JsonSerializer();
                    //    serializer.Serialize(file, json);
                    //}
                }

            }
            catch (Exception ex)
            {
                ex.ToString();
                return "{status:0, return:" + "erro interno. desculpe, tente novamente" + "}";
            }
            return json;
        }

        public string obterTotalPontosDetalhes(string value)
        {
            List<PontuacaoFatura> retorno = new List<PontuacaoFatura>();
            PontuacaoFatura pont = JsonConvert.DeserializeObject<PontuacaoFatura>(value);
            retorno = fachada.LitartodosDetalhes(pont.cartao_id);
            string json = JsonConvert.SerializeObject(retorno);
            ////serialize JSON to a string and then write string to a file
            //File.WriteAllText(@"C:\Users\Lenovo\Documents\Pos Engenharia Software\Pontuacao2.0\Pontuacao\movie.json", JsonConvert.SerializeObject(json));

            ////   serialize JSON directly to a file
            //using (StreamWriter file = File.CreateText(@"C:\Users\Lenovo\Documents\Pos Engenharia Software\Pontuacao2.0\Pontuacao\movie.json"))
            //{
            //    JsonSerializer serializer = new JsonSerializer();
            //    serializer.Serialize(file, json);
            //}
            return json;

        }


        public string pontosPorFatura(int faturaId)
        {
            try
            {
                return fachada.pontosPorFatura(new Fatura { id = faturaId }).ToString();
            }
            catch (Exception ex)
            {
                RetornoPadrao resultado = new RetornoPadrao();
                resultado.sucesso = false;
                resultado.retorno = ex.Message;
                return ex.Message;
            }
        }

        public string pontuarFatura(int faturaId)
        {
            try
            {
                fachada.pontuarFatura(new Fatura { id = faturaId });
            }
            catch (Exception ex)
            {
                RetornoPadrao resultado = new RetornoPadrao();
                resultado.sucesso = false;
                resultado.retorno = ex.Message;
                return ex.Message;
            }
            return "Fatura pontuada!";
        }
    }
}
