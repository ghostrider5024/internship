namespace MusicPlayer.Models
{
    public class Artist : BaseModel
    {
        public string Name { get; set; }
        public string Thumbnail { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }
        public DateTimeOffset DebutDate { get; set; }

        public ICollection<SongArtist> SongArtists { get; set; }
    }
}
