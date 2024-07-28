using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            // var existingActivities = await context.Activities.ToListAsync();

            // // Remove all existing activities
            // if (existingActivities.Any())
            // {
            //     context.Activities.RemoveRange(existingActivities);
            //     await context.SaveChangesAsync();
            // }
            // check if we already have an Activity inside the DB.
            // if we do, we dont want to seed more.
            if (context.Activities.Any()) return;

            var activities = new List<Activity>
            {
                new Activity
                {
                    Title = "title - Activity 1",
                    Date = DateTime.UtcNow.AddMonths(-2),
                    Description = "hey, it's first Activity.",
                    Category = "trip",
                    City = "Tel-Aviv",
                    Venue = "23"
                },
                new Activity
                {
                    Title = "title - Activity 2",
                    Date = DateTime.UtcNow.AddMonths(-1),
                    Description = "hey, it's second Activity.",
                    Category = "music",
                    City = "Bat-Yam",
                    Venue = "24"
                },
                new Activity
                {
                    Title = "title - Activity 3",
                    Date = DateTime.UtcNow.AddMonths(1),
                    Description = "hey, it's last Activity.",
                    Category = "eat",
                    City = "Sderot",
                    Venue = "25"
                },
            };
            // save in the memory.
            await context.Activities.AddRangeAsync(activities);
            // save in the DB.
            await context.SaveChangesAsync();
        }
    }
}