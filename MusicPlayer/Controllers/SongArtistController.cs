using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicPlayer.Models.ResponseModels;
using MusicPlayer.Models;
using MusicPlayer.Services;

namespace MusicPlayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongArtistController : ControllerBase
    {
        private readonly ISongArtistService _songArtistService;
        private readonly IMapper _mapper;

        public SongArtistController(ISongArtistService songArtistService, IMapper mapper)
        {
            _songArtistService = songArtistService;
            _mapper = mapper;
        }

        [HttpGet("SongArtists")]
        public async Task<IActionResult> GetSongArtists()
        {
            var result = await _songArtistService.GetAllSongArtistsAsync();
            return Ok(new ReturnResponse<List<SongArtistResponse>>(_mapper.Map<List<SongArtistResponse>>(result)));
        }

        [HttpPost("SongArtist")]
        public async Task<IActionResult> CreateSongArtist(SongArtistResponse SongArtist)
        {
            var result = await _songArtistService.CreateSongArtistAsync(_mapper.Map<SongArtist>(SongArtist));
            return Ok(new ReturnResponse<SongArtistResponse>(_mapper.Map<SongArtistResponse>(result)));
        }

        [HttpPut("edit/{keyId}")]
        public async Task<IActionResult> UpdateSongArtist(string keyId, SongArtistResponse SongArtist)
        {
            var temp = _mapper.Map<SongArtist>(SongArtist);
            temp.Id = keyId;
            var result = await _songArtistService.UpdateSongArtistAsync(temp);
            return Ok(new ReturnResponse<SongArtistResponse>(_mapper.Map<SongArtistResponse>(result)));
        }

        [HttpDelete("delete/{keyId}")]
        public async Task<IActionResult> DeleteSongArtist(string keyId)
        {
            var result = await _songArtistService.DeleteSongArtistAsync(keyId);
            var returnRes = new ReturnResponse<SongArtistResponse>(_mapper.Map<SongArtistResponse>(result)
                , messageSuccess: "Delete success", messageFail: "Delete failed");

            return Ok(returnRes);
        }
    }
}
