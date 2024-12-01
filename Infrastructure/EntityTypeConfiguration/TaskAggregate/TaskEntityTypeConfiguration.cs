using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task = Domain.Aggregates.TaskAggregate.Task;


namespace Infrastructure.EntityTypeConfiguration.TaskAggregate;

public class TaskEntityTypeConfiguration: IEntityTypeConfiguration<Task>
{
    public void Configure(EntityTypeBuilder<Task> typeBuilder)
    {
        typeBuilder.ToTable("Tasks");
        typeBuilder.HasKey(task => task.Id);
        typeBuilder
            .Property(task => task.Title)
            .HasMaxLength(100)
            .IsRequired();
        typeBuilder
            .Property(task => task.Description)
            .IsRequired();
        typeBuilder
            .Property(task => task.IsCompleted)
            .IsRequired();
        typeBuilder
            .Property(task => task.DueDate)
            .IsRequired();
    }
}