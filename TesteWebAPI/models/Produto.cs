using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteWebAPI.models
{
    public class Produto
    {
        public Produto(){}

        public Produto(int id, string nome, int quantidade) {

            this.Id = id;
            this.Nome = nome;
            this.Quantidade = quantidade;
        }

        public int Id { get; set;}
        public required string Nome { get; set;}
        public int Quantidade { get; set;}
    }
}