using System.Collections.Generic;
using Xunit;

namespace csharpcore
{
    public class GildedRoseTest
    {
        [Fact]
        public void foo()
        {
            var items = new List<Item>
            {
                new Item {Name = "foo", SellIn = 0, Quality = 0}
            };
            
            var app = new GildedRose(items);
            app.UpdateQuality();
            
            Assert.Equal("foo", items[0].Name);
        }
    }
}