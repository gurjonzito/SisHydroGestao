namespace model
{
    public class Cliente
    {
        public int cli_id { get; set; }
        public string nome;
        public string cpf_cnpj;
        public string telefone;
        public string rua;
        public int numero;
        public string bairro;
        public string cidade;
        public Estado estado;
        public string observacoes;

        public enum Estado
        {
            AC, AL, AP, AM, BA, CE, DF, ES, GO, MA,
            MT, MS, MG, PA, PB, PR, PE, PI, RJ, RN,
            RS, RO, RR, SC, SP, SE, TO
        }

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
        public string Rua
        {
            get { return rua; }
            set { rua = value; }
        }

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public string Bairro
        {
            get { return bairro; }
            set { bairro = value; }
        }

        public string Cidade
        {
            get { return cidade; }
            set { cidade = value; }
        }

        public string Observacoes
        {
            get { return observacoes; }
            set { observacoes = value; }
        }
    }
}
