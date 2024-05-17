namespace DesafioProjetoHospedagem.Models;

public class Pessoa
{
    public Pessoa() { }

    public Pessoa(string nome)
    {
        Nome = nome;
    }

    public Pessoa(string nome, string sobrenome)
    {
        Nome = nome;
        Sobrenome = sobrenome;
    }

    public string Nome
    {
        get => _nome;
        set
        {
            if (value == "")
            {
                throw new Exception("Sem nome no campo");
            }
            _nome = value;
        }
    }
    public string Sobrenome
    {
        get => _sobrenome;
        set
        {
            if (value == "")
            {
                throw new Exception("Sem nome no campo");
            }
            _sobrenome = value;
        }
    }
    public string _nome;
    public string _sobrenome;
    public string NomeCompleto => $"{Nome} {Sobrenome}".ToUpper();

}