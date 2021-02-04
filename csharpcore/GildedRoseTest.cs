﻿using System;
using System.Collections.Generic;
using Xunit;

namespace csharpcore
{
    public class GildedRoseTest
    {
        [Fact]
        public void Item_collection_is_retained()
        {
            var items = new List<Item> {new Item {Name = "foo", SellIn = 0, Quality = 0}};

            var app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal("foo", items[0].Name);
        }

        [Fact]
        public void UpdateItem_reduces_SellIn_and_Quality()
        {
            var item = new Item {Name = "foo", SellIn = 4, Quality = 6};

            var app = new GildedRose(Array.Empty<Item>());
            var actual = app.UpdateItem(item);

            Assert.Equal(3, actual.SellIn);
            Assert.Equal(5, actual.Quality);
        }

        [Fact]
        public void Quality_does_not_go_below_zero()
        {
            var item = new Item {Name = "foo", SellIn = 4, Quality = 0};

            var app = new GildedRose(Array.Empty<Item>());
            var actual = app.UpdateItem(item);

            Assert.Equal(0, actual.Quality);
        }

        [Fact]
        public void UpdateItem_passed_sell_date_loses_Quality_twice_as_fast()
        {
            var item = new Item {Name = "foo", SellIn = 0, Quality = 6};

            var app = new GildedRose(Array.Empty<Item>());
            var actual = app.UpdateItem(item);

            Assert.Equal(4, actual.Quality);
        }

        [Fact]
        public void UpdateItem_increases_the_quality_of_brie()
        {
            var item = new Item {Name = ItemNames.Brie, SellIn = 0, Quality = 6};

            var app = new GildedRose(Array.Empty<Item>());
            var actual = app.UpdateItem(item);

            Assert.Equal(7, actual.Quality);
        }
    }
}