
using System;
using System.Collections.Generic;

class Program
{
    private static readonly List<Usuario> usuarios = new();

    static void Main()
    {
        bool executando = true;

        while (executando)
        {
            Console.WriteLine("=== Controle de Usuários ===");
            Console.WriteLine("1 - Cadastrar usuário");
            Console.WriteLine("2 - Listar usuários");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");

            string? opcao = Console.ReadLine();
            Console.WriteLine();

            switch (opcao)
            {
                case "1":
                    CadastrarUsuario();
                    break;
                case "2":
                    ListarUsuarios();
                    break;
                case "0":
                    executando = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida.\n");
                    break;
            }
        }
    }

    static void CadastrarUsuario()
    {
        var usuario = new Usuario();
        string? nome;

        do
        {
            Console.Write("Digite o nome: ");
            nome = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nome))
            {
                Console.WriteLine("O nome não pode ficar vazio. Tente novamente.\n");
            }
        } while (string.IsNullOrWhiteSpace(nome));

        usuario.Nome = nome;

        int idade;
        while (true)
        {
            Console.Write("Digite a idade: ");
            string? idadeTexto = Console.ReadLine();

            if (int.TryParse(idadeTexto, out idade) && idade >= 0)
            {
                break;
            }

            Console.WriteLine("Idade inválida. Digite um número inteiro maior ou igual a zero.\n");
        }

        usuario.Idade = idade;

        usuarios.Add(usuario);
        Console.WriteLine($"Usuário '{usuario.Nome}' cadastrado com sucesso!\n");
    }

    //Função de listagem de usuarios
    static void ListarUsuarios()
    {   
        if (usuarios.Count == 0) //Verifica se existem usuarios
        {
            Console.WriteLine("Nenhum usuário cadastrado ainda.\n");
            return;
        }

        Console.WriteLine("Usuários cadastrados:");
        foreach (var usuario in usuarios) //Lista os usuarios cadastrados
        {
            Console.WriteLine($"- {usuario.Identificador}: {usuario.Nome}, {usuario.Idade} anos");
        }

        Console.WriteLine();
    }
}

public class Usuario
{
    // Contador para Id dos usuarios
    private static int contador = 1;

    public Usuario()
    {
        Identificador = contador++;
    }

    //Utilizado apenas get para não alterar o identificador
    public int Identificador { get; }
    public string Nome { get; set; } = string.Empty;
    public int Idade { get; set; }
}

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

