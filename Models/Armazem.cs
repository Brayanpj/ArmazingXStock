namespace ArmazingXStock.Api.Models
{
    public class Armazem
    { 
        public int Id { get; set; } 
        public string Codigo { get; set; } = string.Empty; 
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; } 
        public bool Ativo { get; set; } = true; 
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public ICollection<Corredor> Corredores { get; set; }
           = new List<Corredor>();

    }
}
