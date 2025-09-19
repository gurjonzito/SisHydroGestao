using DAL;
using model;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class OrcamentoBLL
    {
        private OrcamentoDAL orcamentoDAL = new OrcamentoDAL();

        private string ValidarOrcamento(Orcamento orcamento)
        {
            if (orcamento.Data == DateTime.MinValue)
                return "A data do orçamento é obrigatória.";

            if (orcamento.Data.Date < DateTime.Today)
                return "A data do orçamento não pode ser anterior a hoje.";

            if (orcamento.valor_estimado <= 0)
                return "O valor estimado deve ser maior que zero.";

            return "OK";
        }

        public string CadastrarOrcamento(Orcamento orcamento)
        {
            string validacao = ValidarOrcamento(orcamento);
            if (validacao != "OK") return validacao;

            try
            {
                orcamentoDAL.InserirOrcamento(orcamento);
                return "Sucesso";
            }
            catch (Exception ex)
            {
                return $"Erro ao cadastrar: {ex.Message}";
            }
        }

        public string EditarOrcamento(Orcamento orcamento)
        {
            string validacao = ValidarOrcamento(orcamento);
            if (validacao != "OK") return validacao;

            try
            {
                orcamentoDAL.EditarOrcamento(orcamento);
                return "Sucesso";
            }
            catch (Exception ex)
            {
                return $"Erro ao cadastrar: {ex.Message}";
            }
        }

        public List<Orcamento> GetOrcamentos()
        {
            return orcamentoDAL.GetOrcamentos();
        }
    }
}
