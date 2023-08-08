using Microsoft.EntityFrameworkCore;
using MusicPlayer.Models;

namespace MusicPlayer.Repositories
{
    public class SongRepository : BaseRepository<Song>
    {
        public async Task<IQueryable<Song>> GetSongsWithInclude()
        {
            return _context.Set<Song>()
                .Include(p => p.SongArtists)
                .Include(p => p.SongPlaylists).ThenInclude(c => c.Playlist)
                .Where(t => t.DeleteDate == null);
        }

        public async Task<Song> CreateSongAsync(Song model)
        {
            model.DeleteDate = null;
            return await Add(model);
        }

        public async Task<Song> UpdateSongAsync(Song model)
        {
            return await Update(model);
        }




    }
}
