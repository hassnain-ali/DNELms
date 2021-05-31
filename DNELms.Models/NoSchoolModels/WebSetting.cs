using DNELms.Keys;
using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.Model.NoSchoolModels
{
    public partial class WebSettings : BaseEntity
    {
        //public byte Id { get; set; }
        public string WebName { get; set; }
        public string WebKeywords { get; set; }
        public string WebDesc { get; set; }
        public string Author { get; set; }
        public string Slogan { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNo { get; set; }
        public string YoutubeApiKey { get; set; }
        public string VimeoApiKey { get; set; }
        public string FooterText { get; set; }
        public string FooterLink { get; set; }
        public string LightLogo { get; set; }
        public string DarkLogo { get; set; }
        public string RecapchaSiteKey { get; set; }
        public string RecapchaSecretKey { get; set; }
        public bool CookieStatus { get; set; }
        public string CookieNote { get; set; }
        public string AboutUs { get; set; }
        public string CookiePolicy { get; set; }
        public string TermAndCondition { get; set; }
        public string PrivacyPolicy { get; set; }
    }
}
