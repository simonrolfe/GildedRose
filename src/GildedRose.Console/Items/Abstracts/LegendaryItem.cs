namespace GildedRose.Console
{
    public abstract class LegendaryItem : AbstractItem
    {
        protected sealed override int MaxQuality
        {
            get
            {
                return 80; 
            }
        }

        protected sealed override int MinQuality
        {
            get
            {
                return 80;
            }
        }

        /// <summary>
        /// Legendary items don't ever degrade, so this is sealed
        /// </summary>
        public sealed override int DegradationPerDay
        {
            get
            {
                return 0;
            }
        }

        public sealed override void DegradeItem()
        {
            return;
        }
    }
}
