using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.DBContexts.SchoolContext
{
    public partial class QueueEmail
    {
        public long Id { get; set; }
        public int? EmailProviderId { get; set; }
        public string MailToEmail { get; set; }
        public string MailToDisplayName { get; set; }
        public int? EmailTemplateId { get; set; }
        public bool IsSent { get; set; }

        public virtual EmailSmstemplate EmailTemplate { get; set; }
    }
}
