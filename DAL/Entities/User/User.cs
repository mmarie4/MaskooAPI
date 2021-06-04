using System;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Entities.Diaries;

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

        [Column("password_hash")]
        public string PasswordHash { get; set; }

        [Column("password_salt")]
        public string PasswordSalt { get; set; }

        public Diary Diary { get; set; }

    }
}
