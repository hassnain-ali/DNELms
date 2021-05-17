namespace DNELms.Model
{
    public record ExternalAuth
    {
        public bool GoogleEnabled { get; set; }
        public string GoogleClientId { get; set; }
        public string GoogleClientSecret { get; set; }
        public bool FaceBookEnabled { get; set; }
        public string FaceBookAppId { get; set; }
        public string FaceBookAppSecret { get; set; }
    }
}
