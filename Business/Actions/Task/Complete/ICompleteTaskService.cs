namespace Business.Actions.Task.Complete;

public interface ICompleteTaskService
{
    System.Threading.Tasks.Task CompleteAsync(Guid taskId, CancellationToken cancellationToken);
}