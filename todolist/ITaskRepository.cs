using todolist.Models;
using todolist.Models.DTO;

namespace todolist
{
    public interface ITaskRepository
    {
        Guid Create(CreateTaskDTO createTaskDTO);
        List<TodoTask> GetAllTasks();
        TodoTask GetTaskById(Guid Id);
        int DeleteTaskById(Guid Id);
    }
}
