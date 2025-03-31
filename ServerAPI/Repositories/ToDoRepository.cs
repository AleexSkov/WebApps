using Shared;

namespace ServerAPI.Repositories;

public class TodoRepository : IToDoRepository
{
    private readonly List<BETodoItem> _todoItems = new();

    public List<BETodoItem> GetAll()
    {
        return _todoItems;
    }

    public void Add(BETodoItem todoItem)
    {
        _todoItems.Add(todoItem);
    }

    public void Update(BETodoItem todoItem)
    {
        var existingTodo = _todoItems.FirstOrDefault(t => t.Title == todoItem.Title);
        if (existingTodo != null)
        {
            existingTodo.IsDone = todoItem.IsDone;
        }
    }

    public void Delete(string title)
    {
        var todoToRemove = _todoItems.FirstOrDefault(t => t.Title == title);
        if (todoToRemove != null)
        {
            _todoItems.Remove(todoToRemove);
        }
    }
}