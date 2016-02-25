using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Services;
using UnibraCred.Pontuacao.Entity;
using UnibraCred.Pontuacao.Facade;
using System.Web.Script.Serialization;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using UnibraCred.Pontuacao.Persistencia.basic;


namespace UnibraCred.Pontuacao.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service : IService
    {
        private Fachada fachada = new Fachada();

        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public string obterTotalPontos(string inJson)
        {

            var json = "";
            try
            {

                JSchema schema = JSchema.Parse(@"{
                    'cartao_Id': {'type':'string'}
                  }
                }");

                JSchema user = JSchema.Parse(inJson);
                PontuacaoFatura pont = JsonConvert.DeserializeObject<PontuacaoFatura>(inJson);
                var totalPontos = fachada.obterTotalPontos(pont.cartao_id);



                JavaScriptSerializer jss = new JavaScriptSerializer();


                json = "{return: " + totalPontos + "}";

                //json = JsonConvert.SerializeObject(fachada.obterTotalPontos(pont.cartao_id), Formatting.Indented);

                // serialize JSON to a string and then write string to a file
                File.WriteAllText(@"C:\Users\Lenovo\Documents\Pos Engenharia Software\Pontuacao2.0\Pontuacao\movie.json", JsonConvert.SerializeObject(json));

                // serialize JSON directly to a file
                using (StreamWriter file = File.CreateText(@"C:\Users\Lenovo\Documents\Pos Engenharia Software\Pontuacao2.0\Pontuacao\movie.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, json);
                }
                return json;

            }
            catch (FormatException ex)
            {
                ex.ToString();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return json;
        }

        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public List<PontuacaoFatura> obterTotalDetalhes(int cartaoId)
        {
            PontuacaoFatura retorno = new PontuacaoFatura();
            return fachada.LitartodosDetalhes(cartaoId);
            //var json = "";

            //try
            //{
            //    JavaScriptSerializer jss = new JavaScriptSerializer();

            //    List<PontuacaoFatura> obj = fachada.LitartodosDetalhes(cartaoId);

            //    json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            //    //foreach (var item in obj)
            //    //{
            //    //    retorno.cartao_id = item.cartao_id;
            //    //retorno.fatura_id = item.fatura_id;
            //    //retorno.dtInclusao = item.dtInclusao;
            //    //retorno.pontosQtd = item.pontosQtd;
            //    //json += JsonConvert.SerializeObject(retorno, Formatting.Indented);
            //    //}

            //    //retorno.cartao_id = obj.cartao_id;
            //    //retorno.fatura_id = obj.fatura_id;
            //    //retorno.dtInclusao = obj.dtInclusao;
            //    //retorno.pontosQtd = obj.pontosQtd;
            //    //json = JsonConvert.SerializeObject(retorno, Formatting.Indented);



            //    // serialize JSON to a string and then write string to a file
            //    File.WriteAllText(@"C:\Users\Lenovo\Documents\Pos Engenharia Software\Pontuacao2.0\Pontuacao\movie.json", JsonConvert.SerializeObject(retorno));

            //    // serialize JSON directly to a file
            //    using (StreamWriter file = File.CreateText(@"C:\Users\Lenovo\Documents\Pos Engenharia Software\Pontuacao2.0\Pontuacao\movie.json"))
            //    {
            //        JsonSerializer serializer = new JsonSerializer();
            //        serializer.Serialize(file, retorno);
            //    }
            //    return json;
            //}
            //catch (Exception ex)
            //{
            //    ex.ToString();
            //}
            //return json;
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
