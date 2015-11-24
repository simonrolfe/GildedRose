namespace GildedRose.Console
{
    public abstract class ConjuredItem : AbstractItem
    {
        //Conjured items degrade twice as fast, so call DegradeItem twice - this will take care of itself for post-SellIn items etc
        public override void DegradeItem()
        {
            base.DegradeItem();
            base.DegradeItem();
        }
    }
}
