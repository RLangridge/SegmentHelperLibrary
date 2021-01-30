using System;
using NUnit.Framework;
using SegmentAPIHelper.AnalyticsItems;
using SegmentAPIHelper.Extras;
using SegmentAPIHelper.SegmentHelperWorkers;

namespace SegmentAPIHelperTests
{
    public class IdentifyItemsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateNewIdentifyItem()
        {
            var passableIdentifyItem = new IdentifyItem("user");
        }

        [Test]
        public void BreakIfNeitherAnonymousOrUserIdArentPassedIn()
        {
            Assert.Throws<SegmentHelperException>(() => new IdentifyItem(null, null, null));
        }
    }
}