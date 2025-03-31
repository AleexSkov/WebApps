namespace ServerAPI.Controllers;
using Shared;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Repositories;

[ApiController]
[Route("api/todo")]
public class TodoController : ControllerBase
{
    private readonly IToDoRepository _todoRepository;

    public TodoController(IToDoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<BETodoItem>> GetAll()
    {
        return Ok(_todoRepository.GetAll());
    }

    [HttpPost]
    public ActionResult Add(BETodoItem todoItem)
    {
        if (string.IsNullOrWhiteSpace(todoItem.Title))
        {
            return BadRequest("Title cannot be empty");
        }
        
        _todoRepository.Add(todoItem);
        return Ok();
    }

    [HttpPut]
    public ActionResult Update(BETodoItem todoItem)
    {
        if (string.IsNullOrWhiteSpace(todoItem.Title))
        {
            return BadRequest("Title cannot be empty");
        }
        
        _todoRepository.Update(todoItem);
        return Ok();
    }

    [HttpDelete]
    public ActionResult Delete(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            return BadRequest("Title cannot be empty");
        }
        
        _todoRepository.Delete(title);
        return Ok();
    }
}