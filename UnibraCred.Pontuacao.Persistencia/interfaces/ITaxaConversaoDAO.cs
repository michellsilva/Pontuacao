using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnibraCred.Pontuacao.Entity;

namespace UnibraCred.Pontuacao.Persistencia.interfaces
{
    public interface ITaxaConversaoDAO
    {
        TaxaConversao obterTaxaConversaoAtual();
    }
}
