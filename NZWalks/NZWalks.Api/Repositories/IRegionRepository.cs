using NZWalks.Api.Models.Domains;

namespace NZWalks.Api.Repositories
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region> >GetAllAsync();

        Task<Region> GetAsync(Guid id);

        Task<Region> AddAsync(Region region);
    }
}
