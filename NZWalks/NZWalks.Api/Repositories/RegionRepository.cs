using Microsoft.EntityFrameworkCore;
using NZWalks.Api.Data;
using NZWalks.Api.Models.Domains;

namespace NZWalks.Api.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZWalksDbcontext _NZwalksDbcontext;

        public RegionRepository(NZWalksDbcontext nZWalksDbcontext)
        {
            this._NZwalksDbcontext = nZWalksDbcontext;
        }
        //use aync keyword to make code asynchronous
        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await _NZwalksDbcontext.Regions.ToListAsync();
        }

        public async Task<Region> GetAsync(Guid id)
        {
            return await _NZwalksDbcontext.Regions.FirstOrDefaultAsync(x=>x.Id== id); 
        }
    }
}
