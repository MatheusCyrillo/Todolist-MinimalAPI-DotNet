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

        public async Task<Guid> Create(CreateTaskDTO createTaskDTO)
        {
            var todoTask = _mapper.Map<CreateTaskDTO, TodoTask>(createTaskDTO);
            var script = "INSERT INTO public.todolist (pk_todolistid, name, description, iscompleted, creationdate, completiondate) VALUES (@Id, @Name, @Description, @IsCompleted, @CreationDate, @CompletionDate);";
            await _db.SetData(script, todoTask);
            return todoTask.Id;
        }

        public async Task<IEnumerable<TodoTask>> GetAllTasks()
        {
            var script = "SELECT pk_todolistid as Id, * FROM public.todolist"; //Scripts
            var allTasks = await _db.GetData<TodoTask, dynamic>(script, new { });
            return allTasks;
        }

        public async Task<TodoTask> GetTaskById(Guid Id)
        {
            var script = "SELECT pk_todolistid as Id, * FROM public.todolist where pk_todolistid = @Id"; //Scripts
            var task = await _db.GetData<TodoTask, dynamic>(script, new { Id });
            return task.FirstOrDefault();
        }

        public int DeleteTaskById(Guid Id)
        {
            return _tasks.RemoveAll(t => t.Id == Id);
        }
        public async Task Update(UpdateTaskDTO updateTaskDTO)
        {
            var todoTask = _mapper.Map<UpdateTaskDTO, TodoTask>(updateTaskDTO);
            var script = "UPDATE public.todolist SET name=@Name, description=@Description, iscompleted=@IsCompleted WHERE pk_todolistid=@Id";
            await _db.SetData(script, todoTask);
        }
    }
}
