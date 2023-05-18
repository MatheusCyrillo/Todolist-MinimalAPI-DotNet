using AutoMapper;
using todolist.Models;
using todolist.Models.DTO;

namespace todolist
{
    public class MapperConfiguration : Profile
    {
        public MapperConfiguration()
        {
            CreateMap<CreateTaskDTO, TodoTask>();
            CreateMap<UpdateTaskDTO, TodoTask>();

        }
    }
}
