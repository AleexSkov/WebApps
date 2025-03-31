using Shared;

namespace ServerAPI.Repositories;

public interface IToDoRepository
{
    List<BETodoItem> GetAll();
    void Add(BETodoItem todoItem);
    void Update(BETodoItem todoItem);
    void Delete(string title);
}