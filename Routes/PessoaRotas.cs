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
            app.MapGet(pattern:"/pessoas", handler: () => Pessoas);

            app.MapGet(pattern:"/pessoas/{nome}",
                handler: (string nome) => Pessoas.Find(x => x.Nome == nome));

            app.MapPost(pattern:"/pessoas",
                handler:(HttpContext request, Pessoa pessoa) =>
                {
                    //if (pessoa.Nome != "Gabriel")
                    //    return Results.BadRequest(error: new {message = "Nome não suportado"});

                    var nome = request.Request.Query["name"];

                    Pessoas.Add(pessoa);
                    return Results.Ok(pessoa);
                });

            app.MapPut(pattern: "/pessoas/{id:guid}", handler: (Guid id, Pessoa pessoa) =>
            {
                var encontrado = Pessoas.Find(x => x.Id == id);

                if (encontrado == null)                
                    return Results.NotFound();

                encontrado.Nome = pessoa.Nome;

                return Results.Ok(encontrado);
            });
        }

    }
}
