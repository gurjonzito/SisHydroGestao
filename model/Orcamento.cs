using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class Orcamento
    {
        public int orc_id { get; set; }
        public int cli_id;
        public DateTime data_orcamento;
        public string descricao;
        public decimal valor_estimado;
        public DateTime DataOrcamento
        {
            get { return data_orcamento; }
            set { data_orcamento = value; }
        }
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }
        public decimal ValorEstimado
        {
            get { return valor_estimado; }
            set { valor_estimado = value; }
        }
    }
}
