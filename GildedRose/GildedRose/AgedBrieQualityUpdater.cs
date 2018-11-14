namespace GildedRose
{
    class AgedBrieQualityUpdater : IQualityUpdater
    {
        public void UpdateQuality(Item item)
        {
            item.DecrementSellIn();
            item.IncreaseQuality();
            if (item.SellIn < 0)
            {
                item.IncreaseQuality();
            }
        }
    }
}