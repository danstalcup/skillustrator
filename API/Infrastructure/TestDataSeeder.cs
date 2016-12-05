using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Skillustrator.Api.Entities;

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
                      await InsertData(skillustratorContext);
                    }
                }
            }
        }

        public async Task InsertData(SkillustratorContext db)
        {
            var person = new Person { 
                        Id = new Random().Next(),
                        LastName = "TestLastName",
                        FirstName = "TestFirstName"
                    };

            db.People.Add(person);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception exp)
            {                
                throw; 
            }
        }

    }
}