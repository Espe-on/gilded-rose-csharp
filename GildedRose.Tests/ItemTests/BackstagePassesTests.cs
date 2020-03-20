using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace GildedRose.Tests.ItemTests
{
    public class BackstagePassesTests
    {
        private List<Item> _testItems;
        private GildedRose _gildedRose;

        [SetUp]
        public void Setup()
        {
            _testItems = new List<Item>
            {
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 20,
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 20,
                }
            };
            _gildedRose = new GildedRose(_testItems);
            const int numberOfDays = 10;
            for (var i = 0; i < numberOfDays; i++)
            {
                _gildedRose.UpdateQuality();
            }
        }

        [Test]
        public void BackstagePassesShouldGainQualityCorrectly()
        {
            _testItems[0].Should().BeEquivalentTo(
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 0,
                    Quality = 45,
                });
        }
        [Test]
        public void BackstagePassesShouldLoseQualityCorrectly()
        {
            _testItems[1].Should().BeEquivalentTo(
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = -5,
                    Quality = 0,
                });
        }
    }
}