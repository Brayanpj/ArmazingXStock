namespace ArmazingXStock.Api.Models
{
    public class TipoProduto
    { 
        public int Id { get; set; } 
        public string Nome { get; set; } = string.Empty; 
        public string Descricao { get; set; } = string.Empty;

        //chave estrangeira que referencia Categoria
        public int CategoriaId { get; set; }
        
        //propriedade de navegação para Categoria
        public Categoria Categoria { get; set; } = null!;

        //Relacionamento 1:N com Produto
        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
        public bool Ativo { get; set; } = true;
        public DateTime DataCadastro { get; set; } = DateTime.Now; 
        
    } 
}
