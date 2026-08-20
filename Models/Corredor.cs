namespace ArmazingXStock.Api.Models
{
    public class Corredor
    {
        public int Id { get; set; } 
        public string Codigo { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public int ArmazemId { get; set; } // Chave estrangeira para a tabela Armazem.
        public Armazem Armazem { get; set; } = null!; //Propriedade de navegação para a tabela Armazem.
        public bool Ativo { get; set; } = true;
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public ICollection<Rua> Ruas { get; set; } 
            = new List<Rua>();>


    }
}
