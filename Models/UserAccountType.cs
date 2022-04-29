using System.ComponentModel.DataAnnotations;

namespace cadl.Models
{
    public class UserAccountType
    {
        [Key]
        public System.Guid UserAccountTypeId { get; set; }
        public string AccountTypeName { get; set; }
        public string Description { get; set; }
    }
}
