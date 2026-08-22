

namespace ArmazingXStock.Api.Models
{
    public class PosicaoEstoque
    {
        // Chave primária da tabela PosicaoEstoque.
        public int Id { get; set; }

        // Chave estrangeira para a tabela Endereco.
        public int EnderecoId { get; set; } 

        public int ProdutoId { get; set; } 

        public int Quantidade { get; set; }

        // Propriedade de navegação para Endereco
        public Endereco Endereco { get; set; } = null!;

        // Propriedade de navegação para Produto
        public Produto Produto { get; set; } = null!;

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public DateTime DataAtualizacao { get; set; } = DateTime.Now;

    }
}
