using System;
using System.Collections.Generic;

namespace csharpcore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            var items = new List<Item>
            {
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = ItemNames.Brie, SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = ItemNames.Sulfuras, SellIn = 0, Quality = 80},
                new Item {Name = ItemNames.Sulfuras, SellIn = -1, Quality = 80},
                new Item {Name = ItemNames.ConcertPasses, SellIn = 15, Quality = 20},
                new Item {Name = ItemNames.ConcertPasses, SellIn = 10, Quality = 49},
                new Item {Name = ItemNames.ConcertPasses, SellIn = 5, Quality = 49},
                // this conjured item does not work properly yet
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };

            var app = new GildedRose(items);

            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine($"-------- day {i} --------");
                Console.WriteLine("name, sellIn, quality");
                foreach (var item in items)
                {
                    Console.WriteLine($"{item.Name}, {item.SellIn}, {item.Quality}");
                }

                Console.WriteLine("");
                app.UpdateQuality();
            }
        }
    }
}