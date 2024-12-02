using Business.Actions.Task.Get.Dto;

namespace Business.Actions.Task.GetList;

public interface IGetTaskListService
{
    Task<List<TaskDto>> GetAllAsync(CancellationToken cancellationToken);
}