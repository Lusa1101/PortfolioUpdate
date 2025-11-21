namespace Portfolio.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

    public class SupabaseSettings
    {
        public string? BaseUrl { get; set; }
        public string? ApiKey { get; set; }
    }
}
