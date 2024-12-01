using Business.Actions.Task.Add.Dto;
using Domain.Aggregates.TaskAggregate.Exceptions;
using Domain.Utility.ExceptionHandler;
using MediatR;

namespace Business.Actions.Task.Add;

public class AddTaskService(IMediator mediator) : IAddTaskService
{
    public async System.Threading.Tasks.Task AddAsync(AddTaskDto addTaskDto, CancellationToken cancellationToken = default)
    {
        await mediator.Publish(new AddTaskCommand(addTaskDto), cancellationToken);
    }
    
    
    public class AddTaskErrors : ErrorTypeEnumeration
    {
        public AddTaskErrors(int errorCode, string name) : base(errorCode, name)
        {
        }
        
        public static readonly AddTaskErrors TitleRequired =
            new((int)AddTaskErrorEnum.TitleRequired,
                nameof(AddTaskErrorEnum.TitleRequired));
    
        public static readonly AddTaskErrors TitleMaxLengthExceeded =
            new((int)AddTaskErrorEnum.TitleMaxLengthExceeded,
                nameof(AddTaskErrorEnum.TitleMaxLengthExceeded));

        public static readonly AddTaskErrors DescriptionRequired =
            new((int)AddTaskErrorEnum.DescriptionRequired,
                nameof(AddTaskErrorEnum.DescriptionRequired));

        public static readonly AddTaskErrors DueDateRequired =
            new((int)AddTaskErrorEnum.DueDateRequired,
                nameof(AddTaskErrorEnum.DueDateRequired));
    }
}