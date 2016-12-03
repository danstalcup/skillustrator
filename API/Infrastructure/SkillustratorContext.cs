using Microsoft.EntityFrameworkCore;
using Skillustrator.Api.Entities;

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
            modelBuilder.Entity<Article>();

            modelBuilder.Entity<Organization>()
                .HasMany<Person>(o => o.People)
                .WithOne(p => p.Organization);
            modelBuilder.Entity<Organization>().Property(o => o.Name).IsRequired();

            modelBuilder.Entity<Person>().Property(p => p.FirstName).IsRequired();
            modelBuilder.Entity<Person>().Property(p => p.LastName).IsRequired();

            modelBuilder.Entity<PersonSkill>()
                .HasOne<Person>(ps => ps.Person)
                .WithMany(p => p.Skills)
                .IsRequired();
            modelBuilder.Entity<PersonSkill>()
                .HasOne<Skill>(ps => ps.Skill)
                .WithMany(s => s.People)
                .IsRequired();

            modelBuilder.Entity<Skill>().Property(s => s.Name).IsRequired();

            modelBuilder.Entity<SkillTag>()
                .HasOne<Skill>(st => st.Skill)
                .WithMany(s => s.Tags)
                .IsRequired();
            modelBuilder.Entity<SkillTag>()
                .HasOne<Tag>(st => st.Tag)
                .WithMany(t => t.Skills)
                .IsRequired();

            modelBuilder.Entity<Tag>().Property(t => t.Name).IsRequired();
        }
    }
}
