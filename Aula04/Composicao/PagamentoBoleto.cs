using System;
using System.Collections.Generic;
using System.Text;

namespace Composicao
{
    class PagamentoBoleto : IPagamento
    {
        public PagamentoBoleto()
        {
            pagamentoInfo = new Pagamento(); // instância privada que armazena os dados do pagamento
        }
        public double Valor { get; set; }

        public DateTime DataVencimento { get => pagamentoInfo.DataVencimento; set => pagamentoInfo.DataVencimento = value; }
        public DateTime DataEmissao { get => pagamentoInfo.DataEmissao; set => pagamentoInfo.DataEmissao = value; }
        public DateTime DataPagamento { get => pagamentoInfo.DataPagamento; set => pagamentoInfo.DataPagamento = value; }
        public double ValorPago { get => pagamentoInfo.ValorPago; set => pagamentoInfo.ValorPago = value; }

        public void Pagar(double valor)
        {
            if (DataPagamento.Year > 1)
                throw new Exception("Você está tentando pagar uma conta que já foi paga.");
            if (valor < Valor)
                throw new Exception("Valor insuficiente para pagar a conta.");
            ValorPago = valor;
            DataPagamento = DateTime.Now;
        }

        private IPagamentoInfo pagamentoInfo;
    }
}
