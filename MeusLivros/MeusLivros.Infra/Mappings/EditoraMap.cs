using MeusLivros.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeusLivros.Infra.Mappings
{
    public class EditoraMap : IEntityTypeConfiguration<Editora>
    {
        public void Configure(EntityTypeBuilder<Editora> builder)
        {
            //Informar o nome da tabela no banco de dados
            builder.ToTable("TbEditora");

            //Especifica qual a chave primaria ta tabela
            builder.HasKey(x => x.Id);

            //espeficicar que o campo é auto incremento
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            //Mapeando o campo nome
            builder.Property(x => x.Nome)
                .HasColumnName("EdiNome") //nome da coluna no banco de dados
                .HasColumnType("VARCHAR") //tipo de dados da coluna
                .HasMaxLength(100)        //tamanho da coluna
                .IsRequired();            //define o campo como obrigatorio (NOTNULL)
        }
    }
}
