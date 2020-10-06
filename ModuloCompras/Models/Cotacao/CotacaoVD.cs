using ModuloCompras.Models.Fornecedor;
using ModuloCompras.Models.Produto;
using ModuloCompras.Models.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuloCompras.Models
{
    public class CotacaoVD
    {
        public int? CodCotacao { get; set; }
        public DateTime DatEntrega { get; set; }
        public DateTime DatPrazoPagamento{ get; set; }

        public List<CotacaoProduto> ListaProdutos { get; set; }
        public FornecedorVD Fornecedor { get; set; }
        public UsuarioVD Usuario { get; set; }

        public CotacaoVD()
        {
            Fornecedor = new FornecedorVD();
            ListaProdutos = new List<CotacaoProduto>();
            Usuario = new UsuarioVD();
        }

    }
    public class CotacaoProduto: ProdutoVD
    {
        public int QtdCotacao { get; set; }
        public double PrecoUnitario { get; set; }
        public CotacaoProduto()
        {

        }
    }
}
