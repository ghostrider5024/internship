using Microsoft.EntityFrameworkCore;
using MusicPlayer.Models;

namespace MusicPlayer.Repositories
{
    public class ArtistRepository : BaseRepository<Artist>
    {
        public async Task<IQueryable<Artist>> GetArtistsWithInclude()
        {
            return _context.Set<Artist>()
                .Where(t => t.DeletedDate == null);
        }

        public async Task<Artist> CreateArtistAsync(Artist model)
        {
            model.DeletedDate = null;
            return await Add(model);
        }

        public async Task<Artist> UpdateArtistAsync(Artist model)
        {
            return await Update(model);
        }

    }
}
