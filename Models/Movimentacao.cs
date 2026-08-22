namespace ArmazingXStock.Api.Models
{
    public class Movimentacao
    {
        // Chave primária da tabela Movimentacao.
        public int Id { get; set; } 

        // Chave estrangeira para a tabela PosicaoEstoque
        public int PosicaoEstoqueId { get; set; } 

        // Propriedade de navegação para PosicaoEstoque. 
        public PosicaoEstoque PosicaoEstoque { get; set; } = null!;

        // Tipo de movimentação (entrada ou saída).
        public TipoMovimentacao TipoMovimentacao { get; set; } 

        public int QuantidadeMovimentada { get; set; }

        public DateTime DataMovimentacao { get; set; } = DateTime.Now; 

    }
}
