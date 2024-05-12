using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioProjetoHospedagem.Models
{
    public class Menu
    {

        public bool menu { get; set; }
        public bool menuSuite = false;
        public bool menuReserva = false;
        List<Pessoa> hospedes = new List<Pessoa>();
        List<Suite> Suite { get; set; }

        public Menu(List<Suite> suite)
        {
            menu = true;
            Suite = suite;
            Home();
        }

        public void Home()
        {
            while (menu)
            {
                Console.Clear();
                Console.WriteLine("Digite sua Opção");
                Console.WriteLine("1 - Nova Reserva");
                Console.WriteLine("2 - Encerrar");

                Reserva reserva = new Reserva();

                switch (Console.ReadLine())
                {
                    case "1":
                        menuReserva = true;
                        menu = false;
                        MenuReserva();
                        break;

                    case "2":
                        menu = false;
                        break;

                    default:
                        Console.WriteLine("Opção não valida");
                        break;
                }

                Console.WriteLine("Pressione enter para Continuar");
                Console.ReadLine();
            }

        }

        public void MenuReserva()
        {
            Reserva reserva = new Reserva();

            while (menuReserva)
            {
                Console.Clear();
                Console.WriteLine("Digite sua Opção");
                Console.WriteLine("1 - Adicionar Pessoa");
                Console.WriteLine("2 - Listar");
                Console.WriteLine("3 - Continuar");
                Console.WriteLine("4 - Voltar");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Digite o nome");
                        string nome = Console.ReadLine();

                        Console.WriteLine("Digite o sobrenome");
                        string sobrenome = Console.ReadLine();

                        Pessoa p = new Pessoa(nome: nome);
                        hospedes.Add(p);
                        break;

                    case "2":
                        reserva.ListarHospedes(hospedes);
                        break;

                    case "3":
                        menuSuite = true;
                        menuReserva = false;
                        MenuSuite();
                        break;

                    case "4":
                        menu = true;
                        menuReserva = false;
                        Home();
                        break;

                    default:
                        Console.WriteLine("Opção não valida");
                        break;
                }

                Console.WriteLine("Pressione enter para Continuar");
                Console.ReadLine();
            }
        }

        public void MenuSuite()
        {
            Reserva reserva = new Reserva();

            while (menuSuite)
            {
                Console.Clear();
                Console.WriteLine("Digite sua Opção");
                Console.WriteLine("1 - Selecionar Suite");
                Console.WriteLine("2 - Reservar");
                Console.WriteLine("3 - Voltar");

                switch (Console.ReadLine())
                {
                    case "1":
                        reserva.CadastrarSuite(Suite);
                        break;

                    case "2":
                        // Cadastrar hospedes na suite
                        reserva.CadastrarHospedes(hospedes);
                        Console.WriteLine("Reserva realizada");

                        // Exibe a quantidade de hóspedes e o valor da diária
                        Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
                        Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");

                        // Voltar ao menu principal
                        Console.WriteLine("Aperte enter para voltar ao menu principal");
                        Console.ReadLine();
                        menu = true;
                        menuSuite = false;
                        Home();
                        break;

                    case "3":
                        menuReserva = true;
                        menuSuite = false;
                        MenuReserva();
                        break;

                    default:
                        Console.WriteLine("Opção não valida");
                        break;
                }
                Console.WriteLine("Pressione enter para Continuar");
                Console.ReadLine();
            }
        }
    }
}