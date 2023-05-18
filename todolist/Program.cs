using Microsoft.AspNetCore.Mvc;
using todolist;
using todolist.Data;
using todolist.Data.Postgresql;
using todolist.Models.DTO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ITaskRepository, TaskRepository>();
builder.Services.AddSingleton<IPostgresqlDataAccess, PostgresqlDataAccess>();
builder.Services.AddAutoMapper(typeof(MapperConfiguration));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/tasks", async (ITaskRepository taskRepository) =>
{
    return Results.Ok(await taskRepository.GetAllTasks());
})
.WithName("GetAllTasks")
.WithOpenApi();

app.MapGet("/api/task/{id:Guid}", async (ITaskRepository taskRepository, Guid id) =>
{
    return Results.Ok(await taskRepository.GetTaskById(id));
})
.WithName("GetTask")
.WithOpenApi();

app.MapPost("/api/task", async (ITaskRepository taskRepository, [FromBody] CreateTaskDTO createTaskDTO) =>
{
    Guid id = await taskRepository.Create(createTaskDTO);
    return Results.CreatedAtRoute("GetTask", new { id });
})
.WithName("CreateTask")
.WithOpenApi();

app.MapDelete("/api/task/{id:Guid}", (ITaskRepository taskRepository, Guid id) =>
{
    if (taskRepository.DeleteTaskById(id) == 1)
        return Results.NoContent();
    else
        return Results.NotFound();

})
.WithName("DeleteTask")
.WithOpenApi();

app.MapPut("/api/task", async (ITaskRepository taskRepository, [FromBody] UpdateTaskDTO updateTaskDTO) =>
{
    await taskRepository.Update(updateTaskDTO);
    return Results.Ok();
})
.WithName("UpdateTask")
.WithOpenApi();

app.Run();
