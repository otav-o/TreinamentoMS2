﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaDeCobrancas
{
    class EnderecoModelo
    {
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public int Numero { get; set; }
        public int Complemento { get; set; }
        public string Uf { get; set; }
        public string Pais { get; set; } = "Brasil";

        public EnderecoModelo(string rua, string bairro, string cidade, int numero, int complemento)
        {
            Rua = rua;
            Bairro = bairro;
            Cidade = cidade;
            Numero = numero;
            Complemento = complemento;
        }
    }
}
