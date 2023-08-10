using System;
using System.Collections.Generic;

namespace FAP_HuyPT_WebRazorPage.Repo.Models
{
    public partial class Student
    {
        public string StudentId { get; set; } = null!;
        public string? StudentName { get; set; }
        public decimal? Phone { get; set; }
        public string? Email { get; set; }
    }
}
