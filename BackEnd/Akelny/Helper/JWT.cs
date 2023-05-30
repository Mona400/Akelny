namespace Akelny.Helper
{
    public class JWT
    {
        public string Secret { get; set; } = string.Empty;
        public TimeSpan ExpireTimeFrame { get; set; }
    }
}
