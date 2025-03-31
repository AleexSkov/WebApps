var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpClient();

builder.Services.AddSingleton<ServerAPI.Repositories.IBikeRepository, ServerAPI.Repositories.BikeRepositoryInMemory>();
builder.Services.AddSingleton<ServerAPI.Repositories.IToDoRepository, ServerAPI.Repositories.ToDoRepositoryMongoDB>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("policy",
        policy =>
        {
            policy.AllowAnyOrigin();
            policy.AllowAnyMethod();
            policy.AllowAnyHeader();
        });
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors("policy");

app.UseAuthorization();

app.MapControllers();

app.Run();