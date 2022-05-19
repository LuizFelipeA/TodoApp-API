using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Domain.Entities;

namespace Todo.Domain.Infra.Context.Mappings;

public class TodoMap : IEntityTypeConfiguration<TodoItem>
{
    public void Configure(EntityTypeBuilder<TodoItem> builder)
    {
        // Table name
        builder.ToTable("Todo");

        // Primary Key
        //builder.HasKey(x => x.Id);

        //// Identity
        builder.Property(x => x.Id);

        // Properties
        builder.Property(x => x.User)
            .HasMaxLength(120)
            .HasColumnType("VARCHAR(120)");

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(160);

        builder.Property(x => x.Done)
            .HasColumnType("BIT");

        builder.Property(x => x.Date);

        // Indexes
        builder.HasIndex(x => x.User)
            .IsUnique();
    }
}

