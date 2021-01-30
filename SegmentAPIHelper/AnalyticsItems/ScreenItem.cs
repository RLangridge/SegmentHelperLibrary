using System;
using System.Collections.Generic;
using SegmentAPIHelper.Extras;

namespace SegmentAPIHelper.AnalyticsItems
{
    public class ScreenItem : AnalyticsItem
    {
        public Dictionary<string, object> properties;
        public string name;
        
        public ScreenItem(string? name = null, Dictionary<string, object> properties = null, string? userId = null, DateTime? timestamp = null, string? anonymousId = null,
            Dictionary<string, object> context = null, Dictionary<string, object> integrations = null) :
            base(userId, timestamp, anonymousId, context, integrations)
        {
            this.type = SegmentConstants.SCREEN_TYPE;
            this.name = name;
            this.properties = properties;
        }
    }
}