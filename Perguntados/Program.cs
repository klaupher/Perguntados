using Core.Entities;
using System.Text.Json;

namespace Perguntados
{
    internal class Program
    {
        private static readonly string _filename = "C:\\Projetos\\Treinamento\\Perguntados\\Perguntados\\Data\\banco.json";
        private static readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true,
        };

        static void Main(string[] args)
        {
            while (true)
            {
                var escolha = MenuUsuario();
                if (escolha == 4)
                    return;
                switch (escolha) {
                    case 1: ListaPerguntas();
                        break;
                }
                
            }
            
            
        }

        static void ListaPerguntas()
        {
            List<Pergunta>? perguntas = JsonSerializer.Deserialize<List<Pergunta>>(Helpers.Helper.GetJSON(_filename), _options);

            if (perguntas.Any())
            {
                foreach (var perg in perguntas)
                {
                    Console.WriteLine($"{perg.Id} - {perg.Questao}");
                }
            }
            Console.WriteLine();
        }
        static int MenuUsuario()
        {
            Console.WriteLine("******** SELECIONE UMA OPÇÃO ***********");
            Console.WriteLine();
            Console.WriteLine("1 - Listar todas as perguntas");
            Console.WriteLine("2 - Inserir nova pergunta");
            Console.WriteLine("3 - Excluir uma pergunta");
            Console.WriteLine("4 - Sair");
            Console.Write("Digite sua opção: ");
            try
            {
                int resp = Convert.ToInt32(Console.ReadLine());
                return resp;
            }
            catch (Exception)
            {
                return 4;
            }
        }
    }
}