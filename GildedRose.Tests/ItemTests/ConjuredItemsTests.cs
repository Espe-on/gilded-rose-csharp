using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace GildedRose.Tests.ItemTests
{
    public class ConjuredItemsTests
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
                    Name = "Conjured Mana Cake",
                    SellIn = 20,
                    Quality = 50,
                },
                new Item
                {
                    Name = "Conjured Mana Cake",
                    SellIn = 0,
                    Quality = 50,
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
        public void ConjuredItemsShouldLoseQualityCorrectlyWhileSellInIsPositive()
        {
            _testItems[0].Should().BeEquivalentTo(
                new Item
                {
                    Name = "Conjured Mana Cake",
                    SellIn = 0,
                    Quality = 30,
                });
        }
        [Test]
        public void ConjuredItemsShouldLoseQualityCorrectlyWhileSellInIsNegative()
        {
            _testItems[1].Should().BeEquivalentTo(
                new Item
                {
                    Name = "Conjured Mana Cake",
                    SellIn = -10,
                    Quality = 10,
                });
        }
    }
}