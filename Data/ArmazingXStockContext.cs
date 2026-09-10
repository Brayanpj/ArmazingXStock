using ArmazingXStock.Api.Models; // Permite utilizar as classes do namespace ArmazingXStock.Api.Models.
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace ArmazingXStock.Api.Data
{
    public class ArmazingXStockContext : DbContext
    {
        public ArmazingXStockContext(
            DbContextOptions<ArmazingXStockContext> options)
            : base(options)
        {
        }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<TipoProduto> TiposProdutos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<ProdutoFornecedor> ProdutosFornecedores { get; set; }

        public DbSet<Armazem> Armazens { get; set; }
        public DbSet<Corredor> Corredores { get; set; }
        public DbSet<Rua> Ruas { get; set; }
        public DbSet<Modulo> Modulos { get; set; }
        public DbSet<Nivel> Niveis { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }


        public DbSet<PosicaoEstoque> PosicoesEstoque { get; set; }
        public DbSet<Movimentacao> Movimentacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Produto>()
                .HasIndex(p => p.SKU) //quero um indice para a propriedade Produto.SKU
                .IsUnique(); //garante que o SKU seja único no banco de dados 

            modelBuilder.Entity<Produto>()
                .Property(p => p.SKU)
                .HasMaxLength(8)
                .IsRequired();

            modelBuilder.Entity<Produto>()
                .ToTable(t => t.HasCheckConstraint(
                "CK_Produto_SKU_Length",
                "CHAR_LENGTH(SKU) = 8"
                ));

            modelBuilder.Entity<Produto>()
                .Property(p => p.Nome)
                .HasMaxLength(150)
                .IsRequired();

            modelBuilder.Entity<Produto>()
                .Property(d => d.Descricao)
                .HasMaxLength(500)
                .IsRequired();

            modelBuilder.Entity<Produto>()
                .Property(p => p.EstoqueMinimo)
                .HasDefaultValue(0);

            modelBuilder.Entity<Produto>()
                .ToTable(t => t.HasCheckConstraint(
                "CK_Produto_EstoqueMinimo_NonNegative",
                 "EstoqueMinimo >= 0"
                ));

            modelBuilder.Entity<Produto>()
                .HasOne(p => p.TipoProduto)
                .WithMany(tp => tp.Produtos)
                .HasForeignKey(p => p.TipoProdutoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProdutoFornecedor>()
                .HasOne(pf => pf.Produto)
                .WithMany(p => p.ProdutosFornecedores) // Um produto possui muitas associações ao ProdutoFornecedor.
                .HasForeignKey(pf => pf.ProdutoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProdutoFornecedor>() // Quero Configurar a entidade ProdutoFornecedor 
                .HasIndex(pf => new { pf.ProdutoId, pf.FornecedorId })
                .IsUnique(); // Impede que o mesmo produto seja associado ao mesmo fornecedor mais de uma vez.

            modelBuilder.Entity<ProdutoFornecedor>()
                .HasOne(pf => pf.Fornecedor)
                .WithMany(pf => pf.ProdutosFornecedores) // Um fornecedor possui muitas associações ao ProdutoFornecedor.
                .HasForeignKey(pf => pf.FornecedorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Fornecedor>()
                .HasIndex(f => f.CNPJ)
                .IsUnique(); // Impede que o mesmo fornecedor seja cadastrado mais de uma vez com o mesmo CNPJ.

            modelBuilder.Entity<Fornecedor>()
                .Property(f => f.CNPJ) //Dentro do Fornecedor quero configurar a propriedade CNPJ.
                .HasMaxLength(14) // Define o tamanho máximo do campo CNPJ como 14 caracteres.
                .IsRequired(); // Define que o campo CNPJ é obrigatório (não pode ser nulo).

            modelBuilder.Entity<Fornecedor>()
                 .ToTable(t => t.HasCheckConstraint(// Antes de aceitar uma linha nessa tabela, esta condição precisa ser verdadeira.
                 "CK_Fornecedor_CNPJ_Length",
                 "CHAR_LENGTH(CNPJ) = 14" //O valor armazenado em CNPJ precisa ter exatamente 14 caracteres para satisfazer essa CHECK Constraint.
                 ));

            modelBuilder.Entity<Fornecedor>()
                .Property(f => f.RazaoSocial)
                .HasMaxLength(150)
                .IsRequired();

            modelBuilder.Entity<Fornecedor>()
                .Property(f => f.NomeFantasia)
                .HasMaxLength(150);

            modelBuilder.Entity<Fornecedor>()
                .Property(f => f.Telefone)
                .HasMaxLength(20)
                .IsRequired();

            modelBuilder.Entity<Fornecedor>()
                .Property(f => f.Email)
                .HasMaxLength(150);

            modelBuilder.Entity<Categoria>()
                .HasIndex(c => c.Nome)// Cria um índice na propriedade Nome da entidade Categoria
                .IsUnique(); // Impede que o mesmo nome de categoria seja cadastrado mais de uma vez.

            modelBuilder.Entity<Categoria>()
                .Property(c => c.Nome)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Categoria>()
                .Property(c => c.Descricao)
                .HasMaxLength(300)
                .IsRequired();

            modelBuilder.Entity<TipoProduto>()
                .HasIndex(tp => new { tp.Nome, tp.CategoriaId }) // Cria um índice composto nas propriedades Nome e CategoriaId da entidade TipoProduto
                .IsUnique(); // Impede que o mesmo nome de tipo de produto seja cadastrado mais de uma vez para a mesma categoria.

            modelBuilder.Entity<TipoProduto>()
                .Property(tp => tp.Nome)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<TipoProduto>()
                .Property(tp => tp.Descricao)
                .HasMaxLength(300)
                .IsRequired();

            modelBuilder.Entity<TipoProduto>()
                .HasOne(tp => tp.Categoria)
                .WithMany(c => c.TiposProdutos)
                .HasForeignKey(tp => tp.CategoriaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Armazem>()
                 .Property(ar => ar.Codigo)
                 .HasMaxLength(5)
                 .IsRequired();

            modelBuilder.Entity<Armazem>()
                .HasIndex(ar => ar.Codigo) // Cria um índice na propriedade Codigo da entidade Armazem
                .IsUnique(); // Impede que o mesmo código de armazém seja cadastrado mais de uma vez.

            modelBuilder.Entity<Armazem>() 
                .Property(ar => ar.Nome)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Armazem>()
                .Property(ar => ar.Descricao) 
                .HasMaxLength(300);
            
            modelBuilder.Entity<Armazem>()
                .ToTable(t => t.HasCheckConstraint(
                "CK_Armazem_Codigo_Length",
                "CHAR_LENGTH(Codigo) = 5"
                ));

            modelBuilder.Entity<Corredor>()
                .HasOne(c => c.Armazem) // Um corredor pertence a um armazém 
                .WithMany(ar => ar.Corredores)// Um armazém pode ter muitos corredores.
                .HasForeignKey(c => c.ArmazemId)// Define a chave estrangeira ArmazemId na tabela Corredor.
                .OnDelete(DeleteBehavior.Restrict);// Impede excluir um armazém enquanto existirem corredores associados..

            // Não permite que dois corredores tenham o mesmo código do mesmo armazém.
            modelBuilder.Entity<Corredor>()
                .HasIndex(c => new { c.ArmazemId, c.Codigo })
                .IsUnique();

            // // Não permite que dois corredores tenham o mesmo nome dentro do mesmo armazém.
            modelBuilder.Entity<Corredor>()
                .HasIndex(c => new { c.ArmazemId, c.Nome })
                .IsUnique();

            modelBuilder.Entity<Corredor>()
                 .Property(c => c.Codigo)
                 .HasMaxLength(3)
                 .IsRequired();

            modelBuilder.Entity<Corredor>()
                .ToTable(t => t.HasCheckConstraint(
                "CK_Corredor_Codigo_Length",
                "CHAR_LENGTH(Codigo) = 3"
                ));

            modelBuilder.Entity<Corredor>()
                .Property(c => c.Nome)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Rua>()
                .HasOne(r => r.Corredor) // Uma rua pertence a um corredor 
                .WithMany(c => c.Ruas)// Um corredor pode ter muitas ruas.
                .HasForeignKey(r => r.CorredorId)// Define a chave estrangeira CorredorId na tabela Rua.
                .OnDelete(DeleteBehavior.Restrict);// Impede excluir um corredor enquanto existirem ruas associadas..

            modelBuilder.Entity<Rua>()
                .HasIndex(r => new { r.CorredorId, r.Codigo }) // Cria um índice composto nas propriedades CorredorId e Codigo da entidade Rua
                .IsUnique(); // Impede que o mesmo código de rua seja cadastrado mais de uma vez para o mesmo corredor.

            modelBuilder.Entity<Rua>()
                .HasIndex(r => new { r.CorredorId, r.Nome }) // Cria um índice composto nas propriedades CorredorId e Nome da entidade Rua
                .IsUnique(); // Impede que o mesmo nome de rua seja cadastrado mais de uma vez para o mesmo corredor.

            modelBuilder.Entity<Rua>()
               .Property(r => r.Codigo)
               .HasMaxLength(3)
               .IsRequired();

            modelBuilder.Entity<Rua>()
               .ToTable(t => t.HasCheckConstraint(
               "CK_Rua_Codigo_Length",
               "CHAR_LENGTH(Codigo) = 3"
               ));

            modelBuilder.Entity<Rua>()
               .Property(r => r.Nome)
               .HasMaxLength(100)
               .IsRequired();

            modelBuilder.Entity<Modulo>()
                .HasOne(m => m.Rua) // Um módulo pertence a uma rua 
                .WithMany(r => r.Modulos)// Uma rua pode ter muitos módulos.
                .HasForeignKey(m => m.RuaId)// Define a chave estrangeira RuaId na tabela Modulo.
                .OnDelete(DeleteBehavior.Restrict);// Impede excluir uma rua enquanto existirem módulos associados..


            modelBuilder.Entity<Modulo>()
                .HasIndex(m => new { m.RuaId, m.Codigo })
                .IsUnique();

            modelBuilder.Entity<Modulo>()
                .Property(m => m.Codigo)
                .HasMaxLength(3)
                .IsRequired();

            modelBuilder.Entity<Modulo>()
                .ToTable(t => t.HasCheckConstraint(
                "CK_Modulo_Codigo_Length",
                "CHAR_LENGTH(Codigo) = 3"
                )); 


            modelBuilder.Entity<Nivel>() 
                .HasOne(n => n.Modulo) // Um nível pertence a um módulo 
                .WithMany(m => m.Niveis)// Um módulo pode ter muitos níveis.
                .HasForeignKey(n => n.ModuloId)// Define a chave estrangeira ModuloId na tabela Nivel.
                .OnDelete(DeleteBehavior.Restrict);// Impede excluir um módulo enquanto existirem níveis associados..

            modelBuilder.Entity<Nivel>()
                .HasIndex(n => new { n.ModuloId, n.Codigo })
                .IsUnique();

            modelBuilder.Entity<Nivel>()
                .Property(n => n.Codigo)
                .HasMaxLength(3)
                .IsRequired(); 

            modelBuilder.Entity<Nivel>() 
                .ToTable(t => t.HasCheckConstraint(
                "CK_Nivel_Codigo_Length",
                "CHAR_LENGTH(Codigo) = 3"
                ));

           modelBuilder.Entity<Endereco>()
                .Property(e => e.CodigoCompleto)
                .HasMaxLength(25)
                .IsRequired();

           modelBuilder.Entity<Endereco>() 
                .ToTable(e => e.HasCheckConstraint(
                    "CK_Endereco_CodigoCompleto_Length",
                    "CHAR_LENGTH(CodigoCompleto) = 25"
                ));

            modelBuilder.Entity<Endereco>()
                 .HasOne(e => e.Nivel)
                 .WithMany(n => n.Enderecos) // Um nível pode ter muitos endereços.
                 .HasForeignKey(e => e.NivelId)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Endereco>()
                .HasIndex(e => e.CodigoCompleto)
                .IsUnique(); // Impede que o mesmo código de endereço seja cadastrado mais de uma vez.

            modelBuilder.Entity<Endereco>()
               .ToTable(t => t.HasCheckConstraint(
               "CK_Endereco_CapacidadeMaxima_NonNegative",
                "CapacidadeMaxima >= 0"
               ));

            modelBuilder.Entity<PosicaoEstoque>()
                .ToTable(t => t.HasCheckConstraint(
                "CK_PosicaoEstoque_Quantidade_NonNegative",
                 "Quantidade >= 0"
                ));

            modelBuilder.Entity<PosicaoEstoque>()
                .HasIndex(pe => new { pe.EnderecoId, pe.ProdutoId }) // Cria um índice composto nas propriedades EnderecoId e ProdutoId da entidade PosicaoEstoque
                .IsUnique(); // Impede que a mesma posição de estoque seja criada mais de uma vez para o mesmo endereço e produto.

            modelBuilder.Entity<PosicaoEstoque>()
                .HasOne(pe => pe.Endereco)
                .WithMany()
                .HasForeignKey(pe => pe.EnderecoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PosicaoEstoque>()
                .HasOne(pe => pe.Produto)// Uma posição de estoque pertence a um produto.
                .WithMany() 
                .HasForeignKey(pe => pe.ProdutoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Movimentacao>()
                .HasIndex(mo => new { mo.PosicaoOrigemId, mo.PosicaoDestinoId });
               
            modelBuilder.Entity<Movimentacao>()
                .ToTable(t => t.HasCheckConstraint(
                "CK_Movimentacao_QuantidadeMovimentada_Positive",
                 "QuantidadeMovimentada > 0"
                ));

            modelBuilder.Entity<Movimentacao>()
                .HasOne(m => m.PosicaoOrigem)
                .WithMany()
                .HasForeignKey(m => m.PosicaoOrigemId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Movimentacao>()
                .HasOne(m => m.PosicaoDestino)
                .WithMany()
                .HasForeignKey(m => m.PosicaoDestinoId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }

}
