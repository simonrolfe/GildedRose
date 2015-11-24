using GildedRose.Console.Items;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Console
{
    internal class Program
    {
        internal IList<Item> Items;
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
                          {
                              Items = new List<Item>
                                          {
                                              new DexterityVest(),
                                              new AgedBrie(),
                                              new Elixir(),
                                              new Sulfuras(),
                                              new BackstagePasses(),
                                              new ManaCake()
                                          }

                          };

            app.ProcessDay();

            System.Console.ReadKey();

        }

        public void ProcessDay()
        {
            // Kind of hacky but we should be able to assume all items are now AbstractItems as above. 
            // I don't like it but the alternative is to put crappy static extensions all over the Item,
            // or change the Item class (which isn't allowed).
            foreach(AbstractItem item in Items.OfType<AbstractItem>())
            {
                item.ProcessDay();
            }
        }
    }
}
