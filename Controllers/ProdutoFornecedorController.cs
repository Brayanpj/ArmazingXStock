using ArmazingXStock.Api.Data;
using ArmazingXStock.Api.Models;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public IActionResult CreateProdutoFornecedor([FromBody] ProdutoFornecedor produtoFornecedor)
        {
            _context.ProdutosFornecedores.Add(produtoFornecedor);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetProdutoFornecedor), new { produtoFornecedor.ProdutoId, FornecedorId = produtoFornecedor.FornecedorId }, produtoFornecedor);
        }

    }
}



