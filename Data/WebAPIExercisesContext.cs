using Microsoft.EntityFrameworkCore;

public class WebAPIExercisesContext : DbContext
{
  public WebAPIExercisesContext(DbContextOptions<WebAPIExercisesContext> options) : base(options) { }

  public DbSet<Developer> Developers { get; set; }
}