using PlatfromService.Models;

namespace PlatfromService.Data
{
    public class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using( var serviceScope = app.ApplicationServices.CreateScope())
            {
#pragma warning disable CS8604 // Possible null reference argument.
                SeedData(serviceScope.ServiceProvider.GetService<AppDBContext>());
#pragma warning restore CS8604 // Possible null reference argument.
            }
        }

        private static void SeedData(AppDBContext dbContext) 
        {
            if(!dbContext.Platforms.Any())
            {
                Console.WriteLine("--> Seeding data");
            
                dbContext.Platforms.AddRange(
                    new Platform() { Name = "Dot Net", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "SQL Server Express", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" });
                
                dbContext.SaveChanges();     
               
            }
            else
            {
                Console.WriteLine("--> we already have data");
            }
        }
    }
}
