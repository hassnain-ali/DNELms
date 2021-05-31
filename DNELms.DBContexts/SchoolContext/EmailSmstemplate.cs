using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.DBContexts.SchoolContext
{
    public partial class EmailSmstemplate
    {
        public EmailSmstemplate()
        {
            QueueEmails = new HashSet<QueueEmail>();
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Cc { get; set; }
        public string Bcc { get; set; }
        public string Subject { get; set; }
        public string MessageBody { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<QueueEmail> QueueEmails { get; set; }
    }
}
