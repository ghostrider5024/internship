
using System.ComponentModel.DataAnnotations;

namespace MusicPlayer.Models
{
    public enum Role
    {
        User,
        Admin
    }
   
    public class User : BaseModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string? Name { get; set; }
        public string? Gender { get; set; }
        public DateTimeOffset? BirthDay { get; set; }
        public string? Address { get; set; }
        public Role Role { get; set; } = Role.User;

        public string GenRole()
        {
            var names = Role.GetNames<Role>();
            for (int i = 0; i < names.Length; i++)
            {
                var name = names[i];
                if (name == Role.GetName<Role>(Role))
                    return name;
            }
            return nameof(Role.User);
        }
    }
}
