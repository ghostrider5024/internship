namespace MusicPlayer.Models
{
    public class Playlist : BaseModel
    {
        public string Title { get; set; }
        public string Thumbnail { get; set; }
        public string Description { get; set; }
        public DateTimeOffset ReleasedDate { get; set; }
        public ICollection<SongPlaylist> SongPlaylists { get; set; }
    }
}
