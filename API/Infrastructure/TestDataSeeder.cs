using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Skillustrator.Api.Entities;
using System.Collections.Generic;
using System.Linq;
//////////////////////////////
namespace Skillustrator.Api.Infrastructure
{
    public class TestDataSeeder
    {
        public async Task SeedAsync(IServiceProvider serviceProvider)
        {
            //Based on EF team's example at https://github.com/aspnet/MusicStore/blob/dev/samples/MusicStore/Models/SampleData.cs
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var skillustratorContext = serviceScope.ServiceProvider.GetService<SkillustratorContext>();
                if (await skillustratorContext.Database.EnsureCreatedAsync())
                {
                    if (!await skillustratorContext.People.AnyAsync()) {
                      await InsertTestData(skillustratorContext);
                    }
                }
            }
        }

        public static async Task InitializeDeficiencyDatabaseAsync(IServiceProvider serviceProvider, bool seedData = false)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<SkillustratorContext>();

                var appliedMigrations = await db.Database.GetAppliedMigrationsAsync();

                if (!appliedMigrations.Any())
                {
                    Console.WriteLine("Creating Databse; Applying all migrations; Adding seed data");
                    await db.Database.MigrateAsync();
                    if (seedData) 
                    {
                        await InsertTestData(db);
                    }
                }
                else
                {
                    var pendingMigrations = await db.Database.GetPendingMigrationsAsync();
                    if (pendingMigrations.Any())
                    {
                        Console.WriteLine("Applying pending migrations");
                        await db.Database.MigrateAsync();
                        if (seedData) 
                        {
                            await InsertTestData(db);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No pending migrations");
                    }
                }
            }
        }

        public static async Task InsertTestData(SkillustratorContext db)
        {
            var person = new Person { 
                        Id = 999,
                        LastName = "Tester",
                        FirstName = "Mister"
                    };

            db.People.Add(person);

            var skills = new List<Skill>();
            skills.Add (new Skill { Name = "CSS" });
            skills.Add (new Skill { Name = "Javascript" });            
            skills.Add (new Skill { Name = "C#" });
            skills.Add (new Skill { Name = ".NET Core" });
            skills.Add (new Skill { Name = "Angular" });
            skills.Add (new Skill { Name = "React" });
            skills.Add (new Skill { Name = "jQuery" });
            skills.Add (new Skill { Name = "Python" });
            skills.Add (new Skill { Name = "Django" });
            skills.Add (new Skill { Name = "Flask" });
            skills.Add (new Skill { Name = "Ruby" });
            skills.Add (new Skill { Name = "Rails" });            

            db.Skills.AddRange(skills);

            var skillLevels = new List<SkillLevel>();
            skillLevels.Add (new SkillLevel { Description = "Junior", Code = SkillLevel.Junior });
            skillLevels.Add (new SkillLevel { Description = "Junior-Mid", Code = SkillLevel.JuniorMid });
            skillLevels.Add (new SkillLevel { Description = "Mid", Code = SkillLevel.Mid });
            skillLevels.Add (new SkillLevel { Description = "Senior-Mid", Code = SkillLevel.SeniorMid });
            skillLevels.Add (new SkillLevel { Description = "Senior", Code = SkillLevel.Senior });
            skillLevels.Add (new SkillLevel { Description = "Expert", Code = SkillLevel.Expert });

            db.SkillLevels.AddRange(skillLevels);

            var timePeriods = new List<TimePeriod>();
            timePeriods.Add (new TimePeriod { Description = "Less than One Month", Code = TimePeriod.LessThanOneMonth });
            timePeriods.Add (new TimePeriod { Description = "One to Six Months", Code = TimePeriod.OneToSixMonths });
            timePeriods.Add (new TimePeriod { Description = "Six to Twelve Months", Code = TimePeriod.SixToTwelveMonths });
            timePeriods.Add (new TimePeriod { Description = "One to Two Years", Code = TimePeriod.OneToTwoYears });
            timePeriods.Add (new TimePeriod { Description = "Two to Five Years", Code = TimePeriod.TwoToFiveYears });
            timePeriods.Add (new TimePeriod { Description = "Five to Ten Years", Code = TimePeriod.FiveToTenYears });
            timePeriods.Add (new TimePeriod { Description = "More than Ten Years", Code = TimePeriod.MoreThanTenYears });
            
            db.TimePeriods.AddRange(timePeriods);

            await db.SaveChangesAsync();
        }
    }
}
