using System;
using System.IO;

namespace SistemaLoggingRobusto
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
            try
            {
                string logEntry = $"[FILE] {DateTime.Now}: {message}";
                File.AppendAllText("log.txt", logEntry + Environment.NewLine);
                Console.WriteLine($"Log gravado em arquivo: log.txt");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERRO] Falha ao gravar arquivo: {ex.Message}");
            }
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
            Console.WriteLine("=== TESTE 1: Com métodos registrados ===");
            TestarLogComDelegate(true);

            Console.WriteLine("\n=== TESTE 2: Sem métodos registrados ===");
            TestarLogComDelegate(false);

            Console.WriteLine("\nTestes concluídos com segurança!");
        }

        static void TestarLogComDelegate(bool registrarMetodos)
        {
            var logger = new Logger();
            Action<string>? logHandler = null;

            if (registrarMetodos)
            {
                logHandler = logger.LogToConsole;
                logHandler += logger.LogToFile;
                logHandler += logger.LogToDatabase;
            }

            logHandler?.Invoke("Mensagem de teste do sistema robusto");
            Console.WriteLine("Invocação concluída sem erros, mesmo sem métodos registrados.");
        }
    }
}