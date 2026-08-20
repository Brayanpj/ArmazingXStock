namespace ArmazingXStock.Api.Models
{
    public class ProdutoFornecedor
    { 
        public int Id { get; set; } 
        public int ProdutoId { get; set; } // Chave estrangeira para a tabela Produto.
        public Produto Produto { get; set; } = null!; // Propriedade de navegação para a tabela Produto.
        public int FornecedorId { get; set; } // Chave estrangeira para a tabela Fornecedor.
        public Fornecedor Fornecedor { get; set; } = null!; // Propriedade de navegação para a tabela Fornecedor.
        public bool Ativo { get; set; } = true; 
        public DateTime DataCadastro { get; set; } = DateTime.Now;

    }
}
