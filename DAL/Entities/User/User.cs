using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities.User
{
    [Table("users")]
    public class User : Entity
    {

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("email")]
        public string Email { get; set; }

    }
}
