using AutoMapper;
using MusicPlayer.Models;
using MusicPlayer.Repositories;

namespace MusicPlayer.Services
{
    public interface IArtistService
    {
        public Task<ICollection<Artist>> GetAllArtistsAsync();
        public Task<Artist> CreateArtistAsync(Artist model);
        public Task<Artist> UpdateArtistAsync(Artist model);
        public Task<Artist> DeleteArtistAsync(string id);
    }
    public class ArtistService : IArtistService
    {
        private readonly IMapper _mapper;
        private readonly ArtistRepository _artistRepository;

        public ArtistService(IMapper mapper, ArtistRepository artistRepository)
        {
            _mapper = mapper;
            _artistRepository = artistRepository;
        }

        public async Task<ICollection<Artist>> GetAllArtistsAsync()
        {
            var Artists = await _artistRepository.GetArtistsWithInclude();
            return Artists.ToList();
        }

        public async Task<Artist> CreateArtistAsync(Artist model)
        {
            var result = await _artistRepository.CreateArtistAsync(model);
            if (result != null)
            {
                return model;
            }
            return null;
        }

        public async Task<Artist> UpdateArtistAsync(Artist model)
        {
            var result = await _artistRepository.UpdateArtistAsync(model);
            if (result != null)
            {
                return model;
            }
            return null;
        }

        public async Task<Artist> DeleteArtistAsync(string id)
        {
            var result = await GetArtistById(id);
            if (result != null)
            {
                result.DeleteDate = DateTime.Now;
                return await UpdateArtistAsync(result);
            }
            else
            {
                return null;
            }
        }

        public async Task<Artist> GetArtistById(string Id)
        {
            return await _artistRepository.GetById(Id);
        }
    }
}
