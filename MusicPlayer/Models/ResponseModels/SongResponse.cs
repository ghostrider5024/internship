namespace MusicPlayer.Models.ResponseModels
{
    public class SongResponse
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Audio { get; set; }
        public string Thumbnail { get; set; }
        public DateTimeOffset ReleasedDate { get; set; }
        public string Language { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }

        //public List<ArtistResponse> Artists { get; set; }
        //public List<PlaylistResponse> Playlists { get; set; }
    }
}
