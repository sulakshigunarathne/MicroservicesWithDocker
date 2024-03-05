using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatfromService.Data;
using PlatfromService.DTOs;
using PlatfromService.Models;

namespace PlatfromService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPlatformRepo _repository;
        public PlatformController(IPlatformRepo repository,IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
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
        public ActionResult<PlatformReadDTO> CreatePlatform(PlatformCreateDTO platformCreateDTO)
        {
            var platformModel = _mapper.Map<Platform>(platformCreateDTO);
            _repository.CreatePlatform(platformModel);
            _repository.SaveChanges();

            var platformReadDTO = _mapper.Map<PlatformReadDTO>(platformModel);

            return CreatedAtRoute(nameof(GetPlatformById),new {Id = platformReadDTO.Id},platformReadDTO);
        }
    }



    
}
