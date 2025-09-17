namespace model
{
    public class Cliente
    {
        public int cli_id { get; set; }
        public string nome;
        public string cpf_cnpj;
        public string telefone;
        public string endereco;
        public string observacoes;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public string CpfCnpj
        {
            get { return cpf_cnpj; }
            set { cpf_cnpj = value; }
        }
        public string Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }
        public string Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }

        public string Observacoes
        {
            get { return observacoes; }
            set { observacoes = value; }
        }
    }
}
