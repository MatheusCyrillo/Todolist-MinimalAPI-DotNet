var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/tasks", () =>
{
    return "All Tasks..";
})
.WithName("GetAllTasks")
.WithOpenApi();

app.MapGet("/api/task/{id:Guid}", (Guid id) =>
{
    return $"Task: {id}";
})
.WithName("GetTask")
.WithOpenApi();

app.Run();
