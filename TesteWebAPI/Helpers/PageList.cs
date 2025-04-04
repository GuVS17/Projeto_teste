using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TesteWebAPI.Helpers
{
    public class PageList<T> : List<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public PageList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);   //Ceiling vai arredondar o número e precisa do double pra ele ficar certo
            this.AddRange(items);                                       //AddRange adiciona itens na lista
        }

        public static async Task<PageList<T>> CreateAsync( IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageNumber-1) * pageSize)
                                    .Take(pageSize)                      //Pegar a quantidade de páginas
                                    .ToListAsync();                      
            return new PageList<T>(items, count, pageNumber, pageSize);
        }
    }
}