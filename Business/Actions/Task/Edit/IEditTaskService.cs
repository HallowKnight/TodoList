using Business.Actions.Task.Edit.Dto;

namespace Business.Actions.Task.Edit;

public interface IEditTaskService
{
    System.Threading.Tasks.Task EditAsync(EditTaskDto editTaskDto, CancellationToken cancellationToken);
}