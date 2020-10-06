using ModuloCompras.Models.Fornecedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuloCompras.Models.Produto
{
    public class ProdutoVD
    {
        public int? CodProduto { get; set; }
        public string NomeProduto { get; set; }
        public double? PrecoCustoMedio { get; set; } 
        public FornecedorVD Fornecedor { get; set; }

        public ProdutoVD()
        {  
            Fornecedor = new FornecedorVD();
        }        
    }
}
