namespace Akelny.Helper
{
    public class JWT
    {
        public string Secret { get; set; }
        public TimeSpan ExpireTimeFrame { get; set; }
    }
}
