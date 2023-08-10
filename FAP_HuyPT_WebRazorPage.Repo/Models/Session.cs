using System;
using System.Collections.Generic;

namespace FAP_HuyPT_WebRazorPage.Repo.Models
{
    public partial class Session
    {
        public Session()
        {
            Courses = new HashSet<Course>();
            Rooms = new HashSet<Room>();
        }

        public string SessionId { get; set; } = null!;
        public string? TeacherId { get; set; }
        public string? SessionName { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
