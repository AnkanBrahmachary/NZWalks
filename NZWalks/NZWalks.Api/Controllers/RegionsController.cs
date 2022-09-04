using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Api.Models.Domains;
using NZWalks.Api.Repositories;
using System.Collections.Generic;

namespace NZWalks.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionsController : Controller
    {
        private readonly IRegionRepository _RegionRepository;
        private readonly IMapper _Mapper;

        public RegionsController(IRegionRepository regionRepository,IMapper mapper)
        {
            this._RegionRepository = regionRepository;
            this._Mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllRegions()
        {
            var regions= _RegionRepository.GetAll();

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
            var RegionDTO=_Mapper.Map<List<Models.DTO.Regions>>(regions);


            return Ok(RegionDTO);
        }

        //public void GetById()
        //{

        //}
    }
}
