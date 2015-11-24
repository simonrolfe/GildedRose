using GildedRose.Console;
using GildedRose.Console.Items;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.Tests
{
    //Tests to ensure my understanding of the existing logic is correct.
    public class ItemTests
    {
        [Fact]
        public void DexterityVest_Degrades_1_Per_Day()
        {
            AbstractItem item= new DexterityVest();

            item.ProcessDay();

            Assert.Equal(19, item.Quality);
            Assert.Equal(9, item.SellIn);

            item.ProcessDay();
            Assert.Equal(18, item.Quality);
            Assert.Equal(8, item.SellIn);
        }

        [Fact]
        public void Elixir_Degrades_1_Per_Day()
        {
            AbstractItem item = new Elixir();

            item.ProcessDay();

            Assert.Equal(6, item.Quality);
            Assert.Equal(4, item.SellIn);

            item.ProcessDay();
            Assert.Equal(5, item.Quality);
            Assert.Equal(3, item.SellIn);
        }

        [Fact]
        public void Sulfuras_Does_Not_Degrade()
        {
            AbstractItem item = new Sulfuras();

            item.ProcessDay();

            Assert.Equal(80, item.Quality);
            Assert.Equal(0, item.SellIn);

            item.ProcessDay();
            Assert.Equal(80, item.Quality);
            Assert.Equal(0, item.SellIn);
        }

        [Fact]
        public void Aged_Brie_Improves()
        {
            AbstractItem item = new AgedBrie();

            item.ProcessDay();

            Assert.Equal(1, item.Quality);
            Assert.Equal(1, item.SellIn);

            item.ProcessDay();
            Assert.Equal(2, item.Quality);
            Assert.Equal(0, item.SellIn);

            //Extra test to confirm that brie double-improves after SellIn is 0
            item.ProcessDay();
            Assert.Equal(4, item.Quality);
            Assert.Equal(-1, item.SellIn);

        }

        [Fact]
        public void Conjured_Mana_Cake_Degrades_Double_Speed()
        {
            AbstractItem item = new ManaCake();

            item.ProcessDay();

            Assert.Equal(4, item.Quality);
            Assert.Equal(2, item.SellIn);

            item.ProcessDay();
            Assert.Equal(2, item.Quality);
            Assert.Equal(1, item.SellIn);

            item.ProcessDay();
            Assert.Equal(0, item.Quality);
            Assert.Equal(0, item.SellIn);
        }

        [Fact]
        public void Backstage_Passes_Improve()
        {
            AbstractItem item = new BackstagePasses();

            item.ProcessDay();

            Assert.Equal(21, item.Quality);
            Assert.Equal(14, item.SellIn);

            item.ProcessDay();
            Assert.Equal(22, item.Quality);
            Assert.Equal(13, item.SellIn);

            item.ProcessDay();
            item.ProcessDay();
            item.ProcessDay();
            Assert.Equal(25, item.Quality);
            Assert.Equal(10, item.SellIn);

            //at this point we expect the quality to increase by 2 per day
            item.ProcessDay();
            Assert.Equal(27, item.Quality);
            Assert.Equal(9, item.SellIn);

            item.ProcessDay();
            Assert.Equal(29, item.Quality);
            Assert.Equal(8, item.SellIn);

            item.ProcessDay();
            item.ProcessDay();
            item.ProcessDay();

            Assert.Equal(35, item.Quality);
            Assert.Equal(5, item.SellIn);

            //at this point we expect quality to increase by 3 per day
            item.ProcessDay();

            Assert.Equal(38, item.Quality);
            Assert.Equal(4, item.SellIn);

            item.ProcessDay();

            Assert.Equal(41, item.Quality);
            Assert.Equal(3, item.SellIn);

            item.ProcessDay();
            item.ProcessDay();
            item.ProcessDay();
            Assert.Equal(50, item.Quality);
            Assert.Equal(0, item.SellIn);

            //Quality drops to 0 after SellIn is <0
            item.ProcessDay();
            Assert.Equal(0, item.Quality);
            Assert.Equal(-1, item.SellIn);
        }
    }
}
