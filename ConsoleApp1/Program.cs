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
                Console.WriteLine("=== Controle de Gastos ===");
                Console.WriteLine("1 - Usuários");
                Console.WriteLine("2 - Transações");
                Console.WriteLine("3 - Saldo Total");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha uma opção: ");

                string? opcao = Console.ReadLine();
                Console.WriteLine();

                switch (opcao)
                {
                    case "1":
                        System.Console.WriteLine("=== Usuários ===");
                        Console.WriteLine("1 - Cadastrar");
                        Console.WriteLine("2 - Deletar");
                        Console.WriteLine("3 - Listar");
                        Console.WriteLine("0 - Sair");
                        Console.Write("Escolha uma opção: ");

                        string? opcaoUsuario = Console.ReadLine();
                        switch (opcaoUsuario)
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
                                System.Console.WriteLine("Retornado...");
                                break;
                            default:
                                System.Console.WriteLine("Opção Inválida.\n");
                                continue;
                        }
                        
                        break;
                    case "2":
                        System.Console.WriteLine("=== Transações ===");
                        Console.WriteLine("1 - Cadastrar");
                        Console.WriteLine("2 - Listar");
                        Console.WriteLine("0 - Sair");
                        Console.Write("Escolha uma opção: ");

                        string? opcaoTransacao = Console.ReadLine();
                        switch (opcaoTransacao)
                        {
                            case "1":
                                Transacao.CadastrarTransacao();
                                break;
                            case "2":
                                Transacao.ListarTransacoes();
                                break;
                            case "0":
                                System.Console.WriteLine("Retornado...");
                                break;
                            default:
                                System.Console.WriteLine("Opção Inválida.\n");
                                continue;
                        }
                        break;
                    case "3":
                        Transacao.MostrarSaldo();
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