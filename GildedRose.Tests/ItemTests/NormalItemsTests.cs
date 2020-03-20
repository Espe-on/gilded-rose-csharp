using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace GildedRose.Tests.ItemTests
{
    public class NormalItemsTests
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
                    Name = "+5 Dexterity Vest",
                    SellIn = 20,
                    Quality = 50,
                },
                new Item
                {
                    Name = "Elixir of the Mongoose",
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
        public void NormalItemsShouldLoseQualityCorrectlyWhileSellInIsPositive()
        {
            _testItems[0].Should().BeEquivalentTo(
                new Item
                {
                    Name = "+5 Dexterity Vest",
                    SellIn = 10,
                    Quality = 40,
                });
        }

        [Test]
        public void NormalItemsShouldLoseQualityCorrectlyWhileSellInIsNegative()
        {
            _testItems[1].Should().BeEquivalentTo(
                new Item
                {
                    Name = "Elixir of the Mongoose",
                    SellIn = -10,
                    Quality = 30,
                });
        }
    }
}