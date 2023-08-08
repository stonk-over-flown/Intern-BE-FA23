using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Entity
{
    [Table("User")]
    public class UserEntity : Entity
    {
        [Required]
        [StringLength(50)]
        public string Username { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        [DefaultValue(true)]
        public bool IsActive { get; set; }
    }
}
