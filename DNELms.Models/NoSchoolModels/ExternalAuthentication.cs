using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.Model.NoSchoolModels
{
    public partial class ExternalAuthentication
    {
        public int Id { get; set; }
        public bool FacebookExternalAuthIsActive { get; set; }
        public string FacebookAuthKey { get; set; }
        public string FacebookAppId { get; set; }
        public bool GoogleSigninIsActive { get; set; }
        public string GoogleSecret { get; set; }
        public string GoogleKey { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
