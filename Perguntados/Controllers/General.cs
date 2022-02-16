using Core.Entities;
using Perguntados.Helpers;
using System.Text.Json;

namespace Perguntados.Controllers
{
    public class General
    {
        private string _fileName = "C:\\Projetos\\Treinamento\\Perguntados\\Perguntados\\Data\\banco.json";
        private readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            //PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true,
            WriteIndented = true,
        };
        public string? InserePergunta(Pergunta pergunta)
        {
            try
            {
                List<Pergunta> perguntas = JsonSerializer.Deserialize<List<Pergunta>>(Helper.GetJSON(_fileName), _options);
                perguntas.Add(pergunta);

                var jsonOutput = JsonSerializer.Serialize<List<Pergunta>>(perguntas);

                Helper.SetJSON(_fileName, jsonOutput);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return null;

        }

        public string ExcluiPergunta(int id)
        {
            try
            {
                List<Pergunta> perguntas = JsonSerializer.Deserialize<List<Pergunta>>(Helper.GetJSON(_fileName), _options);
                Pergunta pergunta = perguntas.Where( x => x.Id == id).FirstOrDefault();

                if (pergunta != null)
                {
                    perguntas.Remove(pergunta);
                }

                var jsonOutput = JsonSerializer.Serialize<List<Pergunta>>(perguntas);

                Helper.SetJSON(_fileName, jsonOutput);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return null;
        }
    }
}
