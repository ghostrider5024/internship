namespace MusicPlayer.Models
{
    public class BaseModel
    {
        public string Id { get; set; }
        public DateTimeOffset? DeletedDate { get; set; }
    }
}
