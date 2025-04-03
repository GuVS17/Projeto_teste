using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TesteWebAPI.models;

namespace TesteWebAPI.data
{
    public class DataContext : DbContext 
    {
        
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}  //Configurações do banco de dados || base (options) passa as configurações para DbContext
        public DbSet<Produto> Produtos { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Produto>()
            .HasData(
                new Produto {Id = 1, Nome = "Teclado Mecânico", Quantidade = 10 },
                new Produto {Id = 2, Nome= "Mouse", Quantidade= 20 },
                new Produto {Id = 3, Nome= "Monitor", Quantidade= 5 },
                new Produto {Id = 4, Nome= "Cabo HDMI", Quantidade= 15 }
            );
        }
    }
}