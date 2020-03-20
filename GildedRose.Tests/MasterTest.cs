using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace GildedRose.Tests
{
    public class MasterTest
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
                    SellIn = 10,
                    Quality = 20,
                },
                new Item
                {
                    Name = "Aged Brie", 
                    SellIn = 2, 
                    Quality = 0,
                },
                new Item
                {
                    Name = "Elixir of the Mongoose", 
                    SellIn = 5, 
                    Quality = 7,
                },
                new Item
                {
                    Name = "Sulfuras, Hand of Ragnaros", 
                    SellIn = 0, 
                    Quality = 80,
                },
                new Item
                {
                    Name = "Sulfuras, Hand of Ragnaros", 
                    SellIn = -1, 
                    Quality = 80,
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20,
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49,
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49,
                },
            };
            
            _gildedRose = new GildedRose(_testItems);
        }

        [Test]
        public void ItemValuesShouldBeCorrectAfter6Days()
        {
            const int numberOfDays = 6;
            for (var i = 0; i < numberOfDays; i++)
            {
                _gildedRose.UpdateQuality();
            }
            
            //test item list   
            _testItems[0].Should().BeEquivalentTo(new Item
            {
                Name = "+5 Dexterity Vest", 
                SellIn = 4, 
                Quality = 14,
            });
            _testItems[1].Should().BeEquivalentTo(new Item
            {
                Name = "Aged Brie", 
                SellIn = -4, 
                Quality = 10,
            });
            _testItems[2].Should().BeEquivalentTo(new Item
            {
                Name = "Elixir of the Mongoose", 
                SellIn = -1, 
                Quality = 0,
            });
            _testItems[3].Should().BeEquivalentTo(new Item
            {
                Name = "Sulfuras, Hand of Ragnaros", 
                SellIn = 0, 
                Quality = 80,
            });
            _testItems[4].Should().BeEquivalentTo(new Item
            {
                Name = "Sulfuras, Hand of Ragnaros", 
                SellIn = -1, 
                Quality = 80,
            });
            _testItems[5].Should().BeEquivalentTo(new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 9,
                Quality = 27,
            });
            _testItems[6].Should().BeEquivalentTo(new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 4,
                Quality = 50,
            });
            _testItems[7].Should().BeEquivalentTo(new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = -1,
                Quality = 0,
            });
            
        }
    }
} 