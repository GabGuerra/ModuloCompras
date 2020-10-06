using ModuloCompras.Models;
using ModuloCompras.Repositories.Cotacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuloCompras.Services.Cotacao
{
    public class CotacaoProdutoService : ICotacaoProdutoService
    {
        private ICotacaoProdutoRepository _repository;
        public CotacaoProdutoService(ICotacaoProdutoRepository cotacaoProdutoRepository)
        {
            _repository = cotacaoProdutoRepository;
        }

        public List<CotacaoProduto> BuscarListaCotacaoProduto(int codCotacao)
        {
            var ListaCotacaoRetorno = new List<CotacaoProduto>();
            try
            {
                ListaCotacaoRetorno = _repository.BuscarListaCotacaoProduto(codCotacao);
            }
            catch (Exception ex)
            {

            }
            return ListaCotacaoRetorno;
        }

        public ResultadoVD InsereProdutoCotacao(List<CotacaoProduto> listaCotacaoProduto, int codCotacao)
        {
            var resultado = new ResultadoVD() { Sucesso = true };
            try
            {
                foreach (var cotacaoProduto in listaCotacaoProduto)
                {

                    _repository.InsereCotacaoProduto(cotacaoProduto, codCotacao);
                }
            }
            catch
            {
                resultado.Sucesso = false;
                resultado.Mensagem = "Erro ao Inserir vinculo de cotações e produtos.";
            }
            return resultado;
        }
    }
}
