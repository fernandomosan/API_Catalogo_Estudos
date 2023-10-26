using ApiCatalogo.Repository;
using GraphQL;
using GraphQL.Types;

namespace ApiCatalogo.GraphQL
{
    public class CategoriaQuery : ObjectGraphType
    {
        [System.Obsolete]
        public CategoriaQuery(IUnitOfWork contexto)
        {
            Field<CategoriaType>("categorias", arguments: new QueryArguments(
                new QueryArgument<IntGraphType>() { Name = "id" }),
                resolve: contextGraph =>
                {
                    var id = contextGraph.GetArgument<int>("id");
                    return contexto.CategoriaRepository.GetById(c => c.CategoriaId == id);
                });

            Field<CategoriaType>("categorias",
                resolve: contextGraph =>
                {
                    return contexto.CategoriaRepository.Get();
                }
                );
        }
    }
}
