using DAL;
using model;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class ServicoBLL
    {
        private ServicoDAL servicoDAL = new ServicoDAL();

        private string ValidarServico(Servico servico)
        {
            if (string.IsNullOrWhiteSpace(servico.TipoServico))
                return "Informe o tipo do serviço.";

            if (servico.DataExecucao == DateTime.MinValue)
                return "Informe a data de execução do serviço.";

            if (servico.Valor <= 0)
                return "Valor não pode ser menor ou igual a zero.";

            return "OK";
        }

        public string CadastrarServico(Servico servico)
        {
            string validacao = ValidarServico(servico);
            if (validacao != "OK") return validacao;

            try
            {
                servicoDAL.InserirServico(servico);
                return "Sucesso";
            }
            catch (Exception ex)
            {
                return $"Erro ao cadastrar: {ex.Message}";
            }
        }

        public string EditarServico(Servico servico)
        {
            string validacao = ValidarServico(servico);
            if (validacao != "OK") return validacao;

            try
            {
                servicoDAL.EditarServico(servico);
                return "Sucesso";
            }
            catch (Exception ex)
            {
                return $"Erro ao cadastrar: {ex.Message}";
            }
        }

        public List<Servico> GetServicos()
        {
            return servicoDAL.GetServicos();
        }
    }
}
