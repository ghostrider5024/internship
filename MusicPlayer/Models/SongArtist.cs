namespace MusicPlayer.Models
{
    public class SongArtist : BaseModel
    {
        public string SongId { get; set; }
        public string ArtistId { get; set; }
        public string Role { get; set; }

        public Song Song { get; set; }
        public Artist Aritst { get; set; }
    }
}
