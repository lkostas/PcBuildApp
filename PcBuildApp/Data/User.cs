using System.ComponentModel.DataAnnotations;
using PcBuildApp.Enums;

namespace PcBuildApp.Data
{
    public class User : BaseEntity
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Password { get; set; }
        
        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }
        
        [StringLength(50)]
        public string FirstName { get; set; }
        
        [StringLength(50)]
        public string LastName { get; set; }
        
        public UserRole UserRole { get; set; } = UserRole.User;
        
        public bool IsActive { get; set; } = true;
    }
}