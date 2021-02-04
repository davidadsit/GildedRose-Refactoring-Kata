using System.Collections.Generic;
using Xunit;

namespace csharpcore.Tests
{
    public class UpdateQualityTests
    {
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
        public void Item_collection_is_retained()
        {
            var items = new List<Item> {new Item {Name = "foo", SellIn = 0, Quality = 0}};

            var app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal("foo", items[0].Name);
        }
    }
}