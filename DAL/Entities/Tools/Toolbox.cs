using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities.Tools
{
    [Table("toolboxes")]
    public class Toolbox : Entity
    {
        [Column("user_id")]
        public Guid UserId { get; set; }

        [Column("label")]
        public string Label { get; set; }


        public virtual ICollection<Tool> Tools { get; set; }
    }
}
