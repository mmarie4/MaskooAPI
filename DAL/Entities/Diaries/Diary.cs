using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities.Diaries
{
    [Table("diaries")]
    public class Diary : Entity
    {
        [Column("user_id")]
        [ForeignKey("users")]
        public Guid UserId { get; set; }

        public virtual ICollection<Day> Days { get; set; }

    }
}
