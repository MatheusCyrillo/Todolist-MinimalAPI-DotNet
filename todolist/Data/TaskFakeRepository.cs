using AutoMapper;
using todolist.Models;
using todolist.Models.DTO;

namespace todolist.Data
{
    public class TaskFakeRepository : ITaskRepository
    {
        private List<TodoTask> _tasks = new List<TodoTask>();
        public TaskFakeRepository()
        {
 
        }

        public Guid Create(CreateTaskDTO createTaskDTO)
        {
            _tasks.Add(new TodoTask());
            return Guid.NewGuid();
        }

        public List<TodoTask> GetAllTasks()
        {
            return _tasks;
        }

        public TodoTask GetTaskById(Guid Id) 
        {
            return _tasks.FirstOrDefault(t => t.Id == Id);
        }
    }
}
