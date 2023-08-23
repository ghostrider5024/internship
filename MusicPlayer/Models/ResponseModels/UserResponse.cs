namespace MusicPlayer.Models.ResponseModels
{
    public class UserResponse
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string? Name { get; set; }
        public string? Gender { get; set; }
        public DateTimeOffset? BirthDay { get; set; }
        public string? Address { get; set; }
        public Role Role { get; set; } = Role.User;
    }
}
