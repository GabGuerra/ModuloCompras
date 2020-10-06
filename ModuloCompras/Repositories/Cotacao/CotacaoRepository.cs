using Microsoft.Extensions.Configuration;
using ModuloCompras.Models;
using ModuloCompras.Models.Fornecedor;
using ModuloCompras.Models.Usuario;
using ModuloCompras.Repositories.BD;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuloCompras.Repositories.Cotacao
{
    public class CotacaoRepository : MySqlRepository<CotacaoVD>, ICotacaoRepository
    {
        public CotacaoRepository(IConfiguration config) : base(config)
        {

        }


        public void InserirCotacao(CotacaoVD cotacao)
        {          
            string sql = @"INSERT INTO COTACAO(DAT_ENTREGA,DAT_PRAZO,COD_FORNECEDOR,SITUACAO_COTACAO,COD_USUARIO) VALUES (@DAT_ENTREGA,@DAT_PRAZO, @COD_FORNECEDOR,0,@COD_USUARIO); 
                           SELECT LAST_INSERT_ID()";
            using (var cmd = new MySqlCommand(sql))
            {                
                cmd.Parameters.AddWithValue("DAT_ENTREGA", cotacao.DatEntrega);
                cmd.Parameters.AddWithValue("DAT_PRAZO", cotacao.DatPrazoPagamento);
                cmd.Parameters.AddWithValue("COD_FORNECEDOR", cotacao.Fornecedor.CodFornecedor);
                cmd.Parameters.AddWithValue("COD_USUARIO", cotacao.Usuario.CodUsuario);
                cotacao.CodCotacao = ObterLastID(cmd);
            }
        }
        
        public void AprovarCotacao(CotacaoVD cotacao)
        {
            string sql = @"UPDATE COTACAO SET SITUACAO_COTACAO = 1 WHERE COD_COTACAO = @COD_COTACAO";
            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("COD_COTACAO", cotacao.CodCotacao);
                ExecutarComando(cmd);
            }
        }

        public List<CotacaoVD> BuscarListaCotacao()
        {
            var lista = new List<CotacaoVD>();
            string sql = @"SELECT DISTINCT C.COD_COTACAO, F.NOME_FORNECEDOR, C.DAT_ENTREGA, C.DAT_PRAZO, U.NOME 
                            FROM COTACAO C                             
                            INNER JOIN USUARIO U ON C.COD_USUARIO = U.COD_USUARIO
                            INNER JOIN FORNECEDOR F ON C.COD_FORNECEDOR = F.COD_FORNECEDOR;";
            using (var cmd = new MySqlCommand(sql))
            {
                //cmd.Parameters.AddWithValue("COD_PRODUTO", codProduto);
                lista = ObterRegistros(cmd).ToList();
            }
            return lista;
        }

        public override CotacaoVD PopularDados(MySqlDataReader dr)
        {
            FornecedorVD fornecedor = new FornecedorVD() { DscFornecedor = dr["NOME_FORNECEDOR"].ToString()};          
            UsuarioVD usuario = new UsuarioVD() { NomeUsuario = dr["NOME"].ToString()};          
            return new CotacaoVD
            {
                CodCotacao = Convert.ToInt32(dr["COD_COTACAO"]),
                DatEntrega = Convert.ToDateTime(dr["DAT_ENTREGA"]),               
                Usuario = usuario,
                Fornecedor = fornecedor
            };
        }
    }
}