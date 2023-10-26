using APICatalogo.Models;
using GraphQL.Types;

namespace ApiCatalogo.GraphQL
{
    public class CategoriaType : ObjectGraphType<Categoria>
    {
        public CategoriaType()
        {
            Field(op => op.CategoriaId);
            Field(op => op.Nome);
            Field(op => op.ImagemUrl);

            Field<ListGraphType<CategoriaType>>("categorias");
        }
    }
}
