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

        public async Task<Guid> Create(CreateTaskDTO createTaskDTO)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoTask>> GetAllTasks()
        {
            throw new NotImplementedException();
        }

        public async Task<TodoTask> GetTaskById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(UpdateTaskDTO updateTaskDTO)
        {
            throw new NotImplementedException();
        }

        public int DeleteTaskById(Guid Id)
        {
            return _tasks.RemoveAll(t => t.Id == Id);
        }
    }
}
