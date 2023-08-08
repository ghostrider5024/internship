using System.ComponentModel.DataAnnotations;
using MusicPlayer.Data;

namespace MusicPlayer.Models
{
    public class Song : BaseModel
    {
        [Required]
        public string Title { get; set; }
        public string Audio { get; set; }
        public string Thumbnail { get; set; }
        public DateTimeOffset ReleasedDate { get; set; }
        public string Language { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }

        public ICollection<SongArtist> SongArtists { get; set; }
        public ICollection<SongPlaylist> SongPlaylists { get; set; }
    }
}



