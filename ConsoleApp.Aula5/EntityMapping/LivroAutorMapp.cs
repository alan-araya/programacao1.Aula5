using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp.Aula5.EntityMapping
{
    public class LivroAutorMapp : IEntityTypeConfiguration<LivroAutor>
    {
        public void Configure(EntityTypeBuilder<LivroAutor> builder)
        {
            builder.HasKey(x => new { x.LivroId, x.AutorId });

            builder.HasOne(x => x.Livro)
                   .WithMany(x => x.Autores)
                   .HasForeignKey(x => x.LivroId);

            builder.HasOne(x => x.Autor)
                   .WithMany(x => x.Livros)
                   .HasForeignKey(x => x.AutorId);
        }
    }
}
