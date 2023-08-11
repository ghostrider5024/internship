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
    public class PlaylistController : ControllerBase
    {
        private readonly IPlaylistService _PlaylistService;
        private readonly IMapper _mapper;

        public PlaylistController(IPlaylistService PlaylistService, IMapper mapper)
        {
            _PlaylistService = PlaylistService;
            _mapper = mapper;
        }

        [HttpGet("playlists")]
        public async Task<IActionResult> GetPlaylists()
        {
            var result = await _PlaylistService.GetAllPlaylistsAsync();
            return Ok(new ReturnResponse<List<PlaylistResponse>>(_mapper.Map<List<PlaylistResponse>>(result)));
        }

        [HttpPost("playlist")]
        public async Task<IActionResult> CreatePlaylist(PlaylistResponse Playlist)
        {
            var result = await _PlaylistService.CreatePlaylistAsync(_mapper.Map<Playlist>(Playlist));
            return Ok(new ReturnResponse<PlaylistResponse>(_mapper.Map<PlaylistResponse>(result)));
        }

        [HttpPut("edit/{keyId}")]
        public async Task<IActionResult> UpdatePlaylist(string keyId, PlaylistResponse Playlist)
        {
            var temp = _mapper.Map<Playlist>(Playlist);
            temp.Id = keyId;
            var result = await _PlaylistService.UpdatePlaylistAsync(temp);
            return Ok(new ReturnResponse<PlaylistResponse>(_mapper.Map<PlaylistResponse>(result)));
        }

        [HttpDelete("delete/{keyId}")]
        public async Task<IActionResult> DeletePlaylist(string keyId)
        {
            var result = await _PlaylistService.DeletePlaylistAsync(keyId);
            var returnRes = new ReturnResponse<PlaylistResponse>(_mapper.Map<PlaylistResponse>(result)
                , messageSuccess: "Delete success", messageFail: "Delete failed");

            return Ok(returnRes);
        }
    }
}
