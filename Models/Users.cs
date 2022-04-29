using System.ComponentModel.DataAnnotations;

namespace cadl.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public System.Guid UserAccountTypeId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public System.DateTime DateCreated { get; set; } = System.DateTime.Now;
    }
}
