namespace APIMassaia.Models
{
    public class Pessoa
    {
        public Guid Id { get; set; }
        public String Nome { get; set; }

        public Pessoa(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
