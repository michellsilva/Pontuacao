using System;
using System.Collections.Generic;
using UnibraCred.Pontuacao.Entity;
using UnibraCred.Pontuacao.Facade;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using UnibraCred.Pontuacao.Persistencia.basic;
//using System.Web.Helpers;


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
                    json = "{status:1, response:" + totalPontos + "}";

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
                return "{status:0, response:" + "erro interno. desculpe, tente novamente" + "}";
            }
            return json;
        }

        public string obterTotalPontosDetalhes(string value)
        {
            string json = "";
            json = fachada.validarJson(value);
            if (json == null)
            {
                List<FaturaDetalhada> retorno = new List<FaturaDetalhada>();
                PontuacaoFatura pont = JsonConvert.DeserializeObject<PontuacaoFatura>(value);
                retorno = fachada.LitartodosDetalhes(pont.cartao_id);
                json = JsonConvert.SerializeObject(retorno);
                ////serialize JSON to a string and then write string to a file
                //File.WriteAllText(@"C:\Users\Lenovo\Documents\Pos Engenharia Software\Pontuacao2.0\Pontuacao\movie.json", JsonConvert.SerializeObject(json));

                ////   serialize JSON directly to a file
                //using (StreamWriter file = File.CreateText(@"C:\Users\Lenovo\Documents\Pos Engenharia Software\Pontuacao2.0\Pontuacao\movie.json"))
                //{
                //    JsonSerializer serializer = new JsonSerializer();
                //    serializer.Serialize(file, json);
                //}
            }
            return json;
        }


        public string pontosPorFatura(string faturaJson)
        {
            RetornoPadrao resultado = new RetornoPadrao(); 
            try
            {
                JavaScriptSerializer json_serializer = new JavaScriptSerializer();

                //Fatura fatura = Json.Decode<Fatura>(faturaJson);   
                Fatura fatura = JsonConvert.DeserializeObject<Fatura>(faturaJson);

                PontuacaoFatura pontuacao = fachada.pontosPorFatura(fatura);

                resultado.status = 1;
                resultado.response = pontuacao.pontosQtd.ToString();

                //return Json.Encode(resultado);
                return JsonConvert.SerializeObject(resultado);
            }
            catch (Exception ex)
            {
                resultado.status = 0;
                resultado.response = ex.Message;

                //return Json.Encode(resultado);
                return JsonConvert.SerializeObject(resultado);
            }
        }

        public string pontuarFatura(string faturaJson)
        {
            RetornoPadrao resultado = new RetornoPadrao();
            try
            {
                JavaScriptSerializer json_serializer = new JavaScriptSerializer();

                //Fatura fatura = Json.Decode<Fatura>(faturaJson);
                Fatura fatura = JsonConvert.DeserializeObject<Fatura>(faturaJson);
             
                fachada.pontuarFatura(fatura);
                resultado.status = 1;
                resultado.response = "Fatura pontuada!";

                //return Json.Encode(resultado);
                return JsonConvert.SerializeObject(resultado);

            }
            catch (Exception ex)
            {                
                resultado.status = 0;
                resultado.response = ex.Message;

                //return Json.Encode(resultado);
                return JsonConvert.SerializeObject(resultado);
            }
            
        }
    }
}
