using ModuloCompras.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuloCompras.Services.Cotacao
{
    public interface ICotacaoService
    {
        public List<CotacaoVD> BuscarListaCotacao();
        public ResultadoVD InserirCotacao(List<CotacaoVD> listaCotacao);
        public ResultadoVD AprovarCotacao(CotacaoVD cotacao);
    }
}
