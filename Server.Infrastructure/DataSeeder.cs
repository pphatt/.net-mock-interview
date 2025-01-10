using Microsoft.EntityFrameworkCore;
using Server.Domain.Entity.Identity;
using Server.Infrastructure.Persistence;

namespace Server.Infrastructure;

public class DataSeeder
{
    public async static Task SeedData(AppDbContext context)
    {
        if (!await context.AppUsers.AnyAsync())
        {
            var users = UserList();
            await context.AppUsers.AddRangeAsync(users);
            await context.SaveChangesAsync();

            await context.SaveChangesAsync();
        }
    }

    private static IEnumerable<AppUser> UserList()
    {
        var random = new Random();
        var users = new List<AppUser>
        {
            new ()
            {
                Email = "abc@gmail.com",
                Username = "John Doe",
                Dob = GenerateRandomDob(random),
                DateCreated = DateTime.Now,
            },
            new ()
            {
                Email = "xyz@gmail.com",
                Username = "Alex Doe",
                Dob = GenerateRandomDob(random),
                DateCreated = DateTime.Now,
            },
            new ()
            {
                Email = "k8s@gmail.com",
                Username = "Tim Doe",
                Dob = GenerateRandomDob(random),
                DateCreated = DateTime.Now,
            }
        };

        return users;
    }

    private static DateTime GenerateRandomDob(Random random)
    {
        var today = DateTime.UtcNow;

        var maxDob = today.AddYears(-22);
        var minDob = today.AddYears(-25);

        var range = (maxDob - minDob).Days;
        return minDob.AddDays(random.Next(range));
    }
}
