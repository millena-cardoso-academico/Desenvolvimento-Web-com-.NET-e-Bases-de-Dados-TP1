using System;

namespace CalculoAreaRetangulo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Calculadora de Área de Retângulo ===");

            double baseRetangulo = LerValorPositivo("Digite a base do retângulo: ");
            double altura = LerValorPositivo("Digite a altura do retângulo: ");

            Func<double, double, double> calcularArea = (b, h) => b * h;

            double area = calcularArea(baseRetangulo, altura);

            Console.WriteLine($"\nA área do retângulo com base {baseRetangulo} e altura {altura} é: {area}");
        }

        static double LerValorPositivo(string mensagem)
        {
            double valor;
            while (true)
            {
                Console.Write(mensagem);
                if (double.TryParse(Console.ReadLine(), out valor) && valor > 0)
                    break;
                Console.WriteLine("Valor inválido! Digite um número positivo.");
            }
            return valor;
        }
    }
}