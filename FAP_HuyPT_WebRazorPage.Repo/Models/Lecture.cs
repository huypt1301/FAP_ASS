using System;
using System.Collections.Generic;

namespace FAP_HuyPT_WebRazorPage.Repo.Models
{
    public partial class Lecture
    {
        public Lecture()
        {
            Courses = new HashSet<Course>();
        }

        public string LectureId { get; set; } = null!;
        public string? TecherId { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
