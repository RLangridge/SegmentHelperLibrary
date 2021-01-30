#nullable enable
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SegmentAPIHelper.Extras;

namespace SegmentAPIHelper.AnalyticsItems
{
    [JsonObject]
    public abstract class AnalyticsItem
    {
        public string type;
        public string? userId;
        public string? anonymousId;
        public Dictionary<string, object> context;
        public Dictionary<string, object> integrations;
        public string? timestamp;

        public AnalyticsItem(string? userId = null, DateTime? timestamp = null, string? anonymousId = null,
            Dictionary<string, object> context = null, Dictionary<string, object> integrations = null)
        {
            if (userId == null && anonymousId == null)
                throw new SegmentHelperException(
                    $"You need either anonymous or user id to have a value when creating an identify item.");

            this.userId = userId;
            this.context = context;
            this.integrations = integrations;

            if (timestamp != null)
                this.timestamp = ExtraFuncs.DateToISO8601Format(timestamp);
            
            this.anonymousId = anonymousId;
        }
    }
}