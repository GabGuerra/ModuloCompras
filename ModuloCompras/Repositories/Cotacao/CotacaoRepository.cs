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
    public class CotacaoRepository : MySqlRepository<CotacaoVD>, ICotacaoRepository
    {
        public CotacaoRepository(IConfiguration config) : base(config)
        {

        }


        public void InserirCotacao(CotacaoVD cotacao)
        {
            string sql = @"INSERT INTO COTACAO VALUES (@PRAZO_COTACAO, @DAT_ENTREGA,@DAT_PRACO_PAGAMENTO, @COD_FORNECEDOR";
            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("PRAZO_COTACAO", cotacao.PrazoCotacao);
                cmd.Parameters.AddWithValue("DAT_ENTREGA", cotacao.DatEntegrada);
                cmd.Parameters.AddWithValue("DAT_PRACO_PAGAMENTO", cotacao.DatPrazoPagamento);
                cmd.Parameters.AddWithValue("COD_FORNECEDOR", cotacao.Fornecedor.CodFornecedor);
                //cmd.Parameters.AddWithValue("COD_USUARIO", cotacao.Usuario.CodUsuario);
                ExecutarComando(cmd);
            }
        }

        public void AprovarCotacao(CotacaoVD cotacao)
        {
            string sql = @"UPDATE COTACAO SET .... WHERE COD_COTACAO = @COD_COTACAO";
            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("COD_COTACAO", cotacao.CodCotacao);
            }
        }

        public List<CotacaoVD> BuscarListaCotacao()
        {
            var lista = new List<CotacaoVD>();
            string sql = @"SELECT * FROM COTACAO";
            using (var cmd = new MySqlCommand(sql))
            {
                //cmd.Parameters.AddWithValue("COD_PRODUTO", codProduto);
                lista = ObterRegistros(cmd).ToList();
            }
            return lista;
        }

        public override CotacaoVD PopularDados(MySqlDataReader dr)
        {
            return new CotacaoVD
            {
                CodCotacao = Convert.ToInt32(dr["COD_COTACAO"])
            };
        }
    }
}