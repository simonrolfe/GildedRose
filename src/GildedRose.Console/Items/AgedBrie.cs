namespace GildedRose.Console.Items
{
    public class AgedBrie : AbstractItem
    {
        public override int DegradationPerDay
        {
            get
            {
                return -1;
            }
        }
        public AgedBrie()
        {
            Name = "Aged Brie";
            SellIn = 2;
            Quality = 0;
        }
    }
}
