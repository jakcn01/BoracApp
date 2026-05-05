using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
	//protected override void OnModelCreating(ModelBuilder modelBuilder)
	//{
	//	base.OnModelCreating(modelBuilder);
	//}
	public DbSet<Recipe> Recipes { get; set; }
}
