using System;


namespace Projeto_Controle_Gastos
{
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

        private static readonly List<Usuario> usuarios = new();

        public static void CadastrarUsuario()
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

                if (!int.TryParse(idadeTexto, out idade) || idade >= 0)
                {
                    Console.WriteLine("Idade inválida. Digite um número inteiro maior ou igual a zero.\n");
                    continue;
                }
                else
                {
                    usuario.Idade = idade;

                    usuarios.Add(usuario);
                    Console.WriteLine($"Usuário '{usuario.Nome}' cadastrado com sucesso!\n");
                    break;
                }
            }

        }

        public static void DeletarUsuario()
        {
            int id;
            while (true)
            {
                Console.WriteLine("Escolha o usuário que deseja deletar:");
                if (usuarios.Count == 0) //Verifica se existe usuarios, caso não retorna ao menu
                {
                    Console.WriteLine("Nenhum usuário cadastrado ainda.\n");
                    return;
                }

                ListarUsuarios();
                Console.Write("Digite o identificador do usuário: ");
                
                string? identificadorTexto = Console.ReadLine();
                
                if (!int.TryParse(identificadorTexto, out id) || id < 0)
                {
                    System.Console.WriteLine("Id invalido\n");
                    continue;
                }

                var usuario = usuarios.Find(u => u.Identificador == id);
                
                if (usuario == null)
                {
                    System.Console.WriteLine("Usuario não encontrado\n");
                    continue;
                }
                else
                {
                    usuarios.Remove(usuario);
                    Console.WriteLine($"Usuário '{usuario.Nome}' deletado com sucesso!\n");
                    break;
                }
            }

        }

        //Função de listagem de usuarios
        public static void ListarUsuarios()
        {   
            if (usuarios.Count == 0) //Verifica se existe usuarios, caso não retorna ao menu
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
}