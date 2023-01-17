using System.ComponentModel.DataAnnotations;

namespace WebApplication6.src.Features.Authorization.Dto
{
    public class UserCreateDto
    {
        public string Login { get; set; }
        
        public string Password { get; set; }
    }
}
