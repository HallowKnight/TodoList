using Domain.SeedWork;

namespace Domain.Aggregates.TaskAggregate;

public class Task : Entity<Guid>, IAggregateRoot
{
    #region Constructors

    protected Task(){}

    public Task(string title, string description, DateTime dueDate)
    {
        Title = title;
        Description = description;
        DueDate = dueDate;
        IsCompleted = false;
    }

    #endregion

    public string Title { get; private set; }
    public string Description { get; private set; }
    public bool IsCompleted { get; private set; }
    public DateTime DueDate { get; private set; }
}