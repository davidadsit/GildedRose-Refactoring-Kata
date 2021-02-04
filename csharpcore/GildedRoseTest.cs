using System;
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
        public void Conjured_items_change_quality_twice_as_fast()
        {
            var items = new List<Item> {new Item {Name = "Conjured foo", SellIn = 5, Quality = 8}};

            var app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(4, items[0].SellIn);
            Assert.Equal(6, items[0].Quality);
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
        public void Quality_does_not_go_above_50()
        {
            var item = new Item {Name = ItemNames.Brie, SellIn = 4, Quality = 50};

            var app = new GildedRose(Array.Empty<Item>());
            var actual = app.UpdateItem(item);

            Assert.Equal(50, actual.Quality);
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
            var item = new Item {Name = ItemNames.Brie, SellIn = 2, Quality = 6};

            var app = new GildedRose(Array.Empty<Item>());
            var actual = app.UpdateItem(item);

            Assert.Equal(7, actual.Quality);
        }

        [Fact]
        public void UpdateItem_increases_the_quality_of_EXPIRED_brie_twice()
        {
            var item = new Item {Name = ItemNames.Brie, SellIn = 0, Quality = 6};

            var app = new GildedRose(Array.Empty<Item>());
            var actual = app.UpdateItem(item);

            Assert.Equal(8, actual.Quality);
        }
    }
}