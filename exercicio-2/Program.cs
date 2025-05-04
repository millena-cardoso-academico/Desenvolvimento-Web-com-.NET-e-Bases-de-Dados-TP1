using System;

namespace ExercicioMultiIdiomas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Sistema de Mensagens Multilíngue ===");
            Console.WriteLine("Escolha um idioma:");
            Console.WriteLine("1 - Português");
            Console.WriteLine("2 - Inglês");
            Console.WriteLine("3 - Espanhol");

            int escolha;
            while (true)
            {
                Console.Write("Digite o número do idioma: ");
                if (int.TryParse(Console.ReadLine(), out escolha) && escolha >= 1 && escolha <= 3)
                    break;
                Console.WriteLine("Opção inválida! Digite 1, 2 ou 3.");
            }

            Action<string> exibirMensagem = escolha switch
            {
                1 => MensagemPortugues,
                2 => MensagemIngles,
                3 => MensagemEspanhol,
                _ => throw new InvalidOperationException("Opção inválida")
            };

            Console.Write("\nDigite seu nome: ");
            string nome = Console.ReadLine() ?? "Usuário";

            exibirMensagem(nome);
        }

        static void MensagemPortugues(string nome)
        {
            Console.WriteLine($"\nBem-vindo, {nome}! É um prazer tê-lo conosco.");
        }

        static void MensagemIngles(string nome)
        {
            Console.WriteLine($"\nWelcome, {nome}! We're pleased to have you with us.");
        }

        static void MensagemEspanhol(string nome)
        {
            Console.WriteLine($"\n¡Bienvenido, {nome}! Es un placer tenerte con nosotros.");
        }
    }
}