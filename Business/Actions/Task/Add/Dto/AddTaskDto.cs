namespace Business.Actions.Task.Add.Dto;

public class AddTaskDto
{
    public AddTaskDto()
    {
        
    }
    
    public AddTaskDto(string title, string description, DateTime dueDate)
    {
        Title = title;
        Description = description;
        DueDate = dueDate;
    }
    
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateTime DueDate { get; private set; }
}