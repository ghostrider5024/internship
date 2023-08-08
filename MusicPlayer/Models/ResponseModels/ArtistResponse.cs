namespace MusicPlayer.Models.ResponseModels
{
    public class ArtistResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Thumbnail { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }
        public DateTimeOffset DebutDate { get; set; }

        public List<SongResponse> Songs { get; set; }
    }
}
