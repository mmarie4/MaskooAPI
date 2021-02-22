using System;
namespace MaskooAPI.Models
{
    public class EntityResponse
    {
        public Guid Id { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid UpdatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
