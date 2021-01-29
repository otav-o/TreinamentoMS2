﻿namespace AtividadeFinal_Modulo2_Otavio.Models
{
    public class Endereco
    {
        /// <summary>
        /// Indica se o endereço é residencial, comercial, de cobrança, etc.
        /// </summary>
        public string Tipo { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public int Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
    }
}