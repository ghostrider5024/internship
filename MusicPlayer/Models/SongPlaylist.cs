namespace MusicPlayer.Models
{
    public class SongPlaylist : BaseModel
    {
        public string SongId { get; set; }
        public string PlaylistId { get; set; }
        public string Role { get; set; }

        public Song Song { get; set; }
        public Playlist Playlist { get; set; }
    }
}
