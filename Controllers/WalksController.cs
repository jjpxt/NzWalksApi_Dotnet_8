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
        public async Task<IActionResult> GetAllWalks([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000)
        {
            var walks = await _walkRepository.GetAllWalksAsync(filterOn, filterQuery, sortBy,
                isAscending ?? true, pageNumber, pageSize);
            return Ok(_mapper.Map<List<WalkDto>>(walks));
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetWalkById(Guid id)
        {
            var walk = await _walkRepository.GetByIdAsync(id);
            if (walk is null) return NotFound();
            return Ok(_mapper.Map<WalkDto>(walk));
        }

        [HttpPost]
        public async Task<IActionResult> CreateWalk([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            if (ModelState.IsValid)
            {
                var mappedWalk = _mapper.Map<Walk>(addWalkRequestDto);
                await _walkRepository.CreateAsync(mappedWalk);

                return Ok(_mapper.Map<WalkDto>(mappedWalk));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateWalk([FromRoute] Guid id, [FromBody] UpdateWalkRequestDto updateWalkRequestDto)
        {
            if (ModelState.IsValid)
            {
                var mappedWalk = _mapper.Map<Walk>(updateWalkRequestDto);
                mappedWalk = await _walkRepository.UpdateAsync(id, mappedWalk);
                if (mappedWalk == null) return NotFound();
                return Ok(_mapper.Map<WalkDto>(mappedWalk));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> RemoveWalk(Guid id)
        {
            var walk = await _walkRepository.DeleteAsync(id);

            if (walk is null) return NotFound();

            return Ok(_mapper.Map<WalkDto>(walk));
        }
    }
}
