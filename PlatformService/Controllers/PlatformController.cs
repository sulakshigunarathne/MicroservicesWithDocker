using System.Windows.Input;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatfromService.Data;
using PlatfromService.DTOs;
using PlatfromService.Models;
using PlatformService.SyncDatServices;
using PlatformService.SyncDatServices.Http;

namespace PlatfromService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPlatformRepo _repository;
        private readonly ICommandDataClient _commandDataClient;
        public PlatformController(IPlatformRepo repository,IMapper mapper, ICommandDataClient commandDataClient ) 
        {
            _repository = repository;
            _mapper = mapper;
            _commandDataClient = commandDataClient;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDTO>> GetPlatforms()
        {
            Console.WriteLine("--> Getting platforms...");

            var platformItem = _repository.GetAllPLatforms();

            return Ok(_mapper.Map<IEnumerable<PlatformReadDTO>>(platformItem));
        }

        [HttpGet("{id}",Name ="GetPlatformById")]
        public ActionResult<PlatformReadDTO> GetPlatformById(int Id)
        {
                var platformItem = _repository.GetPlatformByID(Id);
                if (platformItem != null)
                {
                    return Ok(_mapper.Map<PlatformReadDTO>(platformItem));
                }
                return NotFound();
        }
        [HttpPost]
        public async Task<ActionResult<PlatformReadDTO>> CreatePlatform(PlatformCreateDTO platformCreateDTO)
        {
            var platformModel = _mapper.Map<Platform>(platformCreateDTO);
            _repository.CreatePlatform(platformModel);
            _repository.SaveChanges();

            var platformReadDTO = _mapper.Map<PlatformReadDTO>(platformModel);
            
            try
            {
                await _commandDataClient.SendPlatformToCommand(platformReadDTO);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"--> Could not send synchronusly: {ex.Message}");
            }
            return CreatedAtRoute(nameof(GetPlatformById),new {Id = platformReadDTO.Id},platformReadDTO);
        }
    }   
}
