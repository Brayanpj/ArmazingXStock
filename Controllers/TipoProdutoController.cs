using ArmazingXStock.Api.Data;
using ArmazingXStock.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArmazingXStock.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoProdutoController : ControllerBase
    {
        private readonly ArmazingXStockContext _context; 
        public TipoProdutoController(ArmazingXStockContext context)
        {
            _context = context;
        }

        [HttpGet()]
        public async Task<IActionResult> GetTiposProdutos()
        {   // Busca todos os tipos de produto no banco e armazena o resultado na variável Tiposprodutos.
            var Tiposprodutos = await _context.TiposProdutos.ToListAsync();
            // Retorna a lista de tipos de produto como resposta HTTP com status 200 OK.
            return Ok(Tiposprodutos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTipoProduto(int id)
        {
            var TipoProduto = await _context.TiposProdutos.FindAsync(id);
            if (TipoProduto == null)
            {
                return NotFound();
            }
            return Ok(TipoProduto);
        }
        [HttpGet("categoria/{categoriaId}")]
        public async Task<IActionResult> GetTiposProdutosByCategoria(int categoriaId)
        {
            var Tiposprodutos = await _context.TiposProdutos.Where(t => t.CategoriaId == categoriaId).ToListAsync();
            return Ok(Tiposprodutos);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateTipoProduto([FromBody] TipoProduto tipoProduto)
        {
            if (tipoProduto == null)
            {
                return BadRequest("Os dados do TipoProduto são obrigatórios.");
            }

            var categoria = await _context.Categorias
                .FindAsync(tipoProduto.CategoriaId);

            if (categoria == null)
            {
                return BadRequest("Categoria não encontrada.");
            }
            // Gera automaticamente o PrefixoSKU
            string nomeTipoProduto = tipoProduto.Nome
                .Trim()
                .ToUpper();
          
           
            int tamanhoNome = nomeTipoProduto.Length;
            string[] palavras = nomeTipoProduto.Split(' ');


             if(nomeTipoProduto.Length < 4)
            {
                return BadRequest("O nome do TipoProduto deve ter no mínimo 4 caracteres.");
            }

            else if (palavras.Length > 1) 
            {
                if (palavras[0].Length < 4)
                {
                    return BadRequest("O nome do TipoProduto deve ter no mínimo 4 caracteres na primeira palavra.");
                } 

                tipoProduto.PrefixoSKU = palavras[0].Substring(0, 4) + palavras[1].Substring(0, Math.Min(1, palavras[1].Length));
            }

            else if(tamanhoNome >= 7)
            {
                tipoProduto.PrefixoSKU = palavras[0].Substring(0, Math.Min(5, palavras[0].Length));
            }

            else if(nomeTipoProduto.Length >= 4 && nomeTipoProduto.Length <= 6)
            {
                tipoProduto.PrefixoSKU = nomeTipoProduto;
            }
         
            //tipoProduto.PrefixoSKU = prefixo.Length >= 6
            //    ? prefixo.Substring(0, 6)
            //    : prefixo;


            _context.TiposProdutos.Add(tipoProduto);

            await _context.SaveChangesAsync();

            return CreatedAtAction(
            nameof(GetTipoProduto),
            new { id = tipoProduto.Id },
            new
            {
            tipoProduto.Id,
            tipoProduto.Nome,
            tipoProduto.Descricao,
            tipoProduto.CategoriaId, 
            tipoProduto.PrefixoSKU,
            });
        }

        //[HttpPost("create")]
        //public async Task<IActionResult> CreateTipoProdutoWithCategoria([FromBody] TipoProduto tipoProduto)
        //{
        //    // Verifica se a categoria associada ao TipoProduto existe no banco de dados
        //    var categoria = await _context.Categorias.FindAsync(tipoProduto.CategoriaId);
        //    if (categoria == null)
        //    {
        //        return BadRequest("Categoria não encontrada.");
        //    }
        //    // Adiciona o TipoProduto ao contexto do banco de dados
        //    _context.TiposProdutos.Add(tipoProduto);
        //    await _context.SaveChangesAsync();
        //    return CreatedAtAction(nameof(GetTipoProduto), new { id = tipoProduto.Id }, tipoProduto);
        //}

        [HttpPut("{id}")]// Atualiza um TipoProduto existente com base no ID fornecido
        public async Task<IActionResult> UpdateTipoProduto(int id, [FromBody] TipoProduto tipoProduto) // Recebe o ID do TipoProduto a ser atualizado e os novos dados do TipoProduto no corpo da requisição 
        { 
            var tipoProdutoExistente = await _context.TiposProdutos.FindAsync(id);// Busca o TipoProduto existente no banco de dados com base no ID fornecido

            tipoProdutoExistente.Nome = tipoProduto.Nome; // Atualiza o nome do TipoProduto existente com o novo valor fornecido
            tipoProdutoExistente.Descricao = tipoProduto.Descricao;
            tipoProdutoExistente.CategoriaId = tipoProduto.CategoriaId;

            if (tipoProdutoExistente == null) 
            { 
                return NotFound("TipoProduto não encontrado.");
            }
            
            var categoria = await _context.Categorias.FindAsync(tipoProduto.CategoriaId); 
            
            if (categoria == null) 
            {
                return BadRequest("Categoria não encontrada.");
            }
            await _context.SaveChangesAsync(); return NoContent(); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoProduto(int id)
        {
            var TipoProduto = await _context.TiposProdutos.FindAsync(id);
            if (TipoProduto == null)
            {
                return NotFound();
            }

            _context.TiposProdutos.Remove(TipoProduto);
            _context.SaveChanges();

            return NoContent();
        } 


    }
}
