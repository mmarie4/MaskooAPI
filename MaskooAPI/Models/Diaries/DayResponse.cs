﻿using System;
namespace MaskooAPI.Models.Diaries
{
    public class DayResponse : EntityResponse
    {

        public DateTime Date { get; set; }

        public string Content { get; set; }
    }
}
