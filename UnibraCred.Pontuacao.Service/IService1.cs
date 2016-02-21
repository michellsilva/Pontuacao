using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using UnibraCred.Pontuacao.Entity;

namespace UnibraCred.Pontuacao.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService
    {

        [WebGet(ResponseFormat=WebMessageFormat.Json)]
        [OperationContract]
        string obterTotalPontos(string inJson);

        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        List<PontuacaoFatura> obterTotalDetalhes(int cartaoId);

        [OperationContract]
        string pontosPorFatura(int faturaId);
    }
}
