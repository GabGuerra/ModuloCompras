using ModuloCompras.Models;
using ModuloCompras.Repositories.Cotacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuloCompras.Services.Cotacao
{
    public class CotacaoService : ICotacaoService
    {
        private ICotacaoRepository _repository;
        public ICotacaoProdutoService _cotacaoProdutoService;
        public CotacaoService(ICotacaoRepository cotacaoRepository, ICotacaoProdutoService cotacaoProdutoService)
        {
            _repository = cotacaoRepository;
            _cotacaoProdutoService = cotacaoProdutoService;
        }

        public ResultadoVD AprovarCotacao(CotacaoVD cotacao)
        {
            var resultado = new ResultadoVD() { Sucesso = true };
            try
            {
                _repository.AprovarCotacao(cotacao);
            }
            catch (Exception ex)
            {
                resultado.Sucesso = false;
                resultado.Mensagem = "Erro ao Aprovar cotação: " + ex.Message;
            }
            return resultado;
        }

        public List<CotacaoVD> BuscarListaCotacao()
        {
            var ListaCotacaoRetorno = new List<CotacaoVD>();
            try
            {
                ListaCotacaoRetorno = _repository.BuscarListaCotacao();
                if (ListaCotacaoRetorno.Count > 0)
                {
                    foreach (var cotacao in ListaCotacaoRetorno)
                    {
                        cotacao.ListaProdutos =_cotacaoProdutoService.BuscarListaCotacaoProduto(Convert.ToInt32(cotacao.CodCotacao));
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return ListaCotacaoRetorno;
        }

        public ResultadoVD InserirCotacao(List<CotacaoVD> listaCotacao)
        {
            var resultado = new ResultadoVD() { Sucesso = true, Mensagem = "Cotações Inseridas com sucesso." };
            try
            {
                foreach (var cotacao in listaCotacao)
                {

                    _repository.InserirCotacao(cotacao);

                    if (cotacao.ListaProdutos.Count > 0)
                    {
                        _cotacaoProdutoService.InsereProdutoCotacao(cotacao.ListaProdutos, Convert.ToInt32(cotacao.CodCotacao));
                    }
                }
            }
            catch (Exception ex)
            {
                resultado.Sucesso = false;
                resultado.Mensagem = "Erro ao Inserir cotações." + ex;
            }
            return resultado;
        }
    }
}
