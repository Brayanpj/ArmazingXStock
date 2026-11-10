using Microsoft.AspNetCore.Mvc;
using ArmazingXStock.Api.Data;
using ArmazingXStock.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace ArmazingXStock.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]    
    public class FornecedorController : ControllerBase
    {
        private readonly ArmazingXStockContext _context;

        public FornecedorController(ArmazingXStockContext context)
        {
            _context = context;
        }
        
        [HttpGet()]
        public IActionResult GetFornecedores()
        {   // Busca todos os fornecedores no banco e armazena o resultado na variável fornecedores.
            var fornecedores = _context.Fornecedores.ToList();
            // Retorna a lista de fornecedores como resposta HTTP com status 200 OK.
            return Ok(fornecedores);
        }

        [HttpGet("{id}")] 
        public IActionResult GetFornecedor(int id)
        {
            // Busca o fornecedor com o ID especificado no banco de dados e armazena o resultado na variável fornecedor.
            var fornecedor = _context.Fornecedores.Find(id);
            if (fornecedor == null)
            {
                return NotFound();
            }
            return Ok(fornecedor);
        }

        [HttpPost] 
        public async Task<IActionResult> CreateFornecedor([FromBody] Fornecedor fornecedor)
        {
            // Adiciona a nova categoria ao contexto do banco de dados.
            _context.Fornecedores.Add(fornecedor);
            // Salva as alterações no banco de dados de forma assíncrona.
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetFornecedor), new { id = fornecedor.Id }, fornecedor);
        }

        [HttpPut("{id}")] 
        public async Task<IActionResult> UpdateFornecedor(int id, [FromBody] Fornecedor fornecedor)
        {
            if (fornecedor == null)
            {
                return BadRequest();
            }

            var fornecedorExistente = await _context.Fornecedores.FindAsync(id);

            if (fornecedorExistente == null)
            {
                return NotFound();
            }

            fornecedorExistente.NomeFantasia = fornecedorExistente.CNPJ;
            fornecedorExistente.RazaoSocial = fornecedorExistente.RazaoSocial;
            fornecedorExistente.CNPJ = fornecedorExistente.CNPJ; 
            fornecedorExistente.Telefone = fornecedorExistente.Telefone; 
            fornecedorExistente.Email = fornecedorExistente.Email;

            return NoContent(); // retorna 204 No Content para indicar que a atualização foi bem-sucedida, mas não há conteúdo adicional a ser retornado na resposta.
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFornecedor(int id)
        {
            var fornecedor = await _context.Fornecedores.FindAsync(id);
            if (fornecedor == null) 
            {
                return NotFound();
            }

            _context.Fornecedores.Remove(fornecedor); //marca a entidade como Deleted no contexto do Entity Framework Core
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}
