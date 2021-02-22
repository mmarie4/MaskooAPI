using System;

namespace MaskooAPI.Models.Diaries
{
    public class DayUpdateRequest
    {
        public DateTime Date { get; set; }
        public string Content { get; set; }
    }
}
