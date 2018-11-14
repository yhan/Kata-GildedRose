namespace GildedRose
{
    class DefaultProductQualityUpdater :IQualityUpdater
    {
        public void UpdateQuality(Item item)
        {
            item.DecrementSellIn();
            item.DecrementQuality();
            if (item.SellIn < 0)
            {
                item.DecrementQuality();
            }
        }
    }
}