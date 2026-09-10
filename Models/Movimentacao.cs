namespace ArmazingXStock.Api.Models
{
    public class Movimentacao
    {
        // Chave primária da tabela Movimentacao.
        public int Id { get; set; } 

        public int? PosicaoOrigemId { get; set; } // Chave estrangeira para a tabela PosicaoEstoque de origem (opcional). 
       
        public int? PosicaoDestinoId { get; set; } // Chave estrangeira para a tabela PosicaoEstoque de destino (opcional).

        public PosicaoEstoque? PosicaoOrigem { get; set; } // Propriedade de navegação para PosicaoEstoque de origem (opcional).

        // Propriedade de navegação para PosicaoEstoque. 
        public PosicaoEstoque? PosicaoDestino { get; set; }

        // Tipo de movimentação (entrada,saída ou transferêmcia).
        public TipoMovimentacao TipoMovimentacao { get; set; } 

        public int QuantidadeMovimentada { get; set; }

        public DateTime DataMovimentacao { get; set; } = DateTime.Now; 

    }
}
