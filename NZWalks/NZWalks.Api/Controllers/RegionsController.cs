using Microsoft.AspNetCore.Mvc;
using NZWalks.Api.Models.Domains;

namespace NZWalks.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionsController : Controller
    {
        [HttpGet]
        public IActionResult GetAllRegions()
        {
            var regions = new List<Region>() 
            { 
                new Region
                {
                    Id=Guid.NewGuid(),
                    Name="Wellington",
                    Code="WEL",
                    Latitude=-23987,
                    Longitude=-767665,
                    Area=235 , 
                    Population=767676
                },

                new Region
                {
                    Id=Guid.NewGuid(),
                    Name="Delhi",
                    Code="DEL",
                    Latitude=-23987,
                    Longitude=-8787,
                    Area=9898,
                    Population=65765765
                    
                }
                 

            };
            return Ok(regions);
        }
    }
}
