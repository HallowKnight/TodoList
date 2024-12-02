using Business.Actions.Task.Add.Dto;
using MediatR;

namespace Business.Application.Commands.Task.Add;

public class AddTaskCommand(AddTaskDto addTaskDto) : IRequest
{
    public string Title { get; } = addTaskDto.Title;
    public string Description { get; } = addTaskDto.Description;
    public DateTime DueDate { get; } = addTaskDto.DueDate;
}