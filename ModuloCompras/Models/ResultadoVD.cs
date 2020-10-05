﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuloCompras.Models
{
    public class ResultadoVD
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public object ObjetoResultado { get; set; }

        public ResultadoVD(bool sucesso, string mensagem)
        {
            this.Sucesso = sucesso;
            this.Mensagem = mensagem;
        }
        public ResultadoVD(bool sucesso)
        {
            this.Sucesso = sucesso;
        }
        public ResultadoVD()
        {

        }
    }
}
