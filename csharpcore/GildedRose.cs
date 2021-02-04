using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRose
    {
        private readonly IList<Item> items;

        public GildedRose(IList<Item> items)
        {
            this.items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in items)
            {
                if (item.Name == Items.Brie)
                {
                    if (item.Quality < 50)
                    {
                        item.Quality += 1;
                    }
                }
                else if (item.Name == Items.ConcertPasses)
                {
                    if (item.Quality < 50)
                    {
                        item.Quality += 1;

                        if (item.SellIn < 11 && item.Quality < 50)
                        {
                            item.Quality += 1;
                        }

                        if (item.SellIn < 6 && item.Quality < 50)
                        {
                            item.Quality += 1;
                        }
                    }
                }
                else
                {
                    if (item.Quality > 0 && item.Name != Items.Sulfuras)
                    {
                        item.Quality -= 1;
                    }
                }

                if (item.Name != Items.Sulfuras)
                {
                    item.SellIn -= 1;
                }

                if (item.SellIn < 0)
                {
                    if (item.Name == Items.Brie)
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality += 1;
                        }
                    }
                    else
                    {
                        if (item.Name == Items.ConcertPasses)
                        {
                            item.Quality -= item.Quality;
                        }
                        else
                        {
                            if (item.Name == Items.Sulfuras)
                            {
                            }
                            else
                            {
                                if (item.Quality > 0)
                                {
                                    item.Quality -= 1;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}