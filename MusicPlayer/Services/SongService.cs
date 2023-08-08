using AutoMapper;
using MusicPlayer.Models;
using MusicPlayer.Repositories;

namespace MusicPlayer.Services
{
    public interface ISongService
    {
        public Task<ICollection<Song>> GetAllSongsAsync();
        public Task<Song> CreateAsync(Song model);
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

        public async Task<Song> CreateAsync(Song model)
        {
            var result = await _songRepository.CreateSongAsync(model);
            if(result != null)
            {
                return model;
            }
            return null;
        }
       
    }
}
