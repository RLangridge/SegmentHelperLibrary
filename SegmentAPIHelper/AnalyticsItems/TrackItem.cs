using System;
using System.Collections.Generic;
using SegmentAPIHelper.Extras;

namespace SegmentAPIHelper.AnalyticsItems
{
    public class TrackItem : AnalyticsItem
    {
        public string @event;
        public Dictionary<string, object> properties;

        public TrackItem(string @event, string? userId = null, DateTime? timestamp = null, string? anonymousId = null, Dictionary<string, object> context = null,
            Dictionary<string, object> integrations = null, Dictionary<string, object> properties = null) :
            base(userId, timestamp, anonymousId, context, integrations)
        {
            type = SegmentConstants.TRACK_TYPE;
            this.@event = @event;
            this.properties = properties;
        }
    }
}