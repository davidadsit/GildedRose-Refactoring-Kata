using Xunit;

namespace csharpcore.Tests
{
    public class UpdateItemTests
    {
        [Fact]
        public void Quality_does_not_go_above_50()
        {
            var item = new Item {Name = ItemNames.Brie, SellIn = 4, Quality = 50};

            var actual = GildedRose.UpdateItem(item);

            Assert.Equal(50, actual.Quality);
        }

        [Fact]
        public void Quality_does_not_go_below_zero()
        {
            var item = new Item {Name = "foo", SellIn = 4, Quality = 0};

            var actual = GildedRose.UpdateItem(item);

            Assert.Equal(0, actual.Quality);
        }

        [Fact]
        public void UpdateItem_increases_the_quality_of_brie()
        {
            var item = new Item {Name = ItemNames.Brie, SellIn = 2, Quality = 6};

            var actual = GildedRose.UpdateItem(item);

            Assert.Equal(7, actual.Quality);
        }

        [Fact]
        public void UpdateItem_increases_the_quality_of_EXPIRED_brie_twice()
        {
            var item = new Item {Name = ItemNames.Brie, SellIn = 0, Quality = 6};

            var actual = GildedRose.UpdateItem(item);

            Assert.Equal(8, actual.Quality);
        }

        [Fact]
        public void UpdateItem_passed_sell_date_loses_Quality_twice_as_fast()
        {
            var item = new Item {Name = "foo", SellIn = 0, Quality = 6};

            var actual = GildedRose.UpdateItem(item);

            Assert.Equal(4, actual.Quality);
        }

        [Fact]
        public void UpdateItem_reduces_SellIn_and_Quality()
        {
            var item = new Item {Name = "foo", SellIn = 4, Quality = 6};

            var actual = GildedRose.UpdateItem(item);

            Assert.Equal(3, actual.SellIn);
            Assert.Equal(5, actual.Quality);
        }
    }
}