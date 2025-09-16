using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class Servico
    {
        public int ser_id { get; set; }
        public int cli_id;
        public string tipo;
        public DateTime data_execucao;
        public string descricao;
        public decimal valor;

        public string TipoServico
        {
            get { return tipo; }
            set { tipo = value; }
        }
        public DateTime DataExecucao
        {
            get { return data_execucao; }
            set { data_execucao = value; }
        }
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }
        public decimal Valor
        {
            get { return valor; }
            set { valor = value; }
        }
    }
}
