using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MusicPlayer.Models;
using MusicPlayer.Models.ResponseModels;
using MusicPlayer.Services;

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
            return Ok(_mapper.Map<List<SongResponse>>(result));
        }

        [HttpPost("song")]
        public async Task<IActionResult> CreateSong(SongResponse song)
        {
            var result = await _songService.CreateAsync(_mapper.Map<Song>(song));
            return Ok(new ReturnResponse<SongResponse>(_mapper.Map<SongResponse>(result)));
        }
    }
}
