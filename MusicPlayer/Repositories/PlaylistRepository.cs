using MusicPlayer.Models;

namespace MusicPlayer.Repositories
{
    public class PlaylistRepository : BaseRepository<Playlist>
    {
        public async Task<IQueryable<Playlist>> GetPlaylistsWithInclude()
        {
            return _context.Set<Playlist>()
                .Where(t => t.DeleteDate == null);
        }

        public async Task<Playlist> CreatePlaylistAsync(Playlist model)
        {
            model.DeleteDate = null;
            return await Add(model);
        }

        public async Task<Playlist> UpdatePlaylistAsync(Playlist model)
        {
            return await Update(model);
        }
    }
}
