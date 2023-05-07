using Microsoft.AspNetCore.Mvc;
using todolist;
using todolist.Data;
using todolist.Models.DTO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ITaskRepository, TaskFakeRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/tasks", (ITaskRepository taskRepository) =>
{
    return taskRepository.GetAllTasks();
})
.WithName("GetAllTasks")
.WithOpenApi();

app.MapGet("/api/task/{id:Guid}", (ITaskRepository taskRepository, Guid id) =>
{
    return taskRepository.GetTaskById(id);
})
.WithName("GetTask")
.WithOpenApi();

app.MapPost("/api/task", (ITaskRepository taskRepository, [FromBody] CreateTaskDTO createTaskDTO) =>
{
    return taskRepository.Create(createTaskDTO);
})
.WithName("CreateTask")
.WithOpenApi();

app.Run();
