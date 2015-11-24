namespace GildedRose.Console
{
    public abstract class AbstractItem : Item
    {
        protected virtual int MaxQuality { get { return 50; } }
        protected virtual int MinQuality { get { return 0; } }

        public virtual int DegradationPerDay
        {
            get
            {
                return 1;
            }
        }

        public virtual void DegradeItem()
        {
            Quality -= DegradationPerDay;
        }

        public void ProcessDay()
        {
            //decrement SellIn
            DecrementSellin();
            
            //double-hit degradation if sell-in has passed
            if (HasSellInPassed)
            {
                DegradeItem();
            }
            DegradeItem();

            //clamp quality after adjustment
            if(Quality > MaxQuality)
            {
                Quality = MaxQuality;
            }

            if(Quality < MinQuality)
            {
                Quality = MinQuality;
            }
        }

        protected virtual void DecrementSellin()
        {
            SellIn--;
        }

        public bool HasSellInPassed
        {
            get
            {
                return (this.SellIn < 0);
            }
        }
    }
}
