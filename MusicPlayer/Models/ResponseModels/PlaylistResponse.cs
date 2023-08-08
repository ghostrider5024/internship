namespace MusicPlayer.Models.ResponseModels
{
    public class PlaylistResponse
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Thumbnail { get; set; }
        public string Description { get; set; }
        public DateTimeOffset ReleasedDate { get; set; }
        public List<SongResponse> Songs { get; set; }
    }
}
