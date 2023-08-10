using System;
using System.Collections.Generic;

namespace FAP_HuyPT_WebRazorPage.Repo.Models
{
    public partial class Course
    {
        public string CourseId { get; set; } = null!;
        public string? CourseName { get; set; }
        public string? SubjectId { get; set; }
        public string? StudentId { get; set; }
        public string? LectureId { get; set; }
        public string? SessionId { get; set; }
        public string? TeacherId { get; set; }
        public string? SemesterId { get; set; }

        public virtual Lecture? Lecture { get; set; }
        public virtual Semester? Semester { get; set; }
        public virtual Session? Session { get; set; }
        public virtual Subject? Subject { get; set; }
    }
}
