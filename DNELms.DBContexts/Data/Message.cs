using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.DBContexts.Data
{
    public partial class Message
    {
        public long Id { get; set; }
        public string Mfrom { get; set; }
        public string Mto { get; set; }
        public string Message1 { get; set; }
        public DateTime? CreatedDt { get; set; }
        public string IpAddress { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsRead { get; set; }
    }
}
