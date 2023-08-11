namespace MusicPlayer.Models.ResponseModels
{
    public class SongPlaylistResponse
    {
        public string SongId { get; set; }
        public string PlaylistId { get; set; }
        public string Role { get; set; }
        public DateTimeOffset? DeleteDate { get; set; }
    }
}
