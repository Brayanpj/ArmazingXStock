namespace ArmazingXStock.Api.Models
{
    public class Modulo
    {
        // Chave primária da tabela Modulo.
        public int Id { get; set; }
        
        //Código do módulo, não pode ser nulo.
        public string Codigo { get; set; } = string.Empty;
        
        //Propriedade de navegação para Rua  
        public Rua Rua { get; set; } = null!;
        
        //Indica se o módulo está ativo ou não.
        public bool Ativo { get; set; } = true;
        
        // Chave estrangeira para a tabela Rua.  
        public int RuaId { get; set; } 
        public DateTime DataCadastro { get; set; } = DateTime.Now; //Data de cadastro do módulo.
        
        // Relacionamento 1:N com Nivel. 
        public ICollection<Nivel> Niveis { get; set; } 
            = new List<Nivel>();

    }
}
