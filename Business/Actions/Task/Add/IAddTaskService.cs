using Business.Actions.Task.Add.Dto;

namespace Business.Actions.Task.Add;

// It can be named IAddService since the name space has the Task part, it depends on the preferences
public interface IAddTaskService
{
    System.Threading.Tasks.Task AddAsync(AddTaskDto addTaskDto, CancellationToken cancellationToken = default);
}