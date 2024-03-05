using PlatfromService.Models;

namespace PlatfromService.Data
{
    public class PlatformRepo : IPlatformRepo
    {
        private readonly AppDBContext _context;
        public PlatformRepo(AppDBContext context)
        {
            _context = context;
        }
        void IPlatformRepo.CreatePlatform(Platform platform)
        {
            if(platform == null)
            {
                throw new ArgumentNullException(nameof(platform));
            }
            _context.Platforms.Add(platform);
        }

        IEnumerable<Platform> IPlatformRepo.GetAllPLatforms()
        {
            return _context.Platforms.ToList();
        }

        Platform IPlatformRepo.GetPlatformByID(int id)
        {
            return _context.Platforms.FirstOrDefault(p => p.Id == id);
        }

        bool IPlatformRepo.SaveChanges()
        {
            
            return (_context.SaveChanges() >= 0);
        }
    }
}
