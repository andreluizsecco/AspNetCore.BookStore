using AspNetCore.Bookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNetCore.Bookstore.Data.Mappings
{
    public class BookMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Book");

            builder.Property(p => p.ID)
                .ValueGeneratedNever();

            builder.Property(p => p.Title)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(p => p.Author)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(p => p.Category)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(p => p.Price)
                .HasColumnType("numeric(38,2)");

            builder.Property(p => p.CreatedDate)
                .HasColumnType("datetime2");

            builder.HasData(
                new Book(1, "Domain-Driven Design: Tackling Complexity in the Heart of Software", "Eric Evans", "Software", 26, 59.90m),
                new Book(2, "Agile Principles, Patterns, and Practices in C#", "Robert C. Martin", "Software", 13, 45.90m),
                new Book(3, "Clean Code: A Handbook of Agile Software Craftsmanship", "Robert C. Martin", "Software", 10, 33.90m),
                new Book(4, "Implementing Domain-Driven Design", "Vaughn Vernon", "Software", 22, 59.90m),
                new Book(5, "Patterns, Principles, and Practices of Domain-Driven Design", "Scott Millet", "Software", 15, 42.90m),
                new Book(6, "Refactoring: Improving the Design of Existing Code", "Martin Fowler", "Software", 5, 31.90m)
            );
        }
    }
}