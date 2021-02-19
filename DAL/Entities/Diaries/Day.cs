using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities.Diaries
{
    [Table("days")]
    public class Day : Entity
    {
        [Column("date")]
        public DateTime Date { get; set; }

        [Column("content")]
        public string Content { get; set; }

        [Column("diary_id")]
        [ForeignKey("diaries")]
        public Guid DiaryId { get; set; }

    }
}
