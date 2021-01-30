using System;
using System.Collections.Generic;
using SegmentAPIHelper.Extras;

#nullable enable
namespace SegmentAPIHelper.AnalyticsItems
{
    public class IdentifyItem : AnalyticsItem
    {
        public Dictionary<string, object> traits = null;

        public IdentifyItem(string? userId = null, DateTime? timestamp = null, string? anonymousId = null, Dictionary<string, object> context = null,
            Dictionary<string, object> integrations = null, Dictionary<string, object> traits = null) :
            base(userId, timestamp, anonymousId, context, integrations)
        {
            this.type = SegmentConstants.IDENTIFY_TYPE;
            this.traits = traits;
        }
    }

    
}