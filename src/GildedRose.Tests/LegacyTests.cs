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

            Assert.Equal(19, item.Quality);
            Assert.Equal(9, item.SellIn);

            p.UpdateQuality();
            Assert.Equal(18, item.Quality);
            Assert.Equal(8, item.SellIn);
        }

        [Fact]
        public void Elixir_Degrades_1_Per_Day()
        {
            Program p = new Program();

            Item item = new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 };

            p.Items = new List<Item> { item };

            p.UpdateQuality();

            Assert.Equal(6, item.Quality);
            Assert.Equal(4, item.SellIn);

            p.UpdateQuality();
            Assert.Equal(5, item.Quality);
            Assert.Equal(3, item.SellIn);
        }

        [Fact]
        public void Sulfuras_Does_Not_Degrade()
        {
            Program p = new Program();

            Item item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 };

            p.Items = new List<Item> { item };

            p.UpdateQuality();

            Assert.Equal(80, item.Quality);
            Assert.Equal(0, item.SellIn);

            p.UpdateQuality();
            Assert.Equal(80, item.Quality);
            Assert.Equal(0, item.SellIn);
        }

        [Fact]
        public void Aged_Brie_Improves()
        {
            Program p = new Program();

            Item item = new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 };

            p.Items = new List<Item> { item };

            p.UpdateQuality();

            Assert.Equal(1, item.Quality);
            Assert.Equal(1, item.SellIn);

            p.UpdateQuality();
            Assert.Equal(2, item.Quality);
            Assert.Equal(0, item.SellIn);

            //Extra test to confirm that brie double-improves after SellIn is 0
            p.UpdateQuality();
            Assert.Equal(4, item.Quality);
            Assert.Equal(-1, item.SellIn);

        }

        [Fact]
        public void Conjured_Mana_Cake_Degrades_Normal_Speed_Legacy()
        {
            Program p = new Program();

            Item item = new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 };

            p.Items = new List<Item> { item };

            p.UpdateQuality();

            Assert.Equal(5, item.Quality);
            Assert.Equal(2, item.SellIn);

            p.UpdateQuality();
            Assert.Equal(4, item.Quality);
            Assert.Equal(1, item.SellIn);

            p.UpdateQuality();
            Assert.Equal(3, item.Quality);
            Assert.Equal(0, item.SellIn);
        }

        [Fact]
        public void Backstage_Passes_Improve()
        {
            Program p = new Program();

            Item item = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 15,
                Quality = 20
            };

            p.Items = new List<Item> { item };

            p.UpdateQuality();

            Assert.Equal(21, item.Quality);
            Assert.Equal(14, item.SellIn);

            p.UpdateQuality();
            Assert.Equal(22, item.Quality);
            Assert.Equal(13, item.SellIn);

            p.UpdateQuality();
            p.UpdateQuality();
            p.UpdateQuality();
            Assert.Equal(25, item.Quality);
            Assert.Equal(10, item.SellIn);

            //at this point we expect the quality to increase by 2 per day
            p.UpdateQuality();
            Assert.Equal(27, item.Quality);
            Assert.Equal(9, item.SellIn);

            p.UpdateQuality();
            Assert.Equal(29, item.Quality);
            Assert.Equal(8, item.SellIn);

            p.UpdateQuality();
            p.UpdateQuality();
            p.UpdateQuality();

            Assert.Equal(35, item.Quality);
            Assert.Equal(5, item.SellIn);

            //at this point we expect quality to increase by 3 per day
            p.UpdateQuality();

            Assert.Equal(38, item.Quality);
            Assert.Equal(4, item.SellIn);

            p.UpdateQuality();

            Assert.Equal(41, item.Quality);
            Assert.Equal(3, item.SellIn);

            p.UpdateQuality();
            p.UpdateQuality();
            p.UpdateQuality();
            Assert.Equal(50, item.Quality);
            Assert.Equal(0, item.SellIn);

            //Quality drops to 0 after SellIn is <0
            p.UpdateQuality();
            Assert.Equal(0, item.Quality);
            Assert.Equal(-1, item.SellIn);
        }
    }
}
