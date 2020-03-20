using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace GildedRose.Tests.ItemTests
{
    public class AgedBrieTests
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
                    Name = "Aged Brie",
                    SellIn = 0,
                    Quality = 5,
                },
                new Item
                {
                    Name = "Aged Brie",
                    SellIn = 40,
                    Quality = 45,
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
        public void AgedBrieShouldGainQualityCorrectly()
        {
            _testItems[0].Should().BeEquivalentTo(
                new Item
                {
                    Name = "Aged Brie",
                    SellIn = -10,
                    Quality = 25,
                });
            _testItems[1].Should().BeEquivalentTo(
                new Item
                {
                    Name = "Aged Brie",
                    SellIn = 30,
                    Quality = 50,
                });
        }
    }
}