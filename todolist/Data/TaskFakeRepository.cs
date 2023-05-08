using AutoMapper;
using todolist.Models;
using todolist.Models.DTO;

namespace todolist.Data
{
    public class TaskFakeRepository : ITaskRepository
    {
        private List<TodoTask> _tasks = new List<TodoTask>();
        private IMapper _mapper;
        public TaskFakeRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Guid Create(CreateTaskDTO createTaskDTO)
        {
            var todoTask = _mapper.Map<CreateTaskDTO, TodoTask>(createTaskDTO);
            _tasks.Add(todoTask);
            return todoTask.Id;
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
