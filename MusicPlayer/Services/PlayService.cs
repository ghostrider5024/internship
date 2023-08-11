using AutoMapper;
using MusicPlayer.Models;
using MusicPlayer.Repositories;

namespace MusicPlayer.Services
{
    public interface IPlaylistService
    {
        public Task<ICollection<Playlist>> GetAllPlaylistsAsync();
        public Task<Playlist> CreatePlaylistAsync(Playlist model);
        public Task<Playlist> UpdatePlaylistAsync(Playlist model);
        public Task<Playlist> DeletePlaylistAsync(string id);
    }
    public class PlaylistService : IPlaylistService
    {
        private readonly IMapper _mapper;
        private readonly PlaylistRepository _PlaylistRepository;

        public PlaylistService(IMapper mapper, PlaylistRepository PlaylistRepository)
        {
            _mapper = mapper;
            _PlaylistRepository = PlaylistRepository;
        }

        public async Task<ICollection<Playlist>> GetAllPlaylistsAsync()
        {
            var Playlists = await _PlaylistRepository.GetPlaylistsWithInclude();
            return Playlists.ToList();
        }

        public async Task<Playlist> CreatePlaylistAsync(Playlist model)
        {
            var result = await _PlaylistRepository.CreatePlaylistAsync(model);
            if (result != null)
            {
                return model;
            }
            return null;
        }

        public async Task<Playlist> UpdatePlaylistAsync(Playlist model)
        {
            var result = await _PlaylistRepository.UpdatePlaylistAsync(model);
            if (result != null)
            {
                return model;
            }
            return null;
        }

        public async Task<Playlist> DeletePlaylistAsync(string id)
        {
            var result = await GetPlaylistById(id);
            if (result != null)
            {
                result.DeleteDate = DateTime.Now;
                return await UpdatePlaylistAsync(result);
            }
            else
            {
                return null;
            }
        }

        public async Task<Playlist> GetPlaylistById(string Id)
        {
            return await _PlaylistRepository.GetById(Id);
        }
    }
}
