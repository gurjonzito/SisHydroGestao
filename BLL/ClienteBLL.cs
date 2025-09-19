using DAL;
using model;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class ClienteBLL
    {
        private ClienteDAL clienteDAL = new ClienteDAL();

        private string ValidarCliente(Cliente cliente)
        {
            if (string.IsNullOrWhiteSpace(cliente.Nome))
                return "Nome é um campo obrigatório.";

            if (cliente.Numero <= 0)
                return "Número não pode ser menor ou igual a zero.";

            return "OK";
        }

        public string CadastrarCliente(Cliente cliente)
        {
            string validacao = ValidarCliente(cliente);
            if (validacao != "OK") return validacao;

            try
            {
                clienteDAL.InserirCliente(cliente);
                return "Sucesso";
            }
            catch (Exception ex)
            {
                return $"Erro ao cadastrar: {ex.Message}";
            }
        }

        public string EditarCliente(Cliente cliente)
        {
            string validacao = ValidarCliente(cliente);
            if (validacao != "OK") return validacao;

            try
            {
                clienteDAL.EditarCliente(cliente);
                return "Sucesso";
            }
            catch (Exception ex)
            {
                return $"Erro ao cadastrar: {ex.Message}";
            }
        }

        public List<Cliente> GetClientes()
        {
            return clienteDAL.GetClientes();
        }
    }
}
