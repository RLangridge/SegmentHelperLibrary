using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SegmentAPIHelper.AnalyticsEndPoints;
using SegmentAPIHelper.AnalyticsItems;
using SegmentAPIHelper.Extras;

namespace SegmentAPIHelper.SegmentHelperWorkers
{
    public class BasicSegmentAnalyticsSender : AnalyticsSender
    {
        private SegmentEndpoint _endpoint = new SegmentEndpoint();
        
        public BasicSegmentAnalyticsSender(string writeKey) : base(writeKey)
        {
        }
        
        /// <summary>
        /// Send through an analytics item over to segment
        /// </summary>
        /// <param name="analyticsItem">An analytics object that determines what type of data you're sending</param>
        /// <returns>HttpResponseMessage based on how the transaction went</returns>
        public override async Task<HttpResponseMessage> SendData(AnalyticsItem analyticsItem)
        {
            var json = ConvertAnalyticsItemToJson(analyticsItem);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using var client = new HttpClient();
            var encoded = CreateEncodedWriteKey();
            client.DefaultRequestHeaders.Add("Authorization", $"Basic {encoded}");
            return await client.PostAsync($"{_endpoint.GetURL()}{analyticsItem.type}", content);
        }

        /// <summary>
        /// Encodes the segment key so that it can be used for sending data off to segment
        /// </summary>
        /// <returns>The converted key</returns>
        private string CreateEncodedWriteKey()
        {
            var plainTextBytes = Encoding.UTF8.GetBytes($"{_writeKey}:");
            var encoded = Convert.ToBase64String(plainTextBytes);
            return encoded;
        }

        /// <summary>
        /// Converts the analytics item into a json string. Checks the size of the content being passed.
        /// </summary>
        /// <param name="analyticsItem">The item being sent to segment</param>
        /// <returns>A string conversion of the analytics item</returns>
        /// <exception cref="SegmentHelperException">Thrown if the size of the content is larger than 32kb (based on segment requirements)</exception>
        private string ConvertAnalyticsItemToJson(AnalyticsItem analyticsItem)
        {
            var json = JsonConvert.SerializeObject(analyticsItem, Formatting.None, _jsonSerializerSettings);
            var contentSize = json.Length * sizeof(Char);

            if (contentSize >= SegmentConstants.MAX_SEND_SIZE_IN_BYTES)
                throw new SegmentHelperException(
                    $"Analytics item {analyticsItem} was too large to send (Content: {contentSize}, Max: {SegmentConstants.MAX_SEND_SIZE_IN_BYTES}.)" +
                    $"Consider splitting the data into multiple objects and sending them through a batch call.");
            return json;
        }

        /// <summary>
        /// Send multiple items in a batch over to segment
        /// </summary>
        /// <param name="analyticsItems">A set of analytics items to send over</param>
        /// <returns>An http response based on how the transaction went</returns>
        /// <exception cref="SegmentHelperException">Thrown if the data is too large for the batch (500kb per batch, 32kb per item)</exception>
        public override async Task<HttpResponseMessage> BatchSendData(List<AnalyticsItem> analyticsItems)
        {
            var batch = new AnalyticsItemBatch(analyticsItems);
            var json = JsonConvert.SerializeObject(batch, Formatting.None, _jsonSerializerSettings);
            var contentSize = json.Length * sizeof(Char);

            if (contentSize >= SegmentConstants.MAX_BATCH_SEND_SIZE_IN_BYTES)
                throw new SegmentHelperException(
                    $"Batch list {analyticsItems} was too large to send (Content: {contentSize}, Max: {SegmentConstants.MAX_BATCH_SEND_SIZE_IN_BYTES}.)" +
                    $"Please reduce the amount of data being sent through the batch call.");

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using var client = new HttpClient();
            var encoded = CreateEncodedWriteKey();
            client.DefaultRequestHeaders.Add("Authorization", $"Basic {encoded}");
            return await client.PostAsync($"{_endpoint.GetURL()}{SegmentConstants.BATCH_TYPE}", content);
        }

        private class AnalyticsItemBatch
        {
            public List<AnalyticsItem> batch;

            public AnalyticsItemBatch(List<AnalyticsItem> batch)
            {
                this.batch = batch;
            }
        }
    }
}