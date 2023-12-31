﻿using ApiCatalogo.Pagination;
using APICatalogo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiCatalogo.Repository
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        Task<PagedList<Categoria>> GetCategoria(CategoriaParameters categoriaParameters);
        Task<IEnumerable<Categoria>> GetCategoriasProdutos();
    }
}
