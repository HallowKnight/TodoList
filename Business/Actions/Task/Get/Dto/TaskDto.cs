namespace Business.Actions.Task.Get.Dto;

public class TaskDto
{
    public TaskDto()
    {
        
    }

    public TaskDto(string title, string description, bool isCompleted, DateTime dueDate)
    {
        Title = title;
        Description = description;
        IsCompleted = isCompleted;
        DueDate = dueDate;
    }

    public TaskDto(Domain.Aggregates.TaskAggregate.Task task)
    {
        Id = task.Id;
        Title = task.Title;
        Description = task.Description;
        IsCompleted = task.IsCompleted;
        DueDate = task.DueDate;
    }

    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime DueDate { get; set; }
}