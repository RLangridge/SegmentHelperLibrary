using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using SegmentAPIHelper.AnalyticsItems;
using SegmentAPIHelper.SegmentHelperWorkers;

namespace SegmentAPIHelperImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Basics on how to use the api helper
            HttpResponseMessage msg = null;
            
            //todo: insert your segment key here
            BasicSegmentAnalyticsSender sender = new BasicSegmentAnalyticsSender("4H8F7Umac25FLQfpDqWLSbCDvFxfASBj");
            Thread t = new Thread(async () =>
            {
                // Create your analytics item object
                var identifyItem = new IdentifyItem("my_user", DateTime.UtcNow, null, new Dictionary<string, object>
                {
                    {"locale", "en-US"}
                }, new Dictionary<string, object>()
                {
                    {"All", true}
                }, new Dictionary<string, object>
                {
                    {"trait", 1}
                });
                
                //and wait for the send!
                msg = await sender.SendData(identifyItem);
            });
            
            t.Start();
            t.Join();
            Console.ReadLine();
        }
    }
}