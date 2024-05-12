namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            bool ocupacaoHospedes = hospedes.Count <= Suite.Capacidade;

            Hospedes = ocupacaoHospedes ? hospedes : throw new Exception("Capacidade de hospedes não pode ultrapassar a capacidade da Suite");
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {

            decimal valor = DiasReservados * Suite.ValorDiaria;

            if (DiasReservados >= 10)
            {
                decimal percentualDesconto = 10;
                decimal valorDesconto = valor * (percentualDesconto / 100);
                valor = valor - valorDesconto;
            }

            return valor;
        }
    }
}