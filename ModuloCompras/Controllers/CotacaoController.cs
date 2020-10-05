using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModuloCompras.Models;
using ModuloCompras.Services.Cotacao;

namespace ModuloCompras.Controllers
{
    public class CotacaoController : Controller
    {
        public ICotacaoService _cotacaoService;
        public CotacaoController(ICotacaoService cotacaoService)
        {
            _cotacaoService = cotacaoService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult InserirCotacao(List<CotacaoVD> listaCotacao)
        {
            return Json(_cotacaoService.InserirCotacao(listaCotacao));
        }
    }
}