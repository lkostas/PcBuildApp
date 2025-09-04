using System.ComponentModel.DataAnnotations;

namespace PcBuildApp.DTO
{
    public class UserLoginDTO
    {
        [Required]
        public string UserName { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}