using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp.Aula5.EntityMapping
{
    public class LivroMapp : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.HasKey(x => x.LivroId);

            builder.Property(x => x.Titulo)
                   .HasMaxLength(100);

            builder.Property(x => x.Descricao)
                   .HasMaxLength(300);

            builder.Property(x => x.PublicadoEm);
        }
    }
}
