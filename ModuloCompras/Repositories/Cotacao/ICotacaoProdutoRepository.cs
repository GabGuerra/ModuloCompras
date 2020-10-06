using ModuloCompras.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuloCompras.Repositories.Cotacao
{
    public interface ICotacaoProdutoRepository
    {
        public void InsereCotacaoProduto(CotacaoProduto cotacaoProduto, int codCotacao);
        public List<CotacaoProduto> BuscarListaCotacaoProduto(int codCotacao);
    }
}
