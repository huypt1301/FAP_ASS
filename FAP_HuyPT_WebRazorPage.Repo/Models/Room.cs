using System;
using System.Collections.Generic;

namespace FAP_HuyPT_WebRazorPage.Repo.Models
{
    public partial class Room
    {
        public string RoomId { get; set; } = null!;
        public string? SessionId { get; set; }

        public virtual Session? Session { get; set; }
    }
}
