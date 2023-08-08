namespace MusicPlayer.Models
{
    public class SongPlaylist
    {
        public string SongId { get; set; }
        public string PlaylistId { get; set; }
        public string Role { get; set; }
        public DateTimeOffset? DeleteDate { get; set; }

        public Song Song { get; set; }
        public Playlist Playlist { get; set; }
    }
}
