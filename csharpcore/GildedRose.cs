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
            var quality = item.Quality;
            var sellIn = item.SellIn - 1;

            return item.Name switch
            {
                ItemNames.Sulfuras => new Item {Name = item.Name, Quality = 80, SellIn = item.SellIn},
                ItemNames.Brie => new Item {Name = item.Name, Quality = CalculateNewQualityForBrie(quality, sellIn), SellIn = sellIn},
                ItemNames.ConcertPasses => new Item {Name = item.Name, Quality = CalculateNewQualityForConcertPasses(quality, sellIn), SellIn = sellIn},
                _ => new Item {Name = item.Name, Quality = CalculateNewQuality(quality, sellIn), SellIn = sellIn}
            };
        }

        public void UpdateQuality()
        {
            Items.ForEach(item =>
            {
                var updated = UpdateItem(item);
                item.SellIn = updated.SellIn;

                if (item.Name.Contains("Conjured"))
                {
                    updated = UpdateItem(updated);
                }

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
    }
}