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
    /// <summary>
    /// Adds a new task
    /// </summary>
    /// <param name="addTaskService"></param>
    /// <param name="dueDate"></param>
    /// <param name="cancellationToken"></param>
    /// <param name="title"></param>
    /// <param name="description"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
    public async Task<IActionResult> Add([FromServices] IAddTaskService addTaskService,
        [FromForm] string title, [FromForm] string description, [FromForm] DateTime dueDate,
        CancellationToken cancellationToken = default)
    {
        try
        {
            await addTaskService.AddAsync(new AddTaskDto(title, description, dueDate), cancellationToken);
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

    /// <summary>
    /// Sets a task as complete
    /// </summary>
    /// <param name="completeTaskService"></param>
    /// <param name="taskId"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
    public async Task<IActionResult> Complete([FromServices] ICompleteTaskService completeTaskService,
        [FromForm] Guid taskId, CancellationToken cancellationToken = default)
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

    /// <summary>
    /// Edits a task data.
    /// If some fields don't be provided, then it won't be changed
    /// </summary>
    /// <param name="editTaskService"></param>
    /// <param name="dueDate"></param>
    /// <param name="cancellationToken"></param>
    /// <param name="taskId"></param>
    /// <param name="title"></param>
    /// <param name="description"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
    public async Task<IActionResult> Edit([FromServices] IEditTaskService editTaskService,
        [FromForm] Guid taskId, [FromForm] string title, [FromForm] string description, [FromForm] DateTime? dueDate,
        CancellationToken cancellationToken = default)
    {
        try
        {
            await editTaskService.EditAsync(new EditTaskDto(taskId, title, description, dueDate), cancellationToken);
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

    /// <summary>
    /// Deletes a task from the list
    /// </summary>
    /// <param name="deleteTaskService"></param>
    /// <param name="taskId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
    public async Task<IActionResult> Delete([FromServices] IDeleteTaskService deleteTaskService,
        [FromForm] Guid taskId, CancellationToken cancellationToken = default)
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

    /// <summary>
    /// Gets a task by its Id
    /// </summary>
    /// <param name="getTaskService"></param>
    /// <param name="taskId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TaskDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
    public async Task<IActionResult> Get([FromServices] IGetTaskService getTaskService,
        [FromQuery] Guid taskId, CancellationToken cancellationToken = default)
    {
        try
        {
            return Ok(await getTaskService.GetAsync(taskId, cancellationToken));
        }
        catch (Exception e)
        {
            ErrorTypeEnumeration? error = ExceptionHandler.GetError(e);
            return error == null
                ? StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong")
                : StatusCode(StatusCodes.Status404NotFound);
        }
    }

    /// <summary>
    /// GetsAll tasks
    /// </summary>
    /// <param name="getTaskListService"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TaskDto))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
    public async Task<IActionResult> GetList([FromServices] IGetTaskListService getTaskListService,
        CancellationToken cancellationToken = default)
    {
        try
        {
            return Ok(await getTaskListService.GetAllAsync(cancellationToken));
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