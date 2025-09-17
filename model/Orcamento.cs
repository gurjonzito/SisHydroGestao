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
        public DateTime data;
        public string descricao;
        public decimal valor_estimado;
        public DateTime Data
        {
            get { return data; }
            set { data = value; }
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
