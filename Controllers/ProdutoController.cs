using ArmazingXStock.Api.Data;
using ArmazingXStock.Api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArmazingXStock.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {   
        private readonly ArmazingXStockContext _context;//injeção de dependência do contexto do banco de dados
        public ProdutoController(ArmazingXStockContext context) 
        {
            _context = context;
        }

        [HttpGet()] 
        public async Task<IActionResult> GetProdutos() 
        {
            var produtos = await _context.Produtos.ToListAsync();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduto(int id)
        {
            var produto = await _context.Produtos.FindAsync(id); //verifica se o produto existe no banco de dados


            if (produto == null)
            {
                return NotFound();
            } 
            return Ok(produto);
        }
        
        [HttpPost()]//método para criar um novo produto
        public async Task<IActionResult> CreateProduto([FromBody] Produto produto)
        {
            if (produto == null)
            {
                return BadRequest("Os dados do Produto são obrigatórios.");
            }
            var tipoProduto = await _context.TiposProdutos
                .FindAsync(produto.TipoProdutoId);  //verifica se o tipo de produto existe no banco de dados 
           
            if (tipoProduto == null)
            {
                return BadRequest("Tipo de Produto não encontrado.");
            }

            if (string.IsNullOrWhiteSpace(tipoProduto.PrefixoSKU))
            {
                return BadRequest("O Tipo de Produto não possui um prefixo SKU válido.");
            }
            
            string prefixo = tipoProduto.PrefixoSKU.Trim().ToUpperInvariant();

            var skusExistentes = await _context.Produtos //consulta os SKUs existentes no banco de dados
            .Where(p => p.SKU.StartsWith(prefixo) //procura os SKUs que começam com o prefixo desejado.
            && p.SKU.Length == prefixo.Length + 4)
            .Select(p => p.SKU)
            .ToListAsync(); 

            int maiorSequencia = 0;

            foreach (string skuExistente in skusExistentes)
            {
                string parteNumerica = skuExistente.Substring(prefixo.Length);

                if (int.TryParse(parteNumerica, out int numero)
                    && numero > maiorSequencia)
                {
                    maiorSequencia = numero;
                }
            }

            if (maiorSequencia >= 9999)
            {
                return BadRequest("A sequência de SKUs deste prefixo foi esgotada.");
            }

            int proximaSequencia = maiorSequencia + 1;

            produto.SKU = $"{prefixo}{proximaSequencia:D4}";



            _context.Produtos.Add(produto);//adiciona o produto ao contexto do banco de dados
            await _context.SaveChangesAsync();

            //retorna um status code 201 (Created) indicando que o produto foi criado com sucesso
            return CreatedAtAction(
            //retorna o método GetProduto para que o cliente possa obter os detalhes do produto recém-criado
                nameof(GetProduto),
                new { id = produto.Id }, //retorna o id do produto recém-criado
                produto //retorna o produto recém-criado
            ); 

        }

        [HttpPut("{id}")] //método para atualizar um produto existente
          public async Task<IActionResult> UpdateProduto(int id, [FromBody] Produto produto) //recebe o id do produto a ser atualizado e os dados atualizados do produto
        {
              if (produto == null)
              {
                  return BadRequest("Os dados do Produto são obrigatórios.");
              }

              var produtoExistente = await _context.Produtos.FindAsync(id);//verifica se o produto existe no banco de dados 
              
            
            if (produtoExistente == null)
              {
                  return NotFound("Produto não encontrado.");
              }

              // Atualiza as propriedades do produto existente
              produtoExistente.Nome = produto.Nome;
              produtoExistente.TipoProdutoId = produto.TipoProdutoId;
              produtoExistente.Descricao = produto.Descricao;
              produtoExistente.PrecoVenda = produto.PrecoVenda; 


              await _context.SaveChangesAsync();
              return Ok(produtoExistente);
          }

        [HttpDelete("{id}")] //método para deletar um produto existente 
        public async Task<IActionResult> DeleteProduto(int id) //recebe o id do produto a ser deletado
        {
            var produto = await _context.Produtos.FindAsync(id); //verifica se o produto existe no banco de dados
            
            if (produto == null)
            {
                return NotFound("Produto não encontrado.");
            }
            _context.Produtos.Remove(produto); //remove o produto do contexto do banco de dados
            await _context.SaveChangesAsync();
            return NoContent(); //retorna um status code 204 (No Content) indicando que a operação foi bem-sucedida, mas não há conteúdo para retornar.
        }
    }
}
