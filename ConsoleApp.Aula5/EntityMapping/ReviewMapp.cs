using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp.Aula5.EntityMapping
{
    public class ReviewMapp : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(x => x.ReviewId);

            builder.Property(x => x.NomeRevisor)
                   .HasMaxLength(100);

            builder.Property(x => x.QtdEstrelas);

            builder.Property(x => x.Comentario)
                   .HasMaxLength(300);

            builder.HasOne(x => x.Livro)
                   .WithMany(x=> x.Reviews)
                   .HasForeignKey(x=> x.LivroId);
        }
    }
}
