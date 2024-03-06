using PlatfromService.DTOs;

namespace PlatformService.SyncDatServices.Http
{
    public interface ICommandDataClient
    {
        Task SendPlatformToCommand(PlatformReadDTO platformRead);
    }
}