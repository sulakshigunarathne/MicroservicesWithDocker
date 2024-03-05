using System.Collections.Generic;
using PlatfromService.Models;

namespace PlatfromService.Data
{
    public interface IPlatformRepo
    {
        bool SaveChanges();

        IEnumerable<Platform> GetAllPLatforms();
        Platform GetPlatformByID(int id);

        void CreatePlatform(Platform platform);

    }
}
