using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
	public DbSet<Recipe> Recipes { get; set; }
}
