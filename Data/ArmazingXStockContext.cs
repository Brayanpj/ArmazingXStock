using ArmazingXStock.Api.Models; // Permite utilizar as classes do namespace ArmazingXStock.Api.Models.
using Microsoft.EntityFrameworkCore;


namespace ArmazingXStock.Api.Data
{
    public class ArmazingXStockContext : DbContext
    {
        public ArmazingXStockContext(
            DbContextOptions<ArmazingXStockContext> options)
            : base(options)
        {
       
    }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<TipoProduto> TiposProdutos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<ProdutoFornecedor> ProdutosFornecedores { get; set; }


        public DbSet<Armazem> Armazens { get; set; }
        public DbSet<Corredor> Corredores { get; set; }
        public DbSet<Rua> Ruas { get; set; }
        public DbSet<Modulo> Modulos { get; set; }
        public DbSet<Nivel> Niveis { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }


        public DbSet<PosicaoEstoque> PosicoesEstoque { get; set; }
        public DbSet<Movimentacao> Movimentacoes { get; set; }
    }
}
