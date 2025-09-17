using System;

namespace model
{
    public class ServicoEquipamento
    {
        public int ser_id { get; set; }
        public int equ_id { get; set; }
        public int quantidade;

        public int Quantidade
        {
            get { return quantidade; }
            set { quantidade = value; }
        }
    }
}
