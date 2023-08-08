using System.ComponentModel.DataAnnotations;

namespace MusicPlayer.Models
{
    public class BaseModel
    {
        [Key]
        public string Id { get; set; }
        public DateTimeOffset? DeleteDate { get; set; }
    }
}
