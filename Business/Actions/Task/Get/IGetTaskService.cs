using Business.Actions.Task.Get.Dto;

namespace Business.Actions.Task.Get;

public interface IGetTaskService
{
    Task<TaskDto> GetAsync(Guid taskId, CancellationToken cancellationToken);
}