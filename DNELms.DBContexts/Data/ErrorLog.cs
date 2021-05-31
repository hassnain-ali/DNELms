using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.DBContexts.Data
{
    public partial class ErrorLog
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Message { get; set; }
        public string Url { get; set; }
        public DateTime CreateDate { get; set; }
        public string IpAddress { get; set; }
    }
}
