using Microsoft.EntityFrameworkCore;
using MusicPlayer.Models;

namespace MusicPlayer.Repositories
{
    public class SongArtistRepository : BaseRepository<SongArtist>
    {
        public async Task<IQueryable<SongArtist>> GetSongArtistsWithInclude()
        {
            return _context.Set<SongArtist>()
                .Where(t => t.DeletedDate == null);
        }

        public async Task<SongArtist> CreateSongArtistAsync(SongArtist model)
        {
            model.DeletedDate = null;
            return await Add(model);
        }

        public async Task<SongArtist> UpdateSongArtistAsync(SongArtist model)
        {
            return await Update(model);
        }

    }
}
