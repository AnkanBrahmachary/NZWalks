using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Api.Models.Domains;
using NZWalks.Api.Models.DTO;
using NZWalks.Api.Repositories;

namespace NZWalks.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionsController : Controller
    {
        private readonly IRegionRepository _RegionRepository;
        private readonly IMapper _Mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            this._RegionRepository = regionRepository;
            this._Mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegionsAsync()
        {
            var regions = await _RegionRepository.GetAllAsync();

            //USING DTO TO ABSTRACT DATA TO OUTSIDE WORLD.
            //var RegionDTO = new List<Models.DTO.Regions>();

            //foreach (var regionDomain in regions)
            //{
            //    var regionDTO = new Models.DTO.Regions() 
            //    { 
            //       Name = regionDomain.Name,
            //       Id = regionDomain.Id,
            //       Area = regionDomain.Area,
            //       Code = regionDomain.Code,
            //    };
            //    RegionDTO.Add(regionDTO);
            //}
            var RegionDTO = _Mapper.Map<List<Models.DTO.Regions>>(regions);


            return  Ok(RegionDTO);
        }
        
        
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetRegionAsync")]
        public async Task<IActionResult> GetRegionAsync(Guid id)
        {
            var region = await _RegionRepository.GetAsync(id);

            //test1


            if (region==null)
            {
                return NotFound();
            }
            
            var regionDto = _Mapper.Map<Models.DTO.Regions>(region);
            return Ok(regionDto);
            
            
        }

        [HttpPost]
        public async Task<IActionResult> AddRegionAsync(AddRegionRequest addRegionRequest)
        {
            //convert request(DTO) to domain

            var region = new Region()
            {
                Area = addRegionRequest.Area,
                Code = addRegionRequest.Code,
                Name = addRegionRequest.Name,
                Latitude = addRegionRequest.Latitude,
                Longitude = addRegionRequest.Longitude,
                Population = addRegionRequest.Population
            };

            //pass details to repository
            var newregion = await _RegionRepository.AddAsync(region);

            // convert back to DTO
            var regionDTO = new Regions()
            {
                Id = newregion.Id,
                Area = newregion.Area,
                Name = newregion.Name,
                Code = newregion.Code,
                Latitude = newregion.Latitude,
                Longitude = newregion.Longitude,
                Population = newregion.Population

            };

            return await GetRegionAsync(regionDTO.Id);

        }

    }
}
