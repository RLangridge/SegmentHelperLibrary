using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SegmentAPIHelper.AnalyticsItems;

namespace SegmentAPIHelper
{
    public abstract class AnalyticsSender
    {
        protected string _writeKey = "";
        protected JsonSerializerSettings _jsonSerializerSettings;
        
        public AnalyticsSender(string writeKey)
        {
            _writeKey = writeKey;
            _jsonSerializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore,
            };
        }
        
        public abstract Task<HttpResponseMessage> SendData(AnalyticsItem analyticsItem);
        public abstract Task<HttpResponseMessage> BatchSendData(List<AnalyticsItem> analyticsItems);
    }
}