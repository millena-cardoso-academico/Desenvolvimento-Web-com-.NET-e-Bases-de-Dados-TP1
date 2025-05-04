using System;
using System.IO;

namespace SistemaLogging
{
    public class Logger
    {
        public void LogToConsole(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[CONSOLE] {DateTime.Now}: {message}");
            Console.ResetColor();
        }

        public void LogToFile(string message)
        {
            string logEntry = $"[FILE] {DateTime.Now}: {message}";
            File.AppendAllText("log.txt", logEntry + Environment.NewLine);
            Console.WriteLine($"Log gravado em arquivo: log.txt");
        }

        public void LogToDatabase(string message)
        {
            Console.WriteLine($"[DATABASE] Log simulado no BD: {message}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var logger = new Logger();

            Action<string> logHandler = logger.LogToConsole;
            logHandler += logger.LogToFile;
            logHandler += logger.LogToDatabase;

            Console.WriteLine("=== Sistema de Logging Multicast ===");
            Console.WriteLine("Digite mensagens para log (ou 'sair' para encerrar)");

            while (true)
            {
                Console.Write("Mensagem: ");
                string? input = Console.ReadLine();

                if (string.IsNullOrEmpty(input) || input.ToLower() == "sair")
                    break;

                logHandler(input);
            }

            Console.WriteLine("Sistema de logging encerrado.");
        }
    }
}