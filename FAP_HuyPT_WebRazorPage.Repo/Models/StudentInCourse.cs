using System;
using System.Collections.Generic;

namespace FAP_HuyPT_WebRazorPage.Repo.Models
{
    public partial class StudentInCourse
    {
        public string? CourseId { get; set; }
        public string StudentId { get; set; } = null!;
        public string? RoomId { get; set; }

        public virtual Course? Course { get; set; }
        public virtual Student Student { get; set; } = null!;
    }
}
