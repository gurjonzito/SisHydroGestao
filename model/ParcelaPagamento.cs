using System;

namespace model
{
    public class ParcelaPagamento
    {
        public int par_id { get; set; }
        public int pag_id;
        public int qtde_parcelas;
        public int qtde_parcelas_pagas;
        public DateTime data_vencimento;
        public decimal valor_total;
        public decimal valor_abatido;
        public Situacao situacao;

        public enum Situacao
        {
            Pendente, Pago, Atrasado
        }

        public int Parcelas
        {
            get { return qtde_parcelas; }
            set { qtde_parcelas = value; }
        }

        public int ParcelasPagas
        {
            get { return qtde_parcelas_pagas; }
            set { qtde_parcelas_pagas = value; }
        }

        public DateTime DataVencimento
        {
            get { return data_vencimento; }
            set { data_vencimento = value; }
        }

        public decimal ValorTotal
        {
            get { return valor_total; }
            set { valor_total = value; }
        }

        public decimal ValorAbatido
        {
            get { return valor_abatido; }
            set { valor_abatido = value; }
        }
    }
}
