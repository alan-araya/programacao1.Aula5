using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp.Aula5.EntityMapping
{
    public class AutorMapp : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.HasKey(x => x.AutorId);

            builder.Property(x => x.Nome)
                   .HasMaxLength(100);

            builder.Property(x => x.WebUrl)
                   .HasMaxLength(500);
        }
    }
}
