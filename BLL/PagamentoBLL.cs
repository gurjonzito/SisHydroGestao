using DAL;
using model;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class PagamentoBLL
    {
        private PagamentoDAL pagamentoDAL = new PagamentoDAL();

        private string ValidarPagamento(Pagamento pagamento)
        {
            if (string.IsNullOrWhiteSpace(pagamento.FormaPagamento))
                return "Informa uma forma de pagamento.";

            if (pagamento.DataPagamento == DateTime.MinValue)
                return "A data do pagamento é obrigatória.";

            if (pagamento.valor_pago <= 0)
                return "O valor pago deve ser maior que zero.";

            if (pagamento.Parcelado == null)
                return "Informe se o pagamento será parcelado (Sim ou Não).";

            if (pagamento.situacao == null)
                return "Informe a situação do pagamento (Pendente, Parcial, Pago ou Cancelado).";

            return "OK";
        }

        public string CadastrarPagamento(Pagamento pagamento)
        {
            string validacao = ValidarPagamento(pagamento);
            if (validacao != "OK") return validacao;

            try
            {
                pagamentoDAL.InserirPagamento(pagamento);
                return "Sucesso";
            }
            catch (Exception ex)
            {
                return $"Erro ao cadastrar: {ex.Message}";
            }
        }

        public string EditarPagamento(Pagamento pagamento)
        {
            string validacao = ValidarPagamento(pagamento);
            if (validacao != "OK") return validacao;

            try
            {
                pagamentoDAL.EditarPagamento(pagamento);
                return "Sucesso";
            }
            catch (Exception ex)
            {
                return $"Erro ao cadastrar: {ex.Message}";
            }
        }

        public List<Pagamento> GetPagamentos()
        {
            return pagamentoDAL.GetPagamentos();
        }
    }
}
