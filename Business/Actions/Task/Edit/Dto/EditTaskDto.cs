namespace Business.Actions.Task.Edit.Dto;

public class EditTaskDto
{
    public EditTaskDto()
    {
        
    }

    public EditTaskDto(Guid taskId, string? title, string? description, DateTime? dueDate)
    {
        TaskId = taskId;
        Title = title;
        Description = description;
        DueDate = dueDate;
    }
    
    public Guid TaskId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime? DueDate { get; set; }
}