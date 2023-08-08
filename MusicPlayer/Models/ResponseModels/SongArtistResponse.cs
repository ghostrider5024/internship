namespace MusicPlayer.Models.ResponseModels
{
    public class SongArtistResponse
    {
        public string SongId { get; set; }
        public string ArtistId { get; set; }
        public string Role { get; set; }
        public DateTimeOffset ReleasedDate { get; set; }
    }
}
