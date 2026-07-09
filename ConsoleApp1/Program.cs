using System;
using System.Collections.Generic;


namespace Projeto_Controle_Gastos
{
    class Program
    {
        static void Main()
        {
            bool executando = true;

            while (executando)
            {
                Console.WriteLine("=== Controle de Usuários ===");
                Console.WriteLine("1 - Cadastrar usuário");
                Console.WriteLine("2 - Deletar usuário");
                Console.WriteLine("3 - Listar usuários");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha uma opção: ");

                string? opcao = Console.ReadLine();
                Console.WriteLine();

                switch (opcao)
                {
                    case "1":
                        Usuario.CadastrarUsuario();
                        break;
                    case "2":
                        Usuario.DeletarUsuario();
                        break;
                    case "3":
                        Usuario.ListarUsuarios();
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
    }
}