﻿using DNELms.Keys;
using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.Model.NoSchoolModels
{
    public partial class Message : BaseEntity
    {
        //public long Id { get; set; }
        public string Mfrom { get; set; }
        public string Mto { get; set; }
        public string Message1 { get; set; }
        public DateTime? CreatedDt { get; set; }
        public string IpAddress { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsRead { get; set; }
    }
}
