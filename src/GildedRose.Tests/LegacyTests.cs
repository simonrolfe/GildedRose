using GildedRose.Console;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GildedRose.Tests
{
    //Tests to ensure my understanding of the existing logic is correct.
    public class LegacyTests
    {
        [Fact]
        public void DexterityVest_Degrades_1_Per_Day()
        {
            Program p = new Program();

            Item item = new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 };

            p.Items = new List<Item> { item };

            p.UpdateQuality();

            Assert.Equal(item.Quality, 19);
            Assert.Equal(item.SellIn, 9);

            p.UpdateQuality();
            Assert.Equal(item.Quality, 18);
            Assert.Equal(item.SellIn, 8);
        }

        [Fact]
        public void Elixir_Degrades_1_Per_Day()
        {
            Program p = new Program();

            Item item = new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 };

            p.Items = new List<Item> { item };

            p.UpdateQuality();

            Assert.Equal(item.Quality, 6);
            Assert.Equal(item.SellIn, 4);

            p.UpdateQuality();
            Assert.Equal(item.Quality, 5);
            Assert.Equal(item.SellIn, 3);
        }

        [Fact]
        public void Sulfuras_Does_Not_Degrade()
        {
            Program p = new Program();

            Item item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 };

            p.Items = new List<Item> { item };

            p.UpdateQuality();

            Assert.Equal(item.Quality, 80);
            Assert.Equal(item.SellIn, 0);

            p.UpdateQuality();
            Assert.Equal(item.Quality, 80);
            Assert.Equal(item.SellIn, 0);
        }

        [Fact]
        public void Aged_Brie_Improves()
        {
            Program p = new Program();

            Item item = new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 };

            p.Items = new List<Item> { item };

            p.UpdateQuality();

            Assert.Equal(item.Quality, 1);
            Assert.Equal(item.SellIn, 1);

            p.UpdateQuality();
            Assert.Equal(item.Quality, 2);
            Assert.Equal(item.SellIn, 0);

            //Extra test to confirm that brie double-improves after SellIn is 0
            p.UpdateQuality();
            Assert.Equal(item.Quality, 4);
            Assert.Equal(item.SellIn, -1);

        }

        [Fact]
        public void Conjured_Mana_Cake_Degrades_Normal_Speed_Legacy()
        {
            Program p = new Program();

            Item item = new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 };

            p.Items = new List<Item> { item };

            p.UpdateQuality();

            Assert.Equal(item.Quality, 5);
            Assert.Equal(item.SellIn, 2);

            p.UpdateQuality();
            Assert.Equal(item.Quality, 4);
            Assert.Equal(item.SellIn, 1);

            p.UpdateQuality();
            Assert.Equal(item.Quality, 3);
            Assert.Equal(item.SellIn, 0);
        }


    }
}
