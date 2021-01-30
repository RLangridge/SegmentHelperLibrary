using System;
using System.Collections.Generic;
using SegmentAPIHelper.Extras;

namespace SegmentAPIHelper.AnalyticsItems
{
    public class GroupItem : AnalyticsItem
    {
        public string groupId;
        public Dictionary<string, object> traits;
        
        public GroupItem(string groupId, string? userId = null, DateTime? timestamp = null, string? anonymousId = null, Dictionary<string, object> context = null,
            Dictionary<string, object> integrations = null, Dictionary<string, object> traits = null) :
            base(userId, timestamp, anonymousId, context, integrations)
        {
            type = SegmentConstants.GROUP_TYPE;
            this.groupId = groupId;
            this.traits = traits;
        }
    }
}