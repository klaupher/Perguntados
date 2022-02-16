using System.Text.Json.Serialization;

namespace Core.Entities
{
    public class Pergunta
    {
        public Pergunta(
            int id, 
            string? questao, 
            List<Resposta> respostas)
        {
            Id = id;
            Questao = questao;
            Respostas = respostas;
        }

        public Pergunta(
            int id,
            int certa)
        {
            Id = id;
            Certa = certa;
        }

        [JsonConstructor]
        public Pergunta(int id, string? questao, int certa, List<Resposta>? respostas)
        {
            Id = id;
            Questao = questao;
            Certa = certa;
            Respostas = respostas;
        }

        public int Id { get; private set; }

        public string? Questao { get; private set; }

        public int Certa { get; private set; }

        public List<Resposta>? Respostas { get; private set; }
    }
}
