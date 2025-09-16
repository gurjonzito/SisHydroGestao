using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class Peca
    {
        public int pec_id { get; set; }
        public string nome;
        public string codigo;
        public int qtde_estoque;
        public decimal preco_compra;
        public string fabricante;
        public DateTime entrada;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        public int QtdeEstoque
        {
            get { return qtde_estoque; }
            set { qtde_estoque = value; }
        }
        public decimal PrecoCompra
        {
            get { return preco_compra; }
            set { preco_compra = value; }
        }
        public string Fabricante
        {
            get { return fabricante; }
            set { fabricante = value; }
        }
        public DateTime Entrada
        {
            get { return entrada; }
            set { entrada = value; }
        }
    }
}
