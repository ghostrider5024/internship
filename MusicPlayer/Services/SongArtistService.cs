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
        public Task<SongArtist> DeleteSongArtistAsync(string songId, string artistId);
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

        public async Task<SongArtist> DeleteSongArtistAsync(string songId, string artistId)
        {
            var result = await GetSongArtistById(songId, artistId);
            if (result != null)
            {
                result.DeleteDate = DateTime.Now;
                return await UpdateSongArtistAsync(result);
            }
            else
            {
                return null;
            }
        }

        public async Task<SongArtist> GetSongArtistById(string songId, string artistId)
        {
            return await _songArtistRepository.GetById(songId, artistId);
        }
    }
}
