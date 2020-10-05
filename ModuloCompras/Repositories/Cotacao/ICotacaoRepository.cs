using ModuloCompras.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuloCompras.Repositories.Cotacao
{
    public interface ICotacaoRepository
    {
        public void InserirCotacao(CotacaoVD listaCotacao);
        public void AprovarCotacao(CotacaoVD cotacao);
        public List<CotacaoVD> BuscarListaCotacao();
    }
}
