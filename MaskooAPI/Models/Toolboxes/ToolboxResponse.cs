using System.Collections.Generic;

namespace MaskooAPI.Models.Toolboxes
{
    public class ToolboxResponse : EntityResponse
    {
        public string Label { get; set; }
        public virtual ICollection<ToolResponse> Tools { get; set; }
    }
}
