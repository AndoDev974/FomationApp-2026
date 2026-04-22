using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//appel dans le program.cs du contexte , on défini utilisation de SQLite et on lui passe en param la ConnectionString
builder.Services.AddDbContext<AppDbContext>(opt =>{ 
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors();
var app = builder.Build();

// Configure the HTTP request pipeline.
//solve cross origin errors , access granted to http an https below
app.UseCors(x=>x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200","https://localhost:4200"));
app.MapControllers();
app.Run();








