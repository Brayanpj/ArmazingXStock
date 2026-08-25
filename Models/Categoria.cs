namespace ArmazingXStock.Api.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; } = string.Empty; //Descrição é opcional, então pode não possuir valor.
        public bool Ativo { get; set; } = true; //Assim toda nova categoria ficará ativa por padrão.
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public ICollection<TipoProduto> TiposProdutos { get; set; } =
            new List<TipoProduto>(); // Isso responde quais TipoProduto tem essa categoria.



    };
    



    }
