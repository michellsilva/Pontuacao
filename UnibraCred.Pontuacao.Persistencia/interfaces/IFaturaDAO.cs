using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnibraCred.Pontuacao.Persistencia.basic;

namespace UnibraCred.Pontuacao.Persistencia.interfaces
{
    public interface IFaturaDAO
    {
        Fatura obterFatura(int idFatura);
    }
}
