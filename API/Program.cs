using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//appel dans le program.cs du contexte , on défini utilisation de SQLite et on lui passe en param la ConnectionString
builder.Services.AddDbContext<AppDbContext>(opt =>{ 
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapControllers();

app.Run();
