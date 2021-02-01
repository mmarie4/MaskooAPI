using System;
using System.Collections.Generic;

namespace MaskooAPI.Models.Diaries
{
    public class DiaryResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public ICollection<DayResponse> Days { get; set; }
    }
}
