using Microsoft.EntityFrameworkCore;
using PlatfromService.Models;

namespace PlatfromService.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<Platform> Platforms { get; set; }
    }
}
