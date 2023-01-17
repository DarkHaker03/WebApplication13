using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication6.src.Entities
{
    [Index(nameof(Login), IsUnique = true)]
    public class User
    {
        public User(string login,string password) {
            Login = login;
            Password = password;
        }
        public User()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
