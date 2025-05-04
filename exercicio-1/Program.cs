using System;

namespace ExercicioDesconto
{
    class Program
    {
        public delegate decimal CalculateDiscount(decimal precoOriginal);

        static void Main(string[] args)
        {
            Console.WriteLine("=== Sistema de Cálculo de Desconto ===");

            decimal precoOriginal;
            while (true)
            {
                Console.Write("Informe o preço original do produto: ");
                if (decimal.TryParse(Console.ReadLine(), out precoOriginal) && precoOriginal > 0)
                    break;
                Console.WriteLine("Valor inválido! Digite um número positivo.");
            }

            CalculateDiscount calculadorDesconto = AplicarDesconto10Porcento;
            decimal precoComDesconto = calculadorDesconto(precoOriginal);

            Console.WriteLine($"\nPreço original: R${precoOriginal:F2}");
            Console.WriteLine($"Preço com 10% de desconto: R${precoComDesconto:F2}");
        }

        static decimal AplicarDesconto10Porcento(decimal precoOriginal)
        {
            return precoOriginal * 0.9m;
        }
    }
}