using Microsoft.AspNetCore.Mvc;
using ArmazingXStock.Api.Data;
using ArmazingXStock.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ArmazingXStock.Api.Controllers
{
    [ApiController]
    // Nessa Rota que o Front-end vai acessar para pegar os dados da Categoria, ou seja, a rota é api/categorias.
    [Route("api/[controller]")] 
    public class CategoriasController : ControllerBase 
    {
        //Acesso ao banco de dados para o CRUD na tabela categoria.
        private readonly ArmazingXStockContext _context;

        public CategoriasController(ArmazingXStockContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCategorias()
        {   // Busca todas as categorias no banco e armazena o resultado na variável categorias.
            var categorias = _context.Categorias.ToList();
            // Retorna a lista de categorias como resposta HTTP com status 200 OK.
            return Ok(categorias); 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoria(int id)
        {
 // Busca a categoria com o ID especificado no banco de dados de forma assíncrona e armazena o resultado na variável categoria.
            var categoria = await _context.Categorias.FindAsync(id);

            if (categoria == null) 
            {
                return NotFound();
            }
            return Ok(categoria);
        }
        
        [HttpPost]
        // Recebe uma nova categoria no corpo da requisição HTTP e a adiciona ao banco de dados de forma assíncrona.
        public async Task<IActionResult> CreateCategoria([FromBody] Categoria categoria)
        {
            // Adiciona a nova categoria ao contexto do banco de dados.
            _context.Categorias.Add(categoria);
            // Salva as alterações no banco de dados de forma assíncrona.
            await _context.SaveChangesAsync(); 
            return CreatedAtAction(nameof(GetCategoria), new { id = categoria.Id }, categoria);
        }

        [HttpPut("{id}")]
        // Recebe uma categoria atualizada no corpo da requisição HTTP e atualiza a categoria existente no banco de dados com o ID especificado.
        public async Task<IActionResult> UpdateCategoria(int id, [FromBody] Categoria categoria)
      
        {
            if (id != categoria.Id)
            {
                return BadRequest();
            }
            // Marca a categoria como modificada no contexto do banco de dados, indicando que ela deve ser atualizada.
            _context.Entry(categoria).State = EntityState.Modified; 
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")] 
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            _context.Categorias.Remove(categoria);
            _context.SaveChanges();

            return NoContent();
        }

    }
}