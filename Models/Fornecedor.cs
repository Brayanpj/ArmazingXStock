namespace ArmazingXStock.Api.Models
{
    public class Fornecedor
    {
        // Chave Primária da tabela Fornecedor, não pode ser nulo.
        // O EF Core reconhecerá "Id" como chave primária por convenção.
        public int Id { get; set; } 

        public string RazaoSocial { get; set; } = string.Empty; 
        
        public string? NomeFantasia { get; set; }

        public string CNPJ { get; set; } = string.Empty;

        public string? Telefone { get; set; } 

        public string? Email { get; set; } 

        public bool Ativo { get; set; } = true; 

        public ICollection<ProdutoFornecedor> ProdutosFornecedores { get; set; } = new List<ProdutoFornecedor>();

        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
