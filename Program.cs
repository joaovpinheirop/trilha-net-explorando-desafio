using System.Text;
using DesafioProjetoHospedagem.Models;
using Newtonsoft.Json;

Console.OutputEncoding = Encoding.UTF8;


try
{
  string dadosSuite = File.ReadAllText("./Arquivos/DadosSuite.json");

  List<Suite> listaDeDados = JsonConvert.DeserializeObject<List<Suite>>(dadosSuite);
  Menu menu = new Menu(suite: listaDeDados);


}
catch (Exception error)
{
  Console.WriteLine($"Aconteceu um erro: {error}");
}

























// // Cria os modelos de hóspedes e cadastra na lista de hóspedes
// List<Pessoa> hospedes = new List<Pessoa>();

// Pessoa p1 = new Pessoa(nome: "Hóspede 1");
// Pessoa p2 = new Pessoa(nome: "Hóspede 2");

// hospedes.Add(p1);
// hospedes.Add(p2);

// // Cria a suíte


// // Cria uma nova reserva, passando a suíte e os hóspedes
// // Reserva reserva = new Reserva(diasReservados: 10);

// reserva.CadastrarSuite(suite);
// reserva.CadastrarHospedes(hospedes);

// // Exibe a quantidade de hóspedes e o valor da diária
// Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
// Console.WriteLine($"Dias Hospedados: {reserva.DiasReservados}");
// Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");