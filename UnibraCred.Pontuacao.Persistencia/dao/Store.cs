using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnibraCred.Pontuacao.Entity;

namespace UnibraCred.Pontuacao.Persistencia.dao
{
    public class Store : DbContext
    {
        public Store()
            : base("name=ConnectionString")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DebitoPontos> DebitoPontos { get; set; }
        public virtual DbSet<PontuacaoFatura> PontuacaoFatura { get; set; }
        public virtual DbSet<TaxaConversao> TaxaConversao { get; set; }
    }
}
