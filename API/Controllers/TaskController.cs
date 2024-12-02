using Business.Actions.Task.Add;
using Business.Actions.Task.Add.Dto;
using Business.Actions.Task.Complete;
using Business.Actions.Task.Delete;
using Business.Actions.Task.Edit;
using Business.Actions.Task.Edit.Dto;
using Business.Actions.Task.Get;
using Business.Actions.Task.Get.Dto;
using Business.Actions.Task.GetList;
using Domain.Utility.ExceptionHandler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[AllowAnonymous]
[Route("api/[controller]/[action]")]
public class TaskController : Controller
{
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
            //Can get message using localizer
            return error == null
                ? StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong")
                : StatusCode(StatusCodes.Status406NotAcceptable);
                //: StatusCode(StatusCodes.Status406NotAcceptable, error.GetMessage(_stringLocalizer));
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
                    : StatusCodes.Status406NotAcceptable);
        }
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
    public async Task<IActionResult> Edit([FromServices] IEditTaskService editTaskService,
        [FromBody] EditTaskDto editTaskDto, CancellationToken cancellationToken = default)
    {
        try
        {
            await editTaskService.EditAsync(editTaskDto, cancellationToken);
            return Ok();
        }
        catch (Exception e)
        {
            ErrorTypeEnumeration? error = ExceptionHandler.GetError(e);
            return error == null
                ? StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong")
                : StatusCode(Equals(error, ErrorTypeEnumeration.NotFound)
                    ? StatusCodes.Status404NotFound
                    : StatusCodes.Status406NotAcceptable);
        }
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
    public async Task<IActionResult> Delete([FromServices] IDeleteTaskService deleteTaskService,
        [FromBody] Guid taskId, CancellationToken cancellationToken = default)
    {
        try
        {
            await deleteTaskService.DeleteAsync(taskId, cancellationToken);
            return Ok();
        }
        catch (Exception e)
        {
            ErrorTypeEnumeration? error = ExceptionHandler.GetError(e);
            return error == null
                ? StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong")
                : StatusCode(StatusCodes.Status404NotFound);
        }
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TaskDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
    public async Task<IActionResult> Get([FromServices] IGetTaskService getTaskService,
        [FromBody] Guid taskId, CancellationToken cancellationToken = default)
    {
        try
        {
            await getTaskService.GetAsync(taskId, cancellationToken);
            return Ok();
        }
        catch (Exception e)
        {
            ErrorTypeEnumeration? error = ExceptionHandler.GetError(e);
            return error == null
                ? StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong")
                : StatusCode(StatusCodes.Status404NotFound);
        }
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TaskDto))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
    public async Task<IActionResult> GetList([FromServices] IGetTaskListService getTaskListService, CancellationToken cancellationToken = default)
    {
        try
        {
            await getTaskListService.GetAllAsync(cancellationToken);
            return Ok();
        }
        catch (Exception e)
        {
            ErrorTypeEnumeration? error = ExceptionHandler.GetError(e);
            return error == null
                ? StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong")
                : StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}