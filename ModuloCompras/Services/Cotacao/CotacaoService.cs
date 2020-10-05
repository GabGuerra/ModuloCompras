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
        public CotacaoService(ICotacaoRepository cotacaoRepository)
        {
            _repository = cotacaoRepository;
        }

        public ResultadoVD AprovarCotacao(CotacaoVD cotacao)
        {
            var resultado = new ResultadoVD() { Sucesso = true };
            return resultado;
        }

        public List<CotacaoVD> BuscarListaCotacao()
        {
            var ListaCotacaoRetorno = new List<CotacaoVD>();
            try
            {
                ListaCotacaoRetorno = _repository.BuscarListaCotacao();
            }
            catch(Exception ex)
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
                }
            }
            catch
            {
                resultado.Sucesso = false;
                resultado.Mensagem = "Erro ao Inserir cotações.";
            }
            return resultado;
        }
    }
}
