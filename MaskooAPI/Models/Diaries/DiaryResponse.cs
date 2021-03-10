using System;
using System.Collections.Generic;

namespace MaskooAPI.Models.Diaries
{
    public class DiaryResponse : EntityResponse
    {
        public Guid UserId { get; set; }
        public ICollection<DayResponse> Days { get; set; }
    }
}
