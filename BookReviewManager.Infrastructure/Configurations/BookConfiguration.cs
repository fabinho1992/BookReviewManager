using BookReviewManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Infrastructure.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b.Title).HasMaxLength(100)
                .IsRequired();
            builder.Property(b => b.Author).HasMaxLength(100)
                .IsRequired();
            builder.Property(b => b.ISBN).HasMaxLength(13)
                .IsRequired();
            builder.HasIndex(b => b.ISBN)
                .IsUnique();
            builder.Property(b => b.NumberPages)
                .IsRequired();
            builder.Property(b => b.Publisher).HasMaxLength(80)
                .IsRequired();
            builder.Property(b => b.Description).HasMaxLength(200)
                .IsRequired();
            builder.Property(b => b.GenerBook).HasConversion<string>()
                .IsRequired();
            builder.Property(b => b.YearPublication)
                .IsRequired();
            builder.HasMany(b => b.Assessments)
                .WithOne(a => a.Book)
                .HasForeignKey(a => a.BookId);

        }
    }
}
