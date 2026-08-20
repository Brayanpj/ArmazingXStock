namespace ArmazingXStock.Api.Models
{
    public class Rua
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CorredorId { get; set; } // Chave estrangeira para a tabela Corredor.
        public Corredor Corredor { get; set; } = null!; //Propriedade de navegação para a tabela Corredor. 
        public bool Ativo { get; set; } = true; 
        public <Icollection<Modulo> Modulos { get; set; } 
            = new List<Modulo>(); // Relacionamento 1:N com Modulo.




    }
}
