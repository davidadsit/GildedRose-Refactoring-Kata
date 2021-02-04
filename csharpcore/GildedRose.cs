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

            switch (item.Name)
            {
                case ItemNames.Sulfuras:
                    return new Item {Name = ItemNames.Sulfuras, Quality = 80, SellIn = item.SellIn};
                case ItemNames.Brie:
                    quality++;
                    if (sellIn < 0)
                    {
                        quality++;
                    }

                    break;
                case ItemNames.ConcertPasses:
                {
                    quality++;
                    if (sellIn < 10) quality++;
                    if (sellIn < 5) quality++;
                    if (sellIn < 0) quality = 0;
                    break;
                }
                default:
                {
                    quality--;
                    if (sellIn < 0)
                    {
                        quality--;
                    }

                    break;
                }
            }

            if (quality < 0)
            {
                quality = 0;
            }

            if (quality > 50)
            {
                quality = 50;
            }

            return new Item {Name = item.Name, Quality = quality, SellIn = sellIn};
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
    }
}