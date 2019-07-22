namespace Freshdesk
{
    public struct RateLimit
    {
        public int Total;
        public int Remaining;
        public int Used;
        public int RetryAfter;
    }
}
