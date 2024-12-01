using Business.Actions.Task.Add;
using Business.Actions.Task.Add.Dto;
using Domain.Utility.ExceptionHandler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[AllowAnonymous]
public class TaskController : Controller
{
    public TaskController()
    {
        
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
    public async Task<IActionResult> Register([FromServices] IAddTaskService addTaskService,
        [FromBody] AddTaskDto addTaskDto, CancellationToken cancellationToken = default)
    {
        try
        {
            addTaskService.AddAsync(addTaskDto, cancellationToken);
        }
        catch (Exception e)
        {
            ErrorTypeEnumeration? error = ExceptionHandler.GetError(e);
            if (error == null)
            {
            }

            switch (error)
            {
                case AddTaskService.AddTaskErrors.TitleRequired:
                {
                    
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, error[0]);
        }
    }
}