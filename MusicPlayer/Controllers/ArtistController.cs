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
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService _ArtistService;
        private readonly IMapper _mapper;

        public ArtistController(IArtistService ArtistService, IMapper mapper)
        {
            _ArtistService = ArtistService;
            _mapper = mapper;
        }

        [HttpGet("artists")]
        public async Task<IActionResult> GetArtists()
        {
            var result = await _ArtistService.GetAllArtistsAsync();
            return Ok(new ReturnResponse<List<ArtistResponse>>(_mapper.Map<List<ArtistResponse>>(result)));
        }

        [HttpPost("artist")]
        public async Task<IActionResult> CreateArtist(ArtistResponse Artist)
        {
            var result = await _ArtistService.CreateArtistAsync(_mapper.Map<Artist>(Artist));
            return Ok(new ReturnResponse<ArtistResponse>(_mapper.Map<ArtistResponse>(result)));
        }

        [HttpPut("edit/{keyId}")]
        public async Task<IActionResult> UpdateArtist(string keyId, ArtistResponse Artist)
        {
            var temp = _mapper.Map<Artist>(Artist);
            temp.Id = keyId;
            var result = await _ArtistService.UpdateArtistAsync(temp);
            return Ok(new ReturnResponse<ArtistResponse>(_mapper.Map<ArtistResponse>(result)));
        }

        [HttpDelete("delete/{keyId}")]
        public async Task<IActionResult> DeleteArtist(string keyId)
        {
            var result = await _ArtistService.DeleteArtistAsync(keyId);
            var returnRes = new ReturnResponse<ArtistResponse>(_mapper.Map<ArtistResponse>(result)
                , messageSuccess: "Delete success", messageFail: "Delete failed");

            return Ok(returnRes);
        }
    }
}
