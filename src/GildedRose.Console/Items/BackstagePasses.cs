namespace GildedRose.Console.Items
{
    public class BackstagePasses : AbstractItem
    {
        public override int DegradationPerDay
        {
            get
            {
                if(SellIn > 10)
                {
                    return 1;
                }
                if(SellIn > 5)
                {
                    return 2;
                }
                if(SellIn > -1)
                {
                    return 3;
                }

                return 0;
            }
        }

        public BackstagePasses()
        {
            Name = "Backstage passes to a TAFKAL80ETC concert";
            SellIn = 15;
            Quality = 20;
        }
    }
}
