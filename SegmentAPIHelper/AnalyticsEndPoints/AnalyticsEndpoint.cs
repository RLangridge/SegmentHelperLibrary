namespace SegmentAPIHelper.AnalyticsEndPoints
{
    public abstract class AnalyticsEndpoint
    {
        protected string _url;

        public string GetURL() => _url;
    }
}