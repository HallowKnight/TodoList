namespace Business.Actions.Task.Delete;

public interface IDeleteTaskService
{
    System.Threading.Tasks.Task DeleteAsync(Guid taskId, CancellationToken cancellationToken);
}