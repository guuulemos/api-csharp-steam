namespace Steam.Domain.Entidades
{
    public class Games
    {
        public long Id { get; private set; }
        public string Nome { get; set; }
        public string Developer { get; set; }

        public Games(long id, string nome, string developer)
        {
            Id = id;
            Nome = nome;
            Developer = developer;
        }
    }
}
