using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace GildedRose.Tests.ItemTests
{
    public class LegendaryItemsTests
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
                    Name = "Sulfuras, Hand of Ragnaros",
                    SellIn = 1000,
                    Quality = 80,
                },
                new Item
                {
                    Name = "Sulfuras, Hand of Ragnaros",
                    SellIn = 10,
                    Quality = 80,
                },
            };
            _gildedRose = new GildedRose(_testItems);
            const int numberOfDays = 100;
            for (var i = 0; i < numberOfDays; i++)
            {
                _gildedRose.UpdateQuality();
            }
        }

        [Test]
        public void LegendaryItemsNeverLoseQualityOrSellIn()
        {
            _testItems[0].Should().BeEquivalentTo(
                new Item
                {
                    Name = "Sulfuras, Hand of Ragnaros",
                    SellIn = 1000,
                    Quality = 80,
                });
            _testItems[1].Should().BeEquivalentTo(
                new Item
                {
                    Name = "Sulfuras, Hand of Ragnaros",
                    SellIn = 10,
                    Quality = 80,
                });
        }
    }
}