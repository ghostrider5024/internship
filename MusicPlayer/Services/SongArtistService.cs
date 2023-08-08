using AutoMapper;
using MusicPlayer.Models;
using MusicPlayer.Repositories;

namespace MusicPlayer.Services
{
    public interface ISongArtistService
    {
        public Task<ICollection<SongArtist>> GetAllSongArtistsAsync();
        public Task<SongArtist> CreateSongArtistAsync(SongArtist model);
        public Task<SongArtist> UpdateSongArtistAsync(SongArtist model);
        public Task<SongArtist> DeleteSongArtistAsync(string id);
    }
    public class SongArtistService : ISongArtistService
    {
        private readonly IMapper _mapper;
        private readonly SongArtistRepository _songArtistRepository;

        public SongArtistService(IMapper mapper, SongArtistRepository SongArtistRepository)
        {
            _mapper = mapper;
            _songArtistRepository = SongArtistRepository;
        }

        public async Task<ICollection<SongArtist>> GetAllSongArtistsAsync()
        {
            var SongArtists = await _songArtistRepository.GetSongArtistsWithInclude();
            return SongArtists.ToList();
        }

        public async Task<SongArtist> CreateSongArtistAsync(SongArtist model)
        {
            var result = await _songArtistRepository.CreateSongArtistAsync(model);
            if (result != null)
            {
                return model;
            }
            return null;
        }

        public async Task<SongArtist> UpdateSongArtistAsync(SongArtist model)
        {
            var result = await _songArtistRepository.UpdateSongArtistAsync(model);
            if (result != null)
            {
                return model;
            }
            return null;
        }

        public async Task<SongArtist> DeleteSongArtistAsync(string id)
        {
            var result = await GetSongArtistById(id);
            if (result != null)
            {
                result.DeletedDate = DateTime.Now;
                return await UpdateSongArtistAsync(result);
            }
            else
            {
                return null;
            }
        }

        public async Task<SongArtist> GetSongArtistById(string Id)
        {
            return await _songArtistRepository.GetById(Id);
        }
    }
}
