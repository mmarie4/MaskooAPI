using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities.Tools
{
    [Table("tools")]
    public class Tool : Entity
    {
        [Column("toolbox_id")]
        [ForeignKey("toolboxes")]
        public Guid ToolboxId { get; set; }

        [Column("label")]
        public string Label { get; set; }

        [Column("value")]
        public string Value { get; set; }
    }
}
