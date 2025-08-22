using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NzWalksApi_Dotnet_8.CustomActionFilters;
using NzWalksApi_Dotnet_8.Data;
using NzWalksApi_Dotnet_8.Models.Domain;
using NzWalksApi_Dotnet_8.Models.DTO;
using NzWalksApi_Dotnet_8.Repositories;

namespace NzWalksApi_Dotnet_8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext _nZWalksDbContext;
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;


        public RegionsController(NZWalksDbContext nZWalksDbContext, IRegionRepository regionRepository,
            IMapper mapper)
        {
            _nZWalksDbContext = nZWalksDbContext;
            _regionRepository = regionRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            return Ok(await _regionRepository.GetAllAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetRegionById")]
        public async Task<IActionResult> GetRegionById([FromRoute] Guid id)
        {
            var region = await _regionRepository.GetOneRegionAsync(id);
            if (region is null) return NotFound();
            return Ok(region);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateNewRegion([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            var regionDomain = _mapper.Map<Region>(addRegionRequestDto);
            regionDomain = await _regionRepository.CreateAsync(regionDomain);
            var regionDto = _mapper.Map<RegionDto>(regionDomain);
            return CreatedAtAction(nameof(GetRegionById), new { id = regionDto.Id }, regionDto);
        }

        [HttpPut]
        [Route("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            var region = _mapper.Map<Region>(updateRegionRequestDto);
            region = await _regionRepository.UpdateAsync(id, region);
            if (region is null) return NotFound();
            var regionDto = _mapper.Map<RegionDto>(region);
            return Ok(regionDto);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var region = await _regionRepository.DeleteAsync(id);
            if (region is null) return NotFound();
            return Ok("Successfuly deleted!");
        }
    }
}
