
#nullable enable
namespace Core.Entities
{
    public class Pergunta
    {
        public int Id { get; set; }
        public string? Questao { get; set; }
        public int Certa { get; set; }
        public List<Resposta>? Respostas { get; set; }
    }
}
