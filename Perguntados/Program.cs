using Core.Entities;
using Perguntados.Controllers;
using Perguntados.Helpers;
using System.Text.Json;

namespace Perguntados
{
    internal class Program
    {
        private static readonly string _filename = "C:\\Projetos\\Treinamento\\Perguntados\\Perguntados\\Data\\banco.json";
        private static readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            //PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true,
            WriteIndented = true,
        };

        static void Main(string[] args)
        {
            while (true)
            {
                var escolha = MenuUsuario();
                if (escolha == 4)
                    return;
                switch (escolha)
                {
                    case 1:
                        ListaPerguntas();
                        break;
                    case 2:
                        InserirPergunta();
                        break;
                    case 3:
                        DeletarPergunta();
                        break;
                }
                
            }
            
            
        }

        private static void DeletarPergunta()
        {
            Console.WriteLine("Informe a pergunta que vc deseja escluir");
            Console.Write("Informe o ID: ");
            int idQuestao = Convert.ToInt32(Console.ReadLine());
            General general = new General();
            string retorno = general.ExcluiPergunta(idQuestao);

            if (!string.IsNullOrEmpty(retorno))
            {
                Console.WriteLine($"Ocorreu um erro na exclusão: {retorno}");
            }
            Console.WriteLine("----- Pergunta Excluida com sucesso -----");
        }

        private static void InserirPergunta()
        {
            Pergunta pergunta = new Pergunta();

            Console.WriteLine("Informe os dados solicitados");
            Console.Write("Numero da Questao: ");
            pergunta.Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Descrição da Questao: ");
            pergunta.Questao = Console.ReadLine();
            Console.WriteLine("Informe as alternativa da questão");
            int contador = 1;
            string? resp = "S";
            pergunta.Respostas = new List<Resposta>();
            do
            {
                pergunta.Respostas.Add(InsereRespostas(contador));
                contador++;
                Console.Write("Continua (S/N) ?");
                resp = Console.ReadLine();
            } 
            while (!resp.ToUpper().Equals("N"));

            General general = new General();
            string retorno = general.InserePergunta(pergunta);
            
            if (!string.IsNullOrEmpty(retorno)){
                Console.WriteLine($"Ocorreu um erro na gravação: {retorno}");
            }
            Console.WriteLine("----- Dados gravados com sucesso -----");

        }

        private static Resposta InsereRespostas(int id)
        {
            Resposta resposta = new Resposta();
            resposta.Id = id;
            Console.Write($"Resposta {id}: ");
            resposta.Resp = Console.ReadLine();
            return resposta;
        }

        static void ListaPerguntas()
        {
            //List<Pergunta>? perguntas = JsonSerializer.Deserialize<List<Pergunta>>(Helper.GetJSON(_filename), new JsonSerializerOptions
            //{
            //    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            //    WriteIndented = true,
            //});
            var jsonInput = Helper.GetJSON(_filename);
            List<Pergunta> perguntas = JsonSerializer.Deserialize<List<Pergunta>>(jsonInput, _options);

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