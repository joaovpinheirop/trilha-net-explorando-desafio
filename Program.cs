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
