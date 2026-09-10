namespace ArmazingXStock.Api.Models
{
    public class Nivel
    { 
        public int Id { get; set; }
        public string Codigo { get; set; } = string.Empty; 
        public int ModuloId { get; set; } // Chave estrangeira para a tabela Modulo.
        public Modulo Modulo { get; set; } = null!; //Propriedade de navegação para a tabela Modulo.
        public bool Ativo { get; set; } = true; 
        public DateTime DataCadastro { get; set; } = DateTime.Now; //Data de cadastro do nível. 
        public ICollection<Endereco> Enderecos { get; set; }
        = new List<Endereco>();

    }
}
