using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ModuloCompras.Controllers
{
    public class CotacaoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}