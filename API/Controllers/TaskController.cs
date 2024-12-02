using Business.Actions.Task.Add;
using Business.Actions.Task.Add.Dto;
using Business.Actions.Task.Complete;
using Domain.Utility.ExceptionHandler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Api.Controllers;

[AllowAnonymous]
[Route("api/[controller]/[action]")]
public class TaskController : Controller
{
    private readonly IStringLocalizer _stringLocalizer;

    public TaskController(IStringLocalizer stringLocalizer)
    {
        _stringLocalizer = stringLocalizer;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
    public async Task<IActionResult> Add([FromServices] IAddTaskService addTaskService,
        [FromBody] AddTaskDto addTaskDto, CancellationToken cancellationToken = default)
    {
        try
        {
            await addTaskService.AddAsync(addTaskDto, cancellationToken);
            return Ok();
        }
        catch (Exception e)
        {
            ErrorTypeEnumeration? error = ExceptionHandler.GetError(e);
            return error == null
                ? StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong")
                : StatusCode(StatusCodes.Status406NotAcceptable, error.GetMessage(_stringLocalizer));
        }
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
    public async Task<IActionResult> Complete([FromServices] ICompleteTaskService completeTaskService,
        [FromBody] Guid taskId, CancellationToken cancellationToken = default)
    {
        try
        {
            await completeTaskService.CompleteAsync(taskId, cancellationToken);
            return Ok();
        }
        catch (Exception e)
        {
            ErrorTypeEnumeration? error = ExceptionHandler.GetError(e);
            return error == null
                ? StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong")
                : StatusCode(Equals(error, CompleteTaskService.CompleteTaskErrors.NotFound)
                    ? StatusCodes.Status404NotFound
                    : StatusCodes.Status406NotAcceptable, error.GetMessage(_stringLocalizer));
        }
    }
}