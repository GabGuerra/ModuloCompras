using ModuloCompras.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuloCompras.Services.Cotacao
{
    public interface ICotacaoProdutoService
    {
        public ResultadoVD InsereProdutoCotacao(List<CotacaoProduto> listaCotacaoProduto, int codCotacao);
        public List<CotacaoProduto> BuscarListaCotacaoProduto(int codCotacao);
    }
}
