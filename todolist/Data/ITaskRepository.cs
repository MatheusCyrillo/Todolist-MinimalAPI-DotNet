using todolist.Models;
using todolist.Models.DTO;

namespace todolist.Data
{
    public interface ITaskRepository
    {
        Guid Create(CreateTaskDTO createTaskDTO);
        TodoTask GetTaskById(Guid Id);
        int DeleteTaskById(Guid Id);

        Task<IEnumerable<TodoTask>> GetAllTasks();
    }
}
