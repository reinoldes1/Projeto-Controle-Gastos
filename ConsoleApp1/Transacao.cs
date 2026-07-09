

namespace Projeto_Controle_Gastos
{
    public class Transacao
    {
        private static int contador = 1;

        public Transacao()
        {
            Identificador = contador++;
        }

        public int Identificador { get; }

        public string Descricao { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public bool Tipo { get; set; }
    }
}