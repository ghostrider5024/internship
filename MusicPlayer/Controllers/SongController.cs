using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicPlayer.Models;
using MusicPlayer.Models.ResponseModels;
using MusicPlayer.Services;
using System.Data;

namespace MusicPlayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly ISongService _songService;
        private readonly IMapper _mapper;

        public SongController(ISongService songService, IMapper mapper)
        {
            _songService = songService;
            _mapper = mapper;
        }

        [HttpGet("songs")]
        public async Task<IActionResult> GetSongs()
        {
            var result = await _songService.GetAllSongsAsync();
            return Ok(new ReturnResponse<List<SongResponse>>(_mapper.Map<List<SongResponse>>(result)));
        }

        [HttpPost("song")]
        [Authorize(Roles = nameof(Role.Admin))]
        public async Task<IActionResult> CreateSong(SongResponse song)
        {
            var result = await _songService.CreateSongAsync(_mapper.Map<Song>(song));
            return Ok(new ReturnResponse<SongResponse>(_mapper.Map<SongResponse>(result)));
        }

        [HttpPut("edit/{keyId}")]
        [Authorize(Roles = nameof(Role.Admin))]
        public async Task<IActionResult> UpdateSong(string keyId, SongResponse song)
        {
            var temp = _mapper.Map<Song>(song);
            temp.Id = keyId;
            var result = await _songService.UpdateSongAsync(temp);
            return Ok(new ReturnResponse<SongResponse>(_mapper.Map<SongResponse>(result)));
        }

        [HttpDelete("delete/{keyId}")]
        [Authorize(Roles = nameof(Role.Admin))]
        public async Task<IActionResult> DeleteSong(string keyId)
        {
            var result = await _songService.DeleteSongAsync(keyId);
            var returnRes = new ReturnResponse<SongResponse>(_mapper.Map<SongResponse>(result)
                , messageSuccess:"Delete success", messageFail:"Delete failed");

            return Ok(returnRes);
        }
    }   
}
