using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Entities.Diary;

namespace DAL.Entities.Diaries
{
    [Table("diaries")]
    public class Diary : Entity
    {
        [Column("user_id")]
        public Guid UserId { get; set; }

        public virtual ICollection<Day> Days { get; set; }
    }
}
