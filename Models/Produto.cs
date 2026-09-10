namespace ArmazingXStock.Api.Models
{
    public class Produto
    {
        public int Id { get; set; } //Id é a chave primária da tabela Produto, então não pode ser nulo.
        public string SKU { get; set; } = string.Empty; //SKU é obrigatório, então não pode ser nulo.
        public string Nome { get; set; } = string.Empty;//Nome é obrigatório, então não pode ser nulo.
        public string Descricao { get; set; } = string.Empty; //? significa que null é permitido, ou seja, a propriedade Descricao pode não ter valor.
        public int TipoProdutoId { get; set; } //Essa Propriedade é a chave estrangeira que referencia a tabela TipoProduto.
        public TipoProduto TipoProduto { get; set; } = null!; 
        public int EstoqueMinimo { get; set; } 
        public bool Ativo { get; set; } = true;
        public ICollection<ProdutoFornecedor> ProdutosFornecedores { get; set; }
        = new List<ProdutoFornecedor>();
        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
