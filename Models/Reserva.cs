using Newtonsoft.Json;

namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva()
        {
        }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // Verificar se a suite comporta a quantidade de hospedes
            bool ocupacaoHospedes = hospedes.Count <= Suite.Capacidade;
            Hospedes = ocupacaoHospedes ? hospedes : throw new Exception("Capacidade de hospedes não pode ultrapassar a capacidade da Suite");
        }

        public void CadastrarSuite(List<Suite> listaDeDados)
        {
            Console.WriteLine("Selecione a suite");

            int escolha = -1;
            while (escolha < 1 || escolha > listaDeDados.Count)
            {
                Console.Write("Digite o número correspondente à suíte desejada: ");
                if (!int.TryParse(Console.ReadLine(), out escolha))
                {
                    Console.WriteLine("Por favor, digite um número válido.");
                }
            }
            Suite = listaDeDados[Convert.ToInt32(Console.ReadLine()) - 1];

            Console.WriteLine("Quantos dias seram reservados?");
            int dias = Convert.ToInt32(Console.ReadLine());
            while (dias <= 0)
            {
                if (!int.TryParse(Console.ReadLine(), out dias))
                {
                    Console.WriteLine("Por favor, digite um número válido de dias.");
                    continue;
                }

                if (dias <= 0)
                {
                    Console.WriteLine("Por favor, digite um número maior que zero.");
                }
            }

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

        public void ListarHospedes(List<Pessoa> hospedes)
        {
            foreach (Pessoa item in hospedes)
            {
                Console.WriteLine($"Nome: {item.NomeCompleto}");
            }

            if (hospedes.Count == 0)
            {
                Console.WriteLine($"Sem hospedes na lista");
            }
            Console.ReadLine();
        }
    }
}