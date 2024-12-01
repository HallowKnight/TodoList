using Business.Actions.Task.Add.Dto;

namespace Business.Actions.Task.Add;

public interface IAddTaskService
{
    System.Threading.Tasks.Task AddAsync(AddTaskDto addTaskDto, CancellationToken cancellationToken = default);
}