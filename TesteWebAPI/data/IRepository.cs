using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteWebAPI.models;

namespace TesteWebAPI.data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        Task<Produto[]> GetAllProdutosAsync();
        Task<Produto> GetProdutosByIdAsync(int produtoId);

    };
}