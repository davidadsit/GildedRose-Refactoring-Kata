using System.Collections.Generic;
using ApprovalUtilities.Utilities;

namespace csharpcore
{
    public class GildedRose
    {
        private readonly IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public Item UpdateItem(Item item)
        {
            return item.Name switch
            {
                ItemNames.Sulfuras => new Item {Name = item.Name, SellIn = item.SellIn, Quality = 80},
                ItemNames.Brie => new Item {Name = item.Name, SellIn = item.SellIn - 1, Quality = CalculateNewQualityForBrie(item.Quality, item.SellIn - 1)},
                ItemNames.ConcertPasses => new Item {Name = item.Name, SellIn = item.SellIn - 1, Quality = CalculateNewQualityForConcertPasses(item.Quality, item.SellIn - 1)},
                _ => new Item {Name = item.Name, SellIn = item.SellIn - 1, Quality = CalculateNewQuality(item.Quality, item.SellIn - 1)}
            };
        }

        public void UpdateQuality()
        {
            Items.ForEach(item =>
            {
                var updated = UpdateItem(item);
                item.SellIn = updated.SellIn;
                updated = UpdateConjuredItemQualityAgain(updated);
                item.Quality = updated.Quality;
            });
        }

        private static int CalculateNewQuality(int quality, int sellIn)
        {
            quality--;
            if (sellIn < 0) quality--;
            return EnforceQualityConstraints(quality);
        }

        private static int CalculateNewQualityForBrie(int quality, int sellIn)
        {
            quality++;
            if (sellIn < 0) quality++;
            return EnforceQualityConstraints(quality);
        }

        private static int CalculateNewQualityForConcertPasses(int quality, int sellIn)
        {
            quality++;
            if (sellIn < 10) quality++;
            if (sellIn < 5) quality++;
            if (sellIn < 0) quality = 0;
            return EnforceQualityConstraints(quality);
        }

        private static int EnforceQualityConstraints(int quality)
        {
            return quality switch
            {
                > 50 => 50,
                < 0 => 0,
                _ => quality
            };
        }

        private Item UpdateConjuredItemQualityAgain(Item updated)
        {
            return updated.Name.Contains("Conjured") ? UpdateItem(updated) : updated;
        }
    }
}