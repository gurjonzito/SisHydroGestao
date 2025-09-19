using DAL;
using model;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class EquipamentoBLL
    {
        private EquipamentoDAL equipamentoDAL = new EquipamentoDAL();

        private string ValidarEquipamento(Equipamento equipamento)
        {
            if (string.IsNullOrWhiteSpace(equipamento.Nome))
                return "Informe o nome do equipamento.";

            if (string.IsNullOrWhiteSpace(equipamento.Codigo))
                return "Informe o código do equipamento.";

            if (string.IsNullOrWhiteSpace(equipamento.QtdeEstoque.ToString()))
                return "Informe a quantidade em estoque do equipamento.";

            if (equipamento.PrecoCompra <= 0)
                return "O preço de compra não pode ser menor ou igual a zero.";

            if (string.IsNullOrWhiteSpace(equipamento.Fabricante))
                return "Informe o fabricante do equipamento.";

            return "OK";
        }

        public string CadastrarEquipamento(Equipamento equipamento)
        {
            string validacao = ValidarEquipamento(equipamento);
            if (validacao != "OK") return validacao;

            try
            {
                equipamentoDAL.InserirEquipamento(equipamento);
                return "Sucesso";
            }
            catch (Exception ex)
            {
                return $"Erro ao cadastrar: {ex.Message}";
            }
        }

        public string EditarEquipamento(Equipamento equipamento)
        {
            string validacao = ValidarEquipamento(equipamento);
            if (validacao != "OK") return validacao;

            try
            {
                equipamentoDAL.EditarEquipamento(equipamento);
                return "Sucesso";
            }
            catch (Exception ex)
            {
                return $"Erro ao cadastrar: {ex.Message}";
            }
        }

        public List<Equipamento> GetEquipamentos()
        {
            return equipamentoDAL.GetEquipamentos();
        }
    }
}
