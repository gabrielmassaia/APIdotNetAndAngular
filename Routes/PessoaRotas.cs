using APIMassaia.Models;

namespace APIMassaia.Routes
{
    public static class PessoaRotas
    {
        public static List<Pessoa> Pessoas = new List<Pessoa>() 
        { 
            new Pessoa(id:Guid.NewGuid(), nome:"Luana Girola"),
            new Pessoa(id:Guid.NewGuid(), nome:"Carina Massaia"), 
            new Pessoa(id:Guid.NewGuid(), nome:"Eliane Massaia")
        };        
     
        public static void MapPessoaRotas(this WebApplication app)
        {
            app.MapGet(pattern: "/pessoas", handler: () => Pessoas);
        }

    }
}
