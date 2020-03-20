﻿using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace GildedRose.Tests
{
    public class GildedRoseTests
    {
        [Test]
        public void RegularItemsDecreaseTheirSellInValueByOneEachDay()
        {
            var item = new Item { Name = "Test Item", Quality = 10, SellIn = 5};
            var gildedRose = new GildedRose(new List<Item> { item });
            
            gildedRose.UpdateQuality();

            item.SellIn.Should().Be(4);
        }

        [Test]
        public void SulfurasNeverDecreaseTheirSellInValue()
        {
            var item = new Item { Name = "Sulfuras, Hand of Ragnaros", Quality = 10, SellIn = 5};
            var gildedRose = new GildedRose(new List<Item> { item });
            
            gildedRose.UpdateQuality();

            item.SellIn.Should().Be(5);
        }

        [Test]
        public void RegularItemsDecreaseInQualityByOneEachDay()
        {
            var item = new Item { Name = "Test Item", Quality = 10, SellIn = 5};
            var gildedRose = new GildedRose(new List<Item> { item });
            
            gildedRose.UpdateQuality();

            item.Quality.Should().Be(9);
        }
        
        [Test]
        public void RegularItemsDoNotDecreaseTheirValueBelowZero()
        {
            var item = new Item { Name = "Test Item", Quality = 0, SellIn = 5};
            var gildedRose = new GildedRose(new List<Item> { item });
            
            gildedRose.UpdateQuality();

            item.Quality.Should().Be(0);
        }
        
        [Test]
        public void AgedBrieIncreasesInQualityByOneEachDay()
        {
            var item = new Item { Name = "Aged Brie", Quality = 10, SellIn = 5};
            var gildedRose = new GildedRose(new List<Item> { item });
            
            gildedRose.UpdateQuality();

            item.Quality.Should().Be(11);
        }
        
        [Test]
        public void AgedBrieCannotIncreaseInValueAbove50()
        {
            var item = new Item { Name = "Aged Brie", Quality = 50, SellIn = 5};
            var gildedRose = new GildedRose(new List<Item> { item });
            
            gildedRose.UpdateQuality();

            item.Quality.Should().Be(50);
        }
    }
}