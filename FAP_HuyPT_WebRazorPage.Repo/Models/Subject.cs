using System;
using System.Collections.Generic;

namespace FAP_HuyPT_WebRazorPage.Repo.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Courses = new HashSet<Course>();
        }

        public string SubjectId { get; set; } = null!;
        public string? SubjectName { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
