using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class Pagamento
    {
        public int pag_id { get; set; }
        public int ser_id;
        public string forma_pagto;
        public DateTime data_pagto;
        public decimal valor_pago;
        public bool? parcelado;
        public Situacao situacao;

        public enum Situacao
        {
            Pendente, Parcial, Pago, Cancelado
        }

        public string FormaPagamento
        {
            get { return forma_pagto; }
            set { forma_pagto = value; }
        }

        public DateTime DataPagamento
        {
            get { return data_pagto; }
            set { data_pagto = value; }
        }
        public decimal ValorPago
        {
            get { return valor_pago; }
            set { valor_pago = value; }
        }
        public bool Parcelado
        {
            get { return parcelado; }
            set { parcelado = value; }
        }
    }
}
