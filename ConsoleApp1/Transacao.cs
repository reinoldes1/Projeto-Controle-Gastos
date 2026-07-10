

using System;
using System.Collections.Generic;

namespace Projeto_Controle_Gastos
{
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
        public int UsuarioIdentificador { get; set; }

        private static readonly List<Transacao> transacoes = new();
    
        public static void CadastrarTransacao()
        {
            var transacao = new Transacao();
            Usuario? usuario = null;
            
            while (true)
            {     
                Usuario.ListarUsuarios();
                
                Console.WriteLine("Selecione o id do seu usuário:");
                if (Usuario.usuarios.Count == 0)
                {
                    Console.WriteLine("Nenhum usuário cadastrado ainda\n");
                    return;
                }
                
                int id;
                string? identificadorTexto = Console.ReadLine();

                if (!int.TryParse(identificadorTexto, out id) || id < 0)
                {
                   Console.WriteLine("Id inválido\n");
                   continue; 
                }

                usuario = Usuario.usuarios.Find(u => u.Identificador == id);

                if (usuario == null)
                {
                    Console.WriteLine("Usuário não encontrado\n");
                    continue;
                }

                transacao.UsuarioIdentificador = usuario.Identificador;
                break;
            }

            if (usuario!.Idade < 18)
            {
                transacao.Tipo = false;
                Console.WriteLine("Usuário menor de idade só pode cadastrar despesa.");
            }
            else
            {
                while (true)
                {
                    Console.WriteLine("O que você deseja cadastrar?");
                    Console.WriteLine("1 - Receita");
                    Console.WriteLine("2 - Despesa");
                    string? opcao = Console.ReadLine();

                    if (opcao == "1")
                    {
                        transacao.Tipo = true;
                        break;
                    }
                    else if (opcao == "2")
                    {
                        transacao.Tipo = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida. Digite 1 ou 2.");
                    }
                }
            }

            string? descricao;
            do
            {
                Console.Write("Digite a descrição: ");
                descricao = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(descricao))
                {
                    Console.WriteLine("A descrição não pode ficar vazia.");
                }
            } while (string.IsNullOrWhiteSpace(descricao));

            transacao.Descricao = descricao!;

            decimal valor;
            while (true)
            {
                Console.Write("Digite o valor: ");
                string? valorTexto = Console.ReadLine();

                if (!decimal.TryParse(valorTexto, out valor) || valor <= 0)
                {
                    Console.WriteLine("Valor inválido. Digite um número maior que zero.");
                    continue;
                }

                transacao.Valor = valor;
                break;
            }

            transacoes.Add(transacao);
            Console.WriteLine($"Transação de descrição '{transacao.Descricao}' adicionada!\n");
        }

        public static void ListarTransacoes()
        {
            if (transacoes.Count == 0)
            {
                Console.WriteLine("Nenhuma transação cadastrada.\n");
                return;
            }

            Console.WriteLine("Transações cadastradas:");
            foreach (var transacao in transacoes)
            {
                string tipoTexto = transacao.Tipo ? "Receita" : "Despesa";
                Console.WriteLine($"- {transacao.Identificador}: {tipoTexto} | {transacao.Descricao} | {transacao.Valor:C} | Usuário {transacao.UsuarioIdentificador}");
            }

            Console.WriteLine();
        }
    
        public static void MostrarSaldo()
        {
            decimal saldo = 0m;
            foreach (var transacao in transacoes)
            {
                saldo += transacao.Tipo ? transacao.Valor : -transacao.Valor;
            }

            Console.WriteLine($"Saldo total: {saldo:C}\n");
        }

    }

}