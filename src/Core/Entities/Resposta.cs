namespace Core.Entities
{
    public class Resposta
    {
        public Resposta(int id, string? resp)
        {
            Id = id;
            Resp = resp;
        }

        public int Id { get; private set; }

        public string? Resp { get; private set; }
    }
}
