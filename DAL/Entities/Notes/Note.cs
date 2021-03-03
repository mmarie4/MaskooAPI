using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities.Notes
{
    [Table("notes")]
    public class Note : Entity
    {
        [Column("user_id")]
        public Guid UserId { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("content")]
        public string Content { get; set; }
    }
}
