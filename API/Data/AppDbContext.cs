using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{   
    // users représente le nom de la table dans la bdd
    public DbSet <AppUser> Users { get; set; }
}
