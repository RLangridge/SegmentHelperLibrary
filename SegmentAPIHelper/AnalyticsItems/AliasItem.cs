using System;
using System.Collections.Generic;
using SegmentAPIHelper.Extras;

namespace SegmentAPIHelper.AnalyticsItems
{
    public class AliasItem : AnalyticsItem
    {
        public string previousId;

        public AliasItem(string previousId, string? userId = null, DateTime? timestamp = null, string? anonymousId = null, Dictionary<string, object> context = null,
            Dictionary<string, object> integrations = null) :
            base(userId, timestamp, anonymousId, context, integrations)
        {
            type = SegmentConstants.ALIAS_TYPE;
            this.previousId = previousId;
        }
    }
}