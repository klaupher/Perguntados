using Core.Entities;
using Perguntados.Helpers;
using System.Text.Json;

namespace Perguntados.Controllers
{
    public class General
    {
        private string _fileName = "C:\\Projetos\\Treinamento\\Perguntados\\Perguntados\\Data\\banco.json";
        public string? InserePergunta(Pergunta pergunta)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };
            try
            {
                List<Pergunta>? perguntas = JsonSerializer.Deserialize<List<Pergunta>>(Helper.GetJSON(_fileName), options);
                perguntas.Add(pergunta);
                Helper.SetJSON(_fileName, JsonSerializer.Serialize(perguntas));
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return null;

        }
    }
}
