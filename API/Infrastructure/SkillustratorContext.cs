using ConsoleApplication.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApplication.Infrastructure
{
  public class SkillustratorContext : DbContext
  {
      public DbSet<Article> Articles { get; set; }
      public DbSet<Person> People { get; set; }

      public SkillustratorContext(DbContextOptions options) : base(options)
      {
      }

      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
          
      }
  }
}
