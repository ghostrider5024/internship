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
                .Include(p => p.SongPlaylists).ThenInclude(c => c.Playlist);
        }

        public async Task<Song> CreateSongAsync(Song model)
        {
            return await Add(model);
        }

        




    }
}
