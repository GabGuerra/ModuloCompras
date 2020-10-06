using Microsoft.Extensions.Configuration;
using ModuloCompras.Models;
using ModuloCompras.Repositories.BD;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuloCompras.Repositories.Cotacao
{
    public class CotacaoProdutoRepository : MySqlRepository<CotacaoProduto>, ICotacaoProdutoRepository
    {
        public CotacaoProdutoRepository(IConfiguration config) : base(config)
        {

        }
        public List<CotacaoProduto> BuscarListaCotacaoProduto(int codCotacao)
        {
            var lista = new List<CotacaoProduto>();
            string sql = @"SELECT P.COD_PRODUTO, P.NOME_PRODUTO, CP.QTD_COTACAO, CP.PRECO_UNITARIO, C.DAT_ENTREGA, C.DAT_PRAZO, U.NOME FROM COTACAO C 
                            INNER JOIN COTACAO_PRODUTO CP ON C.COD_COTACAO = CP.COD_COTACAO
                            INNER JOIN PRODUTO P ON  CP.COD_PRODUTO = P.COD_PRODUTO
                            INNER JOIN USUARIO U ON C.COD_USUARIO = U.COD_USUARIO
                            INNER JOIN FORNECEDOR F ON C.COD_FORNECEDOR = F.COD_FORNECEDOR WHERE C.COD_COTACAO = @COD_COTACAO;";
            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("COD_COTACAO", codCotacao);
                lista = ObterRegistros(cmd).ToList();
            }
            return lista;
        }

        public void InsereCotacaoProduto(CotacaoProduto cotacaoProduto, int codCotacao)
        {          
            string sql = @"INSERT INTO COTACAO_PRODUTO(COD_COTACAO,QTD_COTACAO,PRECO_UNITARIO,COD_PRODUTO) VALUES (@COD_COTACAO, @QTD_COTACAO, @PRECO_UNITARIO, @COD_PRODUTO)";
            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("COD_COTACAO", codCotacao);
                cmd.Parameters.AddWithValue("QTD_COTACAO", cotacaoProduto.QtdCotacao);
                cmd.Parameters.AddWithValue("PRECO_UNITARIO", cotacaoProduto.PrecoUnitario);
                cmd.Parameters.AddWithValue("COD_PRODUTO", cotacaoProduto.CodProduto);                
                ExecutarComando(cmd);
            }
        }

        public override CotacaoProduto PopularDados(MySqlDataReader dr)
        {
            CotacaoProduto CotacaoProduto = new CotacaoProduto()
            {
                QtdCotacao = Convert.ToInt32(dr["QTD_COTACAO"]),
                PrecoUnitario = Convert.ToDouble(dr["PRECO_UNITARIO"]),
                NomeProduto = dr["NOME_PRODUTO"].ToString(),
                CodProduto = Convert.ToInt32(dr["COD_PRODUTO"])
            };
            return CotacaoProduto;          
        }
    }
}
