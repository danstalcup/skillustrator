using Skillustrator.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Skillustrator.Api.Infrastructure
{
  public class SkillustratorContext : DbContext
  {
      public SkillustratorContext(DbContextOptions options) : base(options)
      {
      }

      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
          
      }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {

      }
  }
}
