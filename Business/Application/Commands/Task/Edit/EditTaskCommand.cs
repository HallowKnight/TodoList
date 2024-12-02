using Business.Actions.Task.Edit.Dto;
using MediatR;

namespace Business.Application.Commands.Task.Edit;

public class EditTaskCommand(EditTaskDto editTaskDto) : IRequest
{
    public Guid Id { get; } = editTaskDto.TaskId;
    public string? Title { get; } = editTaskDto.Title;
    public string? Description { get; } = editTaskDto.Description;
    public DateTime? DueDate { get; } = editTaskDto.DueDate;
}