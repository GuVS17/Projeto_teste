using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TesteWebAPI.Helpers;
using TesteWebAPI.models;

namespace TesteWebAPI.data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;  

        public Repository(DataContext context){
            _context = context;  
        }

        public void Add<T>(T entity) where T : class{
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class{
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class{
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync(){
            return  (await _context.SaveChangesAsync()) > 0;
        }


        public async Task<PageList<Produto>> GetAllProdutosAsync(PageParams pageParams) {

            IQueryable<Produto> query = _context.Produtos;        //Consulta em Produto, permitindo modificar a query antes da execução no banco

            query = query.AsNoTracking()
                         .OrderBy(a => a.Id);
            
            return await Task.Run(() =>
                    PageList<Produto>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize));
        }

        public async Task<Produto> GetProdutosByIdAsync(int id) {

            return await _context.Produtos.FindAsync(id);
        }
    }
}


// public async Task<Produto> GetProdutosByIdAsync(int produtoId) {

//             IQueryable<Produto> query = _context.Produtos;

//             query = query.AsNoTracking()
//                          .Where(produto => produto.Id == produtoId);

//             return await query.FirstOrDefaultAsync();
//         }