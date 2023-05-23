using FireForgetDatabaseCommand.Database;
using FireForgetDatabaseCommand.Database.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<LibraryDbContext>(ctx => ctx.UseInMemoryDatabase("LibraryDb"));
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddSingleton<IFireForgetRepository, FireForgetRepository>();

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
