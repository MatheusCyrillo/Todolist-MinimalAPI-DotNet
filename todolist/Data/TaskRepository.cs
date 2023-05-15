using AutoMapper;
using todolist.Data.Postgresql;
using todolist.Models;
using todolist.Models.DTO;

namespace todolist.Data
{
    public class TaskRepository : ITaskRepository
    {
        private List<TodoTask> _tasks = new List<TodoTask>();
        private IMapper _mapper;
        private IPostgresqlDataAccess _db;
        public TaskRepository(IMapper mapper, IPostgresqlDataAccess db)
        {
            _mapper = mapper;
            _db = db;
        }

        public Guid Create(CreateTaskDTO createTaskDTO)
        {
            var todoTask = _mapper.Map<CreateTaskDTO, TodoTask>(createTaskDTO);
            _tasks.Add(todoTask);
            return todoTask.Id;
        }

        public async Task<IEnumerable<TodoTask>> GetAllTasks()
        {
            try
            {
                var script = "SELECT * FROM public.todolist";
                var teste = await _db.GetData<TodoTask, dynamic>(script, new { });
                return null;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public TodoTask GetTaskById(Guid Id) 
        {
            return _tasks.FirstOrDefault(t => t.Id == Id);
        }

        public int DeleteTaskById(Guid Id)
        {
            return _tasks.RemoveAll(t => t.Id == Id);
        }
    }
}
