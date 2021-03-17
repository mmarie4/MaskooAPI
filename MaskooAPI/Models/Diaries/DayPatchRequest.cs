using System;

namespace MaskooAPI.Models.Diaries
{
    public class DayPatchRequest
    {
        public DateTime Date { get; set; }
        public string Content { get; set; }
    }
}
