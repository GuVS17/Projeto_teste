using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TesteWebAPI.data;
using TesteWebAPI.models;

namespace TesteWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProdutoController : ControllerBase
    {
        public IRepository _repo;
        public ProdutoController(IRepository repo)
        {
            _repo = repo;
        }


        /// <summary>
        /// Busca todos os produtos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get(){

            var produto = await _repo.GetAllProdutosAsync();
            if (produto == null) return BadRequest("Aluno não encontrado");

            return Ok(produto);
        }


        /// <summary>
        /// Busca produtos pelo Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id){

            var produto = await _repo.GetProdutosByIdAsync(id);
            if (produto == null) return BadRequest("Aluno não encontrado");

            return Ok(produto);
        }


        /// <summary>
        /// Insere um novo produto
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(Produto produtos) {
            
            _repo.Add(produtos);
            if (await _repo.SaveChangesAsync()) {
                return Created($"/api/produto/{produtos.Id}", produtos);
            }

            return Ok(produtos);
        }

        /// <summary>
        /// Atualiza um produto
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")] 
        public async Task<IActionResult> Put(int id, Produto produtos) {
            
            _repo.Update(produtos);
            if (await _repo.SaveChangesAsync()) {
                return Created($"/api/produto/{produtos.Id}", produtos);
            }

            return Ok("Produto atualizado");
        }


        /// <summary>
        /// Apaga um produto
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            
            var produto = await _repo.GetProdutosByIdAsync(id);
            if (produto == null) 
            {
                return NotFound("Produto não encontrado");
            }

            _repo.Delete(produto);
            await _repo.SaveChangesAsync();

                return Ok(new { message ="Produto Apagado"});
        }
    }
}



// [HttpDelete("{id}")]
//         public async Task<IActionResult> Delete(int id) {
            
//             _repo.Delete(produtos);
//             if (await _repo.SaveChangesAsync()) {
//                 return Ok("Produto Apagado");
//             }
//             return BadRequest("Produto não apagado");

//         }