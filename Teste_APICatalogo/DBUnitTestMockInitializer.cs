using APICatalogo.Context;
using APICatalogo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_APICatalogo
{
    public class DBUnitTestMockInitializer
    {
        public DBUnitTestMockInitializer()
        { }

        public void Seed(AppDbContext context)
        {
            context.Categorias.Add
                (new Categoria { CategoriaId = 999, Nome = "Bebidas999", ImagemUrl = "Bebidas999.jpg"});

            context.Categorias.Add
                (new Categoria { CategoriaId = 2, Nome = "Sucos", ImagemUrl = "Sucos1.jpg" });

            context.Categorias.Add
                (new Categoria { CategoriaId = 3, Nome = "Doces", ImagemUrl = "Doces1.jpg" });

            context.Categorias.Add
                (new Categoria { CategoriaId = 4, Nome = "Salgados", ImagemUrl = "Salgados1.jpg" });

            context.Categorias.Add
                (new Categoria { CategoriaId = 5, Nome = "Tortas", ImagemUrl = "Tortas1.jpg" });

            context.Categorias.Add
                (new Categoria { CategoriaId = 6, Nome = "Bolos", ImagemUrl = "Bolos1.jpg" });

            context.Categorias.Add
                (new Categoria { CategoriaId = 7, Nome = "Lanches", ImagemUrl = "Lanches1.jpg" });
        }
    }
}
