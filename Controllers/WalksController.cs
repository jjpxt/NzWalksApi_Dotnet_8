using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NzWalksApi_Dotnet_8.Models.Domain;
using NzWalksApi_Dotnet_8.Models.DTO;
using NzWalksApi_Dotnet_8.Repositories;

namespace NzWalksApi_Dotnet_8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IWalkRepository _walkRepository;
        private readonly IMapper _mapper;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            _mapper = mapper;
            _walkRepository = walkRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWalks()
        {
            var walks = await _walkRepository.GetAllWalksAsync();
            return Ok(_mapper.Map<List<WalkDto>>(walks));
        }

        [HttpPost]
        public async Task<IActionResult> CreateWalk([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            var mappedWalk = _mapper.Map<Walk>(addWalkRequestDto);
            await _walkRepository.CreateAsync(mappedWalk);

            return Ok(_mapper.Map<WalkDto>(mappedWalk));
        }
    }
}
