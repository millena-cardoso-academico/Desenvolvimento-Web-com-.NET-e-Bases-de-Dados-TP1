using System;
using System.Threading;

namespace DownloadManagerApp
{
    public class DownloadManager
    {
        public event Action<string> DownloadCompleted;

        public void StartDownload(string fileName, int downloadTime)
        {
            Console.WriteLine($"Iniciando download do arquivo: {fileName}");
            Thread.Sleep(downloadTime);
            OnDownloadCompleted(fileName);
        }

        protected virtual void OnDownloadCompleted(string fileName)
        {
            DownloadCompleted?.Invoke(fileName);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var downloadManager = new DownloadManager();

            downloadManager.DownloadCompleted += fileName => 
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nDownload concluído: {fileName}");
                Console.ResetColor();
            };

            Console.WriteLine("=== Sistema de Gerenciamento de Downloads ===");
            Console.Write("Digite o nome do arquivo: ");
            string fileName = Console.ReadLine() ?? "arquivo";

            Console.Write("Digite o tempo de download (em segundos): ");
            int downloadTime = int.TryParse(Console.ReadLine(), out int time) ? time * 1000 : 3000;

            downloadManager.StartDownload(fileName, downloadTime);

            Console.WriteLine("O sistema continua respondendo durante o download...");
            Console.WriteLine("Pressione qualquer tecla para sair");
            Console.ReadKey();
        }
    }
}