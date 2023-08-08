using AutoMapper;
using MusicPlayer.Models;
using MusicPlayer.Repositories;

namespace MusicPlayer.Services
{
    public interface ISongService
    {
        public Task<ICollection<Song>> GetAllSongsAsync();
        public Task<Song> CreateSongAsync(Song model);
        public Task<Song> UpdateSongAsync(Song model);
        public Task<Song> DeleteSongAsync(string id);
    }
    public class SongService : ISongService
    {
        private readonly IMapper _mapper;
        private readonly SongRepository _songRepository;

        public SongService(IMapper mapper, SongRepository songRepository)
        {
            _mapper = mapper;
            _songRepository = songRepository;
        }
       
        public async Task<ICollection<Song>> GetAllSongsAsync()
        {
            var songs = await _songRepository.GetSongsWithInclude();
            return songs.ToList();
        }

        public async Task<Song> CreateSongAsync(Song model)
        {
            var result = await _songRepository.CreateSongAsync(model);
            if(result != null)
            {
                return model;
            }
            return null;
        }

        public async Task<Song> UpdateSongAsync(Song model)
        {
            var result = await _songRepository.UpdateSongAsync(model);
            if (result != null)
            {
                return model;
            }
            return null;
        }

        public async Task<Song> DeleteSongAsync(string id)
        {
            var result = await GetSongById(id);
            if(result != null)
            {
                result.DeletedDate = DateTime.Now;
                return await UpdateSongAsync(result);
            }
            else
            {
                return null;
            }
        }

        public async Task<Song> GetSongById(string Id)
        {
            return await _songRepository.GetById(Id);
        }
    }
}
