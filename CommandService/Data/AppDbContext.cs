namespace CommandService.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> opt): base(opt)
        {

        }

        public DbSet<Platform> Platforms {get; set;}
        public DbSet<Command> Commands {get; set;}
    }
}