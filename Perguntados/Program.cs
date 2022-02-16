using Core.Entities;
using System.Text.Json;

namespace Perguntados
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            var fileJson = "C:\\Projetos\\Treinamento\\Perguntados\\Perguntados\\Data\\banco.json";
            var jsonString = File.ReadAllText(fileJson);
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };
            List<Pergunta>? perguntas = JsonSerializer.Deserialize<List<Pergunta>>(jsonString, options);

            if (perguntas.Any())
            {
                foreach (var perg in perguntas)
                {
                    Console.WriteLine($"{perg.Id} - {perg.Questao}");
                }
            }
            
        }
    }
}