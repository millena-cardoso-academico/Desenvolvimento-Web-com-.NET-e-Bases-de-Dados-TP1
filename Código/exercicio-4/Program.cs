using System;

namespace MonitoramentoTemperatura
{
    public class TemperatureSensor
    {
        public event Action<double> TemperatureExceeded = null!;

        public void ReadTemperature(double temperature)
        {
            Console.WriteLine($"Temperatura lida: {temperature}°C");

            if (temperature > 100)
            {
                OnTemperatureExceeded(temperature);
            }
        }

        protected virtual void OnTemperatureExceeded(double temperature)
        {
            TemperatureExceeded?.Invoke(temperature);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Sistema de Monitoramento de Temperatura ===");
            Console.WriteLine("Digite as temperaturas (em °C) para simular as leituras do sensor");
            Console.WriteLine("Digite 'sair' para encerrar o programa\n");

            var sensor = new TemperatureSensor();

            sensor.TemperatureExceeded += temperature => 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ALERTA: Temperatura crítica de {temperature}°C detectada!");
                Console.ResetColor();
            };

            while (true)
            {
                Console.Write("Digite a temperatura: ");
                string? input = Console.ReadLine();

                if (input?.ToLower() == "sair")
                    break;

                if (double.TryParse(input, out double temp))
                {
                    sensor.ReadTemperature(temp);
                }
                else
                {
                    Console.WriteLine("Valor inválido! Digite um número ou 'sair'");
                }
            }
        }
    }
}