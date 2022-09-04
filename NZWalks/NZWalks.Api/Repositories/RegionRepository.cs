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
        public IEnumerable<Region> GetAll()
        {
            return _NZwalksDbcontext.Regions.ToList();
        }
    }
}
