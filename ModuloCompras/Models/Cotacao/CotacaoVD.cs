using ModuloCompras.Models.Fornecedor;
using ModuloCompras.Models.Produto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuloCompras.Models
{
    public class CotacaoVD
    {
        public int CodCotacao { get; set; }
        public int PrazoCotacao { get; set; }
        public DateTime DatEntegrada { get; set; }
        public DateTime DatPrazoPagamento { get; set; }
        public List<ProdutoVD> Produto { get; set; }
        public FornecedorVD Fornecedor { get; set; }


        public CotacaoVD()
        {
            Fornecedor = new FornecedorVD();
            Produto = new List<ProdutoVD>();
        }

    }
}
