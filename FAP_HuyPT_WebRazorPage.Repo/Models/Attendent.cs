using System;
using System.Collections.Generic;

namespace FAP_HuyPT_WebRazorPage.Repo.Models
{
    public partial class Attendent
    {
        public string? StudentId { get; set; }
        public string? RoomId { get; set; }
        public TimeSpan? TimeStart { get; set; }
        public TimeSpan? TimeEnd { get; set; }
        public string? TeacherId { get; set; }

        public virtual Student? Student { get; set; }
    }
}
