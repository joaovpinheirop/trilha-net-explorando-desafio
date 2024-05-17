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
                        Environment.Exit(1);
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
                Console.WriteLine("2 - Remover Pessoa");
                Console.WriteLine("3 - Lista de pessoas ");
                Console.WriteLine("4 - Continuar");
                Console.WriteLine("5 - Voltar");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Digite o nome");
                        string nome = Console.ReadLine();
                        while (nome == "")
                        {
                            Console.WriteLine("Digite o nome Valido");
                            nome = Console.ReadLine();
                        }

                        Console.WriteLine("Digite o sobrenome");
                        string sobrenome = Console.ReadLine();
                        while (sobrenome == "")
                        {
                            Console.WriteLine("Digite o sobrenome Valido");
                            sobrenome = Console.ReadLine();
                        }

                        Pessoa p = new Pessoa(nome: nome);
                        hospedes.Add(p);
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("Digite sua Opção");
                        Console.WriteLine("Digite Cancelar para cancelar a operação");

                        Console.WriteLine("Quem vai ser removido da lista?");

                        int contador = 0;
                        foreach (Pessoa hospede in hospedes)
                        {
                            Console.WriteLine($"Nº {contador}, Nome: {hospede.NomeCompleto}");
                            contador++;
                        }

                        string remover = Console.ReadLine();
                        while (remover == "" && remover != "Cancelar")
                        {
                            Console.WriteLine("Digite um numero valido");
                        }
                        if (remover.ToUpper() == "CANCELAR")
                        {
                            break;
                        }

                        hospedes.RemoveAt(Convert.ToInt32(remover));
                        Console.WriteLine("Hospede removido com sucesso");
                        break;

                    case "3":
                        reserva.ListarHospedes(hospedes);
                        break;

                    case "4":
                        menuSuite = true;
                        menuReserva = false;
                        MenuSuite();
                        break;

                    case "5":
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
                        // TODO: Verificar se o numero da suite exite
                        reserva.CadastrarSuite(Suite);
                        break;

                    case "2":
                        // TODO: Verificar se tem alguma suite selecionada
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