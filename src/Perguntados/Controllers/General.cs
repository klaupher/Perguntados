using Core.Entities;
using Perguntados.Helpers;
using System.Text.Json;

namespace Perguntados.Controllers
{
    public class General
    {
        public void InserePergunta(Pergunta pergunta)
        {
            string dataBase = Helper.GetJSON();
            var perguntas = JsonSerializer.Deserialize<List<Pergunta>>(dataBase, new JsonSerializerOptions
            {
                //PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true,
                WriteIndented = true,
            });

            if (perguntas is not null)
            {
                perguntas.Add(pergunta);

                var jsonOutput = JsonSerializer.Serialize<List<Pergunta>>(perguntas);

                Helper.SetJSON(jsonOutput);
            }
        }

        public void ExcluiPergunta(int id)
        {
            string dataBase = Helper.GetJSON();
            var perguntas = JsonSerializer.Deserialize<List<Pergunta>>(dataBase, new JsonSerializerOptions
            {
                //PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true,
                WriteIndented = true,
            });

            if (perguntas != null)
            {
                var itemPergunta = perguntas.Single(x => x.Id == id);

                perguntas.Remove(itemPergunta);

                var jsonOutput = JsonSerializer.Serialize<List<Pergunta>>(perguntas);

                Helper.SetJSON(jsonOutput);
            }
        }
    }
}
