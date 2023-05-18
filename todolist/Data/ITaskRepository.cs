using todolist.Models;
using todolist.Models.DTO;

namespace todolist.Data
{
    public interface ITaskRepository
    {
        Task<Guid> Create(CreateTaskDTO createTaskDTO);
        Task<TodoTask> GetTaskById(Guid Id);
        int DeleteTaskById(Guid Id);
        Task<IEnumerable<TodoTask>> GetAllTasks();
        Task Update(UpdateTaskDTO updateTaskDTO);
    }
}
