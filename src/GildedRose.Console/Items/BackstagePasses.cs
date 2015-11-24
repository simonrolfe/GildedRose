namespace GildedRose.Console.Items
{
    public class BackstagePasses : AbstractItem
    {
        public override int DegradationPerDay
        {
            get
            {
                if(SellIn > 9)
                {
                    return -1;
                }
                if(SellIn > 4)
                {
                    return -2;
                }
                if(SellIn > -1)
                {
                    return -3;
                }

                //if we're past the day of the concert, degrade the passes by a large amount to force their quality to zero.
                return 100;
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
