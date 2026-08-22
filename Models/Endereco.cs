namespace ArmazingXStock.Api.Models
{
    public class Endereco
    {
        // Chave primária da tabela Endereco.
        public int Id { get; set; }

        //Código do endereço, não pode ser nulo.
        public string CodigoCompleto { get; set; } = string.Empty;

        //Classe Estrangeira para a tabela Nivel.
        public int NivelId { get; set; }    

        //Propriedade de navegação para Nivel
        public Nivel Nivel { get; set; } = null!;  

        public bool Ativo { get; set; } = true;

        //Capacidade máxima do endereço.
        public int CapacidadeMaxima { get; set; }

        //Data de cadastro do endereço.
        public DateTime DataCadastro { get; set; } = DateTime.Now; 




    }
}
