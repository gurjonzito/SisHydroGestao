using DAL;
using model;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class ParcelaBLL
    {
        private ParcelaDAL parcelaDAL = new ParcelaDAL();

        private string ValidarParcela(ParcelaPagamento parcela)
        {
            if (string.IsNullOrWhiteSpace(parcela.Parcelas.ToString()))
                return "Informe a quantidade de parcelas.";

            if (string.IsNullOrWhiteSpace(parcela.ParcelasPagas.ToString()))
                return "Informe a quantidade de parcelas pagas.";

            if (parcela.DataVencimento == DateTime.MinValue)
                return "Informe a data de vencimento da parcela.";

            if (parcela.ValorTotal <= 0)
                return "Valor total não pode ser menor ou igual a zero.";

            if (parcela.ValorAbatido <= 0)
                return "Valor abatido não pode ser menor ou igual a zero.";

            return "OK";
        }

        public string CadastrarParcela(ParcelaPagamento parcela)
        {
            string validacao = ValidarParcela(parcela);
            if (validacao != "OK") return validacao;

            try
            {
                parcelaDAL.InserirParcela(parcela);
                return "Sucesso";
            }
            catch (Exception ex)
            {
                return $"Erro ao cadastrar: {ex.Message}";
            }
        }

        public string EditarParcela(ParcelaPagamento parcela)
        {
            string validacao = ValidarParcela(parcela);
            if (validacao != "OK") return validacao;

            try
            {
                parcelaDAL.EditarParcela(parcela);
                return "Sucesso";
            }
            catch (Exception ex)
            {
                return $"Erro ao cadastrar: {ex.Message}";
            }
        }

        public List<ParcelaPagamento> GetParcelas()
        {
            return parcelaDAL.GetParcelas();
        }
    }
}
