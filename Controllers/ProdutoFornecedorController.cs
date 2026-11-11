using ArmazingXStock.Api.Data;
using ArmazingXStock.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace ArmazingXStock.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoFornecedorController : ControllerBase
    {
        private readonly ArmazingXStockContext _context;

        public ProdutoFornecedorController(ArmazingXStockContext context)
        {
            _context = context;
        }

        [HttpGet("{ProdutoId}")] 
        public IActionResult GetProdutosFornecedores(int ProdutoId)
        {
            var produtosFornecedores = _context.ProdutosFornecedores.Where(p => p.ProdutoId == ProdutoId).ToList();
            return Ok(produtosFornecedores);
        }

        [HttpGet("{ProdutoId}/{FornecedorId}")]
        public IActionResult GetProdutoFornecedor(int ProdutoId, int FornecedorId)
        {
            var produtoFornecedor = _context.ProdutosFornecedores.FirstOrDefault(p => p.ProdutoId == ProdutoId && p.FornecedorId == FornecedorId);
            if (produtoFornecedor == null)
            {
                return NotFound();
            }
            return Ok(produtoFornecedor);
        }

        [HttpPost("{ProdutoId}")]
        public IActionResult CreateProdutoFornecedor(int ProdutoId, [FromBody] ProdutoFornecedor produtoFornecedor)
        {
            produtoFornecedor.ProdutoId = ProdutoId; // Recebe o ProdutoId pela rota, e transfere o valor para entidade produtoFornecedor.
            _context.ProdutosFornecedores.Add(produtoFornecedor);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetProdutoFornecedor), new { produtoFornecedor.ProdutoId, FornecedorId = produtoFornecedor.FornecedorId }, produtoFornecedor);
        }

        [HttpPut("{ProdutoId}/{FornecedorId}")]
        public IActionResult UpdateProdutoFornecedor(int ProdutoId, int FornecedorId, [FromBody] ProdutoFornecedor produtoFornecedor)
        {
            var existingProdutoFornecedor = _context.ProdutosFornecedores.FirstOrDefault(p => p.ProdutoId == ProdutoId && p.FornecedorId == FornecedorId);
            
            
            if (existingProdutoFornecedor == null)
            {
                return NotFound();
            }
            
            existingProdutoFornecedor.FornecedorId = produtoFornecedor.FornecedorId; 
            existingProdutoFornecedor.ProdutoId = produtoFornecedor.ProdutoId;
            // Atualize outros campos conforme necessário

            _context.SaveChanges();
            return Ok(existingProdutoFornecedor);
        }

    }
}



