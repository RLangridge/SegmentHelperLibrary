using System;
using System.Collections.Generic;
using NUnit.Framework;
using SegmentAPIHelper.AnalyticsItems;
using SegmentAPIHelper.SegmentHelperWorkers;

namespace SegmentAPIHelperTests
{
    public class BasicSegmentAnalyticsSenderTests
    {
        private BasicSegmentAnalyticsSender _passableSender;
        [OneTimeSetUp]
        public void TestSetup()
        {
            //Insert your key here
            _passableSender = new BasicSegmentAnalyticsSender("");
        }

        [Test]
        public void SendIdentifyItem()
        {
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
            Assert.DoesNotThrowAsync(() => _passableSender.SendData(identifyItem));
        }

        [Test]
        public void SendTrackItem()
        {
            var trackItem = new TrackItem("button_pressed", "my_event_user", DateTime.UtcNow, null, new Dictionary<string, object>
            {
                {"active", false}
            }, new Dictionary<string, object>()
            {
                {"All", true}
            }, new Dictionary<string, object>
            {
                {"trait", 1}
            });
            Assert.DoesNotThrowAsync(() => _passableSender.SendData(trackItem)); 
        }
        
        [Test]
        public void SendPageItem()
        {
            var pageItem = new PageItem(null, null,"page_user", DateTime.UtcNow, null, new Dictionary<string, object>
            {
                {"active", false}
            }, new Dictionary<string, object>()
            {
                {"All", true}
            });
            Assert.DoesNotThrowAsync(() => _passableSender.SendData(pageItem)); 
        }
        
        [Test]
        public void SendScreenItem()
        {
            var screenItem = new ScreenItem("intro screen", null,"screen_user", DateTime.UtcNow, null, new Dictionary<string, object>
            {
                {"active", false}
            }, new Dictionary<string, object>()
            {
                {"All", true}
            });
            Assert.DoesNotThrowAsync(() => _passableSender.SendData(screenItem)); 
        }
        
        [Test]
        public void SendGroupItem()
        {
            var groupItem = new GroupItem("test group", "group user", DateTime.UtcNow, null, new Dictionary<string, object>
            {
                {"active", false}
            }, new Dictionary<string, object>()
            {
                {"All", true}
            }, new Dictionary<string, object>
            {
                {"trait", 1}
            });
            Assert.DoesNotThrowAsync(() => _passableSender.SendData(groupItem)); 
        }
        
        [Test]
        public void SendAliasItem()
        {
            var aliasItem = new AliasItem("previous user", "alias user", DateTime.UtcNow, null, new Dictionary<string, object>
            {
                {"active", false}
            }, new Dictionary<string, object>()
            {
                {"All", true}
            });
            Assert.DoesNotThrowAsync(() => _passableSender.SendData(aliasItem)); 
        }

        [Test]
        public void SendBatchItems()
        {
            var itemList = new List<AnalyticsItem>
            {
                new TrackItem("batch_event", "event batch user"),
                new AliasItem("batch alias user", "new batch alias user"),
                new GroupItem("batch group", "batch group user"),
                new IdentifyItem("batch id user"),
                new PageItem("batch page", null, "batch page user"),
                new ScreenItem("batch screen", null, "batch screen user")
            };
            Assert.DoesNotThrowAsync(() => _passableSender.BatchSendData(itemList));
        }
    }
}